using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models {
    public class GuestResponse {
        [Required(ErrorMessage ="请输入姓名")]
        public string Name { set; get; }
        [Required(ErrorMessage ="请输入邮箱地址。")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="电子邮件地址似乎不正确。")]
        public string Email { set; get; }
        [Required(ErrorMessage ="请输入电话号码")]
        public string Phone { set; get; }
        [Required(ErrorMessage ="请确认你是否能到？")]
        public bool? WillAttend { set; get; }
    }
}