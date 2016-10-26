using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Configuration;

namespace FROST.Utility {
    /// <summary>
    /// 使用对象：
    ///     20161025：HANADB
    /// </summary>
    public class OdbcDbHelper {
        //连接字符串
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["Odbc"].ToString();
        /// <summary>
        /// 执行SQL命令，返回DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="oparas"></param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string strSql,OdbcParameter[] oparas = null) {
            DataTable dt = new DataTable();
            using (OdbcDataAdapter oda = new OdbcDataAdapter(strSql, connStr)) {
                if (oparas != null)
                    oda.SelectCommand.Parameters.AddRange(oparas);
                oda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }
    }
}
