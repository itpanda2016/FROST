using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FROST.Utility;
namespace TestTransaction {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK) {
                DataTable dt = NpoiHelper.ExcelToDataTable(openFileDialog1.FileName);
            }
        }

    }
}
