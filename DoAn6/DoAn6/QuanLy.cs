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
    public partial class QuanLy : Form
    {
        ServiceReference2.WebService1SoapClient hi = new ServiceReference2.WebService1SoapClient();
        static bool hienthi = true;
        static bool andi = false;
        public QuanLy()
        {
            InitializeComponent();
        }

        
        private void QuanLy_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.CHUCVU' table. You can move, or remove it, as needed.
            this.cHUCVUTableAdapter.Fill(this.dataSet1.CHUCVU);
            // TODO: This line of code loads data into the 'dataSet1.PHONGBAN' table. You can move, or remove it, as needed.
            this.pHONGBANTableAdapter1.Fill(this.dataSet1.PHONGBAN);
            // TODO: This line of code loads data into the 'dataSet1.HOPDONG' table. You can move, or remove it, as needed.
            this.hOPDONGTableAdapter.Fill(this.dataSet1.HOPDONG);
            // TODO: This line of code loads data into the 'dsphongban.PHONGBAN' table. You can move, or remove it, as needed.
            //this.pHONGBANTableAdapter.Fill(this.dsphongban.PHONGBAN);

        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            panel1.Visible = hienthi;
            panel2.Visible = andi;
            panel3.Visible = andi;
            DataSet ds = new DataSet();
            ds = hi.getdata();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach(DataRow rows in dt.Rows)
            {
                listView1.Items.Add(rows["MANV"].ToString());
                listView1.Items[i].SubItems.Add(rows["TENNV"].ToString());
                listView1.Items[i].SubItems.Add(rows["GIOITINH"].ToString());
                listView1.Items[i].SubItems.Add(rows["TRINHDO"].ToString());
                listView1.Items[i].SubItems.Add(rows["NGAYSINH"].ToString());
                listView1.Items[i].SubItems.Add(rows["HONNHAN"].ToString());
                listView1.Items[i].SubItems.Add(rows["SOCMND"].ToString());
                listView1.Items[i].SubItems.Add(rows["QUEQUAN"].ToString());
                listView1.Items[i].SubItems.Add(rows["PHONE"].ToString());
                listView1.Items[i].SubItems.Add(rows["EMAIL"].ToString());
                listView1.Items[i].SubItems.Add(rows["TEN"].ToString());
                listView1.Items[i].SubItems.Add(rows["TEN"].ToString());
                i++;

            }
        }

        

        

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            panel2.Visible = hienthi;
            panel1.Visible = andi;
            panel3.Visible = andi;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DataSet ds = new DataSet();
            ds = hi.getInformationDepartment(comboBox1.Text);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach(DataRow rows in dt.Rows)
            {
                tenpb.Text = rows["TEN"].ToString();
                truongphong.Text = rows["TENNV"].ToString();
                diachi.Text = rows["DIACHI"].ToString();
                chitieu.Text = rows["CHITIEU"].ToString();
            }
            
            DataSet ds2 = new DataSet();
            ds2 = hi.getInformationEmplayee(comboBox1.Text);
            DataTable dt2 = new DataTable();
            dt2 = ds2.Tables[0];
            int i = 0;
            employeeDeparment.Items.Clear();
            employeeDeparment.Refresh();
            foreach (DataRow rows in dt2.Rows)
            {
                employeeDeparment.Items.Add(rows["MANV"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["TENNV"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["GIOITINH"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["TRINHDO"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["NGAYSINH"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["HONNHAN"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["SOCMND"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["QUEQUAN"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["PHONE"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["EMAIL"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["TEN"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["TEN"].ToString());
                i++;
            }
          
        }
        public void delete()
        {

            if (employeeDeparment.Items.Count >= 0)
            {
                for (int i = 0; i < employeeDeparment.Items.Count; i++)
                {

                    employeeDeparment.Items[i].Remove();
                    i--;

                }
            }
    }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)

        {
            
            string gioitinh = "";
            if (nam.Checked = true)
            {
                gioitinh = "NAM";
            }
            else
            {
                gioitinh = "NU";
            }
              //  if (hi.insert(manv.Text,tennv.Text,gioitinh,trinhdo.Text,))
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = andi;
            panel1.Visible = andi;
            panel3.Visible = hienthi;
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                manv.Text = item.SubItems[0].Text;
                tennv.Text = item.SubItems[1].Text;

                if (item.SubItems[2].Text.Equals("NAM"))
                {
                    nam.Checked = true;
                }
                else
                {
                    nu.Checked = true;
                }
                trinhdo.Text = item.SubItems[3].Text;
                // dateTimePicker1.Value = item.SubItems[4].Text;
                honnhan.Text = item.SubItems[5].Text;
                socmnd.Text = item.SubItems[6].Text;
                que.Text = item.SubItems[7].Text;
                sodt.Text = item.SubItems[8].Text;
                email.Text = item.SubItems[9].Text;
                comboBox2.Text = item.SubItems[10].Text;
                comboBox3.Text = item.SubItems[11].Text;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
       
    }
   
}
