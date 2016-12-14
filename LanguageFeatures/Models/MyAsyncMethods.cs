using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models {
    public class MyAsyncMethods {
        public static Task<long?> GetPageLength() {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http://www.baidu.com");
            //在等待HTTP请求完成期间，可以在这里做其它事情
            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) => {
                return antecedent.Result.Content.Headers.ContentLength;
            });
        }
        public async static Task<long?> GetPageLength2() {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://www.weizhi12.com");
            //在等待HTTP请求完成期间，可以在这里做其它事情
            return httpMessage.Content.Headers.ContentLength;
        }
    }
}