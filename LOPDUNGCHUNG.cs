using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace BaiMau
{
    class LOPDUNGCHUNG
    {
        string chuoiketnoi = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName +@"\QuanLyThuVien.mdf;Integrated Security=True";
        SqlConnection conn;
        public LOPDUNGCHUNG()
        {
            conn = new SqlConnection(chuoiketnoi);
        }
        public void Mo()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        public void Dong()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        public void ThemXoaSua(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            // conn.Open();
            Mo();
            int ketqua = comm.ExecuteNonQuery();
            //conn.Close();
            Dong();
            if (ketqua >= 1)
                MessageBox.Show("Thao tác thành công");
            else MessageBox.Show("Thao tác không thành công");
        }
        public DataTable LoadDL(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public object ExScalar(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            // conn.Open();
            Mo();
            object ketqua = comm.ExecuteScalar();
            //conn.Close();
            Dong();
            return ketqua;
        }
    }
}


