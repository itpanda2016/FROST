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

namespace TestTransaction {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string strCompany = "";
            OAHrmServiceReference.HrmServicePortTypeClient server = new OAHrmServiceReference.HrmServicePortTypeClient();
            try {
                //server.SynSubCompany("10.1.1.73", strCompany);
                server.checkUser("10.1.1.73", "test", "01764");
            }
            catch (Exception er) {
                MessageBox.Show(er.Message);
            }
            finally {
                MessageBox.Show(strCompany);
            }
        }

    }
}
