using System;
using System.Windows.Forms;
using System.Diagnostics;
using FORBES_5.LOGGER_NAMESPACE;

namespace LOGGER_TEST_APPLICATION
{
    public partial class MAIN_FORM : Form
    {

        public MAIN_FORM()
        {
            InitializeComponent();
            LOGGER.METHOD_ENTER();
            LOGGER.LOG("The form initialized.");
            LOGGER.METHOD_EXIT();
        }

        private void FORM_LOAD(object sender, EventArgs e)
        {
            LOGGER.METHOD_ENTER();
            LOGGER.LOG("The form loaded.");
            LOGGER.METHOD_EXIT();
        }

        private void BTN_CLICK(object sender, EventArgs e)
        {
            LOGGER.METHOD_ENTER();
            LOGGER.LOG("Button clicked.");
            FUNCT_0();
            LOGGER.METHOD_EXIT();
        }

        private void FUNCT_0()
        {
            LOGGER.METHOD_ENTER();
            LOGGER.LOG("Here!");
            FUNCT_1();
            LOGGER.METHOD_EXIT();
        }

        private int FUNCT_1()
        {
            LOGGER.METHOD_ENTER();
            LOGGER.LOG("Here too!");
            FUNCT_2();
            LOGGER.METHOD_EXIT_SUCCESS();
            return 0;
        }

        private int FUNCT_2()
        {
            LOGGER.METHOD_ENTER();
            LOGGER.LOG("Gonna divide by zero.");
            try
            {
                int ZERO = 0;
                int NOT_ZERO = 5;
                int RESULT = NOT_ZERO / ZERO;
            }
            catch (Exception EX)
            {
                LOGGER.EXCEPTION(EX.Message);
                LOGGER.METHOD_EXIT_FAIL();
                return -1;
            }
            LOGGER.METHOD_EXIT_SUCCESS();
            return 0;
        }

        private void BTN_VIEW_LOG_CLICK(object sender, EventArgs e)
        {
            LOGGER.METHOD_ENTER();
            LOGGER.OPEN_LOG();
            LOGGER.METHOD_EXIT();
        }
    }
}
