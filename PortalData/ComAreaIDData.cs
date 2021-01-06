using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class ComAreaIDData
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
            public string ALIAS0 { get; set; }
            /// <summary>
            /// 金秋情缘
            /// </summary>
            public string ALIAS1 { get; set; }
            /// <summary>
            /// 金秋情缘
            /// </summary>
            public string ALIAS2 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS3 { get; set; }
            /// <summary>
            /// 金秋情缘
            /// </summary>
            public string ALIAS4 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS5 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS6 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS7 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS8 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS9 { get; set; }
            /// <summary>
            /// 采集小区大门
            /// </summary>
            public string ALIAS10 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS11 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS12 { get; set; }
            /// <summary>
            /// 标准小区
            /// </summary>
            public string ALIAS13 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS14 { get; set; }
            /// <summary>
            /// 新海
            /// </summary>
            public string ALIAS15 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS16 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS17 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS18 { get; set; }
            /// <summary>
            /// 家庭宽带
            /// </summary>
            public string ALIAS19 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS20 { get; set; }
            /// <summary>
            /// 市区城区
            /// </summary>
            public string ALIAS21 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ALIAS22 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string RN { get; set; }
        }

        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public int page { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<RowsItem> rows { get; set; }
        }
    }
}
