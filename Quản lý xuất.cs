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
    public partial class Quản_lý_xuất : Form
    {
        string connectionString = @"Data Source=.;Initial Catalog=QL_khovattu2;Integrated Security=True";

        public Quản_lý_xuất()
        {

            InitializeComponent();
            LoadComboBoxMaVatTu();
            LoadDataPhieuXuat();
        }
        // 1. Tải danh sách Phiếu Xuất lên dgvphieuxuat (Bảng xuất)
        private void LoadDataPhieuXuat()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaPhieuXuat AS [Mã phiếu], NgayXuat AS [Ngày xuất], MaKhachHang AS [Mã KH], MaNhanVien AS [Mã NV], GhiChu AS [Ghi chú] FROM PhieuXuat";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvphieuxuat.DataSource = dt;

                if (dgvphieuxuat.Rows.Count > 0)
                {
                    string maPhieuDauTien = dgvphieuxuat.Rows[0].Cells["Mã phiếu"].Value.ToString();
                    LoadChiTietPhieuXuat(maPhieuDauTien);
                }
                else
                {
                    dgvchitietphieuxuat.DataSource = null;
                }
            }
        }
        // 2. Tải chi tiết Phiếu Xuất lên dgvChiTietPhieuXuat (Bảng chi tiết xuất)
        private void LoadChiTietPhieuXuat(string maPhieuXuat)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT ct.MaPhieuXuat AS [Mã phiếu], ct.MaHangHoa AS [Mã vật tư], hh.TenHangHoa AS [Tên vật tư], ct.SoLuong AS [Số lượng], ct.DonGia AS [Đơn giá] 
                                 FROM ChiTietPhieuXuat ct 
                                 JOIN HangHoa hh ON ct.MaHangHoa = hh.MaHangHoa 
                                 WHERE ct.MaPhieuXuat = @MaPhieuXuat";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuXuat", maPhieuXuat);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvchitietphieuxuat.DataSource = dt;
            }
        }
        // Tải danh sách Mã vật tư vào ComboBox
        private void LoadComboBoxMaVatTu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaHangHoa, TenHangHoa FROM HangHoa";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow row = dt.NewRow();
                    row["MaHangHoa"] = "";
                    row["TenHangHoa"] = "-- Tất cả vật tư --";
                    dt.Rows.InsertAt(row, 0);

                    cbomavattu.DataSource = dt;
                    cbomavattu.DisplayMember = "MaHangHoa"; // Hoặc TenHangHoa tùy ý bạn muốn hiển thị mã hay tên
                    cbomavattu.ValueMember = "MaHangHoa";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách vật tư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvphieuxuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvphieuxuat.Rows[e.RowIndex];
                if (row.Cells["Mã phiếu"].Value != null)
                {
                    string maPhieu = row.Cells["Mã phiếu"].Value.ToString();
                    LoadChiTietPhieuXuat(maPhieu);
                }
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void Quản_lý_xuất_Load(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở form lập phiếu xuất mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form2 f = new Form2 ();
            f.Show();
            LoadDataPhieuXuat();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgvphieuxuat.SelectedRows.Count > 0)
            {
                string maPhieu = dgvphieuxuat.SelectedRows[0].Cells["Mã phiếu"].Value.ToString();
                DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu xuất [{maPhieu}] không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmdDetail = new SqlCommand("DELETE FROM ChiTietPhieuXuat WHERE MaPhieuXuat = @MaPhieu", conn);
                            cmdDetail.Parameters.AddWithValue("@MaPhieu", maPhieu);
                            cmdDetail.ExecuteNonQuery();

                            SqlCommand cmdMaster = new SqlCommand("DELETE FROM PhieuXuat WHERE MaPhieuXuat = @MaPhieu", conn);
                            cmdMaster.Parameters.AddWithValue("@MaPhieu", maPhieu);
                            cmdMaster.ExecuteNonQuery();

                            MessageBox.Show("Xóa phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataPhieuXuat();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng phiếu xuất cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {

            string maPhieu = txtmaphieu.Text.Trim();
            string maVatTu = cbomavattu.SelectedValue?.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT DISTINCT px.MaPhieuXuat AS [Mã phiếu], px.NgayXuat AS [Ngày xuất], px.MaKhachHang AS [Mã KH], px.MaNhanVien AS [Mã NV], px.GhiChu AS [Ghi chú] 
                         FROM PhieuXuat px
                         LEFT JOIN ChiTietPhieuXuat ct ON px.MaPhieuXuat = ct.MaPhieuXuat
                         WHERE 1=1";

                if (!string.IsNullOrEmpty(maPhieu))
                {
                    query += " AND px.MaPhieuXuat LIKE @MaPhieu";
                }

                if (!string.IsNullOrEmpty(maVatTu))
                {
                    query += " AND ct.MaHangHoa = @MaVatTu";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                if (!string.IsNullOrEmpty(maPhieu))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", "%" + maPhieu + "%");
                }

                if (!string.IsNullOrEmpty(maVatTu))
                {
                    cmd.Parameters.AddWithValue("@MaVatTu", maVatTu);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvphieuxuat.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu xuất nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvchitietphieuxuat.DataSource = null;
                }
                else
                {
                    string maPhieuDauTien = dgvphieuxuat.Rows[0].Cells["Mã phiếu"].Value.ToString();
                    LoadChiTietPhieuXuat(maPhieuDauTien);
                }
            }
        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtptungay.Value.Date;
    DateTime denNgay = dtpdenngay.Value.Date;
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        string query = "SELECT MaPhieuXuat AS [Mã phiếu], NgayXuat AS [Ngày xuất], MaKhachHang AS [Mã KH], MaNhanVien AS [Mã NV], GhiChu AS [Ghi chú] FROM PhieuXuat WHERE NgayXuat BETWEEN @TuNgay AND @DenNgay";

        

        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
        cmd.Parameters.AddWithValue("@DenNgay", denNgay);
        

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        dgvphieuxuat.DataSource = dt;

        // Kiểm tra nếu không có kết quả nào
        if (dt.Rows.Count == 0)
        {
            MessageBox.Show("Không tìm thấy phiếu xuất nào phù hợp với điều kiện lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvchitietphieuxuat.DataSource = null; // Xóa sạch bảng chi tiết phía dưới
        }
        else
        {
            string maPhieuDauTien = dgvphieuxuat.Rows[0].Cells["Mã phiếu"].Value.ToString();
            LoadChiTietPhieuXuat(maPhieuDauTien);
        }
    }
            DateTime tungay = dtptungay.Value.Date;
            DateTime denngay = dtpdenngay.Value.Date;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaPhieuXuat AS [Mã phiếu], NgayXuat AS [Ngày xuất], MaKhachHang AS [Mã KH], MaNhanVien AS [Mã NV], GhiChu AS [Ghi chú] FROM PhieuXuat WHERE NgayXuat BETWEEN @TuNgay AND @DenNgay";

                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvphieuxuat.DataSource = dt;

                // Kiểm tra nếu không có kết quả nào
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu xuất nào phù hợp với điều kiện lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvchitietphieuxuat.DataSource = null; // Xóa sạch bảng chi tiết phía dưới
                }
                else
                {
                    string maPhieuDauTien = dgvphieuxuat.Rows[0].Cells["Mã phiếu"].Value.ToString();
                    LoadChiTietPhieuXuat(maPhieuDauTien);
                }
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            dtptungay.Value = DateTime.Now;
            dtpdenngay.Value = DateTime.Now;
            
            LoadDataPhieuXuat();
        }

        private void dgvchitietphieuxuat_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvphieuxuat_Click(object sender, EventArgs e) { }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            
        }
    }
}
    


