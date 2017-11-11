using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SufeiUtil;
using Newtonsoft.Json;

namespace FROST.WeixinMP.AdvancedAPI.Ticket {
    public partial class OtherApi {
        /// <summary>
        /// 获取永久二维码TICKET（数字）
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static Ticket.TicketResult GetTicket(string access_token, int sceneId) {
            string url = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=" + access_token;
            Ticket.CreateTicket ticket = new Ticket.CreateTicket {
                action_name = "QR_LIMIT_SCENE",
                action_info = new Ticket.Action_Info {
                    scene = new Ticket.Scene {
                        scene_id = sceneId
                    }
                }
            };
            //ErrorResult error = new ErrorResult();
            HttpItem item = new HttpItem();
            item.URL = url;
            item.Method = "POST";
            item.Postdata = JsonConvert.SerializeObject(ticket);
            HttpHelper http = new HttpHelper();
            string ret = http.GetHtml(item).Html;
            if (ret.IndexOf("errcode") > 0)
                return null;
            return JsonConvert.DeserializeObject<Ticket.TicketResult>(ret);
        }
        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <param name="ticket">必须使用Server.URLEncode处理</param>
        /// <returns></returns>
        public static string GetQRCode(string ticket) {
            if (string.IsNullOrEmpty(ticket))
                return null;
            string url = "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + ticket;
            HttpItem item = new HttpItem {
                URL = url
            };
            HttpHelper http = new HttpHelper();
            return http.GetHtml(item).Html;
        }
    }
}
