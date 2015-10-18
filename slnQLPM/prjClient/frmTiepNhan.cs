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
    public partial class frmTiepNhan : Form
    {
        private svcRefQLPM.QLPMClient _proxy;
        public frmTiepNhan()
        {
            InitializeComponent();
        }
        public frmTiepNhan(svcRefQLPM.QLPMClient proxy)
        {
            InitializeComponent();
            _proxy = proxy;
        }

        private void frmTiepNhan_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

    }
}
