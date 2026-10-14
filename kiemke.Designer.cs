namespace baitaplonQLVT
{
    partial class frmkiemke
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbltieude = new System.Windows.Forms.Label();
            this.grpthongtinphieu = new System.Windows.Forms.GroupBox();
            this.btnxoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnsua = new Guna.UI2.WinForms.Guna2Button();
            this.btnlammoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnthem = new Guna.UI2.WinForms.Guna2Button();
            this.dtpngaykiemke = new System.Windows.Forms.DateTimePicker();
            this.cbomanhanvien = new System.Windows.Forms.ComboBox();
            this.cbomahanghoa = new System.Windows.Forms.ComboBox();
            this.txtsoluongton = new System.Windows.Forms.TextBox();
            this.txtsoluongthucte = new System.Windows.Forms.TextBox();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.txtchenhlech = new System.Windows.Forms.TextBox();
            this.txtmaphieu = new System.Windows.Forms.TextBox();
            this.lblchenhlech = new System.Windows.Forms.Label();
            this.lblsoluongthucte = new System.Windows.Forms.Label();
            this.lblsoluongton = new System.Windows.Forms.Label();
            this.lblmanhanvien = new System.Windows.Forms.Label();
            this.lblghichu = new System.Windows.Forms.Label();
            this.lblmahanghoa = new System.Windows.Forms.Label();
            this.lblngaykiemke = new System.Windows.Forms.Label();
            this.lblmaphieu = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.dgvdanhsach = new System.Windows.Forms.DataGridView();
            this.grptimkiem = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.btntimkiem = new Guna.UI2.WinForms.Guna2Button();
            this.btnquaylai = new Guna.UI2.WinForms.Guna2Button();
            this.grpthongtinphieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanhsach)).BeginInit();
            this.grptimkiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltieude
            // 
            this.lbltieude.AutoSize = true;
            this.lbltieude.BackColor = System.Drawing.Color.Transparent;
            this.lbltieude.Font = new System.Drawing.Font("Perpetua Titling MT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbltieude.Location = new System.Drawing.Point(451, 33);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(415, 33);
            this.lbltieude.TabIndex = 1;
            this.lbltieude.Text = "QUẢN LÝ KIỂM KÊ VẬT TƯ";
            // 
            // grpthongtinphieu
            // 
            this.grpthongtinphieu.BackColor = System.Drawing.Color.Transparent;
            this.grpthongtinphieu.Controls.Add(this.btnxoa);
            this.grpthongtinphieu.Controls.Add(this.btnsua);
            this.grpthongtinphieu.Controls.Add(this.btnlammoi);
            this.grpthongtinphieu.Controls.Add(this.btnthem);
            this.grpthongtinphieu.Controls.Add(this.dtpngaykiemke);
            this.grpthongtinphieu.Controls.Add(this.cbomanhanvien);
            this.grpthongtinphieu.Controls.Add(this.cbomahanghoa);
            this.grpthongtinphieu.Controls.Add(this.txtsoluongton);
            this.grpthongtinphieu.Controls.Add(this.txtsoluongthucte);
            this.grpthongtinphieu.Controls.Add(this.txtghichu);
            this.grpthongtinphieu.Controls.Add(this.txtchenhlech);
            this.grpthongtinphieu.Controls.Add(this.txtmaphieu);
            this.grpthongtinphieu.Controls.Add(this.lblchenhlech);
            this.grpthongtinphieu.Controls.Add(this.lblsoluongthucte);
            this.grpthongtinphieu.Controls.Add(this.lblsoluongton);
            this.grpthongtinphieu.Controls.Add(this.lblmanhanvien);
            this.grpthongtinphieu.Controls.Add(this.lblghichu);
            this.grpthongtinphieu.Controls.Add(this.lblmahanghoa);
            this.grpthongtinphieu.Controls.Add(this.lblngaykiemke);
            this.grpthongtinphieu.Controls.Add(this.lblmaphieu);
            this.grpthongtinphieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpthongtinphieu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpthongtinphieu.Location = new System.Drawing.Point(42, 82);
            this.grpthongtinphieu.Name = "grpthongtinphieu";
            this.grpthongtinphieu.Size = new System.Drawing.Size(1422, 200);
            this.grpthongtinphieu.TabIndex = 2;
            this.grpthongtinphieu.TabStop = false;
            this.grpthongtinphieu.Text = "Thông tin phiếu";
            // 
            // btnxoa
            // 
            this.btnxoa.BorderRadius = 15;
            this.btnxoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnxoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnxoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnxoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnxoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnxoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.ForeColor = System.Drawing.Color.White;
            this.btnxoa.Location = new System.Drawing.Point(1099, 92);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(118, 45);
            this.btnxoa.TabIndex = 20;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.BackColor = System.Drawing.Color.Transparent;
            this.btnsua.BorderRadius = 15;
            this.btnsua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnsua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnsua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnsua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnsua.FillColor = System.Drawing.Color.Green;
            this.btnsua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.ForeColor = System.Drawing.Color.White;
            this.btnsua.Location = new System.Drawing.Point(1272, 26);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(118, 45);
            this.btnsua.TabIndex = 19;
            this.btnsua.Text = "Sửa";
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnlammoi
            // 
            this.btnlammoi.BorderRadius = 15;
            this.btnlammoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlammoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlammoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlammoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlammoi.FillColor = System.Drawing.Color.Silver;
            this.btnlammoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlammoi.ForeColor = System.Drawing.Color.White;
            this.btnlammoi.Location = new System.Drawing.Point(1272, 92);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(118, 45);
            this.btnlammoi.TabIndex = 18;
            this.btnlammoi.Text = "Làm mới";
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // btnthem
            // 
            this.btnthem.BorderRadius = 15;
            this.btnthem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnthem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnthem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnthem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnthem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthem.ForeColor = System.Drawing.Color.White;
            this.btnthem.Location = new System.Drawing.Point(1099, 26);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(118, 45);
            this.btnthem.TabIndex = 16;
            this.btnthem.Text = "+ Thêm";
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // dtpngaykiemke
            // 
            this.dtpngaykiemke.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngaykiemke.Location = new System.Drawing.Point(179, 66);
            this.dtpngaykiemke.Name = "dtpngaykiemke";
            this.dtpngaykiemke.Size = new System.Drawing.Size(266, 24);
            this.dtpngaykiemke.TabIndex = 15;
            // 
            // cbomanhanvien
            // 
            this.cbomanhanvien.FormattingEnabled = true;
            this.cbomanhanvien.Location = new System.Drawing.Point(179, 158);
            this.cbomanhanvien.Name = "cbomanhanvien";
            this.cbomanhanvien.Size = new System.Drawing.Size(266, 26);
            this.cbomanhanvien.TabIndex = 14;
            // 
            // cbomahanghoa
            // 
            this.cbomahanghoa.FormattingEnabled = true;
            this.cbomahanghoa.Location = new System.Drawing.Point(179, 111);
            this.cbomahanghoa.Name = "cbomahanghoa";
            this.cbomahanghoa.Size = new System.Drawing.Size(266, 26);
            this.cbomahanghoa.TabIndex = 3;
            // 
            // txtsoluongton
            // 
            this.txtsoluongton.Location = new System.Drawing.Point(746, 25);
            this.txtsoluongton.Name = "txtsoluongton";
            this.txtsoluongton.Size = new System.Drawing.Size(260, 24);
            this.txtsoluongton.TabIndex = 13;
            // 
            // txtsoluongthucte
            // 
            this.txtsoluongthucte.Location = new System.Drawing.Point(746, 65);
            this.txtsoluongthucte.Name = "txtsoluongthucte";
            this.txtsoluongthucte.Size = new System.Drawing.Size(260, 24);
            this.txtsoluongthucte.TabIndex = 12;
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(746, 158);
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(260, 24);
            this.txtghichu.TabIndex = 11;
            // 
            // txtchenhlech
            // 
            this.txtchenhlech.Location = new System.Drawing.Point(746, 111);
            this.txtchenhlech.Name = "txtchenhlech";
            this.txtchenhlech.Size = new System.Drawing.Size(260, 24);
            this.txtchenhlech.TabIndex = 10;
            // 
            // txtmaphieu
            // 
            this.txtmaphieu.Location = new System.Drawing.Point(179, 26);
            this.txtmaphieu.Name = "txtmaphieu";
            this.txtmaphieu.Size = new System.Drawing.Size(266, 24);
            this.txtmaphieu.TabIndex = 9;
            // 
            // lblchenhlech
            // 
            this.lblchenhlech.AutoSize = true;
            this.lblchenhlech.Location = new System.Drawing.Point(582, 117);
            this.lblchenhlech.Name = "lblchenhlech";
            this.lblchenhlech.Size = new System.Drawing.Size(92, 18);
            this.lblchenhlech.TabIndex = 8;
            this.lblchenhlech.Text = "Chênh lệch";
            // 
            // lblsoluongthucte
            // 
            this.lblsoluongthucte.AutoSize = true;
            this.lblsoluongthucte.Location = new System.Drawing.Point(582, 71);
            this.lblsoluongthucte.Name = "lblsoluongthucte";
            this.lblsoluongthucte.Size = new System.Drawing.Size(131, 18);
            this.lblsoluongthucte.TabIndex = 7;
            this.lblsoluongthucte.Text = "Số lượng thực tế";
            // 
            // lblsoluongton
            // 
            this.lblsoluongton.AutoSize = true;
            this.lblsoluongton.Location = new System.Drawing.Point(582, 34);
            this.lblsoluongton.Name = "lblsoluongton";
            this.lblsoluongton.Size = new System.Drawing.Size(104, 18);
            this.lblsoluongton.TabIndex = 6;
            this.lblsoluongton.Text = "Số lượng tồn";
            // 
            // lblmanhanvien
            // 
            this.lblmanhanvien.AutoSize = true;
            this.lblmanhanvien.Location = new System.Drawing.Point(19, 158);
            this.lblmanhanvien.Name = "lblmanhanvien";
            this.lblmanhanvien.Size = new System.Drawing.Size(107, 18);
            this.lblmanhanvien.TabIndex = 5;
            this.lblmanhanvien.Text = "Mã nhân viên";
            // 
            // lblghichu
            // 
            this.lblghichu.AutoSize = true;
            this.lblghichu.Location = new System.Drawing.Point(582, 158);
            this.lblghichu.Name = "lblghichu";
            this.lblghichu.Size = new System.Drawing.Size(66, 18);
            this.lblghichu.TabIndex = 4;
            this.lblghichu.Text = "Ghi chú";
            // 
            // lblmahanghoa
            // 
            this.lblmahanghoa.AutoSize = true;
            this.lblmahanghoa.Location = new System.Drawing.Point(19, 117);
            this.lblmahanghoa.Name = "lblmahanghoa";
            this.lblmahanghoa.Size = new System.Drawing.Size(105, 18);
            this.lblmahanghoa.TabIndex = 2;
            this.lblmahanghoa.Text = "Mã hàng hóa";
            // 
            // lblngaykiemke
            // 
            this.lblngaykiemke.AutoSize = true;
            this.lblngaykiemke.Location = new System.Drawing.Point(19, 72);
            this.lblngaykiemke.Name = "lblngaykiemke";
            this.lblngaykiemke.Size = new System.Drawing.Size(110, 18);
            this.lblngaykiemke.TabIndex = 1;
            this.lblngaykiemke.Text = "Ngày kiểm kê";
            // 
            // lblmaphieu
            // 
            this.lblmaphieu.AutoSize = true;
            this.lblmaphieu.Location = new System.Drawing.Point(19, 31);
            this.lblmaphieu.Name = "lblmaphieu";
            this.lblmaphieu.Size = new System.Drawing.Size(76, 18);
            this.lblmaphieu.TabIndex = 0;
            this.lblmaphieu.Text = "Mã phiếu";
            // 
            // dgvdanhsach
            // 
            this.dgvdanhsach.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvdanhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdanhsach.Location = new System.Drawing.Point(42, 288);
            this.dgvdanhsach.Name = "dgvdanhsach";
            this.dgvdanhsach.RowHeadersWidth = 51;
            this.dgvdanhsach.RowTemplate.Height = 24;
            this.dgvdanhsach.Size = new System.Drawing.Size(1217, 322);
            this.dgvdanhsach.TabIndex = 15;
            // 
            // grptimkiem
            // 
            this.grptimkiem.BackColor = System.Drawing.Color.Transparent;
            this.grptimkiem.Controls.Add(this.txttimkiem);
            this.grptimkiem.Controls.Add(this.btntimkiem);
            this.grptimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grptimkiem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grptimkiem.Location = new System.Drawing.Point(1265, 288);
            this.grptimkiem.Name = "grptimkiem";
            this.grptimkiem.Size = new System.Drawing.Size(199, 149);
            this.grptimkiem.TabIndex = 16;
            this.grptimkiem.TabStop = false;
            this.grptimkiem.Text = "Tìm kiếm";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(7, 41);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(183, 24);
            this.txttimkiem.TabIndex = 18;
            // 
            // btntimkiem
            // 
            this.btntimkiem.BorderRadius = 15;
            this.btntimkiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btntimkiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btntimkiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btntimkiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btntimkiem.FillColor = System.Drawing.Color.Teal;
            this.btntimkiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.ForeColor = System.Drawing.Color.White;
            this.btntimkiem.Location = new System.Drawing.Point(7, 84);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(183, 45);
            this.btntimkiem.TabIndex = 17;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnquaylai
            // 
            this.btnquaylai.BackColor = System.Drawing.Color.Transparent;
            this.btnquaylai.BorderRadius = 15;
            this.btnquaylai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnquaylai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnquaylai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnquaylai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnquaylai.FillColor = System.Drawing.Color.Olive;
            this.btnquaylai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnquaylai.ForeColor = System.Drawing.Color.White;
            this.btnquaylai.Location = new System.Drawing.Point(1300, 521);
            this.btnquaylai.Name = "btnquaylai";
            this.btnquaylai.Size = new System.Drawing.Size(132, 45);
            this.btnquaylai.TabIndex = 17;
            this.btnquaylai.Text = "Quay lại";
            // 
            // frmkiemke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ktv_quanlikiemke.Properties.Resources._1791567112102_4097022809652839946_g7491982391230708265_aa0ecd5958cc05397fc2d9ba7314df6f;
            this.ClientSize = new System.Drawing.Size(1520, 699);
            this.Controls.Add(this.btnquaylai);
            this.Controls.Add(this.grptimkiem);
            this.Controls.Add(this.dgvdanhsach);
            this.Controls.Add(this.grpthongtinphieu);
            this.Controls.Add(this.lbltieude);
            this.Name = "frmkiemke";
            this.Text = "quanlikiemke";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpthongtinphieu.ResumeLayout(false);
            this.grpthongtinphieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanhsach)).EndInit();
            this.grptimkiem.ResumeLayout(false);
            this.grptimkiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltieude;
        private System.Windows.Forms.GroupBox grpthongtinphieu;
        private System.Windows.Forms.DateTimePicker dtpngaykiemke;
        private System.Windows.Forms.ComboBox cbomanhanvien;
        private System.Windows.Forms.ComboBox cbomahanghoa;
        private System.Windows.Forms.TextBox txtsoluongton;
        private System.Windows.Forms.TextBox txtsoluongthucte;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txtchenhlech;
        private System.Windows.Forms.TextBox txtmaphieu;
        private System.Windows.Forms.Label lblchenhlech;
        private System.Windows.Forms.Label lblsoluongthucte;
        private System.Windows.Forms.Label lblsoluongton;
        private System.Windows.Forms.Label lblmanhanvien;
        private System.Windows.Forms.Label lblghichu;
        private System.Windows.Forms.Label lblmahanghoa;
        private System.Windows.Forms.Label lblngaykiemke;
        private System.Windows.Forms.Label lblmaphieu;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridView dgvdanhsach;
        private System.Windows.Forms.GroupBox grptimkiem;
        private System.Windows.Forms.TextBox txttimkiem;
        private Guna.UI2.WinForms.Guna2Button btnxoa;
        private Guna.UI2.WinForms.Guna2Button btnsua;
        private Guna.UI2.WinForms.Guna2Button btnlammoi;
        private Guna.UI2.WinForms.Guna2Button btnthem;
        private Guna.UI2.WinForms.Guna2Button btntimkiem;
        private Guna.UI2.WinForms.Guna2Button btnquaylai;
    }
}

