using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KNCSDL
{
    public partial class Form2 : Form
    {
        public DataHelper dataHelper = new DataHelper(@"Data Source=QQUAN0147\SQLEXPRESS;Initial Catalog=demo;Integrated Security=True");

        public delegate void MyDel(int idLop);
        public MyDel del { get; set; }
        public string MSSV { get; set; }
        public Form2(string mssv)
        {
            InitializeComponent();
            MSSV = mssv;
            string query = "select * from LopSH";
            foreach (DataRow row in dataHelper.GetRecordsSV(query).Rows)
            {
                comboBox1.Items.Add(new CBB_Items
                {
                    Value = Convert.ToInt32(row["ID"].ToString()),
                    Text = row["NameLop"].ToString()
                });
            }
            GUI();
        }
        public void GUI()
        {
            if (MSSV != "")
            {
                string query = " select * from SinhVien where MSSV = '" + MSSV + " '";
                textBoxMssv.Enabled = false;
                textBoxMssv.Text = dataHelper.GetRecordsSV(query).Rows[0]["MSSV"].ToString();
                textBoxName.Text = dataHelper.GetRecordsSV(query).Rows[0]["NameSV"].ToString();
                textBoxGpa.Text = dataHelper.GetRecordsSV(query).Rows[0]["DTB"].ToString();
                if(Convert.ToBoolean(dataHelper.GetRecordsSV(query).Rows[0]["GioiTinh"].ToString()))
                {
                    radioButtonMale.Checked = true;
                }
                else
                {
                    radioButtonFemale.Checked = true;
                }
                checkBoxAnh.Checked = Convert.ToBoolean(dataHelper.GetRecordsSV(query).Rows[0]["Anh"].ToString());
                checkBoxCmnd.Checked = Convert.ToBoolean(dataHelper.GetRecordsSV(query).Rows[0]["CMND"]);
                checkBoxHocBa.Checked = Convert.ToBoolean(dataHelper.GetRecordsSV(query).Rows[0]["HocBa"]);
                int ID_Lop = Convert.ToInt32(dataHelper.GetRecordsSV(query).Rows[0]["ID_Lop"].ToString());
                foreach (CBB_Items item in comboBox1.Items)
                {
                    if (item.Value == ID_Lop)
                    {
                        comboBox1.SelectedItem = item;
                    }
                }
            }
            else
            {
                radioButtonFemale.Checked = true;
                checkBoxAnh.Checked = false;
                checkBoxCmnd.Checked = false;
                checkBoxHocBa.Checked = false;

            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string query;
            if (MSSV != "")
            {
              query = "update SinhVien set NameSV = N'" + textBoxName.Text + "', ID_Lop = " + ((CBB_Items)comboBox1.SelectedItem).Value + ", DTB = " + Convert.ToDouble(textBoxGpa.Text) + ", GioiTinh = '" + Convert.ToBoolean(radioButtonMale.Checked) + "', Anh = '" + checkBoxAnh.Checked + "', HocBa = '" +checkBoxHocBa.Checked + "', CMND = '" + checkBoxCmnd.Checked+ "' where MSSV = '" + textBoxMssv.Text  + "'";
            }
            else
            {
                query = "insert into SinhVien (MSSV, NameSV, ID_Lop, GioiTinh, NgaySinh, DTB,Anh ,CMND ,HocBa) values('" + textBoxMssv.Text + "', '" + textBoxName.Text + "', '" + ((CBB_Items)comboBox1.SelectedItem).Value + "', '" + radioButtonMale.Checked + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + Convert.ToDouble(textBoxGpa.Text) + "', '" + checkBoxAnh.Checked + "', '" + checkBoxCmnd.Checked + "', '" + checkBoxHocBa.Checked + "')";

            }
            dataHelper.ExcuteDB(query);
            del(0);
            this.Close();

        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}

