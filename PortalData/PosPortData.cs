using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class PosPortData
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

        public class RowsItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string NO { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string PORT_OPR_TYPE { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string CONNECTSTATUS { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ACC_NBR { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string PORT_PURPOSE { get; set; }
            /// <summary>
            /// 前张村新吴-GF0051-POS001-1:8
            /// </summary>
            public string EQP_NAME { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string EXCHANGE_MODULE_NO { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string SVLAN { get; set; }
            /// <summary>
            /// 占用
            /// </summary>
            public string OPR_STATE { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string SUB_PORT { get; set; }
            /// <summary>
            /// 未绑定
            /// </summary>
            public string BIND_STATUS { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string DQRPERSON { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int OPR_STATE_ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string PORT_NAME { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string LDMPERSON { get; set; }
        }

        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public ObservableCollection<RowsItem> rows { get; set; }
        }

    }
}
