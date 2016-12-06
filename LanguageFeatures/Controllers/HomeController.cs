using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;
using System.Text;

namespace LanguageFeatures.Controllers {
    public class HomeController : Controller {
        // GET: Home
        public string Index() {
            return "为什么这儿通常不用来使用？";
        }
        public ViewResult AutoProperty() {
            Product myProduct = new Product();
            myProduct.Name = "张三";
            return View("Result", (object)string.Format("该产品的名称为：{0}", myProduct.Name));
        }
        public ViewResult CreateProduct() {
            Product myProduct = new Product {
                ProductID = 100,
                Name = "桌子",
                Description = "可以放电脑的办公桌子",
                Price = 200,
                Category = "办公用品"
            };
            return View("Result", (object)string.Format("{0}的分类是{1}", myProduct.Name, myProduct.Category));
        }
        public ViewResult CreateCollection() {
            string[] stringArray = { "苹果", "香蕉", "梨子" };
            List<int> intList = new List<int> { 1, 2, 3, 4, 5 };
            Dictionary<string, int> myDict = new Dictionary<string, int> {
                {"苹果",3 }, {"香蕉",4 }, {"梨子",5 }
            };
            return View("Result", (object)string.Format("myDict 1:{0}", myDict["苹果"]));
        }
        public ViewResult UseExtension() {
            ShoppingCart cart = new ShoppingCart {
                Products = new List<Product> {
                    new Product {
                        Name = "苹果",Price=3.15m
                    },
                    new Product {Name="香蕉",Price = 4.88m },
                    new Product {Name="梨子",Price = 5 }
                }
            };
            decimal cartTotal = cart.TotalPrices();     //如果在实现该扩展方法的参数加添加了this关键词，一旦使用this 后面的类调用该方法，则不必再传参数
            return View("Result", (object)string.Format("购物车的总金额为：{0:c}", cartTotal));
        }
        public ViewResult UseExtensionEnumerable() {
            IEnumerable<Product> products = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name = "香蕉",Price=33.3323m },
                    new Product {Name="苹果",Price=33m },
                    new Product {Name="梨子",Price = 3m }
                }
            };
            Product[] productArray = {
                new Product {Name="荔枝",Price=133.05m },
                new Product {Name="桃子",Price=99.25m }
            };
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            return View("Result", (object)string.Format("购物车中的总价：{0}；数组中的总价：{1}", cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionEnumerable() {
            IEnumerable<Product> products = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name="苹果",Category="水果",Price=3.9m },
                    new Product {Name="香蕉",Category="水果",Price=4.0m },
                    new Product {Name="白菜",Category="蔬菜",Price=3.5m },
                    new Product {Name="土豆",Category="蔬菜",Price=3.3m }
              }
            };
            decimal total = 0;
            foreach (Product item in products.FilterByCategory("水果")) {
                total += item.Price;
            }
            return View("Result", (object)string.Format("水果总价：{0}", total));
        }

        public ViewResult UseFilterExtensionMethod() {
            IEnumerable<Product> products = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name="苹果",Category="水果",Price=3.9m },
                    new Product {Name="香蕉",Category="水果",Price=4.0m },
                    new Product {Name="葡萄",Category="水果",Price=5.0m },
                    new Product {Name="白菜",Category="蔬菜",Price=3.5m },
                    new Product {Name="土豆",Category="蔬菜",Price=3.3m }
              }
            };
            
            //委托定义方式
            //Func<Product, bool> categoryFilter = delegate (Product prod) {
            //    //return prod.Category == "蔬菜";
            //    return prod.Price > 3.5m;
            //};
            //lambda方式
            //Func<Product, bool> categoryFilter = prod => prod.Price < 3.5m;

            decimal total = 0;
            //更简洁的Lambda方式，是不声明Func的变量了，直接用
            //因为Filter方法的参数，就是扩展给支持IEnumerable接口的对象，并传入Func参数
            foreach (Product prod in products.Filter(prod => prod.Price > 3.9m && prod.Category == "水果")) {
                total += prod.Price;
            }
            return View("Result", (object)string.Format("水果：{0}", total));
        }
        /// <summary>
        /// 创建匿名类型
        /// </summary>
        /// <returns></returns>
        public ViewResult CreateAnonArray() {
            var oddsAndEnds = new[] {
                new {Name = "荔枝",Category = "水果"},
                new {Name = "可口可乐",Category = "饮料" }
            };
            StringBuilder retSB = new StringBuilder();
            foreach (var item in oddsAndEnds) {
                retSB.Append(item.Name + "   ");
            }
            return View("Result", (object)retSB.ToString());
        }
        public ViewResult FindProducts() {
            Product[] products = {
                new Product {Name="苹果",Category="水果",Price=3.9m },
                new Product {Name="香蕉",Category="水果",Price=4.0m },
                new Product {Name="葡萄",Category="水果",Price=5.0m },
                new Product {Name="白菜",Category="蔬菜",Price=3.5m },
                new Product {Name="土豆",Category="蔬菜",Price=3.3m }
            };
            Product[] foundProducts = new Product[3];
            Array.Sort(products, (item1, item2) => {
                return Comparer<decimal>.Default.Compare(item1.Price, item2.Price);
            });
            Array.Copy(products, foundProducts, 3);
            StringBuilder result = new StringBuilder();
            foreach (Product p in foundProducts) {
                result.AppendFormat("Price：{0}   \n\r", p.Price);
            }
            return View("Result", (object)result.ToString());
        }
    }
}