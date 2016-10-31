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
using Newtonsoft.Json;

namespace TEST2 {

    public class Test1 {
        public string UserId { get; set; }
        public string DeviceId { get; set; }
    }
    public class Test2 {
        public string OpenId { get; set; }
        public string DeviceId { get; set; }
    }

    public class Test3 {
        public string errcode { get; set; }
        public string errmsg { get; set; }
    }

    public class Test4 {
        public string UserId { get; set; }
        public string OpenId { get; set; }
        public string DeviceId { get; set; }
        public string errcode { get; set; }
        public string errmsg { get; set; }
    }

    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string corpid = ConfigurationManager.AppSettings["qyhCorpID"];
            string secret = ConfigurationManager.AppSettings["qyhSecret"];
            Test1 t1 = new Test1();
            t1.UserId = "Uid";
            t1.DeviceId = "Did";
            Test3 t3 = new Test3();
            t3.errcode = "33";
            t3.errmsg = "god";
            string test = JsonConvert.SerializeObject(t3);
            Test4 t4 = new Test4();
            t4 = JsonConvert.DeserializeObject<Test4>(test);
            Response.Write(t4.DeviceId);
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