using _102190069_LeVanKet.BLL;
using _102190069_LeVanKet.DTO;
using _102190069_LeVanKet.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT03_102190069_LeVanKet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB();
            setCBBSort();
        }

        private void SetCBB()
        {
            cbbLopSH.Items.Add(new LopSH()
            {
                ID_Lop = 0,
                NameLop = "All"
            });
            foreach (LopSH lsh in BLL_QLSV.Instance.GetAllLopSH())
            {
                cbbLopSH.Items.Add(new LopSH()
                {
                    ID_Lop = lsh.ID_Lop,
                    NameLop = lsh.NameLop
                });
            }
            cbbLopSH.SelectedIndex = 0;
        }

        private void setCBBSort()
        {
            comboBoxSort.Items.AddRange(new string[]
            {
            "Name: A->Z",
            "Name: Z->A",
            "NS: Z->A",
            "NS: A->Z"
            });
            comboBoxSort.SelectedIndex = 0;
        }

        public void LoadData()
        {
            List<SV> listSV = BLL_QLSV.Instance.GetListSV(((LopSH)cbbLopSH.SelectedItem).ID_Lop, txtSearch.Text);
            dataGridView1.DataSource = BLL_QLSV.Instance.GetListSVView(listSV);
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.dLoad = new Form2.MydelLoad(LoadData);
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection data = dataGridView1.SelectedRows;
            if (data.Count == 1)
            {
                string MSSV = data[0].Cells["MSSV"].Value.ToString();
                Form2 form2 = new Form2();
                form2.d(MSSV);
                form2.dLoad += new Form2.MydelLoad(LoadData);
                form2.Show();
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            int ID_lop = ((LopSH)cbbLopSH.SelectedItem).ID_Lop;
            switch (comboBoxSort.Text)
            {
                case "Name: A->Z":
                    dataGridView1.DataSource = BLL_QLSV.Instance.Sort(ID_lop, SV.Compare_NameAscending);
                    break;
                case "Name: Z->A":
                    dataGridView1.DataSource = BLL_QLSV.Instance.Sort(ID_lop, SV.Compare_NameDecending);
                    break;
                case "NS: A->Z":
                    dataGridView1.DataSource = BLL_QLSV.Instance.Sort(ID_lop, SV.Compare_NSAscending);
                    break;
                case "NS: Z->A":
                    dataGridView1.DataSource = BLL_QLSV.Instance.Sort(ID_lop, SV.Compare_NSDecending);
                    break;
                default:
                    break;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRowCollection = dataGridView1.SelectedRows;
            if (selectedRowCollection.Count > 0)
            {
                foreach (DataGridViewRow item in selectedRowCollection)
                {
                    BLL_QLSV.Instance.DeleteSV(item.Cells["MSSV"].Value.ToString());
                }

            }
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
