
namespace MYSQL_TEST_APPLICATION
{
    partial class MAIN_FORM
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAIN_FORM));
            this.TXT_BOX_HOST = new System.Windows.Forms.TextBox();
            this.TXT_BOX_USER = new System.Windows.Forms.TextBox();
            this.TXT_BOX_PASSWORD = new System.Windows.Forms.TextBox();
            this.BTN_DISCONNECT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.STATUS_STRIP = new System.Windows.Forms.StatusStrip();
            this.LBL_CONNECTION = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_DB_CONNECTION = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_TABLE = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_VIEW_LOG = new System.Windows.Forms.ToolStripStatusLabel();
            this.DGV_1 = new System.Windows.Forms.DataGridView();
            this.GRP_BOX_HOST_CONNECTION = new System.Windows.Forms.GroupBox();
            this.TXT_BOX_PORT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_CONNECT = new System.Windows.Forms.Button();
            this.GRP_BOX_DB_CONNECTION = new System.Windows.Forms.GroupBox();
            this.BTN_USE_SELECTED_DB = new System.Windows.Forms.Button();
            this.GRP_BOX_TABLE = new System.Windows.Forms.GroupBox();
            this.BTN_USE_SELECTED_TABLE = new System.Windows.Forms.Button();
            this.DGV_2 = new System.Windows.Forms.DataGridView();
            this.DGV_3 = new System.Windows.Forms.DataGridView();
            this.STATUS_STRIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_1)).BeginInit();
            this.GRP_BOX_HOST_CONNECTION.SuspendLayout();
            this.GRP_BOX_DB_CONNECTION.SuspendLayout();
            this.GRP_BOX_TABLE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_3)).BeginInit();
            this.SuspendLayout();
            // 
            // TXT_BOX_HOST
            // 
            this.TXT_BOX_HOST.Location = new System.Drawing.Point(6, 22);
            this.TXT_BOX_HOST.Name = "TXT_BOX_HOST";
            this.TXT_BOX_HOST.Size = new System.Drawing.Size(130, 23);
            this.TXT_BOX_HOST.TabIndex = 1;
            this.TXT_BOX_HOST.Text = "localhost";
            this.TXT_BOX_HOST.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KEY_PRESSED_IN_CONNECTION_FIELD);
            // 
            // TXT_BOX_USER
            // 
            this.TXT_BOX_USER.Location = new System.Drawing.Point(6, 80);
            this.TXT_BOX_USER.Name = "TXT_BOX_USER";
            this.TXT_BOX_USER.Size = new System.Drawing.Size(130, 23);
            this.TXT_BOX_USER.TabIndex = 3;
            this.TXT_BOX_USER.Text = "root";
            this.TXT_BOX_USER.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KEY_PRESSED_IN_CONNECTION_FIELD);
            // 
            // TXT_BOX_PASSWORD
            // 
            this.TXT_BOX_PASSWORD.Location = new System.Drawing.Point(6, 109);
            this.TXT_BOX_PASSWORD.Name = "TXT_BOX_PASSWORD";
            this.TXT_BOX_PASSWORD.PasswordChar = '*';
            this.TXT_BOX_PASSWORD.Size = new System.Drawing.Size(130, 23);
            this.TXT_BOX_PASSWORD.TabIndex = 4;
            this.TXT_BOX_PASSWORD.Text = "1328259";
            this.TXT_BOX_PASSWORD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KEY_PRESSED_IN_CONNECTION_FIELD);
            // 
            // BTN_DISCONNECT
            // 
            this.BTN_DISCONNECT.Enabled = false;
            this.BTN_DISCONNECT.Location = new System.Drawing.Point(6, 169);
            this.BTN_DISCONNECT.Name = "BTN_DISCONNECT";
            this.BTN_DISCONNECT.Size = new System.Drawing.Size(198, 25);
            this.BTN_DISCONNECT.TabIndex = 6;
            this.BTN_DISCONNECT.Text = "Disconnect";
            this.BTN_DISCONNECT.UseVisualStyleBackColor = true;
            this.BTN_DISCONNECT.Click += new System.EventHandler(this.BTN_DISCONNECT_CLICK);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Host";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password";
            // 
            // STATUS_STRIP
            // 
            this.STATUS_STRIP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LBL_CONNECTION,
            this.LBL_DB_CONNECTION,
            this.LBL_TABLE,
            this.LBL_VIEW_LOG});
            this.STATUS_STRIP.Location = new System.Drawing.Point(0, 398);
            this.STATUS_STRIP.Name = "STATUS_STRIP";
            this.STATUS_STRIP.Size = new System.Drawing.Size(666, 25);
            this.STATUS_STRIP.TabIndex = 11;
            this.STATUS_STRIP.Text = "statusStrip1";
            this.STATUS_STRIP.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.STATUS_STRIP_ITEM_CLICKED);
            // 
            // LBL_CONNECTION
            // 
            this.LBL_CONNECTION.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_CONNECTION.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LBL_CONNECTION.Image = ((System.Drawing.Image)(resources.GetObject("LBL_CONNECTION.Image")));
            this.LBL_CONNECTION.ImageTransparentColor = System.Drawing.Color.White;
            this.LBL_CONNECTION.Name = "LBL_CONNECTION";
            this.LBL_CONNECTION.Size = new System.Drawing.Size(159, 20);
            this.LBL_CONNECTION.Text = " Disconnected from Host";
            this.LBL_CONNECTION.ToolTipText = "Host Connection Status";
            // 
            // LBL_DB_CONNECTION
            // 
            this.LBL_DB_CONNECTION.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_DB_CONNECTION.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LBL_DB_CONNECTION.Image = ((System.Drawing.Image)(resources.GetObject("LBL_DB_CONNECTION.Image")));
            this.LBL_DB_CONNECTION.ImageTransparentColor = System.Drawing.Color.White;
            this.LBL_DB_CONNECTION.Name = "LBL_DB_CONNECTION";
            this.LBL_DB_CONNECTION.Size = new System.Drawing.Size(141, 20);
            this.LBL_DB_CONNECTION.Text = "No Database Selected";
            this.LBL_DB_CONNECTION.ToolTipText = "Database Connection Status";
            // 
            // LBL_TABLE
            // 
            this.LBL_TABLE.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_TABLE.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LBL_TABLE.Image = ((System.Drawing.Image)(resources.GetObject("LBL_TABLE.Image")));
            this.LBL_TABLE.ImageTransparentColor = System.Drawing.Color.White;
            this.LBL_TABLE.Name = "LBL_TABLE";
            this.LBL_TABLE.Size = new System.Drawing.Size(120, 20);
            this.LBL_TABLE.Text = "No Table Selected";
            // 
            // LBL_VIEW_LOG
            // 
            this.LBL_VIEW_LOG.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.LBL_VIEW_LOG.Image = ((System.Drawing.Image)(resources.GetObject("LBL_VIEW_LOG.Image")));
            this.LBL_VIEW_LOG.ImageTransparentColor = System.Drawing.Color.White;
            this.LBL_VIEW_LOG.Name = "LBL_VIEW_LOG";
            this.LBL_VIEW_LOG.Size = new System.Drawing.Size(75, 20);
            this.LBL_VIEW_LOG.Text = "View Log";
            this.LBL_VIEW_LOG.ToolTipText = "View Log";
            // 
            // DGV_1
            // 
            this.DGV_1.AllowUserToAddRows = false;
            this.DGV_1.AllowUserToDeleteRows = false;
            this.DGV_1.AllowUserToResizeRows = false;
            this.DGV_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_1.ColumnHeadersVisible = false;
            this.DGV_1.Location = new System.Drawing.Point(6, 22);
            this.DGV_1.MultiSelect = false;
            this.DGV_1.Name = "DGV_1";
            this.DGV_1.RowHeadersVisible = false;
            this.DGV_1.RowTemplate.Height = 25;
            this.DGV_1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_1.Size = new System.Drawing.Size(198, 141);
            this.DGV_1.TabIndex = 13;
            // 
            // GRP_BOX_HOST_CONNECTION
            // 
            this.GRP_BOX_HOST_CONNECTION.Controls.Add(this.TXT_BOX_PORT);
            this.GRP_BOX_HOST_CONNECTION.Controls.Add(this.label2);
            this.GRP_BOX_HOST_CONNECTION.Controls.Add(this.TXT_BOX_HOST);
            this.GRP_BOX_HOST_CONNECTION.Controls.Add(this.TXT_BOX_USER);
            this.GRP_BOX_HOST_CONNECTION.Controls.Add(this.TXT_BOX_PASSWORD);
            this.GRP_BOX_HOST_CONNECTION.Controls.Add(this.BTN_DISCONNECT);
            this.GRP_BOX_HOST_CONNECTION.Controls.Add(this.label4);
            this.GRP_BOX_HOST_CONNECTION.Controls.Add(this.BTN_CONNECT);
            this.GRP_BOX_HOST_CONNECTION.Controls.Add(this.label1);
            this.GRP_BOX_HOST_CONNECTION.Controls.Add(this.label3);
            this.GRP_BOX_HOST_CONNECTION.Location = new System.Drawing.Point(12, 12);
            this.GRP_BOX_HOST_CONNECTION.Name = "GRP_BOX_HOST_CONNECTION";
            this.GRP_BOX_HOST_CONNECTION.Size = new System.Drawing.Size(210, 201);
            this.GRP_BOX_HOST_CONNECTION.TabIndex = 14;
            this.GRP_BOX_HOST_CONNECTION.TabStop = false;
            this.GRP_BOX_HOST_CONNECTION.Text = "Host Connection";
            // 
            // TXT_BOX_PORT
            // 
            this.TXT_BOX_PORT.Location = new System.Drawing.Point(6, 51);
            this.TXT_BOX_PORT.Name = "TXT_BOX_PORT";
            this.TXT_BOX_PORT.Size = new System.Drawing.Size(130, 23);
            this.TXT_BOX_PORT.TabIndex = 11;
            this.TXT_BOX_PORT.Text = "3306";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Port";
            // 
            // BTN_CONNECT
            // 
            this.BTN_CONNECT.Location = new System.Drawing.Point(6, 138);
            this.BTN_CONNECT.Name = "BTN_CONNECT";
            this.BTN_CONNECT.Size = new System.Drawing.Size(198, 25);
            this.BTN_CONNECT.TabIndex = 5;
            this.BTN_CONNECT.Text = "Connect";
            this.BTN_CONNECT.UseVisualStyleBackColor = true;
            this.BTN_CONNECT.Click += new System.EventHandler(this.BTN_CONNECT_CLICK);
            // 
            // GRP_BOX_DB_CONNECTION
            // 
            this.GRP_BOX_DB_CONNECTION.Controls.Add(this.BTN_USE_SELECTED_DB);
            this.GRP_BOX_DB_CONNECTION.Controls.Add(this.DGV_1);
            this.GRP_BOX_DB_CONNECTION.Enabled = false;
            this.GRP_BOX_DB_CONNECTION.Location = new System.Drawing.Point(228, 12);
            this.GRP_BOX_DB_CONNECTION.Name = "GRP_BOX_DB_CONNECTION";
            this.GRP_BOX_DB_CONNECTION.Size = new System.Drawing.Size(210, 201);
            this.GRP_BOX_DB_CONNECTION.TabIndex = 18;
            this.GRP_BOX_DB_CONNECTION.TabStop = false;
            this.GRP_BOX_DB_CONNECTION.Text = "Database Selection";
            // 
            // BTN_USE_SELECTED_DB
            // 
            this.BTN_USE_SELECTED_DB.Location = new System.Drawing.Point(6, 169);
            this.BTN_USE_SELECTED_DB.Name = "BTN_USE_SELECTED_DB";
            this.BTN_USE_SELECTED_DB.Size = new System.Drawing.Size(198, 25);
            this.BTN_USE_SELECTED_DB.TabIndex = 14;
            this.BTN_USE_SELECTED_DB.Text = "Use Selected Database";
            this.BTN_USE_SELECTED_DB.UseVisualStyleBackColor = true;
            this.BTN_USE_SELECTED_DB.Click += new System.EventHandler(this.BTN_USE_SELECTED_DB_CLICK);
            // 
            // GRP_BOX_TABLE
            // 
            this.GRP_BOX_TABLE.Controls.Add(this.BTN_USE_SELECTED_TABLE);
            this.GRP_BOX_TABLE.Controls.Add(this.DGV_2);
            this.GRP_BOX_TABLE.Enabled = false;
            this.GRP_BOX_TABLE.Location = new System.Drawing.Point(444, 12);
            this.GRP_BOX_TABLE.Name = "GRP_BOX_TABLE";
            this.GRP_BOX_TABLE.Size = new System.Drawing.Size(210, 201);
            this.GRP_BOX_TABLE.TabIndex = 19;
            this.GRP_BOX_TABLE.TabStop = false;
            this.GRP_BOX_TABLE.Text = "Table Selection";
            // 
            // BTN_USE_SELECTED_TABLE
            // 
            this.BTN_USE_SELECTED_TABLE.Location = new System.Drawing.Point(6, 169);
            this.BTN_USE_SELECTED_TABLE.Name = "BTN_USE_SELECTED_TABLE";
            this.BTN_USE_SELECTED_TABLE.Size = new System.Drawing.Size(198, 25);
            this.BTN_USE_SELECTED_TABLE.TabIndex = 14;
            this.BTN_USE_SELECTED_TABLE.Text = "Use Selected Table";
            this.BTN_USE_SELECTED_TABLE.UseVisualStyleBackColor = true;
            this.BTN_USE_SELECTED_TABLE.Click += new System.EventHandler(this.BTN_USE_SELECTED_TABLE_CLICK);
            // 
            // DGV_2
            // 
            this.DGV_2.AllowUserToAddRows = false;
            this.DGV_2.AllowUserToDeleteRows = false;
            this.DGV_2.AllowUserToResizeRows = false;
            this.DGV_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_2.ColumnHeadersVisible = false;
            this.DGV_2.Location = new System.Drawing.Point(6, 22);
            this.DGV_2.MultiSelect = false;
            this.DGV_2.Name = "DGV_2";
            this.DGV_2.RowHeadersVisible = false;
            this.DGV_2.RowTemplate.Height = 25;
            this.DGV_2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_2.Size = new System.Drawing.Size(198, 141);
            this.DGV_2.TabIndex = 13;
            // 
            // DGV_3
            // 
            this.DGV_3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_3.Location = new System.Drawing.Point(12, 219);
            this.DGV_3.Name = "DGV_3";
            this.DGV_3.RowTemplate.Height = 25;
            this.DGV_3.Size = new System.Drawing.Size(642, 176);
            this.DGV_3.TabIndex = 20;
            // 
            // MAIN_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 423);
            this.Controls.Add(this.DGV_3);
            this.Controls.Add(this.GRP_BOX_TABLE);
            this.Controls.Add(this.GRP_BOX_DB_CONNECTION);
            this.Controls.Add(this.GRP_BOX_HOST_CONNECTION);
            this.Controls.Add(this.STATUS_STRIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAIN_FORM";
            this.Text = "MySQL Test Application";
            this.STATUS_STRIP.ResumeLayout(false);
            this.STATUS_STRIP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_1)).EndInit();
            this.GRP_BOX_HOST_CONNECTION.ResumeLayout(false);
            this.GRP_BOX_HOST_CONNECTION.PerformLayout();
            this.GRP_BOX_DB_CONNECTION.ResumeLayout(false);
            this.GRP_BOX_TABLE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TXT_BOX_HOST;
        private System.Windows.Forms.TextBox TXT_BOX_USER;
        private System.Windows.Forms.TextBox TXT_BOX_PASSWORD;
        private System.Windows.Forms.Button BTN_DISCONNECT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip STATUS_STRIP;
        private System.Windows.Forms.ToolStripStatusLabel LBL_CONNECTION;
        private System.Windows.Forms.DataGridView DGV_1;
        private System.Windows.Forms.GroupBox GRP_BOX_HOST_CONNECTION;
        private System.Windows.Forms.Button BTN_CONNECT;
        private System.Windows.Forms.GroupBox GRP_BOX_DB_CONNECTION;
        private System.Windows.Forms.Button BTN_USE_SELECTED_DB;
        private System.Windows.Forms.ToolStripStatusLabel LBL_DB_CONNECTION;
        private System.Windows.Forms.ToolStripStatusLabel LBL_VIEW_LOG;
        private System.Windows.Forms.TextBox TXT_BOX_PORT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GRP_BOX_TABLE;
        private System.Windows.Forms.Button BTN_USE_SELECTED_TABLE;
        private System.Windows.Forms.DataGridView DGV_2;
        private System.Windows.Forms.ToolStripStatusLabel LBL_TABLE;
        private System.Windows.Forms.DataGridView DGV_3;
    }
}

