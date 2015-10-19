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
        private svcRefQLPM.DichVu[] _dsDichVu_By_ChucNang;

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
            _proxy.Get_dsDichVu();

            chkDichVu.BackColor = SystemColors.Control;
            chkDichVu.BorderStyle = BorderStyle.None;
        }


        public void Nhan_frmTiepNhan_dsDichVu_By_ChucNang(svcRefQLPM.DichVu[] dsDichVu_By_ChucNang)
        {
            _dsDichVu_By_ChucNang = dsDichVu_By_ChucNang;

            // Them vao checkedlistbox
            chkDichVu.Items.Clear();
            foreach (var dVu in dsDichVu_By_ChucNang)
            {
                chkDichVu.Items.Add(dVu);
            }
            chkDichVu.DisplayMember = "TenDV";
            chkDichVu.ValueMember = "MaDV";


            
        }

    }
}
