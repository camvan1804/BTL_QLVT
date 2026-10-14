using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace khách_hàng
{
    public partial class Form2 : Form
    {
        string connectionString =
            @"Data Source=.;Initial Catalog=QL_khovattu2;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDanhSachXuatKho("", "");
        }
        
        // Hàm tải dữ liệu lên DataGridView
        private void LoadDanhSachXuatKho(string maPhieu, string tenVatTu)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_timmaphieu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@maphieuxuat", maPhieu);
                        cmd.Parameters.AddWithValue("@tenhanghoa", tenVatTu);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvdanhsach.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TinhTongTien()
        {
            if (decimal.TryParse(txtsoluong.Text.Trim(), out decimal soluong) &&
                decimal.TryParse(txtdongia.Text.Trim(), out decimal dongia))
            {
                decimal tongTien = soluong * dongia;
                txttongtien.Text = tongTien.ToString("N0"); // Hiển thị định dạng phân cách hàng nghìn
            }
            else
            {
                txttongtien.Text = "0";
            }
        }
        private void txtmanhacungcap_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttimmaphieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnxuatfile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv";
            sfd.FileName = "DanhSachXuatKho.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Lấy tiêu đề cột
                    for (int i = 0; i < dgvdanhsach.Columns.Count; i++)
                    {
                        sb.Append(dgvdanhsach.Columns[i].HeaderText + (i == dgvdanhsach.Columns.Count - 1 ? "" : ","));
                    }
                    sb.AppendLine();

                    // Lấy dữ liệu từng dòng
                    foreach (DataGridViewRow row in dgvdanhsach.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgvdanhsach.Columns.Count; i++)
                            {
                                sb.Append((row.Cells[i].Value?.ToString() ?? "") + (i == dgvdanhsach.Columns.Count - 1 ? "" : ","));
                            }
                            sb.AppendLine();
                        }
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Thêm PhieuXuat 
                    string q1 = "IF NOT EXISTS (SELECT 1 FROM PhieuXuat WHERE maphieuxuat = @maphieuxuat) " +
                                "INSERT INTO PhieuXuat(maphieuxuat, ngayxuat, manhanvien, ghichu) " +
                                "VALUES (@maphieuxuat, @ngayxuat, @manhanvien, @ghichu)";
                    using (SqlCommand cmd1 = new SqlCommand(q1, conn))
                    {
                        cmd1.Parameters.AddWithValue("@maphieuxuat", txtmaphieuxuat.Text.Trim());
                        cmd1.Parameters.AddWithValue("@ngayxuat", dtpngayxuat.Value);
                        cmd1.Parameters.AddWithValue("@manhanvien", txtmanguoilap.Text.Trim());
                        cmd1.Parameters.AddWithValue("@ghichu", txtghichu.Text.Trim());
                        cmd1.ExecuteNonQuery();
                    }

                    // Thêm ChiTietPhieuXuat
                    string q2 = "IF EXISTS (SELECT 1 FROM ChiTietPhieuXuat WHERE maphieuxuat = @maphieuxuat AND mahanghoa = @mahanghoa) " +
            "    UPDATE ChiTietPhieuXuat SET soluong = soluong + @soluong, dongia = @dongia WHERE maphieuxuat = @maphieuxuat AND mahanghoa = @mahanghoa " +
            "ELSE " +
            "    INSERT INTO ChiTietPhieuXuat(maphieuxuat, mahanghoa, soluong, dongia) VALUES (@maphieuxuat, @mahanghoa, @soluong, @dongia)";

                    using (SqlCommand cmd2 = new SqlCommand(q2, conn))
                    {
                        cmd2.Parameters.AddWithValue("@maphieuxuat", txtmaphieuxuat.Text.Trim());
                        cmd2.Parameters.AddWithValue("@mahanghoa", txtmavattu.Text.Trim()); // Sửa lại chữ hoa/thường cho khớp (MaHangHoa hoặc mahanghoa)
                        cmd2.Parameters.AddWithValue("@soluong", int.Parse(txtsoluong.Text.Trim()));
                        cmd2.Parameters.AddWithValue("@dongia", float.Parse(txtdongia.Text.Trim()));
                        cmd2.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachXuatKho("", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvdanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvdanhsach.Rows[e.RowIndex];

                txtmaphieuxuat.Text = row.Cells["Mã phiếu"].Value?.ToString() ?? "";

                if (row.Cells["Ngày xuất"].Value != DBNull.Value && row.Cells["Ngày xuất"].Value != null)
                {
                    dtpngayxuat.Value = Convert.ToDateTime(row.Cells["Ngày xuất"].Value);
                }

                txtmavattu.Text = row.Cells["Mã vật tư"].Value?.ToString() ?? "";
                txttenvattu.Text = row.Cells["Tên vật tư"].Value?.ToString() ?? "";
                txtsoluong.Text = row.Cells["Số lượng"].Value?.ToString() ?? "";
                txtdongia.Text = row.Cells["Đơn giá"].Value?.ToString() ?? "";

            
                txtmanguoilap.Text = row.Cells["Mã nhân viên"].Value?.ToString() ?? "";
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string maPhieu = txttimmaphieu.Text.Trim();
            string maVatTu = txttimmavattu.Text.Trim();

            LoadDanhSachXuatKho(maPhieu, maVatTu);

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Cập nhật bảng PhieuXuat trước
                    string q1 = "UPDATE PhieuXuat SET ngayxuat = @ngayxuat, manhanvien = @manhanvien, ghichu = @ghichu WHERE maphieuxuat = @maphieuxuat";
                    using (SqlCommand cmd1 = new SqlCommand(q1, conn))
                    {
                        cmd1.Parameters.AddWithValue("@maphieuxuat", txtmaphieuxuat.Text.Trim());
                        cmd1.Parameters.AddWithValue("@ngayxuat", dtpngayxuat.Value);
                        cmd1.Parameters.AddWithValue("@manhanvien", txtmanguoilap.Text.Trim());
                        cmd1.Parameters.AddWithValue("@ghichu", txtghichu.Text.Trim());
                        cmd1.ExecuteNonQuery();
                    }

                    // Cập nhật bảng ChiTietPhieuXuat
                    string q2 = "UPDATE ChiTietPhieuXuat SET soluong = @soluong, dongia = @dongia WHERE maphieuxuat = @maphieuxuat AND mahanghoa = @mahanghoa";
                    using (SqlCommand cmd2 = new SqlCommand(q2, conn))
                    {
                        cmd2.Parameters.AddWithValue("@maphieuxuat", txtmaphieuxuat.Text.Trim());
                        cmd2.Parameters.AddWithValue("@mahanghoa", txtmavattu.Text.Trim());
                        cmd2.Parameters.AddWithValue("@soluong", int.Parse(txtsoluong.Text.Trim()));
                        cmd2.Parameters.AddWithValue("@dongia", float.Parse(txtdongia.Text.Trim()));
                        cmd2.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachXuatKho("", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtmaphieuxuat.Text.Trim()))
               {
                MessageBox.Show("Vui lòng chọn phiếu cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ phiếu xuất này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // 1. Xóa chi tiết phiếu xuất trước (để tránh lỗi khóa ngoại)
                        string q1 = "DELETE FROM ChiTietPhieuXuat WHERE maphieuxuat = @maphieuxuat";
                        using (SqlCommand cmd1 = new SqlCommand(q1, conn))
                        {
                            cmd1.Parameters.AddWithValue("@maphieuxuat", txtmaphieuxuat.Text.Trim());
                            cmd1.ExecuteNonQuery();
                        }

                        // 2. Sau đó xóa phiếu xuất chính
                        string q2 = "DELETE FROM PhieuXuat WHERE maphieuxuat = @maphieuxuat";
                        using (SqlCommand cmd2 = new SqlCommand(q2, conn))
                        {
                            cmd2.Parameters.AddWithValue("@maphieuxuat", txtmaphieuxuat.Text.Trim());
                            cmd2.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Xóa phiếu xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachXuatKho("", "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbomanguoilap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }
    }
   }




