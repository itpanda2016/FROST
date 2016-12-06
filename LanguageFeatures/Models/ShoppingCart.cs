using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models {
    public class ShoppingCart:IEnumerable<Product> {
        public List<Product> Products { set; get; }

        /// <summary>
        /// 这儿实现的是Products的获取枚举的方法
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Product> GetEnumerator() {
            return Products.GetEnumerator();
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 这儿返回的是上面的方法
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() {
            //throw new NotImplementedException();
            return GetEnumerator();
        }
    }
}