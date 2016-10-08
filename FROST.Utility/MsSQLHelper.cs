using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FROST.Utility {
    /// <summary>
    /// 所有方法都为静态方法、属性
    ///     - 如连接字符串有变动，只需要设置属性：ConnectionString即可
    ///     - 平时执行SQL、存储过程时，只需要配置好语句、参数，调用语句执行并接收返回结果即可。
    /// 版本【v1.1】
    ///     - 增加SqlBulkCopy批量写入表功能
    /// </summary>
    public class MsSQLHelper {
        private static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get { return connString; }
            set { connString = value; }
        }

        /// <summary>
        /// 获取多条记录，存入DataTable
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType, SqlParameter[] parameters) {
            DataTable data = new DataTable();
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = commandType;
            if (parameters != null) {
                foreach (SqlParameter parameter in parameters) {
                    cmd.Parameters.Add(parameter);
                }
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(data);
            return data;
        }
        public static DataTable ExecuteDataTable(string commandText) {
            return ExecuteDataTable(commandText, CommandType.Text, null);
        }
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType) {
            return ExecuteDataTable(commandText, commandType, null);
        }

        /// <summary>
        /// 查询并返回多条记录
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters) {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = commandType;
            if (parameters != null) {
                foreach (SqlParameter parameter in parameters) {
                    cmd.Parameters.Add(parameter);
                }
            }
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static SqlDataReader ExecuteReader(string commandText) {
            return ExecuteReader(commandText, CommandType.Text, null);
        }
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType) {
            return ExecuteReader(commandText, commandType, null);
        }

        /// <summary>
        /// 执行查询，返回结果中的第1行第1列，默认为object，可转为其它类型
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string commandText, CommandType commandType, SqlParameter[] parameters) {
            //object result = null;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(commandText, conn);
            if (parameters != null) {
                foreach (SqlParameter parameter in parameters) {
                    cmd.Parameters.Add(parameter);
                }
            }
            conn.Open();
            return cmd.ExecuteScalar();
        }
        public static object ExecuteScalar(string commandText) {
            return ExecuteScalar(commandText, CommandType.Text, null);
        }
        public static object ExecuteScalar(string commandText, CommandType commandType) {
            return ExecuteScalar(commandText, commandType, null);
        }

        /// <summary>
        /// 执行查询，并返回受影响的行数
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, CommandType cmdType, SqlParameter[] parameters) {
            int count = 0;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            if (parameters != null) {
                //foreach(SqlParameter parameter in parameters)
                //{
                //    cmd.Parameters.Add(parameter);
                //}
                cmd.Parameters.AddRange(parameters);
            }
            conn.Open();
            count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }
        public static int ExecuteNonQuery(string cmdText, CommandType cmdType) {
            return ExecuteNonQuery(cmdText, cmdType, null);
        }
        public static int ExecuteNonQuery(string cmdText) {
            return ExecuteNonQuery(cmdText, CommandType.Text, null);
        }
        /// <summary>
        /// 复制表的方式写入数据记录
        /// </summary>
        /// <param name="destinationTable"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool SqlBulkCopy(string destinationTable, DataTable dt) {
            SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(connString, SqlBulkCopyOptions.UseInternalTransaction);
            sqlbulkcopy.DestinationTableName = destinationTable;
            try {
                sqlbulkcopy.WriteToServer(dt);
            }
            catch {
                return false;
            }
            finally {
                sqlbulkcopy.Close();
            }
            return true;
        }
    }
}
