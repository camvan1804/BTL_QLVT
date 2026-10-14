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
    public partial class frmbaocaothongke : Form
    {
        string str = @"Data Source=.;Initial Catalog=QLY_KHOVATTU;Integrated Security=True";
        public frmbaocaothongke()
        {
            InitializeComponent();
            LoadCacLoaiBaoCao();
        }
        void LoadCacLoaiBaoCao()
        {
            // Đưa 2 loại báo cáo vào danh sách thả xuống
            cboloaibaocao.Items.Add("Báo cáo tồn kho hiện tại");
            cboloaibaocao.Items.Add("Báo cáo vật tư sắp hết (Số lượng <= 10)");

            // Chọn sẵn dòng đầu tiên để ô không bị trống
            cboloaibaocao.SelectedIndex = 0;
        }
        private void btnthongke_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            string sql = "";

            // Kiểm tra xem người dùng đang chọn loại báo cáo nào
            if (cboloaibaocao.Text == "Báo cáo tồn kho hiện tại")
            {
                // Lấy toàn bộ hàng hóa trong kho
                sql = "SELECT * FROM HangHoa";
            }
            else if (cboloaibaocao.Text == "Báo cáo vật tư sắp hết (Số lượng <= 10)")
            {
                // Lọc những hàng hóa có số lượng từ 10 trở xuống
                sql = "SELECT * FROM HangHoa WHERE SoLuong <= 10";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Đổ dữ liệu tìm được lên bảng
            dgvbaocao.DataSource = dt;

            // Đếm xem có bao nhiêu dòng và in ra chữ màu vàng
            lbltongdong.Text = "Tổng số mặt hàng: " + dt.Rows.Count.ToString();

            conn.Close();
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            frmTrangChu f = new frmTrangChu();
            f.Show();
            this.Hide();
        }
    }
}
