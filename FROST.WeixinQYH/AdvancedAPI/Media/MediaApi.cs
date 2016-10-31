/**
 *
 * 说明：
 * 作者：sfrost
 * 最后更新：
 *      2
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FROST.Utility;
using Newtonsoft.Json;

namespace FROST.WeixinQYH{
    public class MediaApi {
        public static GetMaterialByMediaId(string access_token,string media_id) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/material/get?access_token=" + access_token + "&media_id=" + media_id;

        }
        /// <summary>
        /// 获取当前管理组指定类型的素材列表（多媒体、图文素材列表在一起）。
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="mlp"></param>
        /// <returns></returns>
        public static MaterialListResult GetMaterialList(string access_token,MaterialListPost mlp) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/material/batchget?access_token=" + access_token;
            return JsonConvert.DeserializeObject<MaterialListResult>(
                General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(mlp)));
        }
        /// <summary>
        /// 本接口可以获取当前管理组的素材总数以及每种类型素材的数目。
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns>MaterialCountResult</returns>
        public static MaterialCountResult  GetMaterialCount(string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/material/get_count?access_token=" + access_token;
            return JsonConvert.DeserializeObject<MaterialCountResult>(
                General.CurlByDotNet(url, CurlMethod.GET));
        }
    }
}
