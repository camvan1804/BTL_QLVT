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
using System.Data.SqlClient;
namespace BTL_QLKVT
{
    public partial class frmTrangChu : Form
    {
        string str = @"Data Source=.;Initial Catalog=QLY_KHOVATTU;Integrated Security=True";
        public frmTrangChu()
        {
            InitializeComponent();
            LoadDanhSachVatTu();
        }
        void LoadDanhSachVatTu()
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            string sql = "SELECT * FROM HangHoa";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvdanhsachvattu.DataSource = dt;
            conn.Close();
        }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnquanlytaikhoan_Click(object sender, EventArgs e)
        {

        }

        private void dgvdanhsachvattu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            frmdangnhap f = new frmdangnhap();
            f.Show();
            this.Hide();
        }

        private void btnnhacungcap_Click_1(object sender, EventArgs e)
        {
            frmNhaCungCap f = new frmNhaCungCap();
            f.Show();
            this.Hide();
        }

        private void btnbaocaothongke_Click(object sender, EventArgs e)
        {
            frmbaocaothongke f = new frmbaocaothongke();
            f.Show();
            this.Hide();
        }
    }
}