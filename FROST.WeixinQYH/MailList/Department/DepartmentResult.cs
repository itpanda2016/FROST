using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FROST.WeixinQYH {
    public class DepartmentResult {
        /// <summary>
        /// 创建部门（适用获取列表时的子对象List）
        /// </summary>
        public class CreateDepartment {
            /// <summary>
            /// 【是】部门名称。长度限制为32个字（汉字或英文字母），字符不能包括\:*?"<>｜
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 【是】父亲部门id。根部门id为1
            /// </summary>
            public int parentid { get; set; }
            /// <summary>
            /// 【否】在父部门中的次序值。order值小的排序靠前。
            /// </summary>
            public int order { get; set; }
            /// <summary>
            /// 【否】部门id，整型。指定时必须大于1，不指定时则自动生成
            /// </summary>
            public int id { get; set; }
        }
        /// <summary>
        /// 返回结果（创建部门）
        /// </summary>
        public class CreateDepartmentReturn {
            /// <summary>
            /// 返回码
            /// </summary>
            public int errcode { get; set; }
            /// <summary>
            /// 对返回码的文本描述内容
            /// </summary>
            public string errmsg { get; set; }
            /// <summary>
            /// 创建的部门id
            /// </summary>
            public int id { get; set; }
        }
        /// <summary>
        /// 更新部门
        /// </summary>
        public class UpdateDepartment {
            /// <summary>
            /// 【是】部门id
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 【否】更新的部门名称。长度限制为32个字（汉字或英文字母），字符不能包括\:*?"<>｜。修改部门名称时指定该参数
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 【否】父亲部门id。根部门id为1
            /// </summary>
            public int parentid { get; set; }
            /// <summary>
            /// 【否】在父部门中的次序值。order值小的排序靠前。
            /// </summary>
            public int order { get; set; }
        }

        /// <summary>
        /// 返回结果（适用于更新、删除部门）
        /// </summary>
        public class DepartmentReturn {
            /// <summary>
            /// 更新成功时为0
            /// </summary>
            public int errcode { get; set; }
            /// <summary>
            /// 操作成功时，返回：updated、deleted
            /// </summary>
            public string errmsg { get; set; }
        }
        public class DepartmentList {
            /// <summary>
            /// 错误码，为0表示没报错
            /// </summary>
            public int errcode { get; set; }
            /// <summary>
            /// 错误信息
            /// </summary>
            public string errmsg { get; set; }
            /// <summary>
            /// 部门列表
            /// </summary>
            public List<CreateDepartment> department { get; set; }
        }
    }
}
