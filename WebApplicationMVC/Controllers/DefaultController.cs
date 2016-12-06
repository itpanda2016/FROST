using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "上午好" : "下午好";

            return View();
        }

        [HttpGet]
        public ViewResult ReturnForm() {
            return View();
        }

        [HttpPost]
        public ViewResult ReturnForm(GuestResponse guestResponse) {
            if (ModelState.IsValid) {
                //发送邮件
                return View("Thanks", guestResponse);
            }
            else {
                //验证有错误
                return View();
            }
        }
    }
}