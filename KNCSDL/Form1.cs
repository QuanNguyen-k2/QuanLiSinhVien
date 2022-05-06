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

namespace KNCSDL
{
    public partial class Form1 : Form
    {
        DataHelper db = new DataHelper(@"Data Source=QQUAN0147\SQLEXPRESS;Initial Catalog=demo;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            GUI();
        }
        public void GUI()
        {
            comboBoxLopSh.Items.Add(new CBB_Items { Value = 0, Text = "All" });
            comboBoxLopSh.SelectedIndex = 0;
            comboBoxSort.SelectedIndex = 0;
            string query = "select * from LopSH";
            foreach (DataRow i in db.GetRecordsSV(query).Rows)
            {
                comboBoxLopSh.Items.Add(new CBB_Items
                {
                    Value = Convert.ToInt32(i["ID"].ToString()),
                    Text = i["NameLop"].ToString()
                }); ;
            }
        }
        public void Show(int ID_Lop)
        {
            string query = "";
            if(ID_Lop == 0)
            { 
                query = "SELECT MSSV, NameSV,NameLop, DTB, GioiTinh, NgaySinh, Anh, CMND,HocBa FROM SinhVien INNER JOIN LopSH ON SinhVien.ID_Lop = LopSH.ID ";

            }
            else
            {
                query = "SELECT MSSV, NameSV,NameLop, DTB, GioiTinh, NgaySinh, Anh, CMND,HocBa FROM SinhVien INNER JOIN LopSH ON SinhVien.ID_Lop = LopSH.ID where ID_Lop = " + ID_Lop;
            }
            
            dataGridView1.DataSource = db.GetRecordsSV(query);
        }

        private void showBt_Click(object sender, EventArgs e)
        {
            int ID_Lop = ((CBB_Items)comboBoxLopSh.SelectedItem).Value;
            Show(ID_Lop);

        }

        private void addBt_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2("");
            f.del = new Form2.MyDel(Show);
            f.Show();

        }

        private void updateBt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MSSV = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                Form2 f = new Form2(MSSV);
                f.del = new Form2.MyDel(Show);
                f.Show();
            }
            
        }

        private void deleteBt_Click(object sender, EventArgs e)
        {
            string mssv = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
            string query = "delete from SinhVien where MSSV = '" + mssv + "'";
            db.ExcuteDB(query);
            Show(0);
        }

        private void sortBt_Click(object sender, EventArgs e)
        {
            string query;
            switch (comboBoxSort.SelectedIndex)
            {
                case 1:
                    query = "SELECT MSSV, NameSV,NameLop, DTB, GioiTinh, NgaySinh, Anh, CMND,HocBa FROM SinhVien INNER JOIN LopSH ON SinhVien.ID_Lop = LopSH.ID  order by DTB";
                    break;
                case 2:
                    query = "SELECT MSSV, NameSV,NameLop, DTB, GioiTinh, NgaySinh, Anh, CMND,HocBa FROM SinhVien INNER JOIN LopSH ON SinhVien.ID_Lop = LopSH.ID  order by NameSV";
                    break;
                default:
                    query = "SELECT MSSV, NameSV,NameLop, DTB, GioiTinh, NgaySinh, Anh, CMND,HocBa FROM SinhVien INNER JOIN LopSH ON SinhVien.ID_Lop = LopSH.ID  order by MSSV";
                    break;
            }
              
            dataGridView1.DataSource=db.GetRecordsSV(query);
        }

        private void seacrhBt_Click(object sender, EventArgs e)
        {
            if(textBoxSearch.Text == null)
            {
                return;
            }
            string query = "SELECT MSSV, NameSV, NameLop, DTB, GioiTinh, NgaySinh, Anh, CMND, HocBa FROM SinhVien INNER JOIN LopSH ON SinhVien.ID_Lop = LopSH.ID WHERE NameSV LIKE '%"+textBoxSearch.Text+"%'";
            db.ExcuteDB(query);
           dataGridView1.DataSource = db.GetRecordsSV(query);
        }
    }
}
