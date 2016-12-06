using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST2 {
    public class MyEmailSender : IEmailSender {
        public bool Send(string to) {
            return true;
        }
    }
}