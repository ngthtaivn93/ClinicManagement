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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IQLPMCallback))]
    public interface IQLPM
    {
        [OperationContract(IsOneWay = true)]
        void DangNhap(string taikhoanNV, string mK);

        [OperationContract(IsOneWay = true)]
        void DangXuat(string taikhoanNV);

        [OperationContract(IsOneWay = true)]
        void Get_dsNhanVien();

        [OperationContract(IsOneWay = true)]
        void Get_dsChucNang_By_taikhoanNV(string taikhoanNV);

        [OperationContract(IsOneWay = true)]
        void Get_dsChucNang();

        [OperationContract(IsOneWay = true)]
        void Get_PhongKham();

        [OperationContract(IsOneWay = true)]
        void Get_dsNhanVien_By_taikhoanNV(string taikhoanNV);

        [OperationContract(IsOneWay = true)]
        void Get_dsTrangThaiNV();

        [OperationContract(IsOneWay = true)]
        void Add_NhanVien(NhanVien newNhanVien, List<string> dsChucNang_newNhanVien);

        [OperationContract(IsOneWay = true)]
        void Mod_NhanVien(NhanVien modNhanVien, List<string> dsChucNang_modNhanVien);

        [OperationContract(IsOneWay = true)]
        void Get_dsDichVu();

    }

    public interface IQLPMCallback
    {
        [OperationContract(IsOneWay = true)]
        void DangNhap_Callback(bool ketQua, string msg, NhanVien nhanVien, IEnumerable<ChucNang> dsChucNang_By_taikhoanNV);

        [OperationContract(IsOneWay = true)]
        void DangXuat_Callback();

        [OperationContract(IsOneWay = true)]
        void Get_dsNhanVien_Callback(IEnumerable<NhanVien> dsNhanVien);

        [OperationContract(IsOneWay = true)]
        void Get_dsChucNang_By_taikhoanNV_Callback(IEnumerable<ChucNang> dsChucNang_By_taikhoanNV);

        [OperationContract(IsOneWay = true)]
        void Get_dsChucNang_Callback(IEnumerable<ChucNang> dsChucNang);

        [OperationContract(IsOneWay = true)]
        void Get_PhongKham_Callback(ThongTinPhongKham phongKham);

        [OperationContract(IsOneWay = true)]
        void Get_dsNhanVien_By_taikhoanNV_Callback(IEnumerable<NhanVien> dsNhanVien_By_taikhoanNV);

        [OperationContract(IsOneWay = true)]
        void Get_dsTrangThaiNV_Callback(IEnumerable<TrangThaiNV> dsTrangThaiNV);

        [OperationContract(IsOneWay = true)]
        void Add_NhanVien_Callback(string taikhoanNV);

        [OperationContract(IsOneWay = true)]
        void Get_dsDichVu_By_ChucNang_Callback(IEnumerable<DichVu> dsDichVu_By_ChucNang);
    }

    [DataContract]
    public class ChucNang
    {
        private string maCN;
        private string tenCN;
        [DataMember]
        public string MaCN
        {
            get { return maCN; }
            set { maCN = value; }
        }
        [DataMember]
        public string TenCN
        {
            get { return tenCN; }
            set { tenCN = value; }
        }
    }

    [DataContract]
    public class NhanVien
    {
        private string taiKhoanNV;
        private string mkNV;
        private string hoVaTenDemNV;
        private string tenNV;
        private DateTime ngaySinhNV;
        private bool gioiTinhNV;
        private string sDTNV;
        private string diaChiNV;
        private string maTrangThaiNV;

        [DataMember(Order = 1)]
        public string TaiKhoanNV
        {
            get { return taiKhoanNV; }
            set { taiKhoanNV = value; }
        }
        [DataMember(Order = 2)]
        public string MkNV
        {
            get { return mkNV; }
            set { mkNV = value; }
        }
        [DataMember(Order = 3)]
        public string HoVaTenDemNV
        {
            get { return hoVaTenDemNV; }
            set { hoVaTenDemNV = value; }
        }
        [DataMember(Order = 4)]
        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }
        [DataMember(Order = 5)]
        public DateTime NgaySinhNV
        {
            get { return ngaySinhNV; }
            set { ngaySinhNV = value; }
        }
        [DataMember(Order = 6)]
        public bool GioiTinhNV
        {
            get { return gioiTinhNV; }
            set { gioiTinhNV = value; }
        }
        [DataMember(Order = 7)]
        public string SDTNV
        {
            get { return sDTNV; }
            set { sDTNV = value; }
        }
        [DataMember(Order = 8)]
        public string DiaChiNV
        {
            get { return diaChiNV; }
            set { diaChiNV = value; }
        }
        [DataMember(Order = 9)]
        public string MaTrangThaiNV
        {
            get { return maTrangThaiNV; }
            set { maTrangThaiNV = value; }
        }
    }

    [DataContract]
    public class DichVu
    {
        private string maDV;
        private string tenDV;
        private string maCN;
        private double giaDV;

        [DataMember(Order = 1)]
        public string MaDV
        {
            get { return maDV; }
            set { maDV = value; }
        }
        [DataMember(Order = 2)]
        public string TenDV
        {
            get { return tenDV; }
            set { tenDV = value; }
        }
        [DataMember(Order = 3)]
        public string MaCN
        {
            get { return maCN; }
            set { maCN = value; }
        }
        [DataMember(Order = 4)]
        public double GiaDV
        {
            get { return giaDV; }
            set { giaDV = value; }
        }
    }

    [DataContract]
    public class ThongTinPhongKham
    {
        private string tenPK;
        private string sDTPK;
        private string diaChiPK;

        [DataMember]
        public string TenPK
        {
            get { return tenPK; }
            set { tenPK = value; }
        }

        [DataMember]
        public string SDTPK
        {
            get { return sDTPK; }
            set { sDTPK = value; }
        }

        [DataMember]
        public string DiaChiPK
        {
            get { return diaChiPK; }
            set { diaChiPK = value; }
        }
    }

    [DataContract]
    public class TrangThaiNV
    {
        private string maTrangThaiNV;
        private string tenTrangThaiNV;

        [DataMember(Order=1)]
        public string MaTrangThaiNV
        {
            set { maTrangThaiNV = value; }
            get { return maTrangThaiNV; }
        }

        [DataMember(Order=2)]
        public string TenTrangThaiNV
        {
            get { return tenTrangThaiNV; }
            set { tenTrangThaiNV = value; }
        }
    }

    [DataContract]
    public class NhanVien_ChucNang
    {
        private string taiKhoanNV;
        private string maCN;

        [DataMember]
        public string MaCN
        {
            get { return maCN; }
            set { maCN = value; }
        }

        [DataMember]
        public string TaiKhoanNV
        {
            get { return taiKhoanNV; }
            set { taiKhoanNV = value; }
        }
    }
}
