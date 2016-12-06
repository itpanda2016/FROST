using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationAuction.Models
{
    public class AdminController : Controller
    {
        IMemberRepository memberRepository;
        public AdminController(IMemberRepository imr) {
            this.memberRepository = imr;
        }
        // GET: Admin
        public ActionResult ChangeLoginName(string oldLoginParam,string newLoginParam) {
            Member member = memberRepository.FetchByLoginName(oldLoginParam);
            member.LoginName = newLoginParam;
            memberRepository.SubmitChanges();
            return View();
        }
    }
}