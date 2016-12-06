using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Web;

namespace FROST.Utility {
    /// <summary>
    /// 记录日志
    /// </summary>
    public class TxtLogHelper {
        public string logFileName = "";
        public bool isDebug;
        /// <summary>
        /// 初始化时需填写日志保存路径
        /// </summary>
        /// <param name="logPath">文件路径（建议Txt）：可用Server.MapPath或是绝对路径，记得添加最后的 / </param>
        /// <param name="isDebug">是否启用，默认为True：启用，Flash：停止记录</param>
        public TxtLogHelper(string logPath,bool isDebug = true) {
            this.isDebug = isDebug;
            if (logPath.IndexOf(".txt") > 0) {
                this.logFileName = logPath;
            }
            else {
                this.logFileName = logPath + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
        }
        /// <summary>
        /// 写入日志，自动换行
        /// </summary>
        /// <param name="logMsg"></param>
        public void Info(string logMsg) {
            if (!isDebug)
                return;
            File.AppendAllText(this.logFileName, logMsg + "\r\n");
        }
    }
}

