using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class PosData
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
        public List<FacetItem> facet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ResultsItem> results { get; set; }

        public class RowsItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string count { get; set; }
        }

        public class FacetItem
        {
            /// <summary>
            /// 配比
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string field { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public ObservableCollection<RowsItem> rows { get; set; }
        }

        public class ResultsItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string ASSET_INFO { get; set; }
            /// <summary>
            /// 牛山汤庄
            /// </summary>
            public string COM_NAME { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string MAN_IN_CHARGE_NAME { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string MNT_MAN { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string PON_NET_TYPE { get; set; }
            /// <summary>
            /// 牛山汤庄（FTTH）-GJ0001
            /// </summary>
            public string POSIT_TYPE { get; set; }
            /// <summary>
            /// 2级模式光交箱分光器
            /// </summary>
            public string PRODUCT_NO { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string SVLAN { get; set; }
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
            public string eqp_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 牛山汤庄（FTTH）-GJ0001-POS011-1:8
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 牛山汤庄（FTTH）-GJ0001-POS011-1:8
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
            /// 
            /// </summary>
            public string resTypeId { get; set; }
            /// <summary>
            /// 分光器
            /// </summary>
            public string res_type { get; set; }
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
            /// 接入
            /// </summary>
            public string speciality { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string station_no { get; set; }
            /// <summary>
            /// 分光器
            /// </summary>
            public string type { get; set; }
        }
    }
}
