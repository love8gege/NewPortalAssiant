using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class QueryComAreaIDResultData
    {
    
        /// <summary>
        /// 
        /// </summary>
        public string resultStat { get; set; }
        /// <summary>
        /// 执行服务端方法成功
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

        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public string result { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }
        }
    }
}
