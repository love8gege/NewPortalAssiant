using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class FenxianBoxData
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
        public ObservableCollection<ResultsItem> results { get; set; }

        public class ResultsItem
        {
            /// <summary>
            /// GX-连云港-东海-光分-3650174
            /// </summary>
            public string DIGCODE_SOURCE { get; set; }
            /// <summary>
            /// 壁挂
            /// </summary>
            public string FIX_TYPE_ID { get; set; }
            /// <summary>
            /// 连云港地区
            /// </summary>
            public string LAN_ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string PARENT_TYPE { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string PORT_NUM { get; set; }
            /// <summary>
            /// 远地式
            /// </summary>
            public string USER_ACCESS_TYPE { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ZD_BCRL { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ZD_SFCL { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ZD_SYSM { get; set; }
            /// <summary>
            /// 牛山张庄（FTTH）-GJ0001
            /// </summary>
            public string cnt_box_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string create_date { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string create_op { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string eqp_model { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 在网
            /// </summary>
            public string mnt_state { get; set; }
            /// <summary>
            /// 牛山张庄社区加密-GF0022
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 牛山张庄社区加密-GF0022
            /// </summary>
            public string no { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string region_id { get; set; }
            /// <summary>
            /// 东海
            /// </summary>
            public string region_name { get; set; }
            /// <summary>
            /// 牛山张庄社区
            /// </summary>
            public string region_name_com { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string resTypeId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string resource_attribute { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string searchFullSpell { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string searchSimpleSpell { get; set; }
            /// <summary>
            /// 光分纤箱
            /// </summary>
            public string type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string x { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string y { get; set; }
        }
    }
}
