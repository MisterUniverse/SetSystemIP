namespace IpQuickSwitch
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtDisplay = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.btnAddProfile = new Infragistics.Win.Misc.UltraButton();
            this.btnApply = new Infragistics.Win.Misc.UltraButton();
            this.btnSysInfo = new Infragistics.Win.Misc.UltraButton();
            this.btnGetCurrentNet = new Infragistics.Win.Misc.UltraButton();
            this.UserPopupControlContainer = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.cboUsers = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboNIC = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblNIC = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cboUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNIC)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ultraLabel1.Location = new System.Drawing.Point(329, 12);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(121, 26);
            this.ultraLabel1.TabIndex = 1;
            this.ultraLabel1.Text = "Add User Profile:";
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(12, 12);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(300, 300);
            this.txtDisplay.TabIndex = 3;
            this.txtDisplay.Value = "";
            // 
            // btnAddProfile
            // 
            appearance2.Image = global::IpQuickSwitch.Properties.Resources.addItem;
            appearance2.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddProfile.Appearance = appearance2;
            this.btnAddProfile.Location = new System.Drawing.Point(374, 44);
            this.btnAddProfile.Name = "btnAddProfile";
            this.btnAddProfile.Size = new System.Drawing.Size(33, 32);
            this.btnAddProfile.TabIndex = 2;
            this.btnAddProfile.Click += new System.EventHandler(this.btnAddProfile_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(360, 289);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnSysInfo
            // 
            this.btnSysInfo.Location = new System.Drawing.Point(360, 190);
            this.btnSysInfo.Name = "btnSysInfo";
            this.btnSysInfo.Size = new System.Drawing.Size(75, 23);
            this.btnSysInfo.TabIndex = 2;
            this.btnSysInfo.Text = "Sys Info";
            this.btnSysInfo.Click += new System.EventHandler(this.btnSysInfo_Click);
            // 
            // btnGetCurrentNet
            // 
            this.btnGetCurrentNet.Location = new System.Drawing.Point(344, 234);
            this.btnGetCurrentNet.Name = "btnGetCurrentNet";
            this.btnGetCurrentNet.Size = new System.Drawing.Size(106, 23);
            this.btnGetCurrentNet.TabIndex = 2;
            this.btnGetCurrentNet.Text = "Current Network";
            this.btnGetCurrentNet.Click += new System.EventHandler(this.btnGetCurrentNet_Click);
            // 
            // cboUsers
            // 
            this.cboUsers.Location = new System.Drawing.Point(329, 92);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(131, 21);
            this.cboUsers.TabIndex = 5;
            // 
            // cboNIC
            // 
            this.cboNIC.Location = new System.Drawing.Point(329, 150);
            this.cboNIC.Name = "cboNIC";
            this.cboNIC.Size = new System.Drawing.Size(131, 21);
            this.cboNIC.TabIndex = 5;
            // 
            // lblNIC
            // 
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Bottom";
            this.lblNIC.Appearance = appearance3;
            this.lblNIC.Location = new System.Drawing.Point(350, 121);
            this.lblNIC.Name = "lblNIC";
            this.lblNIC.Size = new System.Drawing.Size(100, 23);
            this.lblNIC.TabIndex = 6;
            this.lblNIC.Text = "Network Adapters";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 343);
            this.Controls.Add(this.lblNIC);
            this.Controls.Add(this.cboNIC);
            this.Controls.Add(this.cboUsers);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btnGetCurrentNet);
            this.Controls.Add(this.btnSysInfo);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnAddProfile);
            this.Controls.Add(this.ultraLabel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cboUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNIC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtDisplay;
        private Infragistics.Win.Misc.UltraButton btnAddProfile;
        private Infragistics.Win.Misc.UltraButton btnApply;
        private Infragistics.Win.Misc.UltraButton btnSysInfo;
        private Infragistics.Win.Misc.UltraButton btnGetCurrentNet;
        private Infragistics.Win.Misc.UltraPopupControlContainer UserPopupControlContainer;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboUsers;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboNIC;
        private Infragistics.Win.Misc.UltraLabel lblNIC;
    }
}

