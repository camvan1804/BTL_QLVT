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

namespace khách_hàng
{
    public partial class frmKhachHang : Form
    {

        string connectionString = @"Data Source=DESKTOP-R1M6SPO;Initial Catalog=QL_khovattu;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng kết nối và gọi LoadData khi form mở lên
            conn = new SqlConnection(connectionString);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT * FROM KhachHang";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvkhachhang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void dgvkhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvkhachhang.Rows[e.RowIndex];
                txtmakhachhang.Text = row.Cells["makhachhang"].Value.ToString();
                txttenkhachhang.Text = row.Cells["tenkhachhang"].Value.ToString();
                txtsodienthoai.Text = row.Cells["sodienthoai"].Value.ToString();
                txtdiachi.Text = row.Cells["diachi"].Value.ToString();
                txtghichu.Text = row.Cells["ghichu"].Value.ToString();

                // Khóa ô Mã KH khi chọn dòng để sửa (tránh sửa trùng khóa chính)
                txtmakhachhang.Enabled = false;
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmakhachhang.Text) || string.IsNullOrEmpty(txttenkhachhang.Text))
            {
                MessageBox.Show("Mã khách hàng và Tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Kiểm tra xem Mã KH đã tồn tại trong CSDL hay chưa
                string checkQuery = "SELECT COUNT(*) FROM KhachHang WHERE makhachhang = @makhachhang";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@makhachhang", txtmakhachhang.Text.Trim());
                int count = (int)checkCmd.ExecuteScalar();

                string query = "";
                if (count > 0)
                {
                    // Nếu đã có -> Cập nhật (Update)
                    query = "UPDATE KhachHang SET tenkhachhang = @tenkhachhang, sodienthoai = @sodienthoai, diachi = @diachi, ghichu = @ghichu WHERE makhachhang = @makhachhang";
                }
                else
                {
                    // Nếu chưa có -> Thêm mới (Insert)
                    query = "INSERT INTO KhachHang (makhachhang, tenkhachhang, sodienthoai, diachi, ghichu) VALUES (@makhachhang, @tenkhachhang, @sodienthoai, @diachi, @ghichu)";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makhachhang", txtmakhachhang.Text.Trim());
                cmd.Parameters.AddWithValue("@tenkhachhang", txttenkhachhang.Text.Trim());
                cmd.Parameters.AddWithValue("@sodienthoai", txtsodienthoai.Text.Trim());
                cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text.Trim());
                cmd.Parameters.AddWithValue("@ghichu", txtghichu.Text.Trim());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmakhachhang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string query = "DELETE FROM KhachHang WHERE makhachhang = @makhachhang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@makhachhang", txtmakhachhang.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmakhachhang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtmakhachhang.Enabled = false; // Không cho sửa mã chính
            txttenkhachhang.Focus();
            MessageBox.Show("Đã sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT * FROM KhachHang WHERE MaKhachHang LIKE @makhachhang AND TenKhachHang LIKE @tenkhachhang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makhachhang", "%" + txttimma.Text.Trim() + "%");
                cmd.Parameters.AddWithValue("@tenkhachhang", "%" + txttimten.Text.Trim() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvkhachhang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txttimma.Clear();
            txttimten.Clear();
            ClearInputs();
            LoadData();
        }

        private void ClearInputs()
        {
            txtmakhachhang.Clear();
            txttenkhachhang.Clear();
            txtsodienthoai.Clear();
            txtdiachi.Clear();
            txtghichu.Clear();
            txtmakhachhang.Enabled = true;
        }
    }
}
    
