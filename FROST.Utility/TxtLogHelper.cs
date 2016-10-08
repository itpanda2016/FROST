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
        /// <summary>
        /// 初始化时需填写日志保存路径
        /// </summary>
        /// <param name="logPath">文件名（建议Txt）：可用Server.MapPath或是绝对路径</param>
        public TxtLogHelper(string logPath) {
            if (logPath.IndexOf(".txt") > 0) {
                this.logFileName = logPath;
            }
            else {
                this.logFileName = logPath + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + ".txt";
            }
        }
        /// <summary>
        /// 写入日志，自动换行
        /// </summary>
        /// <param name="logMsg"></param>
        public void Info(string logMsg) {
            File.AppendAllText(this.logFileName, logMsg + "\r\n");
        }
    }
}

