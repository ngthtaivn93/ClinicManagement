using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using prjDB;

namespace prjQLPMService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class QLPM : IQLPM
    {
        private static Dictionary<string, IQLPMCallback> _dsClient = new Dictionary<string, IQLPMCallback>();
        private IQLPMCallback _callbackClient;
        dbQLPMDataContext db = new dbQLPMDataContext();
        #region Các hàm thao tác với _dsClient
        /// <summary>
        /// Thêm một client vào danh sách Client
        /// </summary>
        /// <param name="taikhoanNV">tên tài khoản</param>
        /// <param name="client">IQLPMCallback</param>
        /// <returns></returns>
        private bool SO_dsClient_Add(string taikhoanNV, IQLPMCallback client)
        {
            if (_dsClient.ContainsKey(taikhoanNV))
                return false;
            _dsClient.Add(taikhoanNV, client);
            return true;
        }

        /// <summary>
        /// Xóa một client khỏi danh sách Client
        /// </summary>
        /// <param name="taikhoanNV">tên tài khoản</param>
        private void SO_dsClient_Remove(string taikhoanNV)
        {
            _dsClient.Remove(taikhoanNV);
        }
        #endregion

        #region Các hàm được sử dụng bởi các dịch vụ

        private IEnumerable<ChucNang> SO_Get_dsChucNang()
        {
            return db.tbChucNangs.Select(cn => new ChucNang
            {
                MaCN = cn.maCN,
                TenCN = cn.tenCN
            });
        }

        /// <summary>
        /// Lấy danh sách chức năng của một nhân viên có tài khoản là: taikhoanNV
        /// </summary>
        /// <param name="taikhoanNV">tên tài khoản</param>
        /// <returns>Danh sách chức năng</returns>
        public IEnumerable<ChucNang> SO_Get_dsChucNang_By_taikhoanNV(string taikhoanNV)
        {
            return db.tbNhanVien_ChucNangs.Where(nv => nv.taiKhoanNV == taikhoanNV).Select(cn => new ChucNang
            {
                MaCN = cn.maCN,
                TenCN = db.tbChucNangs.Where(cNang => cNang.maCN == cn.maCN).Select(cNang => cNang.tenCN).FirstOrDefault()
            });
        }

        private IEnumerable<NhanVien> SO_Get_dsNhanVien()
        {
            return db.tbNhanViens.Select(nv => new NhanVien
            {
                TaiKhoanNV = nv.taiKhoanNV,
                MkNV = nv.mkNV,
                HoVaTenDemNV = nv.hoVaTenDemNV,
                TenNV = nv.tenNV,
                NgaySinhNV = nv.ngaySinhNV ?? DateTime.Now,
                GioiTinhNV = nv.gioiTinhNV ?? true,
                SDTNV = nv.sDTNV,
                DiaChiNV = nv.diaChiNV,
                MaTrangThaiNV = nv.maTrangThaiNV
            });
        }
        /// <summary>
        /// Lấy ra toàn bộ thông tin nhân viên dựa vào tên tài khoản
        /// </summary>
        /// <param name="taikhoanNV">tên tài khoản cần lấy thông tin</param>
        /// <returns>toàn bộ thông tin tài khoản</returns>
        private NhanVien SO_Get_NhanVien(string taikhoanNV)
        {
            return db.tbNhanViens.Where(nv => nv.taiKhoanNV.Equals(taikhoanNV)).Select(nv => new NhanVien
            {
                TaiKhoanNV = nv.taiKhoanNV,
                MkNV = nv.mkNV,
                HoVaTenDemNV = nv.hoVaTenDemNV,
                TenNV = nv.tenNV,
                NgaySinhNV = nv.ngaySinhNV ?? DateTime.Now,
                GioiTinhNV = nv.gioiTinhNV ?? true,
                SDTNV = nv.sDTNV,
                DiaChiNV = nv.diaChiNV,
                MaTrangThaiNV = nv.maTrangThaiNV
            }).FirstOrDefault();
        }

        /// <summary>
        /// Thay đổi trạng thái của nhân viên xuống cơ sở dữ liệu
        /// </summary>
        /// <param name="taikhoanNV">tên tài khoản</param>
        /// <param name="tThai">mã trạng thái</param>
        private void SO_ThayDoiTrangThai_NhanVien(string taikhoanNV, string tThai)
        {
            tbNhanVien nVien = db.tbNhanViens.Single(nv => nv.taiKhoanNV == taikhoanNV);
            nVien.maTrangThaiNV = tThai;
            db.SubmitChanges();
        }

        /// <summary>
        /// Lấy danh sách dịch vụ từ mã chức năng
        /// </summary>
        /// <param name="maCN">mã chức năng</param>
        /// <returns>danh sách dịch vụ</returns>
        private IEnumerable<DichVu> SO_Get_dsDichVu_By_MaCN(string maCN)
        {
            return db.tbDichVus.Where(dv => dv.maCN == maCN).Select(dv => new DichVu
                {
                    MaDV = dv.maDV,
                    TenDV = dv.tenDV,
                    MaCN = dv.maCN,
                    GiaDV = dv.giaDV ?? 0
                });
        }

        /// <summary>
        /// Lấy ra các tài khoản đang đăng nhập vào hệ thống có chức năng quản lý nhân viên
        /// </summary>
        /// <param name="maCN">Mã chức năng</param>
        /// <returns>danh sách tên tài khoản</returns>
        private List<string> SO_Get_dsTaiKhoanActive_By_ChucNang(string maCN)
        {
            List<string> dsTaiKhoanNVActive = new List<string>();
            IEnumerable<string> dsTaiKhoanNV = db.tbNhanVien_ChucNangs.Where(nvcn => nvcn.maCN.Equals(maCN)).Select(nvcn => nvcn.taiKhoanNV);
            foreach (var item in dsTaiKhoanNV)
                if (db.tbNhanViens.Single(nv => nv.taiKhoanNV.Equals(item)).maTrangThaiNV.Equals("01"))
                    dsTaiKhoanNVActive.Add(item);
            return dsTaiKhoanNVActive;
        }

        #endregion

        #region Các dịch vụ cung cấp cho Client
        /// <summary>
        /// Dịch vụ đăng nhập
        /// </summary>
        /// <param name="taikhoanNV">tên tài khoản</param>
        /// <param name="mK">mật khẩu</param>
        public void DangNhap(string taikhoanNV, string mK)
        {
            _callbackClient = OperationContext.Current.GetCallbackChannel<IQLPMCallback>();
            if (db.tbNhanViens.Where(nv => nv.taiKhoanNV == taikhoanNV && nv.mkNV == mK).Select(nv => nv).Count() == 1)
                if (SO_dsClient_Add(taikhoanNV, _callbackClient))
                {
                    SO_ThayDoiTrangThai_NhanVien(taikhoanNV, "01");
                    _callbackClient.DangNhap_Callback(true, null, SO_Get_NhanVien(taikhoanNV),SO_Get_dsChucNang_By_taikhoanNV(taikhoanNV));

                    foreach (var active in SO_Get_dsTaiKhoanActive_By_ChucNang("CN010"))
                        foreach (var item in _dsClient)
                            if (item.Key.Equals(active))
                            {
                                item.Value.Get_dsNhanVien_Callback(SO_Get_dsNhanVien());
                            }
                }
                else
                    _callbackClient.DangNhap_Callback(false, "Tài khoản này đã đăng nhập vào hệ thống",null, null);
            else
                _callbackClient.DangNhap_Callback(false, "Tên tài khoản hoặc mật khẩu không chính xác", null, null);
        }

        /// <summary>
        /// Dịch vụ đăng xuất
        /// Xóa client khỏi danh sách client
        /// Gửi phản hồi cho client
        /// </summary>
        /// <param name="taikhoanNV">tên tài khoản</param>
        public void DangXuat(string taikhoanNV)
        {
            SO_ThayDoiTrangThai_NhanVien(taikhoanNV, "00");
            _dsClient.Single(cl => cl.Key.Equals(taikhoanNV)).Value.DangXuat_Callback();
           SO_dsClient_Remove(taikhoanNV);

            foreach (var active in SO_Get_dsTaiKhoanActive_By_ChucNang("CN010"))
                foreach (var item in _dsClient)
                    if (item.Key.Equals(active))
                        item.Value.Get_dsNhanVien_Callback(SO_Get_dsNhanVien());
        }

        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        public void Get_dsNhanVien()
        {
            _callbackClient = OperationContext.Current.GetCallbackChannel<IQLPMCallback>();
            _callbackClient.Get_dsNhanVien_Callback(SO_Get_dsNhanVien());
        }

        /// <summary>
        /// Lấy danh sách chức năng của một nhân viên có tài khoản là: taikhoanNV
        /// </summary>
        /// <param name="taikhoanNV">tên tài khoản</param>
        /// <returns>Danh sách chức năng</returns>
        public void Get_dsChucNang_By_taikhoanNV(string taikhoanNV)
        {
            _callbackClient = OperationContext.Current.GetCallbackChannel<IQLPMCallback>();
            _callbackClient.Get_dsChucNang_By_taikhoanNV_Callback(SO_Get_dsChucNang_By_taikhoanNV(taikhoanNV));
        }

        public void Get_dsChucNang()
        {
            _callbackClient = OperationContext.Current.GetCallbackChannel<IQLPMCallback>();
            _callbackClient.Get_dsChucNang_Callback(SO_Get_dsChucNang());
        }

        public void Get_PhongKham()
        {
            _callbackClient = OperationContext.Current.GetCallbackChannel<IQLPMCallback>();
            _callbackClient.Get_PhongKham_Callback(db.tbThongTinPhongKhams.Select(pk => new ThongTinPhongKham
            {
                TenPK = pk.tenPK,
                SDTPK = pk.sDTPK,
                DiaChiPK = pk.diaChiPK
            }).FirstOrDefault());
        }

        public void Get_dsNhanVien_By_taikhoanNV(string taikhoanNV)
        {
            _callbackClient = OperationContext.Current.GetCallbackChannel<IQLPMCallback>();
            _callbackClient.Get_dsNhanVien_By_taikhoanNV_Callback(db.tbNhanViens.Where(nv => nv.taiKhoanNV.Contains(System.Convert.ToString(taikhoanNV))).Select(nv => new NhanVien
            {
                TaiKhoanNV = nv.taiKhoanNV,
                MkNV = nv.mkNV,
                HoVaTenDemNV = nv.hoVaTenDemNV,
                TenNV = nv.tenNV,
                NgaySinhNV = nv.ngaySinhNV ?? DateTime.Now,
                GioiTinhNV = nv.gioiTinhNV ?? true,
                SDTNV = nv.sDTNV,
                DiaChiNV = nv.diaChiNV,
                MaTrangThaiNV = nv.maTrangThaiNV
            }));
        }

        public void Get_dsTrangThaiNV()
        {
            _callbackClient = OperationContext.Current.GetCallbackChannel<IQLPMCallback>();
            _callbackClient.Get_dsTrangThaiNV_Callback(db.tbTrangThaiNVs.Select(tt => new TrangThaiNV
                {
                    MaTrangThaiNV = tt.maTrangThaiNV,
                    TenTrangThaiNV = tt.tenTrangThaiNV
                }));
        }

        #endregion
    }
}
