using System.Data;
using System.Data.Odbc;
using System.Configuration;

namespace FROST.Utility {
    /// <summary>
    /// 使用对象：
    ///     20161025：HANADB
    ///         1、使用前请安装相应的数据库驱动。连接字符串：DRIVER={HDBODBC32}; UID=;PWD=;SERVERNODE=IP:PORT
    ///         2、执行命令时需加上数据表：OA.table1
    ///         2、自定义表（@），需加上双引号：OA."@table1"
    ///                     
    /// </summary>
    public class OdbcDbHelper {
        /// <summary>
        /// 连接字符串，ConfigurationManager.ConnectionStrings["Odbc"]
        /// </summary>
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["Odbc"].ToString();
        /// <summary>
        /// 执行SQL命令，返回DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="commandType">CommandType，默认Text</param>
        /// <param name="oparas">OdbcParameter[]</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string strSql, CommandType commandType = CommandType.Text, OdbcParameter[] oparas = null) {
            DataTable dt = new DataTable();
            using (OdbcDataAdapter oda = new OdbcDataAdapter(strSql, connStr)) {
                if (oparas != null)
                    oda.SelectCommand.Parameters.AddRange(oparas);
                oda.SelectCommand.CommandType = commandType;
                oda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }

        /// <summary>
        /// 执行SQL命令，返回OdbcDataReader
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="commandType">CommandType，默认Text</param>
        /// <param name="oparas">OdbcParameter[]</param>
        /// <returns>OdbcDataReader</returns>
        public static OdbcDataReader ExecuteReader(string strSql, CommandType commandType = CommandType.Text, OdbcParameter[] oparas = null) {
            using (OdbcConnection oconn = new OdbcConnection(connStr)) {
                if (oconn.State != ConnectionState.Open)
                    oconn.Open();
                using (OdbcCommand ocmd = new OdbcCommand(strSql, oconn)) {
                    if (oparas != null) {
                        ocmd.Parameters.AddRange(oparas);
                    }
                    ocmd.CommandType = commandType;
                    return ocmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
        }

        /// <summary>
        /// 执行SQL命令，返回结果集中第一行的第一列，或 null 引用（如果结果集为空）。
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="commandType">CommandType，默认Text</param>
        /// <param name="oparas">OdbcParameter[]</param>
        /// <returns>object，结果集中第一行的第一列，或 null 引用（如果结果集为空）。</returns>
        public static object ExecuteScalar(string strSql, CommandType commandType = CommandType.Text, OdbcParameter[] oparas = null) {
            using (OdbcConnection oconn = new OdbcConnection(connStr)) {
                if (oconn.State != ConnectionState.Open)
                    oconn.Open();
                using (OdbcCommand ocmd = new OdbcCommand(strSql, oconn)) {
                    if (oparas != null)
                        ocmd.Parameters.AddRange(oparas);
                    ocmd.CommandType = commandType;
                    return ocmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 执行SQL命令，返回受影响的行数。对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="commandType">CommandType</param>
        /// <param name="oparas">OdbcParameter[]</param>
        /// <returns>对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。</returns>
        public static int ExecuteNonQuery(string strSql, CommandType commandType = CommandType.Text, OdbcParameter[] oparas = null) {
            using (OdbcConnection oconn = new OdbcConnection(connStr)) {
                if (oconn.State != ConnectionState.Open)
                    oconn.Open();
                using (OdbcCommand ocmd = new OdbcCommand(strSql, oconn)) {
                    if (oparas != null)
                        ocmd.Parameters.AddRange(oparas);
                    return ocmd.ExecuteNonQuery();
                }
            }
           
        }
    }
}
