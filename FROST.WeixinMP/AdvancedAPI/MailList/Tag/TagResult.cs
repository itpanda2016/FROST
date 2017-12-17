using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FROST.WeixinMP {
    public class TagListResult {
        public TagItem[] Tags { get; set; }
    }

    public class TagItem {
        /// <summary>
        /// 标签ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标签下粉丝数
        /// </summary>
        public int Count { get; set; }
    }
}
