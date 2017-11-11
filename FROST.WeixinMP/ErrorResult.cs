using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FROST.WeixinMP {
    /// <summary>
    /// 错误返回的通用类
    /// </summary>
    public class ErrorResult {
        /// <summary>
        /// 错误编码
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string errmsg { get; set; }
    }

}
