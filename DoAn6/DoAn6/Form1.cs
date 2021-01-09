using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn6
{
    public partial class Form1 : Form
    {
        ServiceReference2.WebService1SoapClient web = new ServiceReference2.WebService1SoapClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = web.getAccount();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
           
            foreach (DataRow rows in dt.Rows)
            {
                string user = rows["USER"].ToString();

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
