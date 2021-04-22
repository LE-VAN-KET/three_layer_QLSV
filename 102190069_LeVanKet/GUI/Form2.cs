using _102190069_LeVanKet.BLL;
using _102190069_LeVanKet.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102190069_LeVanKet.GUI
{
    public partial class Form2 : Form
    {
        public delegate void Mydel(string mssv);
        public Mydel d;

        public delegate void MydelLoad();
        public MydelLoad dLoad;
        public Form2()
        {
            InitializeComponent();
            SetCBB();
            d = new Mydel(SetGUI);
        }

        private void SetCBB()
        {
            foreach (LopSH lsh in BLL_QLSV.Instance.GetAllLopSH())
            {
                CBBLSH.Items.Add(new LopSH()
                {
                    ID_Lop = lsh.ID_Lop,
                    NameLop = lsh.NameLop
                });
            }
            CBBLSH.SelectedIndex = 0;
        }

        public void SetGUI(string MSSV)
        {
            if (MSSV != "")
            {
                SV s = BLL_QLSV.Instance.GetSVByMSSV(MSSV);
                txtMSSV.Text = s.MSSV;
                txtMSSV.Enabled = false;
                txtNameSV.Text = s.NameSV;
                radioBtnMale.Checked = s.Gender;
                radioBtnFemale.Checked = !radioBtnMale.Checked;
                dateTimePicker1.Value = s.NS;
                foreach (LopSH lsh in CBBLSH.Items)
                {
                    if (lsh.ID_Lop == s.ID_Lop)
                    {
                        CBBLSH.SelectedItem = lsh;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOke_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == null || txtNameSV.Text == null || (!radioBtnFemale.Checked && !radioBtnMale.Checked))
            {
                MessageBox.Show("All fields not empty!");
                return;
            }

            SV svExist = BLL_QLSV.Instance.GetSVByMSSV(txtMSSV.Text);
            if (svExist != null && (txtMSSV.Enabled = false))
            {
                MessageBox.Show("MSSV already exist. Please repeat enter!");
                return;
            }

            SV sv = new SV();
            sv.MSSV = txtMSSV.Text.ToString();
            sv.NameSV = txtNameSV.Text.ToString();
            if (radioBtnMale.Checked == true)
            {
                sv.Gender = true;
            }
            else
            {
                sv.Gender = false;
            }
            sv.NS = dateTimePicker1.Value;
            sv.ID_Lop = ((LopSH)CBBLSH.SelectedItem).ID_Lop;
            BLL_QLSV.Instance.ExecuteDB(sv);
            dLoad();
            this.Dispose();
        }
    }
}
