using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FROST.WeixinQYH {
    /// <summary>
    /// 创建成员
    /// </summary>
    public class CreateMemberResult {
        /// <summary>
        /// 【是】成员UserID。对应管理端的帐号，企业内必须唯一。不区分大小写，长度为1~64个字节
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 【是】成员名称。长度为1~64个字节
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 【是】成员所属部门id列表,不超过20个
        /// </summary>
        public int[] department { get; set; }
        /// <summary>
        /// 职位信息。长度为0~64个字节
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// 手机号码。企业内必须唯一，mobile/weixinid/email三者不能同时为空
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 性别。1表示男性，2表示女性
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 邮箱。长度为0~64个字节。企业内必须唯一
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 微信号。企业内必须唯一。（注意：是微信号，不是微信的名字）
        /// </summary>
        public string weixinid { get; set; }
        /// <summary>
        /// 成员头像的mediaid，通过多媒体接口上传图片获得的mediaid
        /// </summary>
        public string avatar_mediaid { get; set; }
        /// <summary>
        /// 扩展属性。扩展属性需要在WEB管理端创建后才生效，否则忽略未知属性的赋值
        /// </summary>
        public Extattr extattr { get; set; }
    }
    /// <summary>
    /// 扩展属性集合，适用（创建、更新、获取成员、获取成员（详情））
    /// </summary>
    public class Extattr {
        public Attr[] attrs { get; set; }
    }
    /// <summary>
    /// 扩展属性实体，适用（创建、更新、获取成员、获取成员（详情））
    /// </summary>
    public class Attr {
        public string name { get; set; }
        public string value { get; set; }
    }
    /// <summary>
    /// 返回结果，适用于（创建、更新、删除、批量删除）
    /// </summary>
    public class MemberResult {
        /// <summary>
        /// 返回0表示成功
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 返回结果包括（created、updated、deleted
        /// </summary>
        public string errmsg { get; set; }
    }
    /// <summary>
    /// 更新成员
    /// </summary>
    public class UpdateMemberResult {
        /// <summary>
        /// 【是】成员UserID。对应管理端的帐号，企业内必须唯一。不区分大小写，长度为1~64个字节
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 【是】成员名称。长度为1~64个字节
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 【是】成员所属部门id列表,不超过20个
        /// </summary>
        public int[] department { get; set; }
        /// <summary>
        /// 职位信息。长度为0~64个字节
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// 手机号码。企业内必须唯一，mobile/weixinid/email三者不能同时为空
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 性别。1表示男性，2表示女性
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 邮箱。长度为0~64个字节。企业内必须唯一
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 微信号。企业内必须唯一。（注意：是微信号，不是微信的名字）
        /// </summary>
        public string weixinid { get; set; }
        /// <summary>
        /// 启用/禁用成员。1表示启用成员，0表示禁用成员
        /// </summary>
        public int enable { get; set; }
        /// <summary>
        /// 成员头像的mediaid，通过多媒体接口上传图片获得的mediaid
        /// </summary>
        public string avatar_mediaid { get; set; }
        /// <summary>
        /// 扩展属性。扩展属性需要在WEB管理端创建后才生效，否则忽略未知属性的赋值
        /// </summary>
        public Extattr extattr { get; set; }
    }
    /// <summary>
    /// 批量删除成员
    /// </summary>
    public class BatchDeleteMemberResult {
        /// <summary>
        /// 成员UserID列表。对应管理端的帐号。（最多支持200个）
        /// </summary>
        public string[] useridlist { get; set; }
    }
    /// <summary>
    /// 获取成员（单个成员）
    /// </summary>
    public class MemberInfoResult {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        /// <summary>
        /// 成员UserID。对应管理端的帐号
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 成员名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 成员所属部门id列表
        /// </summary>
        public int[] department { get; set; }
        /// <summary>
        /// 职位信息
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 性别。0表示未定义，1表示男性，2表示女性
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        public string weixinid { get; set; }
        /// <summary>
        /// 头像url。注：如果要获取小图将url最后的"/0"改成"/64"即可
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 关注状态: 1=已关注，2=已禁用，4=未关注
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 扩展属性
        /// </summary>
        public Extattr extattr { get; set; }
    }
    /// <summary>
    /// 获取部门成员（仅USERID、姓名、部门）
    /// </summary>
    public class MemberSimpleListResult {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        /// <summary>
        /// 成员列表
        /// </summary>
        public UserlistSimple[] userlist { get; set; }
    }
    /// <summary>
    /// 成员列表
    /// </summary>
    public class UserlistSimple {
        /// <summary>
        /// 成员UserID。对应管理端的帐号
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 成员名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 成员所属部门
        /// </summary>
        public int[] department { get; set; }
    }
    /// <summary>
    /// 获取部门成员(详情)
    /// </summary>
    public class MemberComplexResult {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public UserlistComplex[] userlist { get; set; }
    }
    /// <summary>
    /// 成员列表（详情）
    /// </summary>
    public class UserlistComplex {
        /// <summary>
        /// 成员UserID。对应管理端的帐号
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 成员名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 成员所属部门id列表
        /// </summary>
        public int[] department { get; set; }
        /// <summary>
        /// 职位信息
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 	性别。0表示未定义，1表示男性，2表示女性
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 	邮箱
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        public string weixinid { get; set; }
        /// <summary>
        /// 头像url。注：如果要获取小图将url最后的"/0"改成"/64"即可
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 关注状态: 1=已关注，2=已冻结，4=未关注
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 扩展属性
        /// </summary>
        public Extattr extattr { get; set; }
    }
}
