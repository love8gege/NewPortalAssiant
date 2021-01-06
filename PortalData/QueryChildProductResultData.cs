using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class QueryChildProductResultData
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
            /// 
            /// </summary>
            public string BUSINESS_ID { get; set; }
            /// <summary>
            /// 个人宽带
            /// </summary>
            public string PRODUCT_TYPE { get; set; }
            /// <summary>
            /// 已绑定
            /// </summary>
            public string STATUS { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ACC_NBR { get; set; }
            /// <summary>
            /// 连云港地区新海新浦区云台农场云台农场（FTTH）18排2号
            /// </summary>
            public string ADDRESS { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string PROD_INST_ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ADDR_ID { get; set; }
            /// <summary>
            /// 完成
            /// </summary>
            public string OPR_STATE_ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string COM_ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string PRODUCT_ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string CREATETIME { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string SVLAN_STATUS { get; set; }
        }
    }
}
