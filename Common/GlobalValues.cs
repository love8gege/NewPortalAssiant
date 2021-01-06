using NewPortalAssiant.DataAccess.DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewPortalAssiant.Common
{
    public class GlobalValues
    {
        public static UserEntity UserInfo { get; set; }

        public static string Cookies { get; set; }

        public static readonly string Host = "10.40.95.32:8012";
        public static readonly string Origin = "http://10.40.95.32:8012";

        public static readonly string CallServerFunctionUri = "http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr";

    }
}