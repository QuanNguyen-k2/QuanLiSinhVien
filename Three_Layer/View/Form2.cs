using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Three_Layer.BLL;
using Three_Layer.DTO;
namespace Three_Layer.View
{
    public partial class Form2 : Form
    {

        public delegate void MyDel(int idLop,string search);
        public MyDel del { get; set; }
        public string MSSV { get; set; }
        public Form2(string mssv)
        {
            InitializeComponent();
            MSSV = mssv;
            comboBox1.Items.AddRange(BLL_QLSV.Instance.GetCBB().ToArray());
            GUI();
        }
        public void GUI()
        {
            if (MSSV != "")
            {
               
                SV s = BLL_QLSV.Instance.GetSVByMSSV(MSSV);
                textBoxMssv.Text = s.MSSV;
                textBoxName.Text = s.NameSV;

                foreach (CBB_Items item in comboBox1.Items)
                {
                    if ((int)item.Value == s.ID_Lop)
                    {
                        comboBox1.SelectedItem = item;
                        break;
                    }
                }
                if (Convert.ToBoolean(s.Gender) == true)
                    radioButtonMale.Checked = true;
                else
                    radioButtonFemale.Checked = true;
                dateTimePicker1.Value = s.NgaySinh;
                textBoxGpa.Text = s.DTB.ToString();
                checkBoxAnh.Checked = Convert.ToBoolean(s.Anh);
                checkBoxHocBa.Checked = Convert.ToBoolean(s.HocBa);
                checkBoxCmnd.Checked = Convert.ToBoolean(s.Cmnd);
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
            SV s = new SV();
            s.MSSV = textBoxMssv.Text;
            s.NameSV = textBoxName.Text;

            s.ID_Lop = (int)((CBB_Items)comboBox1.SelectedItem).Value;
            s.Gender = radioButtonMale.Checked;
            s.NgaySinh = dateTimePicker1.Value;
            s.DTB = Convert.ToDouble(textBoxGpa.Text);
            s.Anh = checkBoxAnh.Checked;
            s.HocBa= checkBoxHocBa.Checked;
            s.Cmnd = checkBoxCmnd.Checked;

            BLL_QLSV.Instance.AddUpdateSV(s);
            del(0, "");
            this.Close();

        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}

