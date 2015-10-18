using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjClient
{
    public partial class frmThongTinNV : Form
    {
        private svcRefQLPM.QLPMClient _proxy;
        private svcRefQLPM.ChucNang[] _dsChucNang;
        private svcRefQLPM.ChucNang[] _dsChucNang_By_taikhoanNV;

        public frmThongTinNV()
        {
            InitializeComponent();
        }

        public frmThongTinNV(svcRefQLPM.QLPMClient proxy, svcRefQLPM.ChucNang[] dsChucNang)
        {
            InitializeComponent();
            _proxy = proxy;
            _dsChucNang = dsChucNang;
        }

        private void frmThongTinNV_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();

            chkChucNang.SelectionMode = SelectionMode.None;
            chkChucNang.BackColor = SystemColors.Control;
            chkChucNang.BorderStyle = BorderStyle.None;
            KhoiDong_dsChucNang(_dsChucNang);
            
        }
        #region Truyen nhan du lieu
        public void Nhan_frmThongTinNV_ThongTinNV(svcRefQLPM.NhanVien nhanVien, svcRefQLPM.ChucNang[] dsChucNang_By_taikhoanNV)
        {
            _dsChucNang_By_taikhoanNV = dsChucNang_By_taikhoanNV;

            // Đưa thông tin vào các textbox
            txtTaiKhoanNV.Text = nhanVien.TaiKhoanNV;
            txtHoVaTenDemNV.Text = nhanVien.HoVaTenDemNV;
            txtTenNV.Text = nhanVien.TenNV;
            txtNgaySinhNV.Text = nhanVien.NgaySinhNV.ToShortDateString();
            txtGioiTinhNV.Text = nhanVien.GioiTinhNV==true?"Nam":"Nữ";
            txtSDTNV.Text = nhanVien.SDTNV;
            txtDiaChiNV.Text = nhanVien.DiaChiNV;
            switch (nhanVien.MaTrangThaiNV)
            {
                case "00":
                    txtTrangThaiNV.Text = "Đang làm việc cho phòng khám";
                    break;
                case "01":
                    txtTrangThaiNV.Text = "Đã đăng nhập vào hệ thống";
                    break;
                case "02":
                    txtTrangThaiNV.Text = "Đã nghỉ việc";
                    break;
                default:
                    txtTrangThaiNV.Text = "Lỗi";
                    break;
            }

            // Tick các chức năng của nhân viên này
            foreach (var cNang in dsChucNang_By_taikhoanNV)
                for (int i = 0; i < chkChucNang.Items.Count; i++)
                {
                    svcRefQLPM.ChucNang tmp = (svcRefQLPM.ChucNang)chkChucNang.Items[i];
                    if (cNang.MaCN.Equals(tmp.MaCN))
                        chkChucNang.SetItemChecked(i, true);
                }
        }
        #endregion

        public void KhoiDong_dsChucNang(svcRefQLPM.ChucNang[] dsChucNang)
        {
            foreach (var cNang in dsChucNang)
            {
                chkChucNang.Items.Add(cNang, false);
            }
            chkChucNang.DisplayMember = "TenCN";
            chkChucNang.ValueMember = "MaCN";
        }
    }
}
