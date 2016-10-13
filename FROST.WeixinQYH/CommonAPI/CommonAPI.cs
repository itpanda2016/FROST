/**
 * 文档说明
 * 1、UserID与OpenID互换接口
 *      
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FROST.WeixinQYH.Entities;
using Newtonsoft.Json;
using FROST.Utility;

namespace FROST.WeixinQYH {
    public class CommonAPI {
        /// <summary>
        /// userid转换成openid接口
        /// </summary>
        /// <param name="ctop">ConvertToOpenIDPost</param>
        /// <param name="access_token"></param>
        /// <returns>ConvertToOpenIDResult</returns>
        public static ConvertToOpenIDResult ConvertToOpenID(ConvertToOpenIDPost ctop,string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/convert_to_openid?access_token=" + access_token;
            return JsonConvert.DeserializeObject<ConvertToOpenIDResult>(
                General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(ctop)));
        }
        /// <summary>
        /// openid转换成userid接口
        /// </summary>
        /// <param name="ctup">ConvertToUserIDPost</param>
        /// <param name="access_token"></param>
        /// <returns>ConvertToUserIDResult</returns>
        public static ConvertToUserIDResult ConvertToUserID(ConvertToUserIDPost ctup,string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/convert_to_userid?access_token=" + access_token;
            return JsonConvert.DeserializeObject<ConvertToUserIDResult>(
                General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(ctup)));
        }
    }
}
