using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using FROST.Utility;
using System.Data.OleDb;

namespace TEST {
    public partial class SAPB1 : Form {
        public SAPB1() {
            InitializeComponent();
            
        }
        private volatile DataTable _dtOA = new DataTable();
        private delegate void T();
        private void button1_Click(object sender, EventArgs e) {
            DataTable dt = new DataTable();
            //string sql = "select \"CardCode\",\"CardName\" from TEST01.OCRD";
            string sql = "select * from TEST01.\"@HELLOHANA\"";
            dt = OdbcDbHelper.ExecuteDataTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e) {
            T t = GetOA;
            //t.BeginInvoke(null,null);
            t();
            //MessageBox.Show("绑定结束：" + DateTime.Now);
        }

        private void SAPB1_Load(object sender, EventArgs e) {
            //SAPB1.CheckForIllegalCrossThreadCalls = false;
        }

        private void button3_Click(object sender, EventArgs e) {

        }

        private void GetOA() {
            string connString = ConfigurationManager.ConnectionStrings["OleDb"].ConnectionString;
            OleDbConnection conn = new OleDbConnection();
            //DataGridView dgv3 = new DataGridView();
            try {
                conn.ConnectionString = connString;
                conn.Open();
                string sql = "select * from hrmresource";
                using (OleDbDataAdapter oleDa = new OleDbDataAdapter(sql, conn)) {
                    oleDa.Fill(_dtOA);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                conn.Close();
                MessageBox.Show("线程结束：" + DateTime.Now);
                dataGridView2.DataSource = _dtOA;
                //dgv3.DataSource = _dtOA;
                //this.Controls.Add(dgv3);
            }
        }
    }
}
