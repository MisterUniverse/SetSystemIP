using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace IpQuickSwitch
{
    public partial class Form1 : Form
    {
        SystemInfo sysinfo = new SystemInfo();
        List<Profile> userProfileList = new List<Profile>();
        

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            foreach (Profile user in SystemInfo.Users)
            {
                userProfileList.Add(user);
            }

            cboNIC.DataSource = net_adapters();
            cboNIC.DataBind();
            cboNIC.DisplayMember = "";

            cboUsers.DataSource = SystemInfo.Users;
            cboUsers.DataBind();
            cboUsers.DisplayMember = "Name";
        }

        public System.Collections.Generic.List<String> net_adapters()
        {
            List<String> values = new List<String>();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                values.Add(nic.Name);
            }
            return values;
        }

        public bool GetCurrentNetworkSettings(string networkInterfaceName)
        {
            var networkInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(nw => nw.Name == networkInterfaceName);
            var ipProperties = networkInterface.GetIPProperties();
            var getCurrentGateWay = ipProperties.GatewayAddresses.FirstOrDefault(g => g.Address.AddressFamily == AddressFamily.InterNetwork);
            var ipInfo = ipProperties.UnicastAddresses.FirstOrDefault(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork);
            var currentIPaddress = ipInfo.Address.ToString();
            var currentSubnetMask = ipInfo.IPv4Mask.ToString();
            //var currentGateway = getCurrentGateWay.Address.ToString();
            var isDHCPenabled = ipProperties.GetIPv4Properties().IsDhcpEnabled;

            try
            {
                sysinfo.IPAddress = currentIPaddress;
                sysinfo.SubnetMask = currentSubnetMask;
                //sysinfo.GateWay = currentGateway;
            }
            catch
            {

            }
            
            return true;
        }

        public bool SetIP(string networkInterfaceName, string ipAddress, string subnetMask, string gateway = null)
        {
            bool rtn = false;
            var networkInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(nw => nw.Name == networkInterfaceName);
            var ipProperties = networkInterface.GetIPProperties();
            var ipInfo = ipProperties.UnicastAddresses.FirstOrDefault(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork);
            var getCurrentGateWay = ipProperties.GatewayAddresses.FirstOrDefault(g => g.Address.AddressFamily == AddressFamily.InterNetwork);
            var currentIPaddress = ipInfo.Address.ToString();
            var currentSubnetMask = ipInfo.IPv4Mask.ToString();
            //var currentGateway = getCurrentGateWay.Address.ToString();
            var isDHCPenabled = ipProperties.GetIPv4Properties().IsDhcpEnabled;

            if (!isDHCPenabled && currentIPaddress == ipAddress && currentSubnetMask == subnetMask)
                return true;    // no change necessary

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo("netsh", $"interface ip set address \"{networkInterfaceName}\" static {ipAddress} {subnetMask}" + (string.IsNullOrWhiteSpace(gateway) ? "" : $"{gateway} 1")) { Verb = "runas" }
                };
                process.Start();
                process.WaitForExit(300);
                if (!process.HasExited)
                    process.Kill();
                
                var successful = process.ExitCode == 0;
                rtn = successful;
                process.Dispose();
            }
            catch
            {

            }
            return rtn;
        }

        public bool SetDHCP(string networkInterfaceName)
        {
            var networkInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(nw => nw.Name == networkInterfaceName);
            var ipProperties = networkInterface.GetIPProperties();
            var isDHCPenabled = ipProperties.GetIPv4Properties().IsDhcpEnabled;

            if (isDHCPenabled)
                return true;
                

            var process = new Process
            {
                StartInfo = new ProcessStartInfo("netsh", $"interface ip set address \"{networkInterfaceName}\" dhcp") { Verb = "runas" }
            };
            process.Start();
            var successful = process.ExitCode == 0;
            process.Dispose();
            return successful;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var addUser = cboUsers.SelectedItem.ListObject as Profile;
            var nic = cboNIC.SelectedItem.DisplayText.ToString();
            SetIP(nic, addUser.IPaddress, addUser.Subnet);
        }

        public class SystemInfo
        {
            public static List<Profile> Users;
            public Guid SystemGuid { get; set; }
            public SystemInfo()
            {
                Users = new List<Profile>();
            }

            public string path = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            public bool Exist { get; set; }
            public string Message { get; set; }
            public string PCName { get; set; }
            public string OS { get; set; }
            public string Architecture { get; set; }
            public string Version { get; set; }
            public string Processor { get; set; }
            public string User { get; set; }
            public byte[] DigitalProductId;
            public string ProductKey { get; set; }

            public string IPAddress { get; set; }
            public string SubnetMask { get; set; }
            public string GateWay { get; set; }

            public void getOperatingSystemInfo()
            {
                Message = "Displaying operating system info....\n";
                //Create an object of ManagementObjectSearcher class and pass query as parameter.
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                foreach (ManagementObject managementObject in mos.Get())
                {
                    if (managementObject["Caption"] != null)
                    {
                        //Console.WriteLine("Operating System Name  :  " + managementObject["Caption"].ToString());   //Display operating system caption
                        OS = "Operating System Name  :  " + managementObject["Caption"].ToString();   //Display operating system caption
                    }  
                    if (managementObject["OSArchitecture"] != null)
                    {
                        //Console.WriteLine("Operating System Architecture  :  " + managementObject["OSArchitecture"].ToString());   //Display operating system architecture.
                        Architecture = "Operating System Architecture  :  " + managementObject["OSArchitecture"].ToString();   //Display operating system architecture.
                    }
                }

                using (var root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    using (var key = root.OpenSubKey(path, false))
                    {
                        User = $"User  : {key.GetValue("RegisteredOwner").ToString()}";
                        DigitalProductId = key.GetValue("DigitalProductId") as byte[];
                        ProductKey = $"ProductKey : {DecodeProductKey(DigitalProductId)}";
                        PCName = $"Machine Name : {Environment.MachineName}";
                    }
                }
            }

            public void getProcessorInfo()
            {
                RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

                if (processor_name != null)
                {
                    if (processor_name.GetValue("ProcessorNameString") != null)
                    {
                        Processor = processor_name.GetValue("ProcessorNameString").ToString();   //Display processor ingo.
                    }
                }
            }

            public static string DecodeProductKey(byte[] digitalProductId)
            {
                // Offset of first byte of encoded product key in 
                //  'DigitalProductIdxxx" REG_BINARY value. Offset = 34H.
                const int keyStartIndex = 52;
                // Offset of last byte of encoded product key in 
                //  'DigitalProductIdxxx" REG_BINARY value. Offset = 43H.
                const int keyEndIndex = keyStartIndex + 15;
                // Possible alpha-numeric characters in product key.
                char[] digits = new char[]
                {
                    'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'M', 'P', 'Q', 'R',
                    'T', 'V', 'W', 'X', 'Y', '2', '3', '4', '6', '7', '8', '9',
                };
                // Length of decoded product key
                const int decodeLength = 29;
                // Length of decoded product key in byte-form.
                // Each byte represents 2 chars.
                const int decodeStringLength = 15;
                // Array of containing the decoded product key.
                char[] decodedChars = new char[decodeLength];
                // Extract byte 52 to 67 inclusive.
                ArrayList hexPid = new ArrayList();
                for (int i = keyStartIndex; i <= keyEndIndex; i++)
                {
                    hexPid.Add(digitalProductId[i]);
                }
                for (int i = decodeLength - 1; i >= 0; i--)
                {
                    // Every sixth char is a separator.
                    if ((i + 1) % 6 == 0)
                    {
                        decodedChars[i] = '-';
                    }
                    else
                    {
                        // Do the actual decoding.
                        int digitMapIndex = 0;
                        for (int j = decodeStringLength - 1; j >= 0; j--)
                        {
                            int byteValue = (digitMapIndex << 8) | (byte)hexPid[j];
                            hexPid[j] = (byte)(byteValue / 24);
                            digitMapIndex = byteValue % 24;
                            decodedChars[i] = digits[digitMapIndex];
                        }
                    }
                }
                return new string(decodedChars);
            }
        }

        private void btnSysInfo_Click(object sender, EventArgs e)
        {
            sysinfo.getOperatingSystemInfo();
            sysinfo.getProcessorInfo();
            txtDisplay.Text = $"{sysinfo.Message}\n{sysinfo.PCName}\n{sysinfo.User}\n{sysinfo.OS}\n{sysinfo.Architecture}\n{sysinfo.ProductKey}\n{sysinfo.Processor}";
        }

        private void btnGetCurrentNet_Click(object sender, EventArgs e)
        {
            var nic = cboNIC.SelectedItem.DisplayText.ToString();
            GetCurrentNetworkSettings(nic);
            txtDisplay.Text = $"IP : {sysinfo.IPAddress} \nSubnet : {sysinfo.SubnetMask} \nGateWay : {sysinfo.GateWay}";
        }

        private void btnAddProfile_Click(object sender, EventArgs e)
        {
            OpenUserProfileContainerPopout(Guid.Empty);
        }

        public void OpenUserProfileContainerPopout(Guid ProfileGuid)
        {
            if(!UserPopupControlContainer.IsDisplayed)
            {
                UserProfile AddNewUser = new UserProfile();
                AddNewUser.Init(ProfileGuid);

                UserPopupControlContainer.PopupControl = AddNewUser;
                AddNewUser.closeRequestedEvent += AddNewUser_closeRequestedEvent;
                UserPopupControlContainer.Show(this);
            }
            else
            {
                UserPopupControlContainer.PopupControl.Controls.Clear();
                UserPopupControlContainer.Close();
            }
        }

        private void AddNewUser_closeRequestedEvent(UserProfile addUser)
        {
            try
            {
                switch (addUser.closeType)
                {
                    case UserProfile.CloseType.Okay:
                        Init();
                        UserPopupControlContainer.PopupControl.Controls.Clear();
                        UserPopupControlContainer.Close();
                        
                        break;
                    case UserProfile.CloseType.Cancel:
                        Init();
                        UserPopupControlContainer.PopupControl.Controls.Clear();
                        UserPopupControlContainer.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
