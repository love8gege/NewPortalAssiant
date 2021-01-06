using NewPortalAssiant.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.Model
{
    public class PortalLoginInfo:NotifyBase
    {
        private string _userName;

        public string UserNmae
        {
            get { return _userName; }
            set { _userName = value; this.DoNotify(); }
        }

        private string _realName;

        public string RealName
        {
            get { return _realName; }
            set { _realName = value;this.DoNotify(); }
        }

        private string _userId;

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; this.DoNotify(); }
        }






    }
}
