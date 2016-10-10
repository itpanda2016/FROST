using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FROST.Utility;
using Newtonsoft.Json;

namespace FROST.WeixinQYH {
    /// <summary>
    /// AccessToken方法，建议存储在Session、Cookie中，通过设置过期时间，来判断是否到期（但可能在微信客户端中使用时有问题）
    /// </summary>
    public class AccessTokenContainer {
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="corpID"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static string GetToken(string corpID,string secret) {
            return GetTokenObject(corpID, secret).access_token;
        }
        /// <summary>
        /// 获取AccessToken（对象）
        /// </summary>
        /// <param name="corpID"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static AccessTokenResultOK GetTokenObject(string corpID, string secret) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", corpID, secret);
            string ret = General.CurlByDotNet(url, CurlMethod.GET);
            if (ret.IndexOf("errcode") >= 0)
                return null;
            return JsonConvert.DeserializeObject<AccessTokenResultOK>(ret);
        }
        /// <summary>
        /// 正确的Json返回
        /// </summary>
        public class AccessTokenResultOK {
            public string access_token { get; set; }
            public int expires_in { get; set; }
        }
        /// <summary>
        /// 错误的Json返回
        /// </summary>
        public class AccessTokenResultError {
            public int errcode { get; set; }
            public string errmsg { get; set; }
        }

    }
}
