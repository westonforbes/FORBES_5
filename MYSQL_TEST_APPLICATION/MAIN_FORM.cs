using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FORBES_5.LOGGER_NAMESPACE;
using FORBES_5.MYSQL_COMS_NAMESPACE;

namespace MYSQL_TEST_APPLICATION
{
    public partial class MAIN_FORM : Form
    {
        MYSQL_COMS CONNECTION = new MYSQL_COMS(true); //Initialize class with the logger on.
        public MAIN_FORM()
        {
            LOGGER.METHOD_ENTER();
            InitializeComponent(); //System defined method call.
            CONNECTION.CONNECTION_CHANGED += new EventHandler(CONNECTION_CHANGED);
            LOGGER.METHOD_EXIT();
        }

        #region Buttons and Fields
        private void BTN_CONNECT_CLICK(object SENDER, EventArgs E)
        {
            LOGGER.METHOD_ENTER();

            int RESULT = CONNECTION.CONNECT_TO_HOST(TXT_BOX_HOST.Text, TXT_BOX_PORT.Text, TXT_BOX_USER.Text, TXT_BOX_PASSWORD.Text); //Connect to the host.
            if(RESULT != 0)
            {
                DialogResult CHOICE = MessageBox.Show("Connection failed. Would you like to view the log for details?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                LOGGER.EXCEPTION("Connection failed.");
                if (CHOICE == DialogResult.Yes) LOGGER.OPEN_LOG();
                LOGGER.METHOD_EXIT_FAIL();
                return;
            }

            DGV_1.DataSource = CONNECTION.GET_DATABASE_LISTING(); //Get a DataTable of all the databases on the host.
            try { DGV_1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; } //Try to format the column to fill mode.
            catch (Exception EX) //If something didn't populate right, for whatever reason, capture it.
            {
                LOGGER.EXCEPTION(EX.Message);
                LOGGER.METHOD_EXIT_FAIL();
                return;
            }
            LOGGER.METHOD_EXIT_SUCCESS();
        }
        private void BTN_DISCONNECT_CLICK(object SENDER, EventArgs E)
        {
            LOGGER.METHOD_ENTER();
            CONNECTION.DISCONNECT_FROM_DATABASE();
            LOGGER.METHOD_EXIT();
        }
        private void KEY_PRESSED_IN_CONNECTION_FIELD(object SENDER, KeyEventArgs E)
        {
            if (E.KeyData == Keys.Enter)
            {
                Control NEXT_CONTROL = this.GetNextControl((Control)SENDER, true);
                NEXT_CONTROL.Focus();
            }
        }
        private void STATUS_STRIP_ITEM_CLICKED(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == LBL_VIEW_LOG)
            {
                LOGGER.OPEN_LOG();
            }
        }
        private void BTN_USE_SELECTED_DB_CLICK(object sender, EventArgs e)
        {
            LOGGER.METHOD_ENTER();
            string SELECTED_DB = DGV_1.SelectedCells[0].Value.ToString();
            string RESULT = CONNECTION.CONNECT_TO_DATABASE(SELECTED_DB);
            DATABASE_CONNECTION_SWITCH(RESULT);
            DGV_2.DataSource = CONNECTION.GET_TABLE_LISTING();
            try { DGV_2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; } //Try to format the column to fill mode.
            catch (Exception EX) //If something didn't populate right, for whatever reason, capture it.
            {
                LOGGER.EXCEPTION(EX.Message);
                LOGGER.METHOD_EXIT_FAIL();
                return;
            }
            LOGGER.METHOD_EXIT_SUCCESS();
        }
        private void BTN_USE_SELECTED_TABLE_CLICK(object sender, EventArgs e)
        {
            LOGGER.METHOD_ENTER();
            string SELECTED_TABLE = DGV_2.SelectedCells[0].Value.ToString();
            DataTable TABLE = CONNECTION.GET_TABLE(SELECTED_TABLE);
            if (TABLE == null)
            {
                LOGGER.LOG("GET_METHOD returned nothing.");
                LOGGER.METHOD_EXIT_FAIL();
            }
            DGV_3.DataSource = TABLE;
            LBL_TABLE.Text = string.Format("Table {0} Selected", SELECTED_TABLE);
            LBL_TABLE.Image = Properties.Resources.table_green;
            GRP_BOX_TABLE.Enabled = false;
            DGV_2.DataSource = null;
            DGV_2.Refresh();
            LOGGER.METHOD_EXIT_SUCCESS();
        }
        #endregion

        /// <summary>
        /// Event handler for when the MySQL connection changes.
        /// </summary>
        /// <param name="SENDER"></param>
        /// <param name="E"></param>
        private void CONNECTION_CHANGED(object SENDER, EventArgs E)
        {
            var CASTED_E = (MYSQL_COMS.CONNECTION_CHANGED_EVENT_ARGS)E; //Cast the EventArgs into a more specific type.
            if (CASTED_E.FULLY_CONNECTED == true) //If the connection is fully connected...
            {
                LBL_CONNECTION.Image = Properties.Resources.cloud_check_fill;
                LBL_CONNECTION.Text = "Connected to Host";
            }
            else //If the connection is not fully connected...
            {
                DATABASE_CONNECTION_SWITCH(null);
                LBL_TABLE.Image = Properties.Resources.table;
                LBL_TABLE.Text = "No Table Selected";

                LBL_CONNECTION.Image = Properties.Resources.cloud_slash_fill;
                LBL_CONNECTION.Text = "Disconnected from Host";
                DGV_1.DataSource = null;
                DGV_1.Refresh();
            }
            //Binary assignments.
            BTN_DISCONNECT.Enabled = CASTED_E.FULLY_CONNECTED;
            GRP_BOX_DB_CONNECTION.Enabled = CASTED_E.FULLY_CONNECTED;
            //Inverse binary assignments.
            BTN_CONNECT.Enabled = !CASTED_E.FULLY_CONNECTED;
            TXT_BOX_HOST.Enabled = !CASTED_E.FULLY_CONNECTED;
            TXT_BOX_PORT.Enabled = !CASTED_E.FULLY_CONNECTED;
            TXT_BOX_USER.Enabled = !CASTED_E.FULLY_CONNECTED;
            TXT_BOX_PASSWORD.Enabled = !CASTED_E.FULLY_CONNECTED;
        }
        private void DATABASE_CONNECTION_SWITCH(string NAME)
        {
            if(NAME == null)
            {
                LBL_DB_CONNECTION.Text = "Not connected to a DB";
                LBL_DB_CONNECTION.Image = Properties.Resources.server_disconnected;
                GRP_BOX_DB_CONNECTION.Enabled = true;
                GRP_BOX_TABLE.Enabled = false;
                DGV_2.DataSource = null;
                DGV_2.Refresh();
            }
            else
            {
                LBL_DB_CONNECTION.Text = string.Format("Connected to {0}", NAME);
                LBL_DB_CONNECTION.Image = Properties.Resources.server_connected;
                GRP_BOX_DB_CONNECTION.Enabled = false;
                DGV_1.DataSource = null;
                DGV_1.Refresh();
                GRP_BOX_TABLE.Enabled = true;
            }
        }
        
    }
}
