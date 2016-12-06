using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models {
    public static class MyExtensionMethods {
        /// <summary>
        /// 参数中添加的this 关键词是关键，表明了该方法是ShoppingCart类的扩展方法
        /// </summary>
        /// <param name="cartParam"></param>
        /// <returns></returns>
        public static decimal TotalPrices(this IEnumerable<Product> cartParam) {    //改为IEnumerable<>后，表示只要实现了这个接口的类，均可以调用该扩展方法
            decimal total = 0;
            //哈哈，更简的是用foreach
            //for (int i = 0; i < cartParam.Products.Count; i++) {
            //    total += cartParam.Products[i].Price;
            //}
            foreach (Product item in cartParam) {
                total += item.Price;
            }
            return total;
        }
        /// <summary>
        /// 过滤扩展方法，返回同样的核举对象
        /// </summary>
        /// <param name="productEnum"></param>
        /// <param name="categoryParam"></param>
        /// <returns></returns>
        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> productEnum,string categoryParam) {
            foreach (Product item in productEnum) {
                if(item.Category == categoryParam) {
                    yield return item;      //在枚举器中，过滤并返回指定的结果
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum,Func<Product,bool> selectorParam) {
            foreach (Product prod in productEnum) {
                if (selectorParam(prod)) {
                    yield return prod;
                }
            }
        }
    }
}