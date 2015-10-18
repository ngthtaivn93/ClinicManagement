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
    public partial class frmThongTinPK : Form
    {

        private svcRefQLPM.QLPMClient _proxy;
        public frmThongTinPK()
        {
            InitializeComponent();
        }


        public frmThongTinPK(svcRefQLPM.QLPMClient proxy)
        {
            InitializeComponent();
            _proxy = proxy;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongTinPK_Load(object sender, EventArgs e)
        {
            _proxy.Get_PhongKham();
        }
        #region Truyen nhan du lieu

        public void Nhan_frmThongTinPK_TTPhongKham(svcRefQLPM.ThongTinPhongKham tt_PhongKham)
        {
            txtTenPK.Text = tt_PhongKham.TenPK;
            txtSDT.Text = tt_PhongKham.SDTPK;
            txtDiaChi.Text = tt_PhongKham.DiaChiPK;
        }
        #endregion

    }
}
