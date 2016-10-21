using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using FROST.Utility;

namespace FROST.WeixinQYH.AdvancedAPI {
    public class MessageApi {
        /// <summary>
        /// POST发送消息的URL
        /// </summary>
        protected static string PostUrl = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=";
        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="toUser">成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送</param>
        /// <param name="toParty">部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="toTag">标签ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="agentId">企业应用的id，整型。可在应用的设置页面查看</param>
        /// <param name="contEnt">消息内容，最长不超过2048个字节，注意：主页型应用推送的文本消息在微信端最多只显示20个字（包含中英文）</param>
        /// <param name="saFe">	表示是否是保密消息，0表示否，1表示是，默认0</param>
        /// <returns></returns>
        public static PostMessageResult MessageSendText(string accessToken, string toUser, string toParty, string toTag, int agentId, string contEnt, int saFe = 0) {
            var data = new {
                touser = toUser,
                topart = toParty,
                totag = toTag,
                msgtype = "text",
                agentid = agentId,
                text = new {
                    content = contEnt
                },
                safe = saFe
            };
            return JsonConvert.DeserializeObject<PostMessageResult>(
                General.CurlByDotNet(PostUrl, CurlMethod.POST, JsonConvert.SerializeObject(data)));
        }
        /// <summary>
        /// 发送图片消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="toUser">成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送</param>
        /// <param name="toParty">部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="toTag">标签ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="agentId">企业应用的id，整型。可在应用的设置页面查看</param>
        /// <param name="media_ID">图片媒体文件id，可以调用上传临时素材或者永久素材接口获取,永久素材media_id必须由发消息的应用创建</param>
        /// <param name="saFe">	表示是否是保密消息，0表示否，1表示是，默认0</param>
        /// <returns></returns>
        public static PostMessageResult MessageSendImage(string accessToken, string toUser, string toParty, string toTag, int agentId, string media_ID, int saFe = 0) {
            var data = new {
                touser = toUser,
                toparty = toParty,
                totag = toTag,
                msgtype = "image",
                agentid = agentId,
                image = new {
                    media_id = media_ID
                },
                safe = saFe
            };
            return JsonConvert.DeserializeObject<PostMessageResult>(
                General.CurlByDotNet(PostUrl, CurlMethod.POST, JsonConvert.SerializeObject(data)));
        }
        /// <summary>
        /// 发送语音消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="toUser">成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送</param>
        /// <param name="toParty">部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="toTag">标签ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="agentId">企业应用的id，整型。可在应用的设置页面查看</param>
        /// <param name="media_ID">语音文件id，可以调用上传临时素材或者永久素材接口获取</param>
        /// <param name="saFe">	表示是否是保密消息，0表示否，1表示是，默认0</param>
        /// <returns></returns>
        public static PostMessageResult MessageSendVoice(string accessToken, string toUser, string toParty, string toTag, int agentId, string media_ID, int saFe = 0) {
            var data = new {
                touser = toUser,
                toparty = toParty,
                totag = toTag,
                msgtype = "voice",
                agentid = agentId,
                voice = new {
                    media_id = media_ID
                },
                safe = saFe
            };
            return JsonConvert.DeserializeObject<PostMessageResult>(
                    General.CurlByDotNet(PostUrl, CurlMethod.POST, JsonConvert.SerializeObject(data)));
        }
        /// <summary>
        /// 发送视频消息
        /// </summary>
        /// <param name="toUser">成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送</param>
        /// <param name="toParty">部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="toTag">标签ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="agentId">企业应用的id，整型。可在应用的设置页面查看</param>
        /// <param name="media_ID">视频媒体文件id，可以调用上传临时素材或者永久素材接口获取</param>
        /// <param name="vTitle">视频消息的标题，不超过128个字节，超过会自动截断</param>
        /// <param name="vDescription">视频消息的描述，不超过512个字节，超过会自动截断</param>
        /// <param name="saFe">表示是否是保密消息，0表示否，1表示是，默认0</param>
        /// <returns>PostMessageResult</returns>
        public static PostMessageResult MessageSendVideo(string accessToken, string toUser, string toParty, string toTag, int agentId, string media_ID, string vTitle,string vDescription,int saFe = 0) {
            var data = new {
                touser = toUser,
                toparty = toParty,
                totag = toTag,
                msgtype = "video",
                agentid = agentId,
                video = new {
                    media_id = media_ID,
                    title = vTitle,
                    description = vDescription
                },
                safe = saFe
            };
            return JsonConvert.DeserializeObject<PostMessageResult>(
                    General.CurlByDotNet(PostUrl, CurlMethod.POST, JsonConvert.SerializeObject(data)));
        }
        /// <summary>
        /// 发送文件消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="toUser">成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送</param>
        /// <param name="toParty">部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="toTag">标签ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="agentId">企业应用的id，整型。可在应用的设置页面查看</param>
        /// <param name="media_ID">媒体文件id，可以调用上传临时素材或者永久素材接口获取</param>
        /// <param name="saFe">	表示是否是保密消息，0表示否，1表示是，默认0</param>
        /// <returns></returns>
        public static PostMessageResult MessageSendFile(string accessToken, string toUser, string toParty, string toTag, int agentId, string media_ID, int saFe = 0) {
            var data = new {
                touser = toUser,
                toparty = toParty,
                totag = toTag,
                msgtype = "file",
                agentid = agentId,
                file = new {
                    media_id = media_ID
                },
                safe = saFe
            };
            return JsonConvert.DeserializeObject<PostMessageResult>(
                    General.CurlByDotNet(PostUrl, CurlMethod.POST, JsonConvert.SerializeObject(data)));
        }
        /// <summary>
        /// 发送图文消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="toUser">成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送</param>
        /// <param name="toParty">部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="toTag">标签ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="agentId">企业应用的id，整型。可在应用的设置页面查看</param>
        /// <param name="media_ID">素材资源标识ID，通过上传永久图文素材接口获得。注：必须是在该agent下创建的。</param>
        /// <param name="saFe">	表示是否是保密消息，0表示否，1表示是，默认0</param>
        /// <returns></returns>
        public static PostMessageResult MessageSendMPNews(string accessToken, string toUser, string toParty, string toTag, int agentId, string media_ID, int saFe = 0) {
            var data = new {
                touser = toUser,
                toparty = toParty,
                totag = toTag,
                msgtype = "mpnews",
                agentid = agentId,
                mpnews = new {
                    media_id = media_ID
                },
                safe = saFe
            };
            return JsonConvert.DeserializeObject<PostMessageResult>(
                    General.CurlByDotNet(PostUrl, CurlMethod.POST, JsonConvert.SerializeObject(data)));
        }

    }
}
