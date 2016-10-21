using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FROST.WeixinQYH.AdvancedAPI {
    /// <summary>
    /// 如果无权限或收件人不存在，则本次发送失败；如果未关注，发送仍然执行。两种情况下均返回无效的部分（注：由于userid不区分大小写，返回的列表都统一转为小写）。
    /// </summary>
    public class PostMessageResult {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string invaliduser { get; set; }
        public string invalidparty { get; set; }
        public string invalidtag { get; set; }
    }

}
