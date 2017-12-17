/**
 * 创建时间：20161028
 * 作者：sfrost
 * 适用Oracle
 *      1、安装OracleXE112_Win32客户端
 *      2、Provider=OraOLEDB.Oracle.1;Data Source=IP:PORT/SERVERNAME;Password=;User ID=
 *      3、报错：“未在本地计算机上注册 oraoledb.oracle.1”等信息，需手工注册OracleXE安装目录下的OraOledb11.dll文件（regsvr32）
 * 适用于Mysql
 *      1、下载mysql for visualstudio驱动，引用mysql.data.dll
 *      2、https://dev.mysql.com/downloads/windows/visualstudio/
 *      
 * */
 
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace FROST.Utility {
    public class OleDbHelper {
        /// <summary>
        /// 连接字符串，ConfigurationManager.ConnectionStrings["Odbc"]
        /// </summary>
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["OleDb"].ToString();
        /// <summary>
        /// 执行SQL命令，返回DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="commandType">CommandType，默认Text</param>
        /// <param name="oparas">OleDbParameter[]</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string strSql, CommandType commandType = CommandType.Text, OleDbParameter[] oparas = null) {
            DataTable dt = new DataTable();
            using (OleDbDataAdapter oleda = new OleDbDataAdapter(strSql, connStr)) {
                if (oparas != null)
                    oleda.SelectCommand.Parameters.AddRange(oparas);
                oleda.SelectCommand.CommandType = commandType;
                oleda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }

        /// <summary>
        /// 执行SQL命令，返回OleDbDataReader
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="commandType">CommandType，默认Text</param>
        /// <param name="oparas">OleDbParameter[]</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(string strSql, CommandType commandType = CommandType.Text, OleDbParameter[] oparas = null) {
            using (OleDbConnection oleConn = new OleDbConnection(connStr)) {
                if (oleConn.State != ConnectionState.Open)
                    oleConn.Open();
                using (OleDbCommand oleCmd = new OleDbCommand(strSql, oleConn)) {
                    if (oparas != null) {
                        oleCmd.Parameters.AddRange(oparas);
                    }
                    oleCmd.CommandType = commandType;
                    return oleCmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
        }

        /// <summary>
        /// 执行SQL命令，返回结果集中第一行的第一列，或 null 引用（如果结果集为空）。
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="commandType">CommandType，默认Text</param>
        /// <param name="oparas">OleDbParameter[]</param>
        /// <returns>object，结果集中第一行的第一列，或 null 引用（如果结果集为空）。</returns>
        public static object ExecuteScalar(string strSql, CommandType commandType = CommandType.Text, OleDbParameter[] oparas = null) {
            using (OleDbConnection oleConn = new OleDbConnection(connStr)) {
                if (oleConn.State != ConnectionState.Open)
                    oleConn.Open();
                using (OleDbCommand oleCmd = new OleDbCommand(strSql, oleConn)) {
                    if (oparas != null)
                        oleCmd.Parameters.AddRange(oparas);
                    oleCmd.CommandType = commandType;
                    return oleCmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 执行SQL命令，返回受影响的行数。对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="commandType">CommandType</param>
        /// <param name="oparas">OleDbParameter[]</param>
        /// <returns>对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。</returns>
        public static int ExecuteNonQuery(string strSql, CommandType commandType = CommandType.Text, OleDbParameter[] oparas = null) {
            using (OleDbConnection oleConn = new OleDbConnection(connStr)) {
                if (oleConn.State != ConnectionState.Open)
                    oleConn.Open();
                using (OleDbCommand oleCmd = new OleDbCommand(strSql, oleConn)) {
                    if (oparas != null)
                        oleCmd.Parameters.AddRange(oparas);
                    return oleCmd.ExecuteNonQuery();
                }
            }

        }
    }
}
