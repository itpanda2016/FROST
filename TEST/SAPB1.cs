using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using FROST.Utility;

namespace TEST {
    public partial class SAPB1 : Form {
        public SAPB1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            DataTable dt = new DataTable();
            string sql = "select * from TEST01.OCRD";
            dt = OdbcDbHelper.ExecuteDataTable(sql);
            dataGridView1.DataSource = dt;
        }
    }
}
