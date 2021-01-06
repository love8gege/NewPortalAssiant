using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class LoginResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string resultStat { get; set; }
        /// <summary>
        /// 登陆成功
        /// </summary>
        public string mess { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string callBack { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }

        public class User
        {
            /// <summary>
            /// 
            /// </summary>
            public int staffId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string loginName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string expDate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string effDate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string expDateS { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string expDateE { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int staffState { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int title { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string password { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string passwordModifyDate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grayGroups { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string provinceId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string oldPwd { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string lastLoginDate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int userGrade { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userOrganizeInfo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userNo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userOuterInfo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userName { get; set; }
        }
        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public User user { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string tgt { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string st { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string random { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string service { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string loginName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string provinceId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userGrade { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userOrganizeInfo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userNo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userOuterInfo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userName { get; set; }
        }
    }
}
