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
        private svcRefQLPM.BenhNhan[] _dsBenhNhan;
        private Dictionary<string, DateTime> _dicNgaySinh;
        private DataTable _dtbDSTuyChon;
        private int _sttBN;
        private bool _flag;

        private svcRefQLPM.QLPMClient _proxy;
        public frmTiepNhan()
        {
            InitializeComponent();
        }
        public frmTiepNhan(svcRefQLPM.QLPMClient proxy)
        {
            InitializeComponent();
            _proxy = proxy;
            _dicNgaySinh = new Dictionary<string, DateTime>();
        }

        private void frmTiepNhan_Load(object sender, EventArgs e)
        {
            // Đưa datetime picker về chuẩn dd/MM/yyyy
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            cboTrangThaiBN.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinhBN.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTuyChon.DropDownStyle = ComboBoxStyle.DropDownList;

            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
            _proxy.Get_dsDichVu();
            _proxy.Get_dsBenhNhan();
            _dtbDSTuyChon = new DataTable();
            _sttBN = 0;
            _flag = false;
            KhoiTao_cboTuyChon();

            chkDichVu.BackColor = SystemColors.Control;
            chkDichVu.BorderStyle = BorderStyle.None;

            ModifyDatagridview(dgvDSBN);

            dgvDSBN.Columns.Add("MaBN", "Mã bệnh nhân");
            dgvDSBN.Columns.Add("HoVaTenDemBN", "Họ & tên đêm");
            dgvDSBN.Columns.Add("TenBN", "Tên");
            dgvDSBN.Columns.Add("NgaySinhBN", "Ngày sinh");
            dgvDSBN.Columns.Add("GioiTinhBN", "Giới tính");
            dgvDSBN.Columns.Add("SDTBN", "SĐT");
            dgvDSBN.Columns.Add("DiaChiBN", "Địa chỉ");
            dgvDSBN.Columns.Add("TrangThaiBN", "Trạng thái BN");

            btnLamLai.Enabled = false;
            btnHuy.Enabled = false;
        }

        #region Truyen nhan du lieu
        public void Nhan_frmTiepNhan_dsDichVu_By_ChucNang(svcRefQLPM.DichVu[] dsDichVu_By_ChucNang)
        {
            _dsDichVu_By_ChucNang = dsDichVu_By_ChucNang;
            if (_dsDichVu_By_ChucNang.Select(dv => dv).Count() == 0)
            {
                chkDichVu.Items.Clear();
                grpDSDV.Text = " Danh sách dịch vụ (Không có dịch vụ nào)";
            }
            else
            {
                grpDSDV.Text = "Danh sách dịch vụ";
                // Them vao checkedlistbox
                chkDichVu.Items.Clear();
                foreach (var dVu in dsDichVu_By_ChucNang)
                    chkDichVu.Items.Add(dVu);
                chkDichVu.DisplayMember = "TenDV";
                chkDichVu.ValueMember = "MaDV";
            }
        }

        public void Nhan_frmTiepNhan_dsBenhNhan(svcRefQLPM.BenhNhan[] dsBenhNhan)
        {
            _dsBenhNhan = dsBenhNhan;
            _dicNgaySinh.Clear();

            foreach (svcRefQLPM.BenhNhan item in dsBenhNhan)
            {
                _dicNgaySinh.Add(item.MaBN, item.NgaySinhBN);
                dgvDSBN.Rows.Add(
                    item.MaBN,
                    item.HoVaTenDemBN,
                    item.TenBN,
                    item.NgaySinhBN.ToString("dd/MM/yyyy"),
                    item.GioiTinhBN == true ? "Nam" : "Nữ",
                    item.SDTBN,
                    item.DiaChiBN,
                    item.TrangThaiBN
                    );
            }

        }

        #endregion

        // Modify lại datagridview
        private static void ModifyDatagridview(DataGridView dgv)
        {
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor = SystemColors.Control;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.MultiSelect = false;
        }

        private void KhoiTao_cboTuyChon()
        {
            _dtbDSTuyChon.Columns.Add("Key", typeof(string));
            _dtbDSTuyChon.Columns.Add("Value", typeof(string));

            _dtbDSTuyChon.Rows.Add("MaBN", "Mã bệnh nhân");
            _dtbDSTuyChon.Rows.Add("HoVanTenDem", "Họ & tên đệm");
            _dtbDSTuyChon.Rows.Add("TenBN", "Tên bệnh nhân");
            _dtbDSTuyChon.Rows.Add("NgaySinhBN", "Ngày sinh");
            _dtbDSTuyChon.Rows.Add("GioiTinhBN", "Giới tính");
            _dtbDSTuyChon.Rows.Add("SDTBN", "Số điện thoại");
            _dtbDSTuyChon.Rows.Add("DiaChiBN", "Địa chỉ");
            _dtbDSTuyChon.Rows.Add("TrangThaiBN", "Trạng thái");


            cboTuyChon.DataSource = _dtbDSTuyChon;
            cboTuyChon.DisplayMember = "Value";
            cboTuyChon.ValueMember = "Key";

        }

        private void dgvDSBN_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if(cboTrangThaiBN.Enabled)
            if (dgvDSBN.SelectedRows.Count != 0)
            {
                txtMaBN.Text = dgvDSBN.SelectedRows[0].Cells[0].Value.ToString();

                if (dgvDSBN.SelectedRows[0].Cells[1].Value != null)
                    txtHoVaTenDemBN.Text = dgvDSBN.SelectedRows[0].Cells[1].Value.ToString();
                else
                    txtHoVaTenDemBN.Text = string.Empty;

                if (dgvDSBN.SelectedRows[0].Cells[2].Value != null)
                    txtTenBN.Text = dgvDSBN.SelectedRows[0].Cells[2].Value.ToString();
                else
                    txtTenBN.Text = string.Empty;

                dtpNgaySinh.Value = Get_NgaySinh(dgvDSBN.SelectedRows[0].Cells[0].Value.ToString());

                if (dgvDSBN.SelectedRows[0].Cells[4].Value != null)
                    cboGioiTinhBN.Text = dgvDSBN.SelectedRows[0].Cells[4].Value.ToString();
                else
                    cboGioiTinhBN.Text = cboGioiTinhBN.Items[0].ToString();

                if (dgvDSBN.SelectedRows[0].Cells[5].Value != null)
                    txtSDTBN.Text = dgvDSBN.SelectedRows[0].Cells[5].Value.ToString();
                else
                    txtSDTBN.Text = string.Empty;

                if (dgvDSBN.SelectedRows[0].Cells[6].Value != null)
                    txtDiaChiBN.Text = dgvDSBN.SelectedRows[0].Cells[6].Value.ToString();
                else
                    txtDiaChiBN.Text = string.Empty;

                foreach (var item in cboTrangThaiBN.Items)
                    if (item.Equals(dgvDSBN.SelectedRows[0].Cells[7].Value.ToString()))
                        cboTrangThaiBN.SelectedItem = item;
            }
        }

        private DateTime Get_NgaySinh(string maBN)
        {
            foreach (var item in _dicNgaySinh)
            {
                if (item.Key.Equals(maBN))
                    return item.Value;
            }
            return DateTime.Now;
        }

        private string Get_MaBN()
        {
            return "BN" + (DateTime.Now.ToString("dd/MM/yyyy")).Replace("/", string.Empty) +"-" + String.Format("{0:000}", _sttBN);
        }


        private void btnThemMoi_Click(object sender, EventArgs e)
        {

            txtHoVaTenDemBN.Focus();
            btnThemMoi.Enabled = false;
            btnHuy.Enabled = true;
            btnLamLai.Enabled = true;
            btnTaiKham.Enabled = false;

            dtpNgaySinh.Value = new DateTime(1990, 1, 1);

            cboGioiTinhBN.Text = cboGioiTinhBN.Items[0].ToString();
            cboTrangThaiBN.SelectedItem = cboTrangThaiBN.Items[0];
            cboTrangThaiBN.Enabled = false;

            // Clear checked chkDichVu
            chkDichVu.Items.Clear();
            foreach (var item in _dsDichVu_By_ChucNang)
                chkDichVu.Items.Add(item, false);

            // Clear cac textbox
            foreach (TextBox tb in grpThongTinBenhNhan.Controls.OfType<TextBox>())
                tb.Text = string.Empty;

            txtMaBN.Text = Get_MaBN();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnTaiKham.Enabled = true;
            btnLamLai.Enabled = false;
            btnHuy.Enabled = false;
            btnThemMoi.Enabled = true;
            cboTrangThaiBN.Enabled = true;
            dgvDSBN_RowStateChanged(null, null);
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            dtpNgaySinh.Value = new DateTime(1990, 1, 1);

            cboGioiTinhBN.Text = cboGioiTinhBN.Items[0].ToString();
            cboTrangThaiBN.SelectedItem = cboTrangThaiBN.Items[0];

            // Clear checked chkDichVu
            chkDichVu.Items.Clear();
            foreach (var item in _dsDichVu_By_ChucNang)
                chkDichVu.Items.Add(item, false);

            // Clear cac textbox
            foreach (TextBox tb in grpThongTinBenhNhan.Controls.OfType<TextBox>())
                tb.Text = string.Empty;

            txtMaBN.Text = Get_MaBN();
        }

    }
}
