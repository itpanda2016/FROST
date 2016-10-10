using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FROST.Utility;
using System.IO;
using System.Configuration;
using FROST.WeixinQYH;

namespace TEST2 {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string corpid = ConfigurationManager.AppSettings["qyhCorpID"];
            string secret = ConfigurationManager.AppSettings["qyhSecret"];

            Response.Write(AccessTokenContainer.GetToken(corpid, secret));
            //发送邮件示例，可用
            //FileInfo fileInfo1 = new FileInfo(@"D:\新建 Microsoft Excel 工作表.xlsx");
            //FileInfo fileInfo2 = new FileInfo(@"D:\新建 Microsoft Word 文档.docx");
            //MailHelper mail = new MailHelper("sfrost@qq.com", "grd0624<", "smtp.qq.com");
            //var res = mail.SendMail("sfrost@qq.com", "test", DateTime.Now.ToString(),
            //        new List<MailHelper.FileAttachment> {
            //            new MailHelper.FileAttachment {
            //                FileContent = File.ReadAllBytes(fileInfo1.FullName),
            //                FileName = fileInfo1.Name
            //            },
            //            new MailHelper.FileAttachment {
            //                FileContent = File.ReadAllBytes(fileInfo2.FullName),
            //                FileName = fileInfo2.Name
            //            }
            //        });
            //if (res)
            //    Response.Write("发送成功。");
            //else
            //    Response.Write("发送失败。");
            //发送邮件示例，结束
        }

        protected void Button1_Click(object sender, EventArgs e) {
            
            //MailHelper mailHelper = new MailHelper("发件人地址", "邮箱密码", "smtp.qq.com");
            //var flag = mailHelper.SendMail("收件人地址", "测试邮件发送附件", "详情见附件",
            //        new List<MailHelper.FileAttachment>
            //        {
            //    new MailHelper.FileAttachment
            //    {
            //        FileContent = File.ReadAllBytes(fileInfo1.FullName),
            //        FileName = fileInfo1.Name
            //    },
            //    new MailHelper.FileAttachment
            //    {
            //        FileContent = File.ReadAllBytes(fileInfo2.FullName),
            //        FileName = fileInfo2.Name
            //    }
            //        });
            //Console.WriteLine(flag);
            //Console.ReadLine();
        }
    }
}