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

namespace BTLnhom6_quanlybattu
{
    public partial class frmkiemke : Form
    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattufinal;Integrated Security=True;";
        string tableName = "KiemKe";
        public frmkiemke()
        {
            InitializeComponent();
        }

        private void frmkiemke_Load(object sender, EventArgs e)
        {
            LoadData();

            // Gắn sự kiện tự động tính chênh lệch khi gõ số lượng (tùy chọn)
            txtsoluongton.TextChanged += TinhChenhLech;
            txtsoluongthucte.TextChanged += TinhChenhLech;
        }
        // Hàm tải dữ liệu lên DataGridView (Giả sử dgv của bạn tên là dgvkiemke hoặc dataGridView1, ở đây tôi dùng datagridview1 hoặc tên bạn đặt)
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM KiemKeVatTu"; // Thay tên bảng của bạn vào đây
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Nếu DataGridView của bạn tên là dgvkiemke (hoặc đổi lại cho khớp tên trên thiết kế)
                    dgvkiemke.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối hoặc tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO " + tableName + " (MaPhieu, NgayKiemKe, MaHangHoa, MaNhanVien, SoLuongTon, SoLuongThucTe, GhiChu) " +
                                   "VALUES (@MaPhieu, @NgayKiemKe, @MaHangHoa, @MaNhanVien, @SoLuongTon, @SoLuongThucTe, @GhiChu)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhieu", txtmaphieu.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgayKiemKe", dtpngaykiemke.Value);
                    cmd.Parameters.AddWithValue("@MaHangHoa", cbomahanghoa.SelectedValue != null ? cbomahanghoa.SelectedValue.ToString() : cbomahanghoa.Text);
                    cmd.Parameters.AddWithValue("@MaNhanVien", cbomanhanvien.SelectedValue != null ? cbomanhanvien.SelectedValue.ToString() : cbomanhanvien.Text);
                    cmd.Parameters.AddWithValue("@SoLuongTon", string.IsNullOrEmpty(txtsoluongton.Text) ? 0 : int.Parse(txtsoluongton.Text));
                    cmd.Parameters.AddWithValue("@SoLuongThucTe", string.IsNullOrEmpty(txtsoluongthucte.Text) ? 0 : int.Parse(txtsoluongthucte.Text));
                    cmd.Parameters.AddWithValue("@GhiChu", txtghichu.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm phiếu kiểm kê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE KiemKeVatTu SET NgayKiemKe = @NgayKiemKe, MaHangHoa = @MaHangHoa, MaNhanVien = @MaNhanVien, " +
                                   "SoLuongTon = @SoLuongTon, SoLuongThucTe = @SoLuongThucTe, ChenhLech = @ChenhLech, GhiChu = @GhiChu " +
                                   "WHERE MaPhieu = @MaPhieu";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhieu", txtmaphieu.Text);
                    cmd.Parameters.AddWithValue("@NgayKiemKe", dtpngaykiemke.Value);
                    cmd.Parameters.AddWithValue("@MaHangHoa", cbomahanghoa.Text);
                    cmd.Parameters.AddWithValue("@MaNhanVien", cbomanhanvien.Text);
                    cmd.Parameters.AddWithValue("@SoLuongTon", int.Parse(txtsoluongton.Text));
                    cmd.Parameters.AddWithValue("@SoLuongThucTe", int.Parse(txtsoluongthucte.Text));
                    cmd.Parameters.AddWithValue("@ChenhLech", int.Parse(txtchenhlech.Text));
                    cmd.Parameters.AddWithValue("@GhiChu", txtghichu.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message);
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM KiemKeVatTu WHERE MaPhieu = @MaPhieu";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaPhieu", txtmaphieu.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }
        private void ClearFields()
        {
            txtmaphieu.Clear();
            txtsoluongton.Clear();
            txtsoluongthucte.Clear();
            txtchenhlech.Clear();
            txtghichu.Clear();
            txtmaphieu.ReadOnly = false;
            dtpngaykiemke.Value = DateTime.Now;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM KiemKeVatTu WHERE MaPhieu LIKE @keyword OR MaHangHoa LIKE @keyword";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + txttimkiem.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvkiemke.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void dgvkiemke_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvkiemke.Rows[e.RowIndex];
                txtmaphieu.Text = row.Cells["MaPhieu"].Value.ToString();
                txtmaphieu.ReadOnly = true; // Khóa mã phiếu khi chọn để sửa/xóa
                dtpngaykiemke.Value = Convert.ToDateTime(row.Cells["NgayKiemKe"].Value);
                cbomahanghoa.Text = row.Cells["MaHangHoa"].Value.ToString();
                cbomanhanvien.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtsoluongton.Text = row.Cells["SoLuongTon"].Value.ToString();
                txtsoluongthucte.Text = row.Cells["SoLuongThucTe"].Value.ToString();
                txtchenhlech.Text = row.Cells["ChenhLech"].Value.ToString();
                txtghichu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }
        // 7. Hàm tự động tính chênh lệch (Thực tế - Tồn)
        private void TinhChenhLech(object sender, EventArgs e)
        {
            int ton = 0, thucte = 0;
            int.TryParse(txtsoluongton.Text, out ton);
            int.TryParse(txtsoluongthucte.Text, out thucte);
            int chenhlech = thucte - ton;
            txtchenhlech.Text = chenhlech.ToString();
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {

        }
    }
}
