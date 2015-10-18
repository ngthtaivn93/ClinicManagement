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
    public partial class frmKhamBenh : Form
    {
        private svcRefQLPM.QLPMClient _proxy;

        public frmKhamBenh()
        {
            InitializeComponent();
        }

        public frmKhamBenh(svcRefQLPM.QLPMClient proxy)
        {
            InitializeComponent();
            _proxy = proxy;
        }

        private void frmKhamBenh_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();

        }

        private void btnCDDV_Click(object sender, EventArgs e)
        {
            Form frm = new frmChiDinhDichVu();
            frm.ShowDialog();
        }






    }
}
