using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjClient
{
    public partial class frmCDHA : Form
    {
        private svcRefQLPM.QLPMClient _proxy;

        public frmCDHA()
        {
            InitializeComponent();
        }

        public frmCDHA(svcRefQLPM.QLPMClient proxy)
        {
            InitializeComponent();
            _proxy = proxy;
        }

        private void frmCDHA_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();

            string[] dsDuongDan = Directory.GetFiles("E:\\Study\\WorkSpace\\VisualStudio2012\\QLPM\\CDHA");
            foreach (var item in dsDuongDan)
            {
                if (item.EndsWith("png"))
                {
                    PictureBox pic = new PictureBox();
                    pic.Image = Image.FromFile(item);
                    pic.Width = 100;
                    pic.Height = 100;
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.BorderStyle = BorderStyle.FixedSingle;
                    flwDSHA.Controls.Add(pic);
                    pic.Click += pic_Click;
                }
            }
            PictureBox ctrl = (PictureBox)flwDSHA.Controls[0];
            picHACT.Image = ctrl.Image;
        }

        void pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            picHACT.Image = pic.Image;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtGioiTinhBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaBN_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
