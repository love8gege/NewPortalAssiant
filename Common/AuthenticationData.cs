using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.Common
{
    public class AuthenticationData
    {
        private string _limitDate;

        public string LimitDate { get => _limitDate; set => _limitDate = value; }
        public string Author { get => _author; set => _author = value; }
        public string StartDate { get => _startDate; set => _startDate = value; }
        public string UserCrop { get => _userCrop; set => _userCrop = value; }

        private string _author;
        private string _startDate;
        private string _userCrop;
    }
}
