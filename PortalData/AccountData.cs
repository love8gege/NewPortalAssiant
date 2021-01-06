using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class AccountData
    {
    
        /// <summary>
        /// 
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string searchTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string start { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string returnCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alais { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ResultsItem> results { get; set; }

        public class ResultsItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string ACC_NBR { get; set; }
            /// <summary>
            /// 连云港地区新海新浦区云台农场无门牌18排无单元2号
            /// </summary>
            public string ADDR_NAME { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string BANDWIDTH { get; set; }
            /// <summary>
            /// 云台农场
            /// </summary>
            public string COM_NAME { get; set; }
            /// <summary>
            /// 完成
            /// </summary>
            public string OPR_STATE_ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string SENSITIVEPHONE { get; set; }
            /// <summary>
            /// 个人业务融合
            /// </summary>
            public string TYPE { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string region_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string rela_inst_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string resource_attribute { get; set; }
        }
    }
}
