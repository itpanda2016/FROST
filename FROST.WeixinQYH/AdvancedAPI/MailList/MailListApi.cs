/**
 *
 * 说明：通讯录接口功能，包括部门、标签、成员
 * 作者：sfrost
 * 最后更新：
 *      20161031，添加注释说明
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FROST.Utility;

namespace FROST.WeixinQYH {
    public class MailListApi {
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns>TagListResult</returns>
        public static TagListResult TagList(string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/list?access_token=" + access_token;
            return JsonConvert.DeserializeObject<TagListResult>(General.CurlByDotNet(url, CurlMethod.GET));
        }
        /// <summary>
        /// 删除标签成员（返回对象并未判断【部分userid、partylist非法】的情况），要么正确，要么全错（报错）
        /// </summary>
        /// <param name="tma">TagUserAdd</param>
        /// <param name="access_token"></param>
        /// <returns>TagResult</returns>
        public static TagResult TagDeleteMember(TagUserDelete tmd,string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/deltagusers?access_token=" + access_token;
            return JsonConvert.DeserializeObject<TagResult>(
                General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(tmd)));
        }
        /// <summary>
        /// 增加标签成员（返回对象并未判断【部分userid、partylist非法】的情况），要么正确，要么全错（报错）
        /// </summary>
        /// <param name="tma">TagUserAdd</param>
        /// <param name="access_token"></param>
        /// <returns>TagResult</returns>
        public static TagResult TagAddMember(TagUserAdd tma,string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/addtagusers?access_token=" + access_token;
            return JsonConvert.DeserializeObject<TagResult>(
                General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(tma)));
        }
        /// <summary>
        /// 获取标签成员
        /// </summary>
        /// <param name="tagID">标签ID</param>
        /// <param name="access_token"></param>
        /// <returns>TagMemberListResult</returns>
        public static TagMemberListResult GetMemberByTag(int tagID,string access_token) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/tag/get?access_token={0}&tagid={1}", access_token, tagID);
            return JsonConvert.DeserializeObject<TagMemberListResult>(
                General.CurlByDotNet(url, CurlMethod.GET));
        }
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="tagID"></param>
        /// <param name="access_token"></param>
        /// <returns>TagResult</returns>
        public static TagResult DeleteTag(int tagID,string access_token) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/tag/delete?access_token={0}&tagid={1}", access_token, tagID);
            return JsonConvert.DeserializeObject<TagResult>(General.CurlByDotNet(url, CurlMethod.GET));
        }
        /// <summary>
        /// 更新标签名字
        /// </summary>
        /// <param name="ti">TagItem</param>
        /// <param name="access_token"></param>
        /// <returns>TagResult</returns>
        public static TagResult UpdateTagName(TagItem ti,string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/update?access_token=" + access_token;
            return JsonConvert.DeserializeObject<TagResult>(
                General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(ti)));
        }
        /// <summary>
        /// 创建标签（创建的标签属于管理组，默认为加锁状态。加锁状态下只有本管理组才可以增删成员，解锁状态下其它管理组也可以增删成员）
        /// </summary>
        /// <param name="ti">TagItem</param>
        /// <param name="access_token"></param>
        /// <returns>CreateTagResult</returns>
        public static CreateTagResult CreateTag(TagItem ti,string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/create?access_token=" + access_token;
            return JsonConvert.DeserializeObject<CreateTagResult>(
                General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(ti)));
        }
        /// <summary>
        /// 获取成员列表（详细信息）
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="departmentID">获取的部门id</param>
        /// <param name="fetchChild">1/0：是否递归获取子部门下面的成员</param>
        /// <param name="status">0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加，未填写则默认为4</param>
        /// <returns>MemberComplexResult</returns>
        public static MemberComplexResult GetMemberComplexList(string access_token, int departmentID, int fetchChild = 0, int status = 0) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/list?access_token={0}&department_id={1}&fetch_child={2}&status={3}",
                access_token, departmentID, fetchChild, status);
            return JsonConvert.DeserializeObject<MemberComplexResult>(
                General.CurlByDotNet(url, CurlMethod.GET));
        }
        /// <summary>
        /// 获取成员列表（仅USERID、姓名、部门）
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="departmentID">获取的部门id</param>
        /// <param name="fetchChild">1/0：是否递归获取子部门下面的成员</param>
        /// <param name="status">0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加，未填写则默认为4</param>
        /// <returns>MemberSimpleListResult</returns>
        public static MemberSimpleListResult GetMemberSimpleList(string access_token,int departmentID,int fetchChild = 0,int status = 0) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/simplelist?access_token={0}&department_id={1}&fetch_child={2}&status={3}",
                access_token, departmentID, fetchChild, status);
            return JsonConvert.DeserializeObject<MemberSimpleListResult>(
                General.CurlByDotNet(url, CurlMethod.GET));
        }
        /// <summary>
        /// 获取成员详细（单个、详细信息）
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static MemberInfoResult GetMember(string userID,string access_token) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}", access_token, userID);
            return JsonConvert.DeserializeObject<MemberInfoResult>(
                General.CurlByDotNet(url, CurlMethod.GET));
        }
        /// <summary>
        /// 批量删除成员
        /// </summary>
        /// <param name="bdmr">BatchDeleteMemberResult对象</param>
        /// <param name="access_token"></param>
        /// <returns>MemberResult</returns>
        public static MemberResult BatchMember(BatchDeleteMemberResult bdmr,string access_token) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/batchdelete?access_token={0}", access_token);
            return JsonConvert.DeserializeObject<MemberResult>(
                General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(bdmr)));
        }
        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="access_token"></param>
        /// <returns>MemberResult</returns>
        public static MemberResult DeleteMember(string userID, string access_token) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/delete?access_token={0}&userid={1}", access_token, userID);
            return JsonConvert.DeserializeObject<MemberResult>(
                General.CurlByDotNet(url, CurlMethod.GET));
        }
        /// <summary>
        /// 更新成员
        /// </summary>
        /// <param name="umr">UpdateMemberResult对象</param>
        /// <param name="access_token"></param>
        /// <returns>MemberResult</returns>
        public static MemberResult UpdateMember(UpdateMemberResult umr,string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token=" + access_token;
            return JsonConvert.DeserializeObject<MemberResult>(
                General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(umr)));
        }
        /// <summary>
        /// 创建成员
        /// </summary>
        /// <param name="cmr">CreateMemberResult对象</param>
        /// <param name="access_token"></param>
        /// <returns>MemberResult</returns>
        public static MemberResult CreateMember(CreateMemberResult cmr,string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/create?access_token=" + access_token;
            return JsonConvert.DeserializeObject<MemberResult>(
                General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(cmr)));
        }
        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="cp">DepartmentResult.CreateDepartment</param>
        /// <param name="access_token"></param>
        /// <returns>DepartmentResult.CreateDepartmentReturn</returns>
        public static DepartmentResult.CreateDepartmentReturn CreateDepartment(DepartmentResult.CreateDepartment cp, string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token=" + access_token;
            return JsonConvert.DeserializeObject<DepartmentResult.CreateDepartmentReturn>(General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(cp)));
        }
        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="ud">DepartmentResult.UpdateDepartment</param>
        /// <param name="access_token"></param>
        /// <returns>DepartmentResult.DepartmentReturn</returns>
        public static DepartmentResult.DepartmentReturn UpdateDepartment(DepartmentResult.UpdateDepartment ud, string access_token) {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/department/update?access_token=" + access_token;
            return JsonConvert.DeserializeObject<DepartmentResult.DepartmentReturn>(
                General.CurlByDotNet(url, CurlMethod.POST, JsonConvert.SerializeObject(ud))
                );
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id">部门ID</param>
        /// <param name="access_token"></param>
        /// <returns>DepartmentResult.DepartmentReturn</returns>
        public static DepartmentResult.DepartmentReturn DeleteDepartment(int id, string access_token) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/department/delete?access_token={0}&id={1}",
                access_token, id);
            return JsonConvert.DeserializeObject<DepartmentResult.DepartmentReturn>(
                General.CurlByDotNet(url, CurlMethod.GET));
        }
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="id">部门id。获取指定部门及其下的子部门</param>
        /// <param name="access_token">调用接口凭证</param>
        /// <returns>DepartmentResult.DepartmentList</returns>
        public static DepartmentResult.DepartmentList GetDepartmentList(int id, string access_token) {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={0}&id={1}", access_token, id);
            return JsonConvert.DeserializeObject<DepartmentResult.DepartmentList>(
                General.CurlByDotNet(url, CurlMethod.GET));
        }
    }
}
