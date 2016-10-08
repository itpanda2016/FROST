using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FROST.Utility {
    public class MD5Provider {
        /// <summary>
        /// 字符串MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Hash(string str) {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            MD5 md5 = MD5.Create();
            byte[] source = Encoding.Unicode.GetBytes(str);
            byte[] result = md5.ComputeHash(source);
            StringBuilder buffer = new StringBuilder(result.Length);
            for (int i = 0; i < result.Length; i++) {
                buffer.Append(result[i].ToString("x"));
            }
            return buffer.ToString();
        }
    }
}
