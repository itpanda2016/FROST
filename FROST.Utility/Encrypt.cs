﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FROST.Utility {
    /// <summary>
    /// 数据加密/解密
    /// </summary>
    public class Encrypt {
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="codeName">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string EncodeBase64(Encoding encode, string source) {
            string enstring = "";
            byte[] bytes = encode.GetBytes(source);
            try {
                enstring = Convert.ToBase64String(bytes);
            }
            catch {
                enstring = source;
            }
            return enstring;
        }
        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string EncodeBase64(string source) {
            return EncodeBase64(Encoding.UTF8, source);
        }
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="codeName">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(Encoding encode, string result) {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try {
                decode = encode.GetString(bytes);
            }
            catch {
                decode = result;
            }
            return decode;
        }
        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(string result) {
            return DecodeBase64(Encoding.UTF8, result);
        }
        /// <summary>
        /// SHA1加密（微信可用，20171020）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SHA1(string str) {
            System.Security.Cryptography.SHA1 algorithm = System.Security.Cryptography.SHA1.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(str));
            string sh1 = "";
            for (int i = 0; i < data.Length; i++) {
                sh1 += data[i].ToString("x2").ToUpperInvariant();
            }
            return sh1;
        }

        /// <summary>
        /// 字符串MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Hash(string str) {
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