using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models {
    public class Product {
        private string _name;   //这个是【字段】
        public string Name {    //带有getter/setter的是【属性】
            get { return _name; }
            set { _name = value; }
        }
        public int ProductID { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 涉及金额及财务相关的数据，使用decimal类型
        /// </summary>
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}