using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FROST.WeixinQYH {
    /// <summary>
    /// 通用返回结果（删除永久素材）
    /// </summary>
    public class MaterialResult {
        public string errcode { get; set; }
        public string errmsg { get; set; }
    }

    /// <summary>
    /// 获取永久素材，图文类消息返回结果
    /// </summary>
    public class MaterialMpNewsResult {
        public string type { get; set; }
        public Mpnews mpnews { get; set; }
    }
    public class Mpnews {
        public Article[] articles { get; set; }
    }
    public class ArticleSimple {
        public string thumb_media_id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string digest { get; set; }
        public string content_source_url { get; set; }
        public int show_cover_pic { get; set; }
        public string content { get; set; }
    }

    /// <summary>
    /// （返回）当前管理组指定类型的素材列表，是详情
    /// </summary>
    public class MaterialListResult {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string type { get; set; }
        /// <summary>
        /// 返回该类型素材列表
        /// </summary>
        public Itemlist[] itemlist { get; set; }
    }
    public class Itemlist {
        /// <summary>
        /// 图文素材的媒体id
        /// </summary>
        public string media_id { get; set; }
        /// <summary>
        /// （图片，文件，视频，音频）此字段不为空
        /// </summary>
        public string filename { get; set; }
        /// <summary>
        /// （永久图文消息素材）此字段不为空
        /// </summary>
        public Content content { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public int update_time { get; set; }
    }
    public class Content {
        /// <summary>
        /// 图文消息，一个图文消息支持1到10个图文
        /// </summary>
        public Article[] articles { get; set; }
    }
    /// <summary>
    /// 图文消息
    /// </summary>
    public class Article {
        /// <summary>
        /// 图文消息缩略图的media_id, 可以在上传多媒体文件接口中获得。此处thumb_media_id即上传接口返回的media_id
        /// </summary>
        public string thumb_media_id { get; set; }
        /// <summary>
        /// 图文消息的标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 	图文消息的作者
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 图文消息的描述
        /// </summary>
        public string digest { get; set; }
        /// <summary>
        /// 图文消息点击“阅读原文”之后的页面链接
        /// </summary>
        public string content_source_url { get; set; }
        /// <summary>
        /// 	是否显示封面，1为显示，0为不显示
        /// </summary>
        public int show_cover_pic { get; set; }
    }

    /// <summary>
    /// （提交）获取当前管理组指定类型的素材列表。
    /// </summary>
    public class MaterialListPost {
        /// <summary>
        /// 素材类型，可以为图文(mpnews)、图片（image）、音频（voice）、视频（video）、文件（file）
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 从该类型素材的该偏移位置开始返回，0表示从第一个素材 返回
        /// </summary>
        public int offset { get; set; }
        /// <summary>
        /// 	返回素材的数量，取值在1到50之间
        /// </summary>
        public int count { get; set; }
    }
    /// <summary>
    /// 返回：获取当前管理组的素材总数以及每种类型素材的数目。
    /// </summary>
    public class MaterialCountResult {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        /// <summary>
        /// 	应用素材总数目
        /// </summary>
        public int total_count { get; set; }
        /// <summary>
        /// 图片素材总数目
        /// </summary>
        public int image_count { get; set; }
        /// <summary>
        /// 	音频素材总数目
        /// </summary>
        public int voice_count { get; set; }
        /// <summary>
        /// 	视频素材总数目
        /// </summary>
        public int video_count { get; set; }
        /// <summary>
        /// 文件素材总数目
        /// </summary>
        public int file_count { get; set; }
        /// <summary>
        /// 	图文素材总数目
        /// </summary>
        public int mpnews_count { get; set; }
    }
}
