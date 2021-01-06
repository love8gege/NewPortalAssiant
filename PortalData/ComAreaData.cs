using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class ComAreaData
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
        public List<RowsItem> rows { get; set; }

        //如果好用，请收藏地址，帮忙分享。
        public class RowsItem
        {
            /// <summary>
            /// 青岛花园小区
            /// </summary>
            public string no { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string resTypeId { get; set; }
            /// <summary>
            /// 青岛花园小区
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 小区
            /// </summary>
            public string type { get; set; }
        }
    }
}
