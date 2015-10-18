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
    public partial class frmXetNghiem : Form
    {
        private svcRefQLPM.QLPMClient _proxy;

        public frmXetNghiem()
        {
            InitializeComponent();
        }

        public frmXetNghiem(svcRefQLPM.QLPMClient proxy)
        {
            InitializeComponent();
            _proxy = proxy;
        }

        private void frmXetNghiem_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
            axFoxitCtl.OpenFile("E:\\Study\\Document\\LapTrinh\\WCF\\WCF Tutorial\\WCF_Lesson_1.pdf");
        }

    }
}
