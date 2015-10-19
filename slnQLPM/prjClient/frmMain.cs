using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace prjClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public partial class frmMain : RibbonForm, svcRefQLPM.IQLPMCallback
    {
        private svcRefQLPM.NhanVien[] _dsNhanVien;
        private svcRefQLPM.ChucNang[] _dsChucNang;
        private svcRefQLPM.TrangThaiNV[] _dsTrangThaiNV;

        private svcRefQLPM.QLPMClient _proxy;
        // Thông tin nhân viên hiện tại
        private svcRefQLPM.NhanVien _nhanVien_HienTai;
        private svcRefQLPM.ChucNang[] _dsChucNang_By_taikhoanNV_HienTai;

        public delegate void frmThongTinNV_ThongTinNV(svcRefQLPM.NhanVien nhanVien, svcRefQLPM.ChucNang[] dsChucNang_By_taikhoanNV);
        public delegate void frmDangNhap_DangNhapFail();
        public delegate void frmThongTinPK_TTPhongKham(svcRefQLPM.ThongTinPhongKham ttPhongKham);
        public delegate void frmQLNhanVien_dsNhanVien(svcRefQLPM.NhanVien[] dsNhanVien);
        public delegate void frmQLNhanVien_dsChucNang_By_taikhoanNV(svcRefQLPM.ChucNang[] dSChucNang_By_taikhoanNV);
        public delegate void frmQLNhanVien_dsNhanVien_By_taikhoanNV(svcRefQLPM.NhanVien[] dsNhanVien_By_taikhoanNV);
        public delegate void frmQLNHanVien_AddResponse(string taikhoanNV);
        public delegate void frmTiepNhan_dsDichVu_By_ChucNang(svcRefQLPM.DichVu[] dsDichVu);
        public delegate void frmTiepNhan_dsBenhNhan(svcRefQLPM.BenhNhan[] dsBenhNhan);

        public frmMain()
        {
            InitializeComponent();
            _proxy = new svcRefQLPM.QLPMClient(new InstanceContext(this));
            _nhanVien_HienTai = new svcRefQLPM.NhanVien();
            _dsNhanVien = new svcRefQLPM.NhanVien[0];
            _dsChucNang = new svcRefQLPM.ChucNang[0];
            _dsTrangThaiNV = new svcRefQLPM.TrangThaiNV[0];
            _dsChucNang_By_taikhoanNV_HienTai = new svcRefQLPM.ChucNang[0];
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Lấy danh sách chức năng đưa vào _dsChucNang
            _proxy.Get_dsChucNang();

            // Lấy danh sách trạng thái nhân viên đưa vào _dsTrangThaiNV
            _proxy.Get_dsTrangThaiNV();
            rbtnDangNhap.PerformClick();
        }

        #region Truyen nhan du lieu
        // Form Thong tin phong kham
        public void Gui_frmThongTinPK_TTPhongKham(svcRefQLPM.ThongTinPhongKham ttPhongKham)
        {
            frmThongTinPK frm = Application.OpenForms["frmThongTinPK"] as frmThongTinPK;
            frmThongTinPK_TTPhongKham gui_frmThongTinPK_TTPhongKham = new frmThongTinPK_TTPhongKham(frm.Nhan_frmThongTinPK_TTPhongKham);
            gui_frmThongTinPK_TTPhongKham(ttPhongKham);
        }

        // Form Dang nhap

        public void Gui_frmDangNhap_DangNhapFail()
        {
            if (this.MdiChildren.Contains(this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmDangNhap"))))
            {
                frmDangNhap frmChild = (frmDangNhap)this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmDangNhap"));
                frmDangNhap_DangNhapFail gui_frmDangNhap_DangNhapFail = new frmDangNhap_DangNhapFail(frmChild.Nhan_frmDangNhap_DangNhapFail);
                gui_frmDangNhap_DangNhapFail();
            }
        }

        // Form Thong Tin Nhan Vien
        public void Gui_frmThongTinNV_ThongTinNV(svcRefQLPM.NhanVien nhanVien, svcRefQLPM.ChucNang[] dsChucNang_By_taikhoanNV)
        {
            if (this.MdiChildren.Contains(this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmThongTinNV"))))
            {
                frmThongTinNV frmChild = (frmThongTinNV)this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmThongTinNV"));
                frmThongTinNV_ThongTinNV gui_frmThongTinNV_ThongTinNV = new frmThongTinNV_ThongTinNV(frmChild.Nhan_frmThongTinNV_ThongTinNV);
                gui_frmThongTinNV_ThongTinNV(nhanVien, dsChucNang_By_taikhoanNV);
            }
        }

        // Form Quan ly nhan vien
        public void Gui_frmQLNhanVien_dsNhanVien(svcRefQLPM.NhanVien[] dsNhanVien)
        {
            if (this.MdiChildren.Contains(this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmQLNhanVien"))))
            {
                frmQLNhanVien frmChild = (frmQLNhanVien)this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmQLNhanVien"));
                frmQLNhanVien_dsNhanVien gui_frmQLNhanVien_dsNhanVien = new frmQLNhanVien_dsNhanVien(frmChild.Nhan_frmQLNhanVien_dsNhanVien);
                gui_frmQLNhanVien_dsNhanVien(dsNhanVien);
            }
        }

        public void Gui_frmQLNhanVien_dsChucNang_By_taikhoanNV(svcRefQLPM.ChucNang[] dSChucNang_By_taikhoanNV)
        {
            if (this.MdiChildren.Contains(this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmQLNhanVien"))))
            {
                frmQLNhanVien frmChild = (frmQLNhanVien)this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmQLNhanVien"));
                frmQLNhanVien_dsChucNang_By_taikhoanNV gui_frmQLNhanVien_dsChucNang_By_taikhoanNV = new frmQLNhanVien_dsChucNang_By_taikhoanNV(frmChild.Nhan_frmQLNhanVien_dsChucNang_By_taikhoanNV);
                gui_frmQLNhanVien_dsChucNang_By_taikhoanNV(dSChucNang_By_taikhoanNV);
            }
        }

        public void Gui_frmQLNhanVien_dsNhanVien_By_taikhoanNV(svcRefQLPM.NhanVien[] dsNhanVien_By_taikhoanNV)
        {
            if (this.MdiChildren.Contains(this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmQLNhanVien"))))
            {
                frmQLNhanVien frmChild = (frmQLNhanVien)this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmQLNhanVien"));
                frmQLNhanVien_dsNhanVien_By_taikhoanNV gui_frmQLNhanVien_dsNhanVien_By_taikhoanNV = new frmQLNhanVien_dsNhanVien_By_taikhoanNV(frmChild.Nhan_frmQLNhanVien_dsNhanVien_By_taikhoanNV);
                gui_frmQLNhanVien_dsNhanVien_By_taikhoanNV(dsNhanVien_By_taikhoanNV);
            }
        }

        public void Gui_frmQLNHanVien_AddResponse(string taikhoanNV)
        {
            if (this.MdiChildren.Contains(this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmQLNhanVien"))))
            {
                frmQLNhanVien frmChild = (frmQLNhanVien)this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmQLNhanVien"));
                frmQLNHanVien_AddResponse gui_frmQLNHanVien_AddResponse = new frmQLNHanVien_AddResponse(frmChild.Nhan_frmQLNhanVien_AddResponse);
                gui_frmQLNHanVien_AddResponse(taikhoanNV);
            }
        }

        // From tiep nhan
        public void Gui_frmTiepNhan_dsDichVu_By_ChucNang(svcRefQLPM.DichVu[] dsDichVu)
        {
            if (this.MdiChildren.Contains(this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmTiepNhan"))))
            {
                frmTiepNhan frmChild = (frmTiepNhan)this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmTiepNhan"));
                frmTiepNhan_dsDichVu_By_ChucNang gui_frmTiepNhan_dsDichVu = new frmTiepNhan_dsDichVu_By_ChucNang(frmChild.Nhan_frmTiepNhan_dsDichVu_By_ChucNang);
                gui_frmTiepNhan_dsDichVu(dsDichVu);
            }
        }

        public void Gui_frmTiepNhan_dsBenhNhan(svcRefQLPM.BenhNhan[] dsBenhNhan)
        {
            if (this.MdiChildren.Contains(this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmTiepNhan"))))
            {
                frmTiepNhan frmChild = (frmTiepNhan)this.MdiChildren.FirstOrDefault(f => f.Name.Equals("frmTiepNhan"));
                frmTiepNhan_dsBenhNhan gui_frmTiepNhan_dsBenhNhan = new frmTiepNhan_dsBenhNhan(frmChild.Nhan_frmTiepNhan_dsBenhNhan);
                gui_frmTiepNhan_dsBenhNhan(dsBenhNhan);
            }
        }

        #endregion

        #region Code cho các ribbon Button để mở các form con
        private void rbtnTiepNhan_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(frmTiepNhan))
                {
                    f.Activate();
                    return;
                }
            }
            Form frm = new frmTiepNhan(_proxy);
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnThuNgan_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(frmThuNgan))
                {
                    f.Activate();
                    return;
                }
            }
            Form frm = new frmThuNgan(_proxy);
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnDangNhap_Click(object sender, EventArgs e)
        {
            if (rbtnDangNhap.Text.Equals("Đăng nhập"))
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.GetType() == typeof(frmDangNhap))
                    {
                        f.Activate();
                        return;
                    }
                }
                Form frm = new frmDangNhap(_proxy);
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                _proxy.DangXuat(_nhanVien_HienTai.TaiKhoanNV);
            }
        }

        private void rbtnThongTinNV_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(frmThongTinNV))
                {
                    f.Activate();
                    return;
                }
            }
            frmThongTinNV frm = new frmThongTinNV(_proxy, _dsChucNang);
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnKhamBenh_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(frmKhamBenh))
                {
                    f.Activate();
                    return;
                }
            }
            Form frm = new frmKhamBenh(_proxy);
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnXetNghiem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(frmXetNghiem))
                {
                    f.Activate();
                    return;
                }
            }
            Form frm = new frmXetNghiem(_proxy);
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnCDHA_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(frmCDHA))
                {
                    f.Activate();
                    return;
                }
            }
            Form frm = new frmCDHA(_proxy);
            frm.MdiParent = this;
            frm.Show();
        }


        private void rbtnPhatThuoc_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(frmPhatThuoc))
                {
                    f.Activate();
                    return;
                }
            }
            Form frm = new frmPhatThuoc(_proxy);
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtmQLThuoc_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(frmQLThuoc))
                {
                    f.Activate();
                    return;
                }
            }
            Form frm = new frmQLThuoc(_proxy);
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnQLNhanVien_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(frmQLNhanVien))
                {
                    f.Activate();
                    return;
                }
            }
            Form frm = new frmQLNhanVien(_proxy, _dsChucNang, _dsTrangThaiNV);
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnQLDichVu_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(frmQLDichVu))
                {
                    f.Activate();
                    return;
                }
            }
            Form frm = new frmQLDichVu(_proxy);
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtmQLPhongKham_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(frmQLPhongKham))
                {
                    f.Activate();
                    return;
                }
            }
            Form frm = new frmQLPhongKham(_proxy);
            frm.MdiParent = this;
            frm.Show();
        }


        private void rbtnThongTinPK_Click(object sender, EventArgs e)
        {
            Form frm = new frmThongTinPK(_proxy);
            frm.ShowDialog();
        }

        private void rbtnThoat_Click(object sender, EventArgs e)
        {
            //if (_nhanVien_HienTai.Equals(null))
                _proxy.DangXuat(_nhanVien_HienTai.TaiKhoanNV);
            Application.Exit();
        }
        #endregion

        #region Các hàm được sử dụng bởi các sự kiện
        /// <summary>
        /// Khởi động các chức năng trong danh sách chức năng của nhân viên
        /// </summary>
        /// <param name="dsChucNang"></param>
        private void KhoiDongCN(svcRefQLPM.ChucNang[] dsChucNang)
        {
            rbtnThongTinNV.Enabled = true;
            rbtnThongTinNV.PerformClick();
            bool flag = false;
            foreach (var item in dsChucNang)
            {
                switch (item.MaCN)
                {
                    case "CN000":
                        rbtnTiepNhan.Enabled = true;
                        if (!flag)
                        {
                            rbtnTiepNhan.PerformClick();
                            flag = true;
                        }
                        break;
                    case "CN001":
                        rbtnThuNgan.Enabled = true;
                        if (!flag)
                        {
                            rbtnThuNgan.PerformClick();
                            flag = true;
                        }
                        break;
                    case "CN002":
                        rbtmQLThuoc.Enabled = true;
                        rbtnPhatThuoc.Enabled = true;
                        if (!flag)
                        {
                            rbtmQLThuoc.PerformClick();
                            flag = true;
                        }
                        break;
                    case "CN003":
                        rbtnKhamBenh.Enabled = true;
                        if (!flag)
                        {
                            rbtnKhamBenh.PerformClick();
                            flag = true;
                        }
                        break;
                    case "CN004":
                        rbtnKhamBenh.Enabled = true;
                        if (!flag)
                        {
                            rbtnKhamBenh.PerformClick();
                            flag = true;
                        }
                        break;
                    case "CN005":
                        rbtnKhamBenh.Enabled = true;
                        if (!flag)
                        {
                            rbtnKhamBenh.PerformClick();
                            flag = true;
                        }
                        break;
                    case "CN006":
                        rbtnKhamBenh.Enabled = true;
                        if (!flag)
                        {
                            rbtnKhamBenh.PerformClick();
                            flag = true;
                        }
                        break;
                    case "CN007":
                        rbtnKhamBenh.Enabled = true;
                        if (!flag)
                        {
                            rbtnKhamBenh.PerformClick();
                            flag = true;
                        }
                        break;
                    case "CN008":
                        rbtnXetNghiem.Enabled = true;
                        if (!flag)
                        {
                            rbtnXetNghiem.PerformClick();
                            flag = true;
                        }
                        break;
                    case "CN009":
                        rbtnCDHA.Enabled = true;
                        if (!flag)
                        {
                            rbtnCDHA.PerformClick();
                            flag = true;
                        }
                        break;
                    case "CN010":
                        rbtnQLDichVu.Enabled = true;
                        rbtnQLNhanVien.Enabled = true;
                        rbtnQLPhongKham.Enabled = true;
                        if (!flag)
                        {
                            rbtnQLNhanVien.PerformClick();
                            flag = true;
                        }
                        break;
                    default:
                        MessageBox.Show("Chức năng không tồn tại");
                        break;
                }
            }
        }

        /// <summary>
        /// Tắt các chức năng trong danh sách chức năng của nhân viên
        /// </summary>
        /// <param name="dS_ChucNang_By_TaiKhoan"></param>
        private void TatCN(svcRefQLPM.ChucNang[] dS_ChucNang_By_TaiKhoan)
        {
            rbtnThongTinNV.Enabled = false;
            foreach (var item in dS_ChucNang_By_TaiKhoan)
            {
                switch (item.MaCN)
                {
                    case "CN000":
                        rbtnTiepNhan.Enabled = false;
                        break;
                    case "CN001":
                        rbtnThuNgan.Enabled = false;
                        break;
                    case "CN002":
                        rbtmQLThuoc.Enabled = false;
                        rbtnPhatThuoc.Enabled = false;
                        break;
                    case "CN003":
                        rbtnKhamBenh.Enabled = false;
                        break;
                    case "CN004":
                        rbtnKhamBenh.Enabled = false;
                        break;
                    case "CN005":
                        rbtnKhamBenh.Enabled = false;
                        break;
                    case "CN006":
                        rbtnKhamBenh.Enabled = false;
                        break;
                    case "CN007":
                        rbtnKhamBenh.Enabled = false;
                        break;
                    case "CN008":
                        rbtnXetNghiem.Enabled = false;
                        break;
                    case "CN009":
                        rbtnCDHA.Enabled = false;
                        break;
                    case "CN010":
                        rbtnQLDichVu.Enabled = false;
                        rbtnQLNhanVien.Enabled = false;
                        rbtnQLPhongKham.Enabled = false;
                        break;
                    default:
                        MessageBox.Show("Chức năng không tồn tại");
                        break;
                }
            }
        }

        #endregion

        #region Các hàm callback

        public void DangNhap_Callback(bool ketQua, string msg, svcRefQLPM.NhanVien nhanVien, svcRefQLPM.ChucNang[] dsChucNang_By_taikhoanNV)
        {
            if (ketQua)
            {
                // Thay đổi button Đăng nhập
                rbtnDangNhap.Text = "Đăng xuất";
                rbtnDangNhap.Image = Image.FromFile("E:\\Study\\WorkSpace\\VisualStudio2012\\QLPM2\\HinhAnh\\Logout-icon32.png");
                rbtnDangNhap.SmallImage = Image.FromFile("E:\\Study\\WorkSpace\\VisualStudio2012\\QLPM2\\HinhAnh\\Logout-icon16.png");

                // Lấy thông tin của nhân viên hiện tại
                _nhanVien_HienTai = nhanVien;
                _dsChucNang_By_taikhoanNV_HienTai = dsChucNang_By_taikhoanNV;

                toolStripStatusLabelTen.Text += _nhanVien_HienTai.TaiKhoanNV;
                toolStripStatusLabelHoTen.Text += _nhanVien_HienTai.HoVaTenDemNV + " " + _nhanVien_HienTai.TenNV;
                KhoiDongCN(dsChucNang_By_taikhoanNV);

                // Gửi thông tin nhân viên và danh sách chức năng của nv đó sang cho frmThongTinNV 
                Gui_frmThongTinNV_ThongTinNV(nhanVien, dsChucNang_By_taikhoanNV);
            }
            else
            {
                MessageBox.Show(msg);
                Gui_frmDangNhap_DangNhapFail();
            }
        }

        public void DangXuat_Callback()
        {
            foreach (Form frm in this.MdiChildren)
                frm.Close();

            TatCN(_dsChucNang_By_taikhoanNV_HienTai);

            toolStripStatusLabelTen.Text = "Tên tài khoản: ";
            toolStripStatusLabelHoTen.Text = "Họ và tên: ";

            rbtnDangNhap.Text = "Đăng nhập";
            rbtnDangNhap.Image = Image.FromFile("E:\\Study\\WorkSpace\\VisualStudio2012\\QLPM2\\HinhAnh\\Login-icon32.png");
            rbtnDangNhap.SmallImage = Image.FromFile("E:\\Study\\WorkSpace\\VisualStudio2012\\QLPM2\\HinhAnh\\Login-icon16.png");
            rbtnDangNhap.PerformClick();
        }

        public void Get_dsNhanVien_Callback(svcRefQLPM.NhanVien[] dsNhanVien)
        {
            _dsNhanVien = dsNhanVien;
            Gui_frmQLNhanVien_dsNhanVien(dsNhanVien);
        }

        public void Get_dsChucNang_By_taikhoanNV_Callback(svcRefQLPM.ChucNang[] dsChucNang_By_taikhoanNV)
        {
            Gui_frmQLNhanVien_dsChucNang_By_taikhoanNV(dsChucNang_By_taikhoanNV);
        }


        public void Get_dsChucNang_Callback(svcRefQLPM.ChucNang[] dsChucNang)
        {
            _dsChucNang = dsChucNang;
        }

        public void Get_PhongKham_Callback(svcRefQLPM.ThongTinPhongKham phongKham)
        {
            Gui_frmThongTinPK_TTPhongKham(phongKham);
        }

        public void Get_dsNhanVien_By_taikhoanNV_Callback(svcRefQLPM.NhanVien[] dsNhanVien_By_taikhoanNV)
        {
            Gui_frmQLNhanVien_dsNhanVien_By_taikhoanNV(dsNhanVien_By_taikhoanNV);
        }

        public void Get_dsTrangThaiNV_Callback(svcRefQLPM.TrangThaiNV[] dsTrangThaiNV)
        {
            _dsTrangThaiNV = dsTrangThaiNV;
        }

        public void Add_NhanVien_Callback(string taikhoanNV)
        {
            Gui_frmQLNHanVien_AddResponse(taikhoanNV);
        }

        public void Get_dsDichVu_By_ChucNang_Callback(svcRefQLPM.DichVu[] dsDichVu_By_ChucNang)
        {
            Gui_frmTiepNhan_dsDichVu_By_ChucNang(dsDichVu_By_ChucNang);
        }

        public void Get_dsBenhNhan_Callback(svcRefQLPM.BenhNhan[] dsBenhNhan)
        {
            Gui_frmTiepNhan_dsBenhNhan(dsBenhNhan);
        }

        #endregion












        
    }
}
