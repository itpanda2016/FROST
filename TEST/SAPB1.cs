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
            string sql = "select * from ECOLOGY.TEST";
            dt = OdbcDbHelper.ExecuteDataTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e) {

            //t.BeginInvoke(null,null);
            //MessageBox.Show("绑定结束：" + DateTime.Now);
        }

        private void SAPB1_Load(object sender, EventArgs e) {
            //SAPB1.CheckForIllegalCrossThreadCalls = false;
        }

        private void button3_Click(object sender, EventArgs e) {

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void button4_Click(object sender, EventArgs e) {
            int i = -1;
            try {
                i = OdbcDbHelper.ExecuteNonQuery(textBox1.Text);
            }
            catch (Exception er) {
                MessageBox.Show("执行失败：" + er.Message);
                i = -1;
            }
            if (i >= 0)
                MessageBox.Show("执行命令成功：" + i);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) {

        }

        private void button2_Click_1(object sender, EventArgs e) {
            int i = -1;
            try {
                string sql = "delete from ECOLOGY.TEST where \"CODE\" = " + textBox2.Text;
                i = OdbcDbHelper.ExecuteNonQuery(sql);
            }
            catch (Exception er) {
                MessageBox.Show("执行失败：" + er.Message);
                i = -1;
            }
            if (i >= 0)
                MessageBox.Show("执行命令成功：" + i);
        }

        private void button3_Click_1(object sender, EventArgs e) {
            string sql = "select \"NAME\" from ECOLOGY.TEST where \"CODE\" = 1";
            MessageBox.Show("查询结果：" + (string)OdbcDbHelper.ExecuteScalar(sql));
        }
    }
}
