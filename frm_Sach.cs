using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BaiMau
{
    public partial class frm_Sach : Form
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        string duongdan = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+"\\HINH\\";
        public frm_Sach()
        {
            InitializeComponent();
        }
        public void LoadSach()
        {
            string sql = "Select * from SACH";
            dataGridView1.DataSource = lopchung.LoadDL(sql);
        }
        public void LoadCombo()
        {
            string sql = "Select * from THELOAI";
            cb_TheLoai.DataSource = lopchung.LoadDL(sql);
            cb_TheLoai.DisplayMember = "TENTHELOAI";
            cb_TheLoai.ValueMember = "MATHELOAI";
        }
        private void frm_Sach_Load(object sender, EventArgs e)
        {
            LoadSach();
            LoadCombo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string sql = "Insert into SACH values (N'"+txt_MaSach.Text+"',N'"+cb_TheLoai.SelectedValue+"',N'"+txt_TenSach.Text+"',N'"+txt_SoTrang.Text+"',N'"+txt_TomTat.Text+ "',N'" + txt_HinhAnh.Text + "')";
            lopchung.ThemXoaSua(sql);
            pictureBox1.Image.Save(duongdan + txt_HinhAnh.Text);
            LoadSach();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn thật sự có xóa hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                string sql = "Delete from SACH where MASACH = '" + txt_MaSach.Text + "'";
                lopchung.ThemXoaSua(sql);
                File.Delete(duongdan + txt_HinhAnh.Text);
                LoadSach();
            }
            
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        { 
            string sql = "Update SACH set MATHELOAI = N'" + cb_TheLoai.SelectedValue + "',TENSACH = N'" + txt_TenSach.Text + "',SOTRANG = N'" + txt_SoTrang.Text + "',TOMTAT = N'" + txt_TomTat.Text + "',HINHANH = '"+txt_HinhAnh.Text+"' where MASACH = N'" + txt_MaSach.Text + "'";
            lopchung.ThemXoaSua(sql);
            pictureBox1.Image.Save(duongdan + txt_HinhAnh.Text);
            LoadSach();
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn thật sự có muốn thoát hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaSach.Text = dataGridView1.CurrentRow.Cells["MASACH"].Value.ToString();
            txt_SoTrang.Text = dataGridView1.CurrentRow.Cells["SOTRANG"].Value.ToString();
            txt_TenSach.Text = dataGridView1.CurrentRow.Cells["TENSACH"].Value.ToString();
            txt_TomTat.Text = dataGridView1.CurrentRow.Cells["TOMTAT"].Value.ToString();
            cb_TheLoai.SelectedValue = dataGridView1.CurrentRow.Cells["MATHELOAI"].Value.ToString();
            txt_HinhAnh.Text = dataGridView1.CurrentRow.Cells["HINHANH"].Value.ToString();
            pictureBox1.ImageLocation = duongdan + txt_HinhAnh.Text;
        }

        private void btn_TaiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Hãy chọn ảnh của cuốn sách";
            open.Filter = "Ảnh dạng JPG|*.JPG|Ảnh dạng PNG|*.PNG|Tất cả|*.*";
            if (open.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
            }
        }
    }
}
