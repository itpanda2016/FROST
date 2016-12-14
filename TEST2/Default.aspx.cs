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

    public partial class Default : System.Web.UI.Page {
        public string hello;
        protected void Page_Load(object sender, EventArgs e) {
            TxtLogHelper log = new TxtLogHelper(Server.MapPath("~/log/"));
            hello = DateTime.Now.ToString();
            MyEmailSender mes = new MyEmailSender();
            log.Info("ssss");
            Response.Write(SendMail(mes));
            EcanRMB rmb = new EcanRMB();
            decimal amount;
            amount = 32123435.34m;
            Response.Write(rmb.CmycurD(amount));
        }
        public bool SendMail(IEmailSender ies) {
            return ies.Send("a");
        }
    }
}