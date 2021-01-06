using NewPortalAssiant.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.Model
{
    public class PortalLoginModel : NotifyBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                this.DoNotify();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                this.DoNotify();
            }
        }


    }
}
