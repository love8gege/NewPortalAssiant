using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class BoxPosesData
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
        public ObservableCollection<DataItem> data { get; set; }

        public class BuizListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string RES_ID { get; set; }
            /// <summary>
            /// 牛山汤庄（FTTH）-GF0018-POS002-1:8
            /// </summary>
            public string RES_NAME { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int RES_TYPE_ID { get; set; }
            /// <summary>
            /// 牛山汤庄（FTTH）-GF0018-POS002-1:8
            /// </summary>
            public string RES_NO { get; set; }
        }

        public class DataItem
        {
            /// <summary>
            /// 
            /// </summary>
            public int listNum { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int buizTypeId { get; set; }
            /// <summary>
            /// 分光器
            /// </summary>
            public string buizDesc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public ObservableCollection<BuizListItem> buizList { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public ObservableCollection<string> titleList { get; set; }
        }
    }
}
