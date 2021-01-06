using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.DataAccess.DataEntity
{
    public class UserEntity
    {
        public string UserAccount { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPhone { get; set; }
        public string UserLim { get; set; }
        public string UserCert { get; set; }
        public string PortalName { get; set; }
        public string PortalPassword { get; set; }
        public string PortalStaff { get; set; }
    }
}
