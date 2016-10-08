using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Net;
using System.Net.Mail;
using System.IO;

namespace FROST.Utility {
    /**
     * 
     * 使用说明
     * 
    FileInfo fileInfo1 = new FileInfo(@"D:\新建 Microsoft Excel 工作表.xlsx");
    FileInfo fileInfo2 = new FileInfo(@"D:\新建 Microsoft Word 文档.docx");
    MailHelper mail = new MailHelper("sfrost@qq.com", "账号密码", "smtp.qq.com");
    var res = mail.SendMail("sfrost@qq.com", "test", DateTime.Now.ToString(),
        new List<MailHelper.FileAttachment> {
            new MailHelper.FileAttachment {
                FileContent = File.ReadAllBytes(fileInfo1.FullName),
                FileName = fileInfo1.Name
            },
            new MailHelper.FileAttachment {
                FileContent = File.ReadAllBytes(fileInfo2.FullName),
                FileName = fileInfo2.Name
            }
        });
    * 
    * 
    **/
    /// <summary>
    /// 邮件发送类
    /// </summary>
    public class MailHelper {
        /// <summary>
        /// 发送邮件账号
        /// </summary>
        private String _mailAccount;
        /// <summary>
        /// 账号密码
        /// </summary>
        private String _password;
        /// <summary>
        /// SMTP服务器地址
        /// </summary>
        private String _smtpServer;
        /// <summary>
        /// SMTP端口号
        /// </summary>
        private int _port;
        /// <summary>
        /// 设置发送账号信息
        /// </summary>
        /// <param name="mailAccount">发送邮件账号</param>
        /// <param name="password">账号密码</param>
        /// <param name="smtpServer">SMTP服务器地址</param>
        /// <param name="port">SMTP端口号</param>
        public MailHelper(String mailAccount, String password, String smtpServer, int port = 587) {
            _mailAccount = mailAccount;
            _password = password;
            _smtpServer = smtpServer;
            _port = port;
        }
        /// <summary>
        /// 附件实体类
        /// </summary>
        public class FileAttachment {
            public String FileName { get; set; }
            public byte[] FileContent { get; set; }
        }
        /// <summary>
        /// 发送邮件（后期实现多个收件人、抄送多人）
        /// </summary>
        /// <param name="toAddress">收件人地址（后期实现多个）</param>
        /// <param name="subject">邮件标题</param>
        /// <param name="text">邮件内容</param>
        /// <param name="fileAttachments">附件</param>
        /// <returns></returns>
        public bool SendMail(String toAddress, String subject, String text,List<FileAttachment> fileAttachments = null) {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(toAddress);
            /* 
            * msg.To.Add("b@b.com");
            * msg.To.Add("b@b.com");
            * msg.To.Add("b@b.com");可以发送给多人 
            */
            /* 
            * msg.CC.Add("c@c.com"); 
            * msg.CC.Add("c@c.com");可以抄送给多人
            */
            msg.From = new MailAddress(_mailAccount, _mailAccount, System.Text.Encoding.UTF8);
            /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
            msg.Subject = subject;//邮件标题
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码
            msg.Body = "<h1>" + text + "</h1>";//邮件内容
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码
            msg.IsBodyHtml = true;//是否是HTML邮件
            msg.Priority = MailPriority.High;//邮件优先级
            if (fileAttachments != null && fileAttachments.Count != 0) {
                foreach (var fileAttachment in fileAttachments) {
                    msg.Attachments.Add(new Attachment(new MemoryStream(fileAttachment.FileContent),
                        fileAttachment.FileName));
                }
            }
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_mailAccount, _password);
            client.Port = _port;
            client.Host = _smtpServer;
            client.EnableSsl = true;//经过ssl加密
            try {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex) {
                return false;
            }
        }
    }
}