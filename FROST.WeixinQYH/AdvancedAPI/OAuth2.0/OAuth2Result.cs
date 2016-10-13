using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FROST.WeixinQYH {
    /// <summary>
    /// 根据code获取成员信息返回结果
    /// </summary>
    public class GetUserInfoResult {
        /// <summary>
        /// 成员UserID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 非企业成员的标识，对当前企业号唯一
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 手机设备号(由微信在安装时随机生成，删除重装会改变，升级不受影响，同一设备上不同的登录账号生成的deviceid也不同)
        /// </summary>
        public string DeviceId { get; set; }
        public string errcode { get; set; }
        public string errmsg { get; set; }
    }
}
