using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ktv_quanlikiemke
{
    public partial class Frmquanlitaikhoan : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattu;Integrated Security=True;";
        string tableName = "TaiKhoan";
        // Biến kiểm tra trạng thái ẩn/hiện mật khẩu
        private bool hienMatKhau = false;
        public Frmquanlitaikhoan()
        {
            InitializeComponent();
        }

        private void Frmquanlitaikhoan_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadVaiTroVaTrangThai();

            // Gắn sự kiện click cho DataGridView
            dgvtaikhoan.CellClick += dgvtaikhoan_CellClick;

            // Mật khẩu ẩn mặc định (dấu sao)
            txtmatkhau.UseSystemPasswordChar = true;
        }
        // Tải dữ liệu vào ComboBox Vai trò và Trạng thái (nếu dùng ComboBox)
        private void LoadVaiTroVaTrangThai()
        {
            // Vai trò mẫu (có thể thay đổi tùy ý)
            if (cbovaitro != null && cbovaitro.Items.Count == 0)
            {
                cbovaitro.Items.Add("Quản trị viên");
                cbovaitro.Items.Add("Thủ kho");
                cbovaitro.Items.Add("Nhân viên");
            }

            // Trạng thái mẫu (1: Hoạt động, 0: Khóa)
            if (cbotrangthai != null && cbotrangthai.Items.Count == 0)
            {
                cbotrangthai.Items.Add("1");
                cbotrangthai.Items.Add("0");
            }
        }

        // Hàm tải danh sách tài khoản lên DataGridView
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TenDangNhap, MatKhau, HoTen, VaiTro, TrangThai FROM " + tableName;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvtaikhoan.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu tài khoản: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // 1. Chức năng Thêm tài khoản
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttendangnhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttendangnhap.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO " + tableName + " (TenDangNhap, MatKhau, HoTen, VaiTro, TrangThai) " +
                                   "VALUES (@TenDangNhap, @MatKhau, @HoTen, @VaiTro, @TrangThai)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", txttendangnhap.Text.Trim());
                    cmd.Parameters.AddWithValue("@MatKhau", txtmatkhau.Text.Trim());
                    cmd.Parameters.AddWithValue("@HoTen", txthoten.Text.Trim());
                    cmd.Parameters.AddWithValue("@VaiTro", cbovaitro.Text.Trim());
                    cmd.Parameters.AddWithValue("@TrangThai", string.IsNullOrEmpty(cbotrangthai.Text) ? 1 : int.Parse(cbotrangthai.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm (Tên đăng nhập có thể đã tồn tại): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // 2. Chức năng Sửa tài khoản
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttendangnhap.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE " + tableName + " SET MatKhau = @MatKhau, HoTen = @HoTen, VaiTro = @VaiTro, TrangThai = @TrangThai " +
                                   "WHERE TenDangNhap = @TenDangNhap";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", txttendangnhap.Text.Trim());
                    cmd.Parameters.AddWithValue("@MatKhau", txtmatkhau.Text.Trim());
                    cmd.Parameters.AddWithValue("@HoTen", txthoten.Text.Trim());
                    cmd.Parameters.AddWithValue("@VaiTro", cbovaitro.Text.Trim());
                    cmd.Parameters.AddWithValue("@TrangThai", int.Parse(cbotrangthai.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // 3. Chức năng Xóa tài khoản
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttendangnhap.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM " + tableName + " WHERE TenDangNhap = @TenDangNhap";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@TenDangNhap", txttendangnhap.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // 4. Chức năng Làm mới (Reset form)
        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }
        private void ClearFields()
        {
            txttendangnhap.Clear();
            txtmatkhau.Clear();
            txthoten.Clear();
            cbovaitro.SelectedIndex = -1;
            cbotrangthai.SelectedIndex = -1;
            txttendangnhap.ReadOnly = false; // Mở khóa tên đăng nhập khi thêm mới
        }
        // 5. Chức năng Tìm kiếm
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TenDangNhap, MatKhau, HoTen, VaiTro, TrangThai FROM " + tableName +
                                   " WHERE TenDangNhap LIKE @keyword OR HoTen LIKE @keyword";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + txttimkiem.Text.Trim() + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvtaikhoan.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // 6. Sự kiện Click dòng trên DataGridView để đưa dữ liệu lên các ô nhập
        private void dgvtaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvtaikhoan.Rows[e.RowIndex];
                txttendangnhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txttendangnhap.ReadOnly = true;

                txtmatkhau.Text = row.Cells["MatKhau"].Value.ToString();
                txthoten.Text = row.Cells["HoTen"].Value.ToString();
                cbovaitro.Text = row.Cells["VaiTro"].Value.ToString();

                // Xử lý chuyển đổi giá trị True/False hoặc 1/0 sang ComboBox Trạng Thái
                object valTrangThai = row.Cells["TrangThai"].Value;
                if (valTrangThai != null && valTrangThai != DBNull.Value)
                {
                    bool isTrangThai = Convert.ToBoolean(valTrangThai);
                    cbotrangthai.Text = isTrangThai ? "1" : "0";
                }
                else
                {
                    cbotrangthai.Text = "1";
                }
            }
        }

        private void btneye_Click(object sender, EventArgs e)
        {
            hienMatKhau = !hienMatKhau;
            if (hienMatKhau)
            {
                txtmatkhau.UseSystemPasswordChar = false; // Hiện mật khẩu rõ
            }
            else
            {
                txtmatkhau.UseSystemPasswordChar = true;  // Ẩn mật khẩu (dấu sao)
            }
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {

            // 1. Khởi tạo lại form trang chủ
            frmtrangchu fTrangChu = new frmtrangchu();
            fTrangChu.Show();

            // 2. Đóng form chức năng hiện tại đi
            this.Close();
        }
    }
}
