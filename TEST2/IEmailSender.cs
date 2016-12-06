using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST2 {
    public interface IEmailSender {
        bool Send(string to);
    }
}