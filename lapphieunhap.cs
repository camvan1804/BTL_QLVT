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

namespace baitaplonQLVT
{
    public partial class quanlyphieunhap : Form

    {
        string str = @"Data Source=.;Initial Catalog=QL_khovattu3;Integrated Security=True";
        public quanlyphieunhap()
        {
            InitializeComponent();
        }

        private void LoadDanhSachPhieuNhap()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT pn.MaPhieuNhap, pn.NgayNhap, ncc.TenNhaCungCap, nv.TenNhanVien, pn.GhiChu, " +
                             "(SELECT SUM(ct.SoLuong * ct.DonGia) FROM ChiTietPhieuNhap ct WHERE ct.MaPhieuNhap = pn.MaPhieuNhap) AS TongTien " +
                             "FROM PhieuNhap pn " +
                             "JOIN NhaCungCap ncc ON pn.MaNhaCungCap = ncc.MaNhaCungCap " +
                             "JOIN NhanVien nv ON pn.MaNhanVien = nv.MaNhanVien " +
                             "WHERE pn.NgayNhap BETWEEN @tuNgay AND @denNgay";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@tuNgay", SqlDbType.Date).Value = dtptungay.Value.Date;
                cmd.Parameters.Add("@denNgay", SqlDbType.Date).Value = dtpdenngay.Value.Date;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvphieunhap.DataSource = dt;
                if (dgvphieunhap.Rows.Count > 0)
                {
                    string maPhieuDauTien = dgvphieunhap.Rows[0].Cells["MaPhieuNhap"].Value.ToString();
                    LoadChiTietPhieuNhap(maPhieuDauTien);
                }
                else
                {
                    dgvchitietphieunhap.DataSource = null;
                }
            }
        }
        // Đổ dữ liệu cho ComboBox Phiếu Nhập (Mã phiếu và Ghi chú/Mã phiếu)
        private void LoadComboBoxPhieuNhap()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT MaPhieuNhap, GhiChu FROM PhieuNhap";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // ComboBox mã phiếu nhập
                cbomaphieunhap.DataSource = dt;
                cbomaphieunhap.DisplayMember = "MaPhieuNhap";
                cbomaphieunhap.ValueMember = "MaPhieuNhap";
                cbomaphieunhap.SelectedIndex = -1;
                cbomaphieunhap.Text = "";
                // ComboBox ghi chú hoặc mã phiếu tương ứng (hoặc tùy chỉnh cột hiển thị)

            }
        }
        
        
        

        // Đổ dữ liệu cho ComboBox Vật Tư (Mã vật tư và Tên vật tư)
        private void LoadComboBoxVatTu()
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT MaHangHoa, TenHangHoa FROM HangHoa";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // ComboBox mã vật tư
                cbomavattu.DataSource = dt;
                cbomavattu.DisplayMember = "MaHangHoa";
                cbomavattu.ValueMember = "MaHangHoa";
                cbomavattu.SelectedIndex = -1;
                cbomavattu.Text = "";

            }
        }
        private void ResetBoLoc()
        {
            cbomaphieunhap.SelectedIndex = -1;
            cbomaphieunhap.Text = "";

            cbomavattu.SelectedIndex = -1;
            cbomavattu.Text = "";

            // Nếu bạn có thêm các ComboBox khác thì reset luôn tại đây
           

           
        }
        private void LoadChiTietPhieuNhap(string maPhieuNhap, string maVatTu = null)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string sql = "SELECT ct.MaHangHoa, h.TenHangHoa, h.DonViTinh, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien " +
                             "FROM ChiTietPhieuNhap ct " +
                             "JOIN HangHoa h ON ct.MaHangHoa = h.MaHangHoa " +
                             "WHERE ct.MaPhieuNhap = @maPhieu";

                // Chỉ lọc đúng mã vật tư nếu có truyền vào
                if (!string.IsNullOrWhiteSpace(maVatTu))
                {
                    sql += " AND ct.MaHangHoa = @maVatTu";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@maPhieu", SqlDbType.VarChar, 20).Value = maPhieuNhap;

                if (!string.IsNullOrWhiteSpace(maVatTu))
                {
                    cmd.Parameters.Add("@maVatTu", SqlDbType.VarChar, 20).Value = maVatTu;
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvchitietphieunhap.DataSource = dt;
            }
        }

        private void Lập_phiếu_nhập_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void dgvphieunhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0 && i < dgvphieunhap.Rows.Count)
            {
                string maPhieu = dgvphieunhap.Rows[i].Cells["MaPhieuNhap"].Value.ToString();
                LoadChiTietPhieuNhap(maPhieu);
            }
        }*/
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            LoadDanhSachPhieuNhap();
        }


        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgvphieunhap.SelectedRows.Count == 0 && dgvphieunhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập cần hủy/xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhieu = dgvphieunhap.CurrentRow.Cells["MaPhieuNhap"].Value.ToString();

            DialogResult kq = MessageBox.Show($"Bạn có chắc chắn muốn hủy phiếu nhập [{maPhieu}] không?\n(Thao tác này sẽ trừ ngược lại số lượng tồn kho của các mặt hàng trong phiếu)",
                "Xác nhận hủy phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Bước A: Lấy danh sách các mặt hàng và số lượng trong phiếu để trừ kho
                        string sqlGetCT = "SELECT MaHangHoa, SoLuong FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @maphieu";
                        DataTable dtCT = new DataTable();
                        using (SqlCommand cmdGet = new SqlCommand(sqlGetCT, conn, transaction))
                        {
                            cmdGet.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maPhieu;
                            SqlDataAdapter da = new SqlDataAdapter(cmdGet);
                            da.Fill(dtCT);
                        }

                        // Bước B: Trừ ngược lại số lượng tồn kho trong bảng HangHoa
                        foreach (DataRow row in dtCT.Rows)
                        {
                            string maHH = row["MaHangHoa"].ToString();
                            int slXoa = Convert.ToInt32(row["SoLuong"]);

                            string sqlUpdateKho = "UPDATE HangHoa SET SoLuong = SoLuong - @soluong WHERE MaHangHoa = @mahh";
                            using (SqlCommand cmdUpKho = new SqlCommand(sqlUpdateKho, conn, transaction))
                            {
                                cmdUpKho.Parameters.Add("@soluong", SqlDbType.Int).Value = slXoa;
                                cmdUpKho.Parameters.Add("@mahh", SqlDbType.VarChar, 20).Value = maHH;
                                cmdUpKho.ExecuteNonQuery();
                            }
                        }

                        // Bước C: Xóa dữ liệu trong bảng ChiTietPhieuNhap
                        string sqlDelCT = "DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @maphieu";
                        using (SqlCommand cmdDelCT = new SqlCommand(sqlDelCT, conn, transaction))
                        {
                            cmdDelCT.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maPhieu;
                            cmdDelCT.ExecuteNonQuery();
                        }

                        // Bước D: Xóa dữ liệu trong bảng PhieuNhap
                        string sqlDelPN = "DELETE FROM PhieuNhap WHERE MaPhieuNhap = @maphieu";
                        using (SqlCommand cmdDelPN = new SqlCommand(sqlDelPN, conn, transaction))
                        {
                            cmdDelPN.Parameters.Add("@maphieu", SqlDbType.VarChar, 20).Value = maPhieu;
                            cmdDelPN.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Đã hủy phiếu nhập và cập nhật lại kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachPhieuNhap(); // Tải lại danh sách
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi hủy phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnthem_Click_1(object sender, EventArgs e)
        {
            form2 frm = new form2();
            frm.ShowDialog(); // Mở form lập phiếu nhập
            LoadDanhSachPhieuNhap();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            dtptungay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpdenngay.Value = DateTime.Now;

            LoadDanhSachPhieuNhap();
            ResetBoLoc();
        }

        private void quanlyphieunhap_Load(object sender, EventArgs e)
        {
            dtptungay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpdenngay.Value = DateTime.Now;
            


            // Tải danh sách phiếu nhập lên bảng Master
            LoadDanhSachPhieuNhap();
            LoadComboBoxPhieuNhap();
           
           
            LoadComboBoxVatTu();
        }

        private void dgvphieunhap_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvphieunhap.Rows[e.RowIndex];

                var cellValue = row.Cells["MaPhieuNhap"].Value;
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    string maPhieu = cellValue.ToString();

                    // Lấy mã vật tư đang chọn trên ComboBox phía trên
                    string maVatTuDangChon = cbomavattu != null && cbomavattu.SelectedValue != null ? cbomavattu.SelectedValue.ToString().Trim() : "";

                    // Nếu người dùng chọn "System.Data.DataRowView" hoặc để trống thì coi như không lọc theo vật tư
                    if (maVatTuDangChon == "System.Data.DataRowView")
                    {
                        maVatTuDangChon = "";
                    }

                    // Truyền cả mã phiếu và mã vật tư đang chọn xuống hàm load chi tiết
                    LoadChiTietPhieuNhap(maPhieu, maVatTuDangChon);
                }
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                // 1. Lấy giá trị từ cả 2 ComboBox (Mã phiếu và Mã vật tư)
                string maPhieu = cbomaphieunhap != null && cbomaphieunhap.SelectedValue != null ? cbomaphieunhap.SelectedValue.ToString().Trim() : "";
                string maVatTu = cbomavattu != null && cbomavattu.SelectedValue != null ? cbomavattu.SelectedValue.ToString().Trim() : "";

                bool chonMaPhieu = !string.IsNullOrEmpty(maPhieu) && maPhieu != "System.Data.DataRowView";
                bool chonMaVatTu = !string.IsNullOrEmpty(maVatTu) && maVatTu != "System.Data.DataRowView";

                // Nếu người dùng chưa chọn cái nào cả thì báo lỗi
                if (!chonMaPhieu && !chonMaVatTu)
                {
                    MessageBox.Show("Vui lòng chọn Mã phiếu nhập hoặc Mã vật tư cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Xây dựng câu lệnh SQL linh hoạt theo lựa chọn của người dùng
                string sql = "SELECT DISTINCT pn.MaPhieuNhap, pn.NgayNhap, pn.GhiChu, " +
                             "(SELECT SUM(ct.SoLuong * ct.DonGia) FROM ChiTietPhieuNhap ct WHERE ct.MaPhieuNhap = pn.MaPhieuNhap) AS TongTien " +
                             "FROM PhieuNhap pn ";

                // Nếu có chọn mã vật tư thì mới JOIN thêm bảng ChiTietPhieuNhap
                if (chonMaVatTu)
                {
                    sql += "JOIN ChiTietPhieuNhap ctpn ON pn.MaPhieuNhap = ctpn.MaPhieuNhap ";
                }

                sql += "WHERE 1=1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // Thêm điều kiện Mã phiếu nếu người dùng chọn
                if (chonMaPhieu)
                {
                    sql += " AND pn.MaPhieuNhap = @maPhieu";
                    cmd.Parameters.Add("@maPhieu", SqlDbType.VarChar, 20).Value = maPhieu;
                }

                // Thêm điều kiện Mã vật tư nếu người dùng chọn
                if (chonMaVatTu)
                {
                    sql += " AND ctpn.MaHangHoa = @maVatTu";
                    cmd.Parameters.Add("@maVatTu", SqlDbType.VarChar, 20).Value = maVatTu;
                }

                cmd.CommandText = sql;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvphieunhap.DataSource = dt;

                // 3. Tự động load bảng chi tiết cho dòng đầu tiên tìm được
                if (dgvphieunhap.Rows.Count > 0)
                {
                    var cellValue = dgvphieunhap.Rows[0].Cells["MaPhieuNhap"].Value;
                    if (cellValue != null && cellValue != DBNull.Value)
                    {
                        string maPhieuDauTien = cellValue.ToString();

                        // Nếu tìm theo mã vật tư thì truyền thêm mã vật tư để lọc đúng dòng, ngược lại chỉ truyền mã phiếu
                        if (chonMaVatTu)
                        {
                            LoadChiTietPhieuNhap(maPhieuDauTien, maVatTu);
                        }
                        else
                        {
                            LoadChiTietPhieuNhap(maPhieuDauTien);
                        }
                    }
                    else
                    {
                        dgvchitietphieunhap.DataSource = null;
                    }
                }
                else
                {
                    dgvchitietphieunhap.DataSource = null;
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        
    }
    }

