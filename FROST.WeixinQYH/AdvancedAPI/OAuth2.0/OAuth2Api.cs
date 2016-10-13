/**
 * 企业获取code的URL
 * 根据code获取成员信息
 * 
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FROST.Utility;
using Newtonsoft.Json;

namespace FROST.WeixinQYH {
    public class OAuth2Api {
        /// <summary>
        /// 企业如果需要员工在跳转到企业网页时带上员工的身份信息，需构造如下的链接，员工点击后，页面将跳转至 redirect_uri?code=CODE&state=STATE，企业可根据code参数获得员工的userid。
        /// </summary>
        /// <param name="corpID">企业的CorpID</param>
        /// <param name="redirectURI">授权后重定向的回调链接地址，请使用urlencode对链接进行处理</param>
        /// <param name="state">重定向后会带上state参数，企业可以填写a-zA-Z0-9的参数值，长度不可超过128个字节</param>
        /// <param name="response_type">返回类型，此时固定为：code</param>
        /// <param name="scope">应用授权作用域，此时固定为：snsapi_base</param>
        /// <returns></returns>
        public static string GetCodeUrl(string corpID,string redirectURI,string state = null, string response_type = "code", string scope = "snsapi_base") {
            string url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type={2}&scope={3}&state={4}#wechat_redirect",
                corpID,redirectURI,response_type,scope,state);
            return url;
        }
        /// <summary>
        /// 根据code获取成员信息
        /// </summary>
        /// <param name="code">通过成员授权获取到的code，每次成员授权带上的code将不一样，code只能使用一次，10分钟未被使用自动过期</param>
        /// <param name="access_token"></param>
        /// <returns>GetUserInfoResult</returns>
        public static GetUserInfoResult GetUserInfo(string code,string access_token) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}",
                access_token, code);
            return JsonConvert.DeserializeObject<GetUserInfoResult>(
                General.CurlByDotNet(url, CurlMethod.GET));
        }
    }
}
