using NewPortalAssiant.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.Model
{
    public class UserModel:NotifyBase
    {
        
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; this.DoNotify(); }
        }       
    }
}
