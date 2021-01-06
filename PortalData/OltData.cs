using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class OltData
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
            public string SPEC_ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// LYG-GUY-南岗岗西-OLT002-HW-MA5800
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// LYG-GUY-南岗岗西-OLT002-HW-MA5800
            /// </summary>
            public string no { get; set; }
            /// <summary>
            /// 南岗岗西节点机房01F
            /// </summary>
            public string posit_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string region_id { get; set; }
            /// <summary>
            /// 灌云
            /// </summary>
            public string region_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string resTypeId { get; set; }
            /// <summary>
            /// OLT设备
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
            /// 
            /// </summary>
            public string type { get; set; }
        }
    }
}
