﻿using System;
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
    public partial class frmQLDichVu : Form
    {
        private svcRefQLPM.QLPMClient _proxy;
        public frmQLDichVu()
        {
            InitializeComponent();
        }

        public frmQLDichVu(svcRefQLPM.QLPMClient proxy)
        {
            InitializeComponent();
            _proxy = proxy;
        }

        private void frmQLDichVu_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

    }
}
