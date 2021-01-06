using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    public class QueryFenxianBoxReslut
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

        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public string result { get; set; }
            /// <summary>
            /// {condition=[{"fieldName":"resource_attribute","fieldValue":"1485682,1485685,1485685,1485684"},{"fieldName":"region_id","fieldValue":"000102000000000000000015,000102000000000000001527,000102000000000000001528,000102000000000000001529,000102000000000000001530,000102000000000000001531,000102000000000000001576,000102000000000229246762,000102000000000229246767"}], versionId=31991da1-e009-4758-9ec3-5c3b981ca6b7, resTypeId=9267, sysId=d4b9a860-9cef-4475-a2c2-2a8d441b54fa, count=16, location=[], sort=[], begin=0, categoryId=, keyWord=牛山张庄社区加密-GF0022}
            /// </summary>
            public string happySearchParams { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }
        }
    }
}
