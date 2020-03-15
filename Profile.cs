using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpQuickSwitch
{
    public class Profile
    {
        public Profile()
        {

        }

        public Guid ProfileGuid { get; set; }
        public string Name { get; set; }
        public string IPaddress { get; set; }
        public string Subnet { get; set; }
        public string GateWay { get; set; }
    }
}
