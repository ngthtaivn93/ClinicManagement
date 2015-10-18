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
    public partial class frmDangNhap : Form
    {
        private svcRefQLPM.QLPMClient _proxy;
        private frmMain frmParent;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public frmDangNhap(svcRefQLPM.QLPMClient proxy)
        {
            _proxy = proxy;
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                MessageBox.Show("Yêu cầu nhập tên tài khoản", "Lỗi");
                txtTaiKhoan.Clear();
                txtTaiKhoan.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Yêu cầu nhập mật khẩu", "Lỗi");
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
            else
            {
                // Gui lai cho frmMain
                _proxy.DangNhap(txtTaiKhoan.Text, txtMatKhau.Text);
            }
        }

        public void Nhan_frmDangNhap_DangNhapFail()
        {
            txtTaiKhoan.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            txtTaiKhoan.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
