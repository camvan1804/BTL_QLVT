using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BTL_QLKVT
{
    public partial class frmNhaCungCap : Form
    {
        string str = @"Data Source=.;Initial Catalog=QLY_KHOVATTU;Integrated Security=True";

        public frmNhaCungCap()
        {
            InitializeComponent();
            LoadDanhSachNCC();
        }
        void LoadDanhSachNCC()
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            string sql = "SELECT * FROM NhaCungCap";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvnhacungcap.DataSource = dt;
            conn.Close();
        }

        private void dgvnhacungcap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvnhacungcap.Rows[e.RowIndex];

                txtmanhacungcap.Text = row.Cells[0].Value.ToString();
                txttennhacungcap.Text = row.Cells[1].Value.ToString();
                txtsodienthoai.Text = row.Cells[2].Value.ToString();
                txtdiachi.Text = row.Cells[3].Value.ToString();
                txtemail.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu quên chưa nhập Mã hoặc Tên thì nhắc nhở
            if (txtmanhacungcap.Text == "" || txttennhacungcap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã và tên nhà cung cấp!");
                return;
            }

            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            // Câu lệnh thêm dòng mới vào bảng NhaCungCap trong SQL
            string sql = "INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, SoDienThoai, DiaChi, Email) " +
             "VALUES (@ma, @ten, @sdt, @diachi, @email)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            // Lấy chữ từ 5 ô bạn nhập trên màn hình đưa vào SQL
            cmd.Parameters.AddWithValue("@ma", txtmanhacungcap.Text.Trim());
            cmd.Parameters.AddWithValue("@ten", txttennhacungcap.Text.Trim());
            cmd.Parameters.AddWithValue("@sdt", txtsodienthoai.Text.Trim());
            cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());

            cmd.ExecuteNonQuery(); // Thực thi lệnh lưu
            conn.Close();

            MessageBox.Show("Lưu nhà cung cấp thành công!");

            // Tự động tải lại bảng bên trái để hiện ngay dòng vừa lưu
            LoadDanhSachNCC();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtmanhacungcap.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xoá!");
                return;
            }

            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            string sql = "DELETE FROM NhaCungCap WHERE MaNhaCungCap = @ma";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ma", txtmanhacungcap.Text.Trim());

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Xoá thành công!");
            LoadDanhSachNCC();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            string sql = "SELECT * FROM NhaCungCap " +
                         "WHERE TenNhaCungCap LIKE @ten AND MaNhaCungCap LIKE @ma";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ten", "%" + txttimkiemtennhacungcap.Text.Trim() + "%");
            cmd.Parameters.AddWithValue("@ma", "%" + txttimkiemmanhacungcap.Text.Trim() + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvnhacungcap.DataSource = dt;
            conn.Close();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
           txttimkiemmanhacungcap.Clear();
           txttimkiemtennhacungcap.Clear();
            txtmanhacungcap.Clear();
            txttennhacungcap.Clear();
            txtsodienthoai.Clear();
            txtdiachi.Clear();
            txtemail.Clear();
            LoadDanhSachNCC();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtmanhacungcap.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!");
                return;
            }

            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            string sql = "UPDATE NhaCungCap SET TenNhaCungCap = @ten, " +
                         "SoDienThoai = @sdt, DiaChi = @diachi, Email = @email " +
                         "WHERE MaNhaCungCap = @ma";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ma", txtmanhacungcap.Text.Trim());
            cmd.Parameters.AddWithValue("@ten", txttennhacungcap.Text.Trim());
            cmd.Parameters.AddWithValue("@sdt", txtsodienthoai.Text.Trim());
            cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Sửa thành công!");
            LoadDanhSachNCC();
        }
        private void btnquaylai_Click(object sender, EventArgs e)
        {
            frmTrangChu f = new frmTrangChu();
            f.Show();
            this.Hide();
        }
    }
}
