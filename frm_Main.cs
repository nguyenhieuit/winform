using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiMau
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void nhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_Sach"] == null)
            {
                frm_Sach sach = new frm_Sach();
                sach.MdiParent = this;
                sach.Show();
            }
            else Application.OpenForms["frm_Sach"].Activate();
        }
    }
}
