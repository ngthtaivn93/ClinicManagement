namespace prjClient
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.rbnControl = new System.Windows.Forms.Ribbon();
            this.rbtnThongTinPK = new System.Windows.Forms.RibbonOrbMenuItem();
            this.rbtnThoat = new System.Windows.Forms.RibbonOrbMenuItem();
            this.rbnTab = new System.Windows.Forms.RibbonTab();
            this.rpnlTaiKhoan = new System.Windows.Forms.RibbonPanel();
            this.rbtnDangNhap = new System.Windows.Forms.RibbonButton();
            this.rbtnThongTinNV = new System.Windows.Forms.RibbonButton();
            this.rpnlTiepNhanThuNgan = new System.Windows.Forms.RibbonPanel();
            this.rbtnTiepNhan = new System.Windows.Forms.RibbonButton();
            this.rbtnThuNgan = new System.Windows.Forms.RibbonButton();
            this.rpnlKhamBenh = new System.Windows.Forms.RibbonPanel();
            this.rbtnKhamBenh = new System.Windows.Forms.RibbonButton();
            this.rbtnXetNghiem = new System.Windows.Forms.RibbonButton();
            this.rbtnCDHA = new System.Windows.Forms.RibbonButton();
            this.rpnlThuoc = new System.Windows.Forms.RibbonPanel();
            this.rbtnPhatThuoc = new System.Windows.Forms.RibbonButton();
            this.rbtmQLThuoc = new System.Windows.Forms.RibbonButton();
            this.rpnlQuanTri = new System.Windows.Forms.RibbonPanel();
            this.rbtnQLNhanVien = new System.Windows.Forms.RibbonButton();
            this.rbtnQLDichVu = new System.Windows.Forms.RibbonButton();
            this.rbtnQLPhongKham = new System.Windows.Forms.RibbonButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelHoTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbnControl
            // 
            this.rbnControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbnControl.Location = new System.Drawing.Point(0, 0);
            this.rbnControl.Minimized = false;
            this.rbnControl.Name = "rbnControl";
            // 
            // 
            // 
            this.rbnControl.OrbDropDown.BorderRoundness = 8;
            this.rbnControl.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.rbnControl.OrbDropDown.MenuItems.Add(this.rbtnThongTinPK);
            this.rbnControl.OrbDropDown.MenuItems.Add(this.rbtnThoat);
            this.rbnControl.OrbDropDown.Name = "";
            this.rbnControl.OrbDropDown.Size = new System.Drawing.Size(527, 160);
            this.rbnControl.OrbDropDown.TabIndex = 0;
            this.rbnControl.OrbImage = null;
            this.rbnControl.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.rbnControl.OrbText = "Hệ thống";
            this.rbnControl.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.rbnControl.Size = new System.Drawing.Size(1354, 146);
            this.rbnControl.TabIndex = 0;
            this.rbnControl.Tabs.Add(this.rbnTab);
            this.rbnControl.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.rbnControl.Text = "ribbon1";
            this.rbnControl.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // rbtnThongTinPK
            // 
            this.rbtnThongTinPK.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnThongTinPK.Image = ((System.Drawing.Image)(resources.GetObject("rbtnThongTinPK.Image")));
            this.rbtnThongTinPK.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnThongTinPK.SmallImage")));
            this.rbtnThongTinPK.Text = "Thông tin phòng khám";
            this.rbtnThongTinPK.Click += new System.EventHandler(this.rbtnThongTinPK_Click);
            // 
            // rbtnThoat
            // 
            this.rbtnThoat.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnThoat.Image = ((System.Drawing.Image)(resources.GetObject("rbtnThoat.Image")));
            this.rbtnThoat.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnThoat.SmallImage")));
            this.rbtnThoat.Text = "Thoát";
            this.rbtnThoat.Click += new System.EventHandler(this.rbtnThoat_Click);
            // 
            // rbnTab
            // 
            this.rbnTab.Panels.Add(this.rpnlTaiKhoan);
            this.rbnTab.Panels.Add(this.rpnlTiepNhanThuNgan);
            this.rbnTab.Panels.Add(this.rpnlKhamBenh);
            this.rbnTab.Panels.Add(this.rpnlThuoc);
            this.rbnTab.Panels.Add(this.rpnlQuanTri);
            this.rbnTab.Text = "Chức năng";
            // 
            // rpnlTaiKhoan
            // 
            this.rpnlTaiKhoan.Items.Add(this.rbtnDangNhap);
            this.rpnlTaiKhoan.Items.Add(this.rbtnThongTinNV);
            this.rpnlTaiKhoan.Text = "Tài khoản";
            // 
            // rbtnDangNhap
            // 
            this.rbtnDangNhap.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDangNhap.Image")));
            this.rbtnDangNhap.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtnDangNhap.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDangNhap.SmallImage")));
            this.rbtnDangNhap.Text = "Đăng nhập";
            this.rbtnDangNhap.Click += new System.EventHandler(this.rbtnDangNhap_Click);
            // 
            // rbtnThongTinNV
            // 
            this.rbtnThongTinNV.Enabled = false;
            this.rbtnThongTinNV.Image = ((System.Drawing.Image)(resources.GetObject("rbtnThongTinNV.Image")));
            this.rbtnThongTinNV.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtnThongTinNV.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnThongTinNV.SmallImage")));
            this.rbtnThongTinNV.Text = "Thông tin";
            this.rbtnThongTinNV.Click += new System.EventHandler(this.rbtnThongTinNV_Click);
            // 
            // rpnlTiepNhanThuNgan
            // 
            this.rpnlTiepNhanThuNgan.Items.Add(this.rbtnTiepNhan);
            this.rpnlTiepNhanThuNgan.Items.Add(this.rbtnThuNgan);
            this.rpnlTiepNhanThuNgan.Text = "Tiếp nhận - thu ngân";
            // 
            // rbtnTiepNhan
            // 
            this.rbtnTiepNhan.Enabled = false;
            this.rbtnTiepNhan.Image = ((System.Drawing.Image)(resources.GetObject("rbtnTiepNhan.Image")));
            this.rbtnTiepNhan.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtnTiepNhan.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnTiepNhan.SmallImage")));
            this.rbtnTiepNhan.Text = "Tiếp nhận";
            this.rbtnTiepNhan.Click += new System.EventHandler(this.rbtnTiepNhan_Click);
            // 
            // rbtnThuNgan
            // 
            this.rbtnThuNgan.Enabled = false;
            this.rbtnThuNgan.Image = ((System.Drawing.Image)(resources.GetObject("rbtnThuNgan.Image")));
            this.rbtnThuNgan.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtnThuNgan.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnThuNgan.SmallImage")));
            this.rbtnThuNgan.Text = "Thu ngân";
            this.rbtnThuNgan.Click += new System.EventHandler(this.rbtnThuNgan_Click);
            // 
            // rpnlKhamBenh
            // 
            this.rpnlKhamBenh.Items.Add(this.rbtnKhamBenh);
            this.rpnlKhamBenh.Items.Add(this.rbtnXetNghiem);
            this.rpnlKhamBenh.Items.Add(this.rbtnCDHA);
            this.rpnlKhamBenh.Text = "Khám bệnh";
            // 
            // rbtnKhamBenh
            // 
            this.rbtnKhamBenh.Enabled = false;
            this.rbtnKhamBenh.Image = ((System.Drawing.Image)(resources.GetObject("rbtnKhamBenh.Image")));
            this.rbtnKhamBenh.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtnKhamBenh.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnKhamBenh.SmallImage")));
            this.rbtnKhamBenh.Text = "Khám";
            this.rbtnKhamBenh.Click += new System.EventHandler(this.rbtnKhamBenh_Click);
            // 
            // rbtnXetNghiem
            // 
            this.rbtnXetNghiem.Enabled = false;
            this.rbtnXetNghiem.Image = ((System.Drawing.Image)(resources.GetObject("rbtnXetNghiem.Image")));
            this.rbtnXetNghiem.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtnXetNghiem.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnXetNghiem.SmallImage")));
            this.rbtnXetNghiem.Text = "Xét nghiệm";
            this.rbtnXetNghiem.Click += new System.EventHandler(this.rbtnXetNghiem_Click);
            // 
            // rbtnCDHA
            // 
            this.rbtnCDHA.Enabled = false;
            this.rbtnCDHA.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCDHA.Image")));
            this.rbtnCDHA.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtnCDHA.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCDHA.SmallImage")));
            this.rbtnCDHA.Text = "Chẩn đoán HA";
            this.rbtnCDHA.Click += new System.EventHandler(this.rbtnCDHA_Click);
            // 
            // rpnlThuoc
            // 
            this.rpnlThuoc.Items.Add(this.rbtnPhatThuoc);
            this.rpnlThuoc.Items.Add(this.rbtmQLThuoc);
            this.rpnlThuoc.Text = "Thuốc";
            // 
            // rbtnPhatThuoc
            // 
            this.rbtnPhatThuoc.Enabled = false;
            this.rbtnPhatThuoc.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPhatThuoc.Image")));
            this.rbtnPhatThuoc.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtnPhatThuoc.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPhatThuoc.SmallImage")));
            this.rbtnPhatThuoc.Text = "Phát thuốc";
            this.rbtnPhatThuoc.Click += new System.EventHandler(this.rbtnPhatThuoc_Click);
            // 
            // rbtmQLThuoc
            // 
            this.rbtmQLThuoc.Enabled = false;
            this.rbtmQLThuoc.Image = ((System.Drawing.Image)(resources.GetObject("rbtmQLThuoc.Image")));
            this.rbtmQLThuoc.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtmQLThuoc.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtmQLThuoc.SmallImage")));
            this.rbtmQLThuoc.Text = "QL thuốc";
            this.rbtmQLThuoc.Click += new System.EventHandler(this.rbtmQLThuoc_Click);
            // 
            // rpnlQuanTri
            // 
            this.rpnlQuanTri.Items.Add(this.rbtnQLNhanVien);
            this.rpnlQuanTri.Items.Add(this.rbtnQLDichVu);
            this.rpnlQuanTri.Items.Add(this.rbtnQLPhongKham);
            this.rpnlQuanTri.Text = "Quản trị";
            // 
            // rbtnQLNhanVien
            // 
            this.rbtnQLNhanVien.Enabled = false;
            this.rbtnQLNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("rbtnQLNhanVien.Image")));
            this.rbtnQLNhanVien.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtnQLNhanVien.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnQLNhanVien.SmallImage")));
            this.rbtnQLNhanVien.Text = "Nhân viên";
            this.rbtnQLNhanVien.Click += new System.EventHandler(this.rbtnQLNhanVien_Click);
            // 
            // rbtnQLDichVu
            // 
            this.rbtnQLDichVu.Enabled = false;
            this.rbtnQLDichVu.Image = ((System.Drawing.Image)(resources.GetObject("rbtnQLDichVu.Image")));
            this.rbtnQLDichVu.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtnQLDichVu.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnQLDichVu.SmallImage")));
            this.rbtnQLDichVu.Text = "Dịch vụ";
            this.rbtnQLDichVu.Click += new System.EventHandler(this.rbtnQLDichVu_Click);
            // 
            // rbtnQLPhongKham
            // 
            this.rbtnQLPhongKham.Enabled = false;
            this.rbtnQLPhongKham.Image = ((System.Drawing.Image)(resources.GetObject("rbtnQLPhongKham.Image")));
            this.rbtnQLPhongKham.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbtnQLPhongKham.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnQLPhongKham.SmallImage")));
            this.rbtnQLPhongKham.Text = "Phòng khám";
            this.rbtnQLPhongKham.Click += new System.EventHandler(this.rbtmQLPhongKham_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTen,
            this.toolStripStatusLabelHoTen});
            this.statusStrip.Location = new System.Drawing.Point(0, 670);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1354, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabelTen
            // 
            this.toolStripStatusLabelTen.Name = "toolStripStatusLabelTen";
            this.toolStripStatusLabelTen.Size = new System.Drawing.Size(85, 17);
            this.toolStripStatusLabelTen.Text = "Tên tài khoản: ";
            // 
            // toolStripStatusLabelHoTen
            // 
            this.toolStripStatusLabelHoTen.Name = "toolStripStatusLabelHoTen";
            this.toolStripStatusLabelHoTen.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabelHoTen.Text = "Họ và tên: ";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 692);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.rbnControl);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phòng khám tư";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon rbnControl;
        private System.Windows.Forms.RibbonTab rbnTab;
        private System.Windows.Forms.RibbonPanel rpnlTaiKhoan;
        private System.Windows.Forms.RibbonButton rbtnDangNhap;
        private System.Windows.Forms.RibbonButton rbtnThongTinNV;
        private System.Windows.Forms.RibbonPanel rpnlTiepNhanThuNgan;
        private System.Windows.Forms.RibbonButton rbtnTiepNhan;
        private System.Windows.Forms.RibbonButton rbtnThuNgan;
        private System.Windows.Forms.RibbonPanel rpnlKhamBenh;
        private System.Windows.Forms.RibbonButton rbtnKhamBenh;
        private System.Windows.Forms.RibbonButton rbtnXetNghiem;
        private System.Windows.Forms.RibbonButton rbtnCDHA;
        private System.Windows.Forms.RibbonPanel rpnlThuoc;
        private System.Windows.Forms.RibbonButton rbtnPhatThuoc;
        private System.Windows.Forms.RibbonButton rbtmQLThuoc;
        private System.Windows.Forms.RibbonPanel rpnlQuanTri;
        private System.Windows.Forms.RibbonButton rbtnQLNhanVien;
        private System.Windows.Forms.RibbonButton rbtnQLDichVu;
        private System.Windows.Forms.RibbonButton rbtnQLPhongKham;
        private System.Windows.Forms.RibbonOrbMenuItem rbtnThongTinPK;
        private System.Windows.Forms.RibbonOrbMenuItem rbtnThoat;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelHoTen;
    }
}