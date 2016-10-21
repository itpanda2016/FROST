using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FROST.WeixinQYH.AdvancedAPI {
    public class MessageApi {
        /// <summary>
        /// POST发送消息的URL
        /// </summary>
        protected static string PostUrl = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=";
        public static PostMessageResult MessageSendText(string accessToken, string toUser, string toParty, string toTag, int agentId, string contEnt, int saFe = 0) {
            var data = new {
                touser = toUser,
                topart = toParty,
                totag = toTag,
                msgtype = "text",
                agentid = agentId,
                text = new {
                    content = contEnt
                },
                safe = saFe
            };

        }
    }
}
