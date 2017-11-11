using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SufeiUtil;
using Newtonsoft.Json;

namespace FROST.WeixinMP.AdvancedAPI.MailList {
    public class MailListApi {
        public static Tag.TagListResult TagList(string access_token) {
            string url = "https://api.weixin.qq.com/cgi-bin/tags/get?access_token=" + access_token;
            HttpItem item = new HttpItem();
            item.URL = url;
            HttpHelper http = new HttpHelper();
            return JsonConvert.DeserializeObject<Tag.TagListResult>(http.GetHtml(item).Html);
        }
    }
}
