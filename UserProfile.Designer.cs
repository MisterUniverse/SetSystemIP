namespace IpQuickSwitch
{
    partial class UserProfile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.lblTitle = new Infragistics.Win.Misc.UltraLabel();
            this.profilePanel = new Infragistics.Win.Misc.UltraPanel();
            this.btnOkay = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtGate = new System.Windows.Forms.TextBox();
            this.lbProfileName = new Infragistics.Win.Misc.UltraLabel();
            this.lblIPaddress = new Infragistics.Win.Misc.UltraLabel();
            this.lblGateWay = new Infragistics.Win.Misc.UltraLabel();
            this.lblSubNet = new Infragistics.Win.Misc.UltraLabel();
            this.txtSub = new System.Windows.Forms.TextBox();
            this.profilePanel.ClientArea.SuspendLayout();
            this.profilePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblTitle.Appearance = appearance2;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(342, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add User Profile";
            // 
            // profilePanel
            // 
            // 
            // profilePanel.ClientArea
            // 
            this.profilePanel.ClientArea.Controls.Add(this.lblGateWay);
            this.profilePanel.ClientArea.Controls.Add(this.lblSubNet);
            this.profilePanel.ClientArea.Controls.Add(this.lblIPaddress);
            this.profilePanel.ClientArea.Controls.Add(this.lbProfileName);
            this.profilePanel.ClientArea.Controls.Add(this.txtName);
            this.profilePanel.ClientArea.Controls.Add(this.txtGate);
            this.profilePanel.ClientArea.Controls.Add(this.txtSub);
            this.profilePanel.ClientArea.Controls.Add(this.txtIP);
            this.profilePanel.ClientArea.Controls.Add(this.btnCancel);
            this.profilePanel.ClientArea.Controls.Add(this.btnOkay);
            this.profilePanel.ClientArea.Controls.Add(this.lblTitle);
            this.profilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilePanel.Location = new System.Drawing.Point(0, 0);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.Size = new System.Drawing.Size(342, 290);
            this.profilePanel.TabIndex = 1;
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(74, 230);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "Okay";
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(195, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(177, 88);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(145, 20);
            this.txtIP.TabIndex = 3;
            this.txtIP.Text = "192.168.1.";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(177, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(145, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtGate
            // 
            this.txtGate.Location = new System.Drawing.Point(177, 166);
            this.txtGate.Name = "txtGate";
            this.txtGate.Size = new System.Drawing.Size(145, 20);
            this.txtGate.TabIndex = 3;
            this.txtGate.Text = "192.168.1.1";
            // 
            // lbProfileName
            // 
            this.lbProfileName.Location = new System.Drawing.Point(39, 43);
            this.lbProfileName.Name = "lbProfileName";
            this.lbProfileName.Size = new System.Drawing.Size(100, 21);
            this.lbProfileName.TabIndex = 4;
            this.lbProfileName.Text = "Profile Name :";
            // 
            // lblIPaddress
            // 
            this.lblIPaddress.Location = new System.Drawing.Point(39, 88);
            this.lblIPaddress.Name = "lblIPaddress";
            this.lblIPaddress.Size = new System.Drawing.Size(100, 21);
            this.lblIPaddress.TabIndex = 4;
            this.lblIPaddress.Text = "IP Address : ";
            // 
            // lblGateWay
            // 
            this.lblGateWay.Location = new System.Drawing.Point(39, 166);
            this.lblGateWay.Name = "lblGateWay";
            this.lblGateWay.Size = new System.Drawing.Size(100, 21);
            this.lblGateWay.TabIndex = 4;
            this.lblGateWay.Text = "Gateway :";
            // 
            // lblSubNet
            // 
            this.lblSubNet.Location = new System.Drawing.Point(39, 125);
            this.lblSubNet.Name = "lblSubNet";
            this.lblSubNet.Size = new System.Drawing.Size(100, 21);
            this.lblSubNet.TabIndex = 4;
            this.lblSubNet.Text = "Subnet : ";
            // 
            // txtSub
            // 
            this.txtSub.Location = new System.Drawing.Point(177, 125);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(145, 20);
            this.txtSub.TabIndex = 3;
            this.txtSub.Text = "255.255.255.0";
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.profilePanel);
            this.Name = "UserProfile";
            this.Size = new System.Drawing.Size(342, 290);
            this.profilePanel.ClientArea.ResumeLayout(false);
            this.profilePanel.ClientArea.PerformLayout();
            this.profilePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblTitle;
        private Infragistics.Win.Misc.UltraPanel profilePanel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtGate;
        private System.Windows.Forms.TextBox txtIP;
        private Infragistics.Win.Misc.UltraButton btnCancel;
        private Infragistics.Win.Misc.UltraButton btnOkay;
        private Infragistics.Win.Misc.UltraLabel lblGateWay;
        private Infragistics.Win.Misc.UltraLabel lblIPaddress;
        private Infragistics.Win.Misc.UltraLabel lbProfileName;
        private Infragistics.Win.Misc.UltraLabel lblSubNet;
        private System.Windows.Forms.TextBox txtSub;
    }
}
