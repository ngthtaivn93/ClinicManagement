using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.ServiceModel;

namespace prjClient
{
    public partial class frmQLNhanVien : Form
    {
        private svcRefQLPM.QLPMClient _proxy;
        private svcRefQLPM.ChucNang[] _dsChucNang;
        private svcRefQLPM.TrangThaiNV[] _dsTrangThaiNV;
        private svcRefQLPM.NhanVien[] _dsNhanVien;
        private string _currentPasswd;
        private bool _flag;
        private bool _passwd_Changed;

        private Dictionary<string, DateTime> _dicNgaySinh;
        private DataTable _dtbDSTuyChon;

        public frmQLNhanVien()
        {
            InitializeComponent();
        }
        public frmQLNhanVien(svcRefQLPM.QLPMClient proxy, svcRefQLPM.ChucNang[] dsChucNang, svcRefQLPM.TrangThaiNV[] dsTrangThaiNV)
        {
            _proxy = proxy;
            _dsChucNang = dsChucNang;
            _dsTrangThaiNV = dsTrangThaiNV;
            _passwd_Changed = false;
            _flag = false;
            InitializeComponent();

            _dicNgaySinh = new Dictionary<string, DateTime>();
            _dtbDSTuyChon = new DataTable();
        }

        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
            btnHuy.Enabled = false;
            btnLamLai.Enabled = false;

            // Đưa datetime picker về chuẩn dd/MM/yyyy
            dtpNgaySinhNV.Format = DateTimePickerFormat.Custom;
            dtpNgaySinhNV.CustomFormat = "dd/MM/yyyy";

            KhoiTao_DGV();
            ModifyDatagridview(dgvDSNV);

            _proxy.Get_dsNhanVien();

            chkChucNang.BackColor = SystemColors.Control;
            chkChucNang.BorderStyle = BorderStyle.None;

            _dtbDSTuyChon.Columns.Add("Key", typeof(string));
            _dtbDSTuyChon.Columns.Add("Value", typeof(string));

            KhoiTao_dtbDSTuyChon();
            AutoComplete_ComboBox(cboTuyChon, _dtbDSTuyChon, "Value", "Key");
            AutoComplete_ComboBox(cboTrangThaiNV, _dsTrangThaiNV, "tenTrangThaiNV", "maTrangThaiNV");
            cboGioiTinhNV.DropDownStyle = ComboBoxStyle.DropDownList;

            KhoiTao_dsChucNang(_dsChucNang);
        }

        #region Truyen nhan du lieu
        public void Nhan_frmQLNhanVien_dsNhanVien(svcRefQLPM.NhanVien[] dsNhanVien)
        {
            _dsNhanVien = dsNhanVien;
            _dicNgaySinh.Clear();
            dgvDSNV.Rows.Clear();
            foreach (var item in dsNhanVien)
            {
                _dicNgaySinh.Add(item.TaiKhoanNV, item.NgaySinhNV);
                _currentPasswd = item.MkNV;
                dgvDSNV.Rows.Add(
                    item.TaiKhoanNV,
                    new String('*', item.MkNV.Length),
                    item.HoVaTenDemNV, item.TenNV,
                    item.NgaySinhNV.ToString("dd/MM/yyyy"),
                    item.GioiTinhNV == true ? "Nam" : "Nữ",
                    item.SDTNV, item.DiaChiNV,
                    Get_TrangthaiNV(item.MaTrangThaiNV)
                    );
            }
            if (!txtTuKhoa.Text.Equals(string.Empty))
                txtTuKhoa_TextChanged(null, null);
        }

        public void Nhan_frmQLNhanVien_dsChucNang_By_taikhoanNV(svcRefQLPM.ChucNang[] dSChucNang_By_taikhoanNV)
        {
            for (int i = 0; i < chkChucNang.Items.Count; i++)
                chkChucNang.SetItemChecked(i, false);

            foreach (var cNang in dSChucNang_By_taikhoanNV)
                for (int i = 0; i < chkChucNang.Items.Count; i++)
                {
                    svcRefQLPM.ChucNang tmp = (svcRefQLPM.ChucNang)chkChucNang.Items[i];
                    if (cNang.MaCN.Equals(tmp.MaCN))
                        chkChucNang.SetItemChecked(i, true);
                }
        }

        public void Nhan_frmQLNhanVien_dsNhanVien_By_taikhoanNV(svcRefQLPM.NhanVien[] dsNhanVien_By_taikhoanNV)
        {
            dgvDSNV.Rows.Clear();
            foreach (var item in dsNhanVien_By_taikhoanNV)
                dgvDSNV.Rows.Add(
                    item.TaiKhoanNV,
                    new String('*', item.MkNV.Length),
                    item.HoVaTenDemNV, item.TenNV,
                    item.NgaySinhNV.ToString("dd/MM/yyyy"),
                    item.GioiTinhNV == true ? "Nam" : "Nữ",
                    item.SDTNV, item.DiaChiNV,
                    Get_TrangthaiNV(item.MaTrangThaiNV
                    ));
        }

        public void Nhan_frmQLNhanVien_AddResponse(string taikhoanNV)
        {
            foreach (DataGridViewRow row in dgvDSNV.Rows)
                if (row.Cells[0].Value.ToString().Equals(taikhoanNV))
                    row.Selected = true;
            btnHuy.PerformClick();
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

        public void KhoiTao_dsChucNang(svcRefQLPM.ChucNang[] dsChucNang)
        {
            foreach (var cNang in dsChucNang)
            {
                chkChucNang.Items.Add(cNang);
            }
            chkChucNang.DisplayMember = "TenCN";
            chkChucNang.ValueMember = "MaCN";
        }

        private void KhoiTao_dtbDSTuyChon()
        {
            _dtbDSTuyChon.Rows.Add("TaiKhoanNV", "TK Nhân viên");
            _dtbDSTuyChon.Rows.Add("HoVaTenDemNV", "Họ & tên đệm");
            _dtbDSTuyChon.Rows.Add("TenNV", "Tên");
            _dtbDSTuyChon.Rows.Add("NgaySinhNV", "Ngày sinh");
            _dtbDSTuyChon.Rows.Add("GioiTinhNV", "Giới tính");
            _dtbDSTuyChon.Rows.Add("SDTNV", "Số điện thoại");
            _dtbDSTuyChon.Rows.Add("DiaChiNV", "Địa chỉ");
            _dtbDSTuyChon.Rows.Add("TrangThaiNV", "Trạng thái");
        }

        private void KhoiTao_DGV()
        {
            dgvDSNV.Columns.Add("TaiKhoanNV", "TK Nhân viên");
            dgvDSNV.Columns.Add("MkNV", "Mật khẩu");
            dgvDSNV.Columns.Add("HoVaTenDemNV", "Họ & tên đệm");
            dgvDSNV.Columns.Add("TenNV", "Tên");
            dgvDSNV.Columns.Add("NgaySinhNV", "Ngày sinh");
            dgvDSNV.Columns.Add("GioiTinhNV", "Giới tính");
            dgvDSNV.Columns.Add("SDTNV", "Số điện thoại");
            dgvDSNV.Columns.Add("DiaChiNV", "Địa chỉ");
            dgvDSNV.Columns.Add("TrangThaiNV", "Trạng thái");

        }

        private String Get_TrangthaiNV(string maTrangThaiNV)
        {
            foreach (var item in _dsTrangThaiNV)
                if (item.MaTrangThaiNV.Equals(maTrangThaiNV))
                    return item.TenTrangThaiNV;
            return "NULL";
        }

        private DateTime Get_NgaySinh(string taikhoanNV)
        {
            foreach (var item in _dicNgaySinh)
            {
                if (item.Key.Equals(taikhoanNV))
                    return item.Value;
            }
            return DateTime.Now;
        }

        private void AutoComplete_ComboBox(ComboBox cboIn, DataTable dtbIn, string displayMember, string valueMember)
        {
            cboIn.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIn.DataSource = dtbIn;
            cboIn.DisplayMember = displayMember;
            cboIn.ValueMember = valueMember;
        }

        private void AutoComplete_ComboBox(ComboBox cboIn, svcRefQLPM.TrangThaiNV[] dsIn, string displayMember, string valueMember)
        {
            cboIn.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIn.DataSource = dsIn;
            cboIn.DisplayMember = displayMember;
            cboIn.ValueMember = valueMember;
        }

        private void dgvDSNV_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (btnThemMoi.Enabled == true)
                if (dgvDSNV.SelectedRows.Count != 0)
                {
                    //txtTaiKhoanNV.ReadOnly = true;
                    //btnLamLai.Enabled = false;
                    //btnHuy.Enabled = false;
                    //btnThemMoi.Enabled = true;
                    //cboTrangThaiNV.Enabled = true;


                    txtTaiKhoanNV.Text = dgvDSNV.SelectedRows[0].Cells[0].Value.ToString();

                    txtMkNV.Text = dgvDSNV.SelectedRows[0].Cells[1].Value.ToString();
                    _flag = true;

                    if (dgvDSNV.SelectedRows[0].Cells[2].Value != null)
                        txtHoVaTenDemNV.Text = dgvDSNV.SelectedRows[0].Cells[2].Value.ToString();
                    else
                        txtHoVaTenDemNV.Text = string.Empty;

                    if (dgvDSNV.SelectedRows[0].Cells[3].Value != null)
                        txtTenNV.Text = dgvDSNV.SelectedRows[0].Cells[3].Value.ToString();
                    else
                        txtTenNV.Text = string.Empty;

                    dtpNgaySinhNV.Value = Get_NgaySinh(dgvDSNV.SelectedRows[0].Cells[0].Value.ToString());

                    if (dgvDSNV.SelectedRows[0].Cells[5].Value != null)
                        cboGioiTinhNV.Text = dgvDSNV.SelectedRows[0].Cells[5].Value.ToString();
                    else
                        cboGioiTinhNV.Text = cboGioiTinhNV.Items[0].ToString();

                    if (dgvDSNV.SelectedRows[0].Cells[6].Value != null)
                        txtSDTNV.Text = dgvDSNV.SelectedRows[0].Cells[6].Value.ToString();
                    else
                        txtSDTNV.Text = string.Empty;

                    if (dgvDSNV.SelectedRows[0].Cells[7].Value != null)
                        txtDiaChiNV.Text = dgvDSNV.SelectedRows[0].Cells[7].Value.ToString();
                    else
                        txtDiaChiNV.Text = string.Empty;

                    foreach (var item in cboTrangThaiNV.Items)
                    {
                        svcRefQLPM.TrangThaiNV tmp = item as svcRefQLPM.TrangThaiNV;
                        if (tmp.TenTrangThaiNV.Equals(dgvDSNV.SelectedRows[0].Cells[8].Value.ToString()))
                            cboTrangThaiNV.SelectedItem = item;
                    }

                    _proxy.Get_dsChucNang_By_taikhoanNV(dgvDSNV.SelectedRows[0].Cells[0].Value.ToString());
                }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            txtTuKhoa.Focus();
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa;
            tuKhoa = txtTuKhoa.Text.Trim().ToLower();
            if (!tuKhoa.Equals(string.Empty))
            {
                switch (cboTuyChon.SelectedValue.ToString())
                {
                    case "TaiKhoanNV":
                        _proxy.Get_dsNhanVien_By_taikhoanNV(tuKhoa);
                        break;
                    case "TenNV":

                        break;
                    case "HoVaTenDemNV":
                        break;
                    case "NgaySinhNV":
                        break;
                    case "GioiTinhNV":
                        break;
                    case "SDTNV":
                        break;
                    case "DiaChiNV":
                        break;
                    case "TrangThaiNV":
                        break;

                    default:
                        MessageBox.Show("Vui lòng chọn Kiểu tìm kiếm");
                        break;
                }
            }
            else
                _proxy.Get_dsNhanVien();
        }

        private bool Textbox_IsEmpty()
        {
            //foreach (TextBox tb in grpThongTinNV.Controls.OfType<TextBox>())
            //    if (tb.Text.Trim().Equals(string.Empty))
            //        return true;
            //return false;
            if (txtTaiKhoanNV.Text.Trim().Equals(string.Empty)
                || txtMkNV.Text.Trim().Equals(string.Empty))
                return true;
            return false;
        }

        private bool CheckedLBItem_IsChecked()
        {
            for (int i = 0; i < chkChucNang.Items.Count; i++)
                if (chkChucNang.GetItemChecked(i))
                    return true;
            return false;
        }

        private bool TaiKhoanNV_IsDuplicated(string tkhoanNV)
        {
            foreach (DataGridViewRow row in dgvDSNV.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(tkhoanNV.Trim()))
                    return true;
            }
            return false;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra các textbox có trống hay không (Chỉ những trường not null)
            if (!Textbox_IsEmpty())
                // Kiểm tra xem có chức năng nào được chọn chưa
                if (CheckedLBItem_IsChecked())
                    if (txtTaiKhoanNV.ReadOnly == false)
                    {
                        // Them moi
                        if (!TaiKhoanNV_IsDuplicated(txtTaiKhoanNV.Text))
                        {
                            svcRefQLPM.NhanVien newNhanVien = new svcRefQLPM.NhanVien();
                            newNhanVien.TaiKhoanNV = txtTaiKhoanNV.Text;
                            newNhanVien.MkNV = txtMkNV.Text;
                            newNhanVien.DiaChiNV = txtDiaChiNV.Text;
                            newNhanVien.GioiTinhNV = cboGioiTinhNV.Text.Trim().Equals("Nam") ? true : false;
                            newNhanVien.HoVaTenDemNV = txtHoVaTenDemNV.Text;
                            newNhanVien.MaTrangThaiNV = "00";
                            newNhanVien.NgaySinhNV = dtpNgaySinhNV.Value;
                            newNhanVien.SDTNV = txtSDTNV.Text;
                            newNhanVien.TenNV = txtTenNV.Text;

                            string[] dsChucNang_newNhanVien = new string[10];
                            int i = 0;
                            foreach (var item in chkChucNang.CheckedItems)
                            {
                                svcRefQLPM.ChucNang tmp = item as svcRefQLPM.ChucNang;
                                dsChucNang_newNhanVien[i] = tmp.MaCN;
                                i++;
                            }

                            _proxy.Add_NhanVien(newNhanVien, dsChucNang_newNhanVien);
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản nhân viên này đã tồn tại", "Lỗi");
                            txtTaiKhoanNV.Clear();
                            txtTaiKhoanNV.Focus();
                        }
                    }
                    else
                    {
                        // Sua thong tin
                        svcRefQLPM.NhanVien modNhanVien = new svcRefQLPM.NhanVien();
                        modNhanVien.TaiKhoanNV = txtTaiKhoanNV.Text;
                        modNhanVien.DiaChiNV = txtDiaChiNV.Text;
                        modNhanVien.GioiTinhNV = cboGioiTinhNV.Text.Trim().Equals("Nam") ? true : false;
                        modNhanVien.HoVaTenDemNV = txtHoVaTenDemNV.Text;
                        modNhanVien.MaTrangThaiNV = "00";
                        modNhanVien.NgaySinhNV = dtpNgaySinhNV.Value;
                        modNhanVien.SDTNV = txtSDTNV.Text;
                        modNhanVien.TenNV = txtTenNV.Text;
                        if (_passwd_Changed)
                        {
                            modNhanVien.MkNV = txtMkNV.Text;
                            _passwd_Changed = false;
                        }
                        else
                            modNhanVien.MkNV = _currentPasswd;

                        string[] dsChucNang_modNhanVien = new string[10];
                        int i = 0;
                        foreach (var item in chkChucNang.CheckedItems)
                        {
                            svcRefQLPM.ChucNang tmp = item as svcRefQLPM.ChucNang;
                            dsChucNang_modNhanVien[i] = tmp.MaCN;
                            i++;
                        }

                        _proxy.Mod_NhanVien(modNhanVien, dsChucNang_modNhanVien);
                    }
                else
                    MessageBox.Show("Yêu cầu chọn ít nhất một chức năng cho nhân viên");
            else
                MessageBox.Show("Yêu cầu nhập đầy đủ thông tin vào các ô trống");

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTaiKhoanNV.ReadOnly = true;
            btnLamLai.Enabled = false;
            btnHuy.Enabled = false;
            btnThemMoi.Enabled = true;
            cboTrangThaiNV.Enabled = true;
            dgvDSNV_RowStateChanged(null, null);

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            btnThemMoi.Enabled = false;
            btnHuy.Enabled = true;
            btnLamLai.Enabled = true;

            txtTaiKhoanNV.ReadOnly = false;
            dtpNgaySinhNV.Value = new DateTime(1990, 1, 1);

            cboGioiTinhNV.Text = cboGioiTinhNV.Items[0].ToString();
            cboTrangThaiNV.SelectedItem = cboTrangThaiNV.Items[0];
            cboTrangThaiNV.Enabled = false;

            // Clear checked chkChucNang
            chkChucNang.Items.Clear();
            foreach (var item in _dsChucNang)
                chkChucNang.Items.Add(item, false);

            // Clear cac textbox
            foreach (TextBox tb in grpThongTinNV.Controls.OfType<TextBox>())
                tb.Text = string.Empty;
            txtTaiKhoanNV.Focus();
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            // Clear checked chkChucNang
            chkChucNang.Items.Clear();
            foreach (var item in _dsChucNang)
                chkChucNang.Items.Add(item, false);

            // Clear cac textbox
            foreach (TextBox tb in grpThongTinNV.Controls.OfType<TextBox>())
                tb.Text = string.Empty;

            txtTaiKhoanNV.Focus();

            cboGioiTinhNV.Text = cboGioiTinhNV.Items[0].ToString();
            dtpNgaySinhNV.Value = new DateTime(1990, 1, 1);

        }

        private void txtMkNV_TextChanged(object sender, EventArgs e)
        {
            if (_flag)
            {
                _passwd_Changed = true;
                _flag = false;
            }
        }





    }
}
