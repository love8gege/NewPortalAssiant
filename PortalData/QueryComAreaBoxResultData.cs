using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.PortalData
{
   
    public class QueryComAreaBoxResultData
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
        public List<DataItem> data { get; set; }

        public class DataItem
        {
            /// <summary>
            /// 38-2#1单元
            /// </summary>
            public string LOCATION { get; set; }
            /// <summary>
            /// 新海
            /// </summary>
            public string REGION_NAME { get; set; }
            /// <summary>
            /// 青岛花园小区-GJ0001
            /// </summary>
            public string UPPERBOX { get; set; }
            /// <summary>
            /// 光分纤箱
            /// </summary>
            public string BOX_TYPE { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double? X { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double? Y { get; set; }
            /// <summary>
            /// 分光器
            /// </summary>
            public string BOX_EQP_TYPE { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ID { get; set; }
            /// <summary>
            /// 青岛花园-GF0005
            /// </summary>
            public string BOX_NAME { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string RES_TYPE_ID { get; set; }
        }
    }
}
