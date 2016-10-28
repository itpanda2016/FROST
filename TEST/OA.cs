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
    public partial class OA : Form {
        public OA() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            dataGridView1.DataSource = OleDbHelper.ExecuteDataTable("select * from hrmresource");
        }
    }
}
