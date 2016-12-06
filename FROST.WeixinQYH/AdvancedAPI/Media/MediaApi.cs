/**
 *
 * 说明：获取素材总数、获取素材列表、获取永久素材、删除永久素材
 * 作者：sfrost
 * 最后更新：
 *      
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
        /// <summary>
        /// 获取永久素材（图片、语音、文件、视频素材），返回下载存储的文件名
        /// </summary>
        /// <param name="gmbmi">根据接口GetMaterialByMediaId获取到的字符串</param>
        /// <param name="saveFilePath">下载文件保存的位置</param>
        /// <returns>保存文件名完整路径</returns>
        public static string GetMaterial(string gmbmi,string saveFilePath) {
            string fileName = saveFilePath + "filename";
            return fileName;
        }
        /// <summary>
        /// 获取永久图文素材（实体对象）
        /// </summary>
        /// <param name="gmbmi">根据接口GetMaterialByMediaId获取到的字符串</param>
        /// <returns>MaterialMpNewsResult</returns>
        public static MaterialMpNewsResult GetMaterial(string gmbmi) {
            return JsonConvert.DeserializeObject<MaterialMpNewsResult>(gmbmi);
        }
        /// <summary>
        /// 通过media_id删除上传的图文消息、图片、语音、文件、视频素材。
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <returns></returns>
        public static MaterialResult DeleteMaterial(string access_token,string media_id) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/material/del?access_token="+ access_token + "&media_id=" + media_id;
            return JsonConvert.DeserializeObject<MaterialResult>(
                General.CurlByDotNet(url, CurlMethod.GET));
        }
        /// <summary>
        /// 通过media_id获取上传的图文消息、图片、语音、文件、视频素材（需自己判断string中是否有errcode，并根据图文和其它素材做相应的处理）
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <returns>string</returns>
        public static string GetMaterialByMediaId(string access_token,string media_id) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/material/get?access_token=" + access_token + "&media_id=" + media_id;
            return General.CurlByDotNet(url, CurlMethod.GET);
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
