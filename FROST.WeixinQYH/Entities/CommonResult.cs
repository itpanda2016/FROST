using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FROST.WeixinQYH.Entities {
    /// <summary>
    /// userid转换成openid接口（请求实体）
    /// </summary>
    public class ConvertToOpenIDPost {
        public string userid { get; set; }
        public int agentid { get; set; }
    }
    /// <summary>
    /// userid转换成openid接口（返回结果）
    /// </summary>
    public class ConvertToOpenIDResult {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string openid { get; set; }
        public string appid { get; set; }
    }
    /// <summary>
    /// openid转换成userid接口（请求实体）
    /// </summary>
    public class ConvertToUserIDPost {
        public string openid { get; set; }
    }
    /// <summary>
    /// openid转换成userid接口（返回结果）
    /// </summary>
    public class ConvertToUserIDResult {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string userid { get; set; }
    }

}
