using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FROST.WeixinMP.AdvancedAPI.Ticket {

    public class TicketResult {
        /// <summary>
        /// 获取的二维码ticket，凭借此ticket可以在有效时间内换取二维码。
        /// </summary>
        public string ticket { get; set; }
        /// <summary>
        /// 该二维码有效时间，以秒为单位。 最大不超过2592000（即30天）。
        /// </summary>
        public int expire_seconds { get; set; }
        /// <summary>
        /// 二维码图片解析后的地址，开发者可根据该地址自行生成需要的二维码图片
        /// </summary>
        public string url { get; set; }
    }
    /// <summary>
    /// 创建永久二维码
    /// </summary>
    public class CreateTicket {
        public string action_name { get; set; }
        public Action_Info action_info { get; set; }
    }

    public class Action_Info {
        public Scene scene { get; set; }
    }

    public class Scene {
        public int scene_id { get; set; }
    }

}
