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
