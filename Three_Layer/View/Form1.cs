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

using Three_Layer.DTO;
using Three_Layer.BLL;
namespace Three_Layer.View
{
    public partial class Form1 : Form
    {

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

            comboBoxLopSh.Items.AddRange(BLL_QLSV.Instance.GetCBB().ToArray());

        }
        public void Show(int ID_Lop, string search)
        {
            List<SV> data = new List<SV>();
            if (search == "")
            {
                dataGridView1.DataSource = BLL_QLSV.Instance.GetSVByIDLop(ID_Lop);
                return;
            }
            else
            {
                data = BLL_QLSV.Instance.Search(search, ID_Lop);
            }
            dataGridView1.DataSource = data;
        }

        private void showBt_Click(object sender, EventArgs e)
        {
            int ID_Lop = (int)((CBB_Items)comboBoxLopSh.SelectedItem).Value;
            dataGridView1.DataSource = BLL_QLSV.Instance.GetSVViewByIDLop(ID_Lop);
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    BLL_QLSV.Instance.DeleteSV(i.Cells["MSSV"].Value.ToString());
                }
            }
            int ID_Lop = (int)((CBB_Items)comboBoxLopSh.SelectedItem).Value;
            dataGridView1.DataSource = BLL_QLSV.Instance.Search("",ID_Lop);
        }

        private void sortBt_Click(object sender, EventArgs e)
        {

            if ((comboBoxSort.Text) == "MSSV")
                dataGridView1.DataSource = BLL_QLSV.Instance.Sort(comboBoxSort.Text, SV.CompareMSSV);
            if ((comboBoxSort.Text) == "Name")
                dataGridView1.DataSource = BLL_QLSV.Instance.Sort(comboBoxSort.Text, SV.CompareName);
            if ((comboBoxSort.Text) == "DTB")
                dataGridView1.DataSource = BLL_QLSV.Instance.Sort(comboBoxSort.Text, SV.CompareName);
        }


        private void seacrhBt_Click_1(object sender, EventArgs e)
        {
            int ID_Lop = (int)((CBB_Items)comboBoxLopSh.SelectedItem).Value;
            dataGridView1.DataSource = BLL_QLSV.Instance.Search(textBoxSearch.Text, ID_Lop);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Cut"));
                m.MenuItems.Add(new MenuItem("Copy"));
                m.MenuItems.Add(new MenuItem("Paste"));

                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                }

                m.Show(dataGridView1, new Point(e.X, e.Y));

            }
        }
    }
}

