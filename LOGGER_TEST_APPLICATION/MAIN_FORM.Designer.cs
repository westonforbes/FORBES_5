
namespace LOGGER_TEST_APPLICATION
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
            this.BTN_CREATE_EVENTS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_VIEW_LOG = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_CREATE_EVENTS
            // 
            this.BTN_CREATE_EVENTS.Location = new System.Drawing.Point(10, 45);
            this.BTN_CREATE_EVENTS.Name = "BTN_CREATE_EVENTS";
            this.BTN_CREATE_EVENTS.Size = new System.Drawing.Size(285, 25);
            this.BTN_CREATE_EVENTS.TabIndex = 0;
            this.BTN_CREATE_EVENTS.Text = "Create Events";
            this.BTN_CREATE_EVENTS.UseVisualStyleBackColor = true;
            this.BTN_CREATE_EVENTS.Click += new System.EventHandler(this.BTN_CLICK);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "The \"Create Events\" button will jump through several methods and create a error.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // BTN_VIEW_LOG
            // 
            this.BTN_VIEW_LOG.Location = new System.Drawing.Point(10, 75);
            this.BTN_VIEW_LOG.Name = "BTN_VIEW_LOG";
            this.BTN_VIEW_LOG.Size = new System.Drawing.Size(285, 25);
            this.BTN_VIEW_LOG.TabIndex = 2;
            this.BTN_VIEW_LOG.Text = "View Log";
            this.BTN_VIEW_LOG.UseVisualStyleBackColor = true;
            this.BTN_VIEW_LOG.Click += new System.EventHandler(this.BTN_VIEW_LOG_CLICK);
            // 
            // MAIN_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 111);
            this.Controls.Add(this.BTN_VIEW_LOG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_CREATE_EVENTS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "MAIN_FORM";
            this.Text = "Logger Test Application";
            this.Load += new System.EventHandler(this.FORM_LOAD);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_CREATE_EVENTS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_VIEW_LOG;
    }
}

