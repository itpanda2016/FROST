using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FROST.WeixinQYH {
    /// <summary>
    /// 标签项目（创建、更新）
    /// </summary>
    public class TagItem {
        /// <summary>
        /// 【是】标签名称，长度限制为32个字（汉字或英文字母），标签名不可与其他标签重名。
        /// </summary>
        public string tagname { set; get; }
        /// <summary>
        /// 标签id，整型，指定此参数时新增的标签会生成对应的标签id，不指定时则以目前最大的id自增。
        /// </summary>
        public int tagid { set; get; }
    }
    /// <summary>
    /// 创建标签返回结果
    /// </summary>
    public class CreateTagResult {
        /// <summary>
        /// 成功时返回0
        /// </summary>
        public int errcode { set; get; }
        /// <summary>
        /// 成功时返回created
        /// </summary>
        public string errmsg { set; get; }
        /// <summary>
        /// 成功时返回标签ID
        /// </summary>
        public string tagid { set; get; }
    }
    /// <summary>
    /// 标签返回结果（更新、删除、增加（删除）标签成员[成功、当包含userid/partylist全部非法时返回]）
    /// </summary>
    public class TagResult {
        /// <summary>
        /// 成功时为0、40070{当包含userid/partylist全部非法时返回[增加标签成员时]、40031（删除标签成员时全部非法）}
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 返回（updated、deleted、OK[增加标签成员时]、all list invalid{当包含userid/partylist全部非法时返回[增加（删除）标签成员时]}）
        /// </summary>
        public string errmsg { get; set; }
    }
    /// <summary>
    /// 获取标签成员返回结果
    /// </summary>
    public class TagMemberListResult {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        /// <summary>
        /// 	成员列表
        /// </summary>
        public Userlist[] userlist { get; set; }
        /// <summary>
        /// 	部门列表
        /// </summary>
        public int[] partylist { get; set; }
    }
    /// <summary>
    /// 成员列表
    /// </summary>
    public class Userlist {
        /// <summary>
        /// 	成员UserID
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 	成员姓名
        /// </summary>
        public string name { get; set; }
    }
    /// <summary>
    /// 增加标签成员（请求实体）
    /// </summary>
    public class TagUserAdd {
        /// <summary>
        /// 【是】标签ID
        /// </summary>
        public string tagid { get; set; }
        /// <summary>
        /// 企业成员ID列表，注意：userlist、partylist不能同时为空，单次请求长度不超过1000
        /// </summary>
        public string[] userlist { get; set; }
        /// <summary>
        /// 企业部门ID列表，注意：userlist、partylist不能同时为空，单次请求长度不超过100
        /// </summary>
        public int[] partylist { get; set; }
    }
    /// <summary>
    /// 增加（删除）标签成员（部分userid、partylist非法，则返回）
    /// </summary>
    public class TagUserAddResult {
        public int errcode { get; set; }
        /// <summary>
        /// invalid userlist and partylist faild、invalid userlist faild、invalid partylist faild
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        /// 不在权限内的成员ID列表，以“|”分隔
        /// </summary>
        public string invalidlist { get; set; }
        /// <summary>
        /// 不在权限内的部门ID列表
        /// </summary>
        public int[] invalidparty { get; set; }
    }
    /// <summary>
    /// 删除标签成员（请求实体）
    /// </summary>
    public class TagUserDelete {
        public string tagid { get; set; }
        public string[] userlist { get; set; }
        public int[] partylist { get; set; }
    }
    /// <summary>
    /// 获取标签列表
    /// </summary>
    public class TagListResult {
        /// <summary>
        /// 0
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// OK
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        /// 标签列表
        /// </summary>
        public TagItem[] taglist { get; set; }
    }
    

}
