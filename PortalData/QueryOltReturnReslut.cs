using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.PortalData
{
    
    public class QueryOltReturnReslut
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
            /// {condition=[{"fieldName":"resource_attribute","fieldValue":"1485682,1485685,1485685,1485684"}], versionId=31991da1-e009-4758-9ec3-5c3b981ca6b7, resTypeId=9777, sysId=d4b9a860-9cef-4475-a2c2-2a8d441b54fa, count=16, location=[], sort=[{"fieldName":"station_no","fieldValue":"asc"}], begin=0, categoryId=, keyWord=LYG-GUY-南岗岗西-OLT002-HW-MA5800}
            /// </summary>
            public string happySearchParams { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }
        }
    }
}
