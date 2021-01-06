using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class BoxAddressData
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

        public class DataListItem
        {
            /// <summary>
            /// 标准十级地址
            /// </summary>
            public string SEGM_TYPE { get; set; }
            /// <summary>
            /// 牛山张庄社区加密-GF0022
            /// </summary>
            public string EQP_NO { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string SEGM_TYPE_ID { get; set; }
            /// <summary>
            /// 牛山张庄社区加密-GF0022
            /// </summary>
            public string EQP_NAME { get; set; }
            /// <summary>
            /// 光分纤箱
            /// </summary>
            public string RES_TYPE { get; set; }

            public string isHaveBusiness { get; set; }
            /// <summary>
            /// 连云港地区东海县城牛山张庄新村牛山张庄社区122122-4
            /// </summary>
            public string STAND_NAME { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string SEGM_EQP_ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string SEGM_NAME { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string EQP_ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string SEGM_ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int RN { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int RES_TYPE_ID { get; set; }
        }

        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public int totalNum { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public ObservableCollection<DataListItem> dataList { get; set; }
        }
    }
}
