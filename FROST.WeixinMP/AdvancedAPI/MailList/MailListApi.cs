using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SufeiUtil;
using Newtonsoft.Json;

namespace FROST.WeixinMP {
    public class MailListApi {
        /// <summary>
        /// 获取用户的详细信息
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static MemberResult GetMemberInfo(string openid, string access_token) {
            string url = "https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + access_token
                + "&openid=" + openid + "&lang=zh_CN";
            HttpItem item = new HttpItem();
            item.URL = url;
            HttpHelper http = new HttpHelper();
            return JsonConvert.DeserializeObject<MemberResult>(http.GetHtml(item).Html);
        }
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static TagListResult TagList(string access_token) {
            string url = "https://api.weixin.qq.com/cgi-bin/tags/get?access_token=" + access_token;
            HttpItem item = new HttpItem();
            item.URL = url;
            HttpHelper http = new HttpHelper();
            return JsonConvert.DeserializeObject<TagListResult>(http.GetHtml(item).Html);
        }
    }
}
