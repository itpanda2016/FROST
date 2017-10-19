using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

/// <summary>
/// 通用方法
/// </summary>
namespace FROST.Utility {
    /// <summary>
    /// Curl提交数据方式
    /// </summary>
    public enum CurlMethod {
        POST = 0,
        GET = 1
    }
    /// <summary>
    /// 公用核心类
    /// </summary>
    public class General {
        /// <summary>
        /// unix时间转换为datetime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeToTime(string timeStamp) {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        /// <summary>
        /// datetime转换为unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private static int ConvertDateTimeInt(System.DateTime time) {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        /// <summary>
        /// .NET版Curl
        /// </summary>
        /// <param name="uri">URL地址</param>
        /// <param name="method"></param>
        /// <param name="jsonData">数据主体，可为空</param>
        /// <returns></returns>
        public static string CurlByDotNet(string uri, CurlMethod method, string jsonData = null) {
            //HTTPS证书无效处理方式，见SBO的Servicelayer开发DEMO
            Uri codeUrl = new Uri(uri);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(codeUrl);
            webRequest.Method = method.ToString();
            if (jsonData != null) {
                //这儿必须要设置utf8，如果用default就会出问题
                byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
                //webRequest.ContentType = "application/x-www-form-urlencoded";   //接入纷享销客前
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = bytes.Length;
                Stream postData = webRequest.GetRequestStream();
                postData.Write(bytes, 0, bytes.Length);
                postData.Close();
            }
            WebResponse webResponse = webRequest.GetResponse();
            StreamReader srResponse = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
            string retString = srResponse.ReadToEnd();
            return retString;
        }
        
        /// <summary>
        /// 获取农历时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime LunarDate(DateTime date) {
            ChineseLunisolarCalendar clc = new ChineseLunisolarCalendar();
            int year = clc.GetYear(date);
            int month = clc.GetMonth(date);
            int leapMonth = clc.GetLeapMonth(year);
            if (leapMonth > 0 && leapMonth <= month)
                month--;
            return Convert.ToDateTime(string.Format("{0}-{1}-{2}", year, month, clc.GetDayOfMonth(date)));
        }
        /// <summary>
        /// 校验手机号码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool CheckMobilePhone(string phone) {
            if (phone.Length == 11) {
                return Regex.IsMatch(phone, @"13[0123456789]\d{8}|15[0123456789]\d{8}|1[0123456789]\d{8}/");
            }
            return false;
        }
        /// <summary>
        /// 校验邮箱地址
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool CheckMail(string email) {
            if (Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                return true;
            return false;
        }
        /// <summary>
        /// 校验QQ号码
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public static bool CheckQQ(string qq) {
            if (Regex.IsMatch(qq, @"^[1-9]*[1-9][0-9]*$"))
                return true;
            return false;
        }
        /// <summary>
        /// 校验座机号码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool CheckPhone(string phone) {
            if (Regex.IsMatch(phone, @"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$"))
                return true;
            return false;
        }
    }
}
