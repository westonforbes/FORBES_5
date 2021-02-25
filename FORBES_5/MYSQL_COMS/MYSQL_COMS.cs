using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using FORBES_5.LOGGER_NAMESPACE;

namespace FORBES_5.MYSQL_COMS_NAMESPACE
{
    #region Namespace Structures

    /// <summary>
    /// A structure to hold SQL parameters. This is done to prevent SQL injections. Use parameters for any part of a command that a user can influence.
    /// </summary>
    public struct COMMAND_PARAMETER
    {
        /// <summary>
        /// The sub-string to search for in a command string.
        /// </summary>
        public string ESCAPE_STRING;
        /// <summary>
        /// The string to insert at the location of the found ESCAPE_STRING.
        /// </summary>
        public string STRING_TO_INSERT;
    }

    #endregion

    /// <summary>
    /// This class handles safe communications with a MySQL server.
    /// </summary>
    public class MYSQL_COMS
    {
        #region Properties

        /// <summary>
        /// Set this to true to activate the event logger for this class.
        /// </summary>
        public bool LOGGER_ON { get; set; } = false;

        /// <summary>
        /// True when fully connected, false under all other conditions.
        /// </summary>
        public bool FULLY_CONNECTED { get; private set; } = false;


        #endregion

        #region Objects
        /// <summary>
        /// The MySQL connection object.
        /// </summary>
        private MySqlConnection CONNECTION = new MySqlConnection();
        #endregion

        #region Events
        /// <summary>
        /// This event is raised when the connection state is changed. The connection state is embedded in a custom EventArgs
        /// called CONNECTION_CHANGED_EVENT_ARGS.
        /// </summary>
        public event EventHandler CONNECTION_CHANGED;

        /// <summary>
        /// Custom EventArgs structure, holds the connection state in FULLY_CONNECTED.
        /// </summary>
        public class CONNECTION_CHANGED_EVENT_ARGS : EventArgs
        {
            /// <summary>
            /// Constructor for CONNECTION_CHANGED_EVENT_ARGS class, a value must be assigned on initialization.
            /// </summary>
            /// <param name="VALUE"> Current connection state.</param>
            public CONNECTION_CHANGED_EVENT_ARGS(bool VALUE)
            {
                this.FULLY_CONNECTED = VALUE;
            }
            /// <summary>
            /// Current Connection State.
            /// </summary>
            public bool FULLY_CONNECTED { get; private set; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="LOGGER_ON">Set to true if you want this class to output log information.</param>
        public MYSQL_COMS(bool LOGGER_ON = false)
        {
            this.LOGGER_ON = LOGGER_ON;
            if (LOGGER_ON) LOGGER.METHOD_ENTER();
            CONNECTION.StateChange += new StateChangeEventHandler(CONNECTION_STATE_CHANGED); //Setup a event handler method for when the connection changes.
            if (LOGGER_ON) LOGGER.METHOD_EXIT();
        }
        #endregion

        #region Private Methods
        private void CONNECTION_STATE_CHANGED(object SENDER, EventArgs E)
        {
            if (LOGGER_ON) LOGGER.METHOD_ENTER();
            ConnectionState STATE = CONNECTION.State; //Get the current connection status.
            LOGGER.LOG(string.Format("Connection state change detected. Current state : {0}", STATE.ToString())); //Write to log.

            //Set a simple property FULLY_CONNECTED so that other classes can easily check.
            if (STATE == ConnectionState.Open) //If the connection is fully open...
                FULLY_CONNECTED = true; //Set fully connected to true.
            else //If the connection is not fully open...
                FULLY_CONNECTED = false; //Set fully connected to false.
            var ARGS = new CONNECTION_CHANGED_EVENT_ARGS(FULLY_CONNECTED); //Insert FULLY_CONNECTED state into the arguments that the delegate will carry out.
            CONNECTION_CHANGED?.Invoke(null, ARGS); //Send out the delegate to notify other classes.
            if (LOGGER_ON) LOGGER.METHOD_EXIT();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Connects to the database defined in intialization.
        /// </summary>
        /// <returns>
        /// <para> 0: Connection success.</para>
        /// <para> 1: A connection-level error occurred while opening the connection.</para>
        /// <para> 2: Cannot open a connection without specifying a data source or server.</para>
        /// <para> 3: Unhandled exception type.</para>
        /// </returns>
        public int CONNECT_TO_HOST(string HOST, string PORT, string USER, string PASSWORD)
        {
            if (LOGGER_ON) LOGGER.METHOD_ENTER();
            try
            {
                string CONNECTION_STRING_NO_PW = "server=" + HOST + ";User ID=" + USER + ";Port=" + PORT;
                string CONNECTION_STRING = CONNECTION_STRING_NO_PW + ";Password=" + PASSWORD;
                string CONNECTION_STRING_HIDDEN_PW = CONNECTION_STRING_NO_PW + ";Password={Hidden, nice try}";
                if (LOGGER_ON) LOGGER.LOG(string.Format("Connection string constructed: {0}", CONNECTION_STRING_HIDDEN_PW));
                CONNECTION.ConnectionString = CONNECTION_STRING;
                CONNECTION.Open();
            }
            catch (Exception EX)
            {
                if (LOGGER_ON) LOGGER.EXCEPTION(EX.Message);
                if (EX.InnerException is MySqlException)
                {
                    if (LOGGER_ON) LOGGER.EXCEPTION("A connection-level error occurred while opening the connection.");
                    if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                    return 1;
                }
                else if (EX.InnerException is InvalidOperationException)
                {
                    if (LOGGER_ON) LOGGER.EXCEPTION("Cannot open a connection without specifying a data source or server.");
                    if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                    return 2;
                }
                else
                {
                    if (LOGGER_ON) LOGGER.EXCEPTION("Unhandled exception type.");
                    if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                    return 3;
                }
            }
            if (LOGGER_ON) LOGGER.METHOD_EXIT_SUCCESS();
            return 0;
        }
        
        /// <summary>
        /// This method will connect to the database selected. If all goes well, it will echo back the name of the Database.
        /// </summary>
        /// <param name="NAME">The name of the database to connect to.</param>
        /// <returns>On success it will echo back the name of the database. On failure it will return null.</returns>
        public string CONNECT_TO_DATABASE(string NAME)
        {
            if (LOGGER_ON) LOGGER.METHOD_ENTER();
            if (!FULLY_CONNECTED) //If the connection is not fully connected...
            {
                if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                return null; //Escape out.
            }
            try
            {
                MySqlCommand COMMAND = new MySqlCommand(string.Format("use {0};", NAME), CONNECTION);
                int RESULT = COMMAND.ExecuteNonQuery(); //Execute command.
                if (RESULT == 0) //If everything went fine.
                {
                    if (LOGGER_ON) LOGGER.LOG(string.Format("Connection to {0} successful.", NAME));
                    if (LOGGER_ON) LOGGER.METHOD_EXIT_SUCCESS();
                    return NAME; //Echo back the database you've connected to.
                }
                else //If the command exited with a non-zero code...
                {
                    if (LOGGER_ON) LOGGER.LOG(string.Format("ExecuteNonQuery returned {0}.", RESULT));
                    if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                    return null;
                }
            }
            catch (Exception EX) //If something went wrong...
            {
                if (LOGGER_ON) LOGGER.EXCEPTION(EX.Message);
                if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                return null; //Escape out.
            }
        }

        /// <summary>
        /// Disconnects from the current database. Note that this method does not indicate success or failure.
        /// </summary>
        public void DISCONNECT_FROM_DATABASE()
        {
            if (LOGGER_ON) LOGGER.METHOD_ENTER();
            LOGGER.LOG("Closing connection.");
            CONNECTION.Close(); //No exceptions are generated by these method calls.
            if (LOGGER_ON) LOGGER.METHOD_EXIT();
        }

        /// <summary>
        /// This method returns a DataTable of all the tables in the MySQL database.
        /// </summary>
        /// <returns>A DataTable of all the tables in the MySQL database.</returns>
        public DataTable GET_TABLE_LISTING()
        {
            if (LOGGER_ON) LOGGER.METHOD_ENTER();
            if (!FULLY_CONNECTED) //If the connection is not fully connected...
            {
                if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                return null; //Escape out.
            }
            try
            {
                MySqlCommand COMMAND = new MySqlCommand("show tables;", CONNECTION);
                MySqlDataReader READER = COMMAND.ExecuteReader();
                DataTable DATA = new DataTable();
                DATA.Load(READER);
                if (LOGGER_ON) LOGGER.METHOD_EXIT_SUCCESS();
                return DATA;
            }
            catch (Exception EX) //If something went wrong...
            {
                if (LOGGER_ON) LOGGER.EXCEPTION(EX.Message);
                if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                return null; //Escape out.
            }
        }

        /// <summary>
        /// This method will return a DataTable listing of all databases on the host.
        /// </summary>
        /// <returns>A DataTable of visible databases on host.</returns>
        public DataTable GET_DATABASE_LISTING()
        {
            if (LOGGER_ON) LOGGER.METHOD_ENTER();
            if (!FULLY_CONNECTED) //If the connection is not fully connected...
            {
                if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                return null; //Escape out.
            }
            try
            {
                MySqlCommand COMMAND = new MySqlCommand("show databases;", CONNECTION);
                MySqlDataReader READER = COMMAND.ExecuteReader();
                DataTable DATA = new DataTable();
                DATA.Load(READER);
                if (LOGGER_ON) LOGGER.METHOD_EXIT_SUCCESS();
                return DATA;
            }
            catch (Exception EX) //If something went wrong...
            {
                if (LOGGER_ON) LOGGER.EXCEPTION(EX.Message);
                if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                return null; //Escape out.
            }
        }
       
        /// <summary>
        /// This method returns a DataTable object of the MySql table specified.
        /// </summary>
        /// <param name="TABLE_NAME">The name of the MySQL table.</param>
        /// <returns>A DataTable of the the specified MySQL table.</returns>
        public DataTable GET_TABLE(string TABLE_NAME)
        {
            if (LOGGER_ON) LOGGER.METHOD_ENTER();
            if (!FULLY_CONNECTED) //If the connection is not fully connected...
            {
                if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                return null; //Escape out.
            }
            try //Protect in a try-catch.
            {
                DataTable DATA = new DataTable(); //Create a DataTable to put the returned information in.
                string QUERY = string.Format("SELECT * FROM {0}", TABLE_NAME); //Construct the command string.
                MySqlCommand COMMAND = new MySqlCommand(QUERY, CONNECTION); //Build the command.
                MySqlDataAdapter RETURNED_DATA_ADAPTER = new MySqlDataAdapter(QUERY, CONNECTION);  //Create a DataAdapter for the incoming data.
                RETURNED_DATA_ADAPTER.Fill(DATA); //Put the information into the DataTable.
                if (LOGGER_ON) LOGGER.METHOD_EXIT_SUCCESS();
                return DATA; //Return the data.
            }
            catch (Exception EX) //If something went wrong...
            {
                if (LOGGER_ON) LOGGER.EXCEPTION(EX.Message);
                if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
                return null; //Escape out.
            }
        }

        /// <summary>
        /// This method is used to issue database commands. If the command is a hardcoded command, it can be just sent in COMMAND_STRING. If the command
        /// string in any way depended on variables or user inputs, a array of parameters should be sent containing those values, otherwise SQL injections may be possible.
        /// </summary>
        /// <param name="COMMAND_STRING">The command you wish to execute.</param>
        /// <param name="PARAMETERS_ARRAY">The parameters you wish to send. See documentation for the COMMAND_PARAMETER structure in this namespace for more details.</param>
        /// <returns>
        /// <para>Success: A value greater than or equal to zero. This value represents the number of rows affected.</para>
        /// <para>Failure: -1</para>
        /// </returns>
        public int EXECUTE_COMMAND(string COMMAND_STRING, COMMAND_PARAMETER[] PARAMETERS_ARRAY = null)
        {
            if (LOGGER_ON) LOGGER.METHOD_ENTER();
            try
            {
                int NUMBER_OF_ROWS_AFFECTED; //This will be returned.
                MySqlTransaction TRANSACTION = CONNECTION.BeginTransaction(); //Start transaction.
                MySqlCommand COMMAND = CONNECTION.CreateCommand(); //Create a command object.
                COMMAND.CommandText = COMMAND_STRING; //Set the command literal text.
                if (PARAMETERS_ARRAY != null) //If parameters were passed...
                {
                    foreach (COMMAND_PARAMETER PARAMETER in PARAMETERS_ARRAY) //For each parameter passed...
                    {
                        COMMAND.Parameters.AddWithValue(PARAMETER.ESCAPE_STRING, PARAMETER.STRING_TO_INSERT); //Find the escape string in the literal string and substitute it with STRING_TO_INSERT.
                    }
                }
                NUMBER_OF_ROWS_AFFECTED = COMMAND.ExecuteNonQuery(); //Execute the command.
                TRANSACTION.Commit(); //Finalize transaction.
                if (LOGGER_ON) LOGGER.METHOD_EXIT_SUCCESS();
                return NUMBER_OF_ROWS_AFFECTED;
            }
            catch (Exception EX)
            {
                if (LOGGER_ON) LOGGER.EXCEPTION(EX.Message);
                if (LOGGER_ON) LOGGER.METHOD_EXIT_FAIL();
            }
            return -1;
        }
        #endregion
    }
}
