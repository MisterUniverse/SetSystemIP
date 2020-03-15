using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static IpQuickSwitch.Form1;

namespace IpQuickSwitch
{
    public partial class UserProfile : UserControl
    {
        private AccessType accessType;
        public CloseType closeType;
        public Profile newProfile;

        public UserProfile()
        {
            InitializeComponent();
        }

        public delegate void CloseRequestEventHandler(UserProfile addUser);
        public event CloseRequestEventHandler closeRequestedEvent;

        private enum AccessType
        {
            Adding,
            Editing
        }

        public enum CloseType
        {
            Okay,
            Cancel
        }

        public void Init(Guid ProfileGuid)
        {
            try
            {
                if (ProfileGuid == Guid.Empty)
                {
                    accessType = AccessType.Adding;

                    newProfile = new Profile();
                }
                else
                {
                    accessType = AccessType.Editing;
                    newProfile = SystemInfo.Users.FirstOrDefault(p => p.ProfileGuid == ProfileGuid);
                    txtName.Text = newProfile.Name;
                    txtIP.Text = newProfile.IPaddress;
                    txtSub.Text = newProfile.Subnet;
                    txtGate.Text = newProfile.GateWay;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            try
            {
                var newUser = new Profile()
                {
                    Name = txtName.Text,
                    IPaddress = txtIP.Text,
                    Subnet = txtSub.Text,
                    GateWay = txtGate.Text
                };

                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtIP.Text) || string.IsNullOrEmpty(txtSub.Text))
                {
                    return;
                }

                closeType = CloseType.Okay;

                if (accessType == AccessType.Adding)
                {
                    if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtIP.Text) && !string.IsNullOrEmpty(txtSub.Text))
                    {
                        var newUserProfile = new Profile()
                        {
                            ProfileGuid = Guid.NewGuid(),
                            Name = txtName.Text,
                            IPaddress = txtIP.Text,
                            Subnet = txtSub.Text,
                            GateWay = txtGate.Text
                        };

                        if (newUserProfile != null)
                        {
                            SystemInfo.Users.Add(newUserProfile);
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        newProfile.Name = txtName.Text;
                        newProfile.IPaddress = txtIP.Text;
                        newProfile.Subnet = txtSub.Text;
                        newProfile.GateWay = txtGate.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
                closeRequestedEvent(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
           
        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeType = CloseType.Cancel;

            closeRequestedEvent(this);
        }
    }
}
