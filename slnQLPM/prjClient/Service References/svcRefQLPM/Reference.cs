﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjClient.svcRefQLPM {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NhanVien", Namespace="http://schemas.datacontract.org/2004/07/prjQLPMService")]
    [System.SerializableAttribute()]
    public partial class NhanVien : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TaiKhoanNVField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MkNVField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HoVaTenDemNVField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TenNVField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime NgaySinhNVField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool GioiTinhNVField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SDTNVField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DiaChiNVField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MaTrangThaiNVField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TaiKhoanNV {
            get {
                return this.TaiKhoanNVField;
            }
            set {
                if ((object.ReferenceEquals(this.TaiKhoanNVField, value) != true)) {
                    this.TaiKhoanNVField = value;
                    this.RaisePropertyChanged("TaiKhoanNV");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string MkNV {
            get {
                return this.MkNVField;
            }
            set {
                if ((object.ReferenceEquals(this.MkNVField, value) != true)) {
                    this.MkNVField = value;
                    this.RaisePropertyChanged("MkNV");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string HoVaTenDemNV {
            get {
                return this.HoVaTenDemNVField;
            }
            set {
                if ((object.ReferenceEquals(this.HoVaTenDemNVField, value) != true)) {
                    this.HoVaTenDemNVField = value;
                    this.RaisePropertyChanged("HoVaTenDemNV");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string TenNV {
            get {
                return this.TenNVField;
            }
            set {
                if ((object.ReferenceEquals(this.TenNVField, value) != true)) {
                    this.TenNVField = value;
                    this.RaisePropertyChanged("TenNV");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public System.DateTime NgaySinhNV {
            get {
                return this.NgaySinhNVField;
            }
            set {
                if ((this.NgaySinhNVField.Equals(value) != true)) {
                    this.NgaySinhNVField = value;
                    this.RaisePropertyChanged("NgaySinhNV");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public bool GioiTinhNV {
            get {
                return this.GioiTinhNVField;
            }
            set {
                if ((this.GioiTinhNVField.Equals(value) != true)) {
                    this.GioiTinhNVField = value;
                    this.RaisePropertyChanged("GioiTinhNV");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public string SDTNV {
            get {
                return this.SDTNVField;
            }
            set {
                if ((object.ReferenceEquals(this.SDTNVField, value) != true)) {
                    this.SDTNVField = value;
                    this.RaisePropertyChanged("SDTNV");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public string DiaChiNV {
            get {
                return this.DiaChiNVField;
            }
            set {
                if ((object.ReferenceEquals(this.DiaChiNVField, value) != true)) {
                    this.DiaChiNVField = value;
                    this.RaisePropertyChanged("DiaChiNV");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public string MaTrangThaiNV {
            get {
                return this.MaTrangThaiNVField;
            }
            set {
                if ((object.ReferenceEquals(this.MaTrangThaiNVField, value) != true)) {
                    this.MaTrangThaiNVField = value;
                    this.RaisePropertyChanged("MaTrangThaiNV");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChucNang", Namespace="http://schemas.datacontract.org/2004/07/prjQLPMService")]
    [System.SerializableAttribute()]
    public partial class ChucNang : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MaCNField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TenCNField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MaCN {
            get {
                return this.MaCNField;
            }
            set {
                if ((object.ReferenceEquals(this.MaCNField, value) != true)) {
                    this.MaCNField = value;
                    this.RaisePropertyChanged("MaCN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TenCN {
            get {
                return this.TenCNField;
            }
            set {
                if ((object.ReferenceEquals(this.TenCNField, value) != true)) {
                    this.TenCNField = value;
                    this.RaisePropertyChanged("TenCN");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ThongTinPhongKham", Namespace="http://schemas.datacontract.org/2004/07/prjQLPMService")]
    [System.SerializableAttribute()]
    public partial class ThongTinPhongKham : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DiaChiPKField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SDTPKField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TenPKField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DiaChiPK {
            get {
                return this.DiaChiPKField;
            }
            set {
                if ((object.ReferenceEquals(this.DiaChiPKField, value) != true)) {
                    this.DiaChiPKField = value;
                    this.RaisePropertyChanged("DiaChiPK");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SDTPK {
            get {
                return this.SDTPKField;
            }
            set {
                if ((object.ReferenceEquals(this.SDTPKField, value) != true)) {
                    this.SDTPKField = value;
                    this.RaisePropertyChanged("SDTPK");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TenPK {
            get {
                return this.TenPKField;
            }
            set {
                if ((object.ReferenceEquals(this.TenPKField, value) != true)) {
                    this.TenPKField = value;
                    this.RaisePropertyChanged("TenPK");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TrangThaiNV", Namespace="http://schemas.datacontract.org/2004/07/prjQLPMService")]
    [System.SerializableAttribute()]
    public partial class TrangThaiNV : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MaTrangThaiNVField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TenTrangThaiNVField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MaTrangThaiNV {
            get {
                return this.MaTrangThaiNVField;
            }
            set {
                if ((object.ReferenceEquals(this.MaTrangThaiNVField, value) != true)) {
                    this.MaTrangThaiNVField = value;
                    this.RaisePropertyChanged("MaTrangThaiNV");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TenTrangThaiNV {
            get {
                return this.TenTrangThaiNVField;
            }
            set {
                if ((object.ReferenceEquals(this.TenTrangThaiNVField, value) != true)) {
                    this.TenTrangThaiNVField = value;
                    this.RaisePropertyChanged("TenTrangThaiNV");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="svcRefQLPM.IQLPM", CallbackContract=typeof(prjClient.svcRefQLPM.IQLPMCallback))]
    public interface IQLPM {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/DangNhap")]
        void DangNhap(string taikhoanNV, string mK);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/DangNhap")]
        System.Threading.Tasks.Task DangNhapAsync(string taikhoanNV, string mK);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/DangXuat")]
        void DangXuat(string taikhoanNV);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/DangXuat")]
        System.Threading.Tasks.Task DangXuatAsync(string taikhoanNV);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsNhanVien")]
        void Get_dsNhanVien();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsNhanVien")]
        System.Threading.Tasks.Task Get_dsNhanVienAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsChucNang_By_taikhoanNV")]
        void Get_dsChucNang_By_taikhoanNV(string taikhoanNV);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsChucNang_By_taikhoanNV")]
        System.Threading.Tasks.Task Get_dsChucNang_By_taikhoanNVAsync(string taikhoanNV);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsChucNang")]
        void Get_dsChucNang();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsChucNang")]
        System.Threading.Tasks.Task Get_dsChucNangAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_PhongKham")]
        void Get_PhongKham();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_PhongKham")]
        System.Threading.Tasks.Task Get_PhongKhamAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsNhanVien_By_taikhoanNV")]
        void Get_dsNhanVien_By_taikhoanNV(string taikhoanNV);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsNhanVien_By_taikhoanNV")]
        System.Threading.Tasks.Task Get_dsNhanVien_By_taikhoanNVAsync(string taikhoanNV);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsTrangThaiNV")]
        void Get_dsTrangThaiNV();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsTrangThaiNV")]
        System.Threading.Tasks.Task Get_dsTrangThaiNVAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Add_NhanVien")]
        void Add_NhanVien(prjClient.svcRefQLPM.NhanVien newNhanVien, string[] dsChucNang_newNhanVien);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Add_NhanVien")]
        System.Threading.Tasks.Task Add_NhanVienAsync(prjClient.svcRefQLPM.NhanVien newNhanVien, string[] dsChucNang_newNhanVien);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Mod_NhanVien")]
        void Mod_NhanVien(prjClient.svcRefQLPM.NhanVien modNhanVien, string[] dsChucNang_modNhanVien);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Mod_NhanVien")]
        System.Threading.Tasks.Task Mod_NhanVienAsync(prjClient.svcRefQLPM.NhanVien modNhanVien, string[] dsChucNang_modNhanVien);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IQLPMCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/DangNhap_Callback")]
        void DangNhap_Callback(bool ketQua, string msg, prjClient.svcRefQLPM.NhanVien nhanVien, prjClient.svcRefQLPM.ChucNang[] dsChucNang_By_taikhoanNV);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/DangXuat_Callback")]
        void DangXuat_Callback();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsNhanVien_Callback")]
        void Get_dsNhanVien_Callback(prjClient.svcRefQLPM.NhanVien[] dsNhanVien);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsChucNang_By_taikhoanNV_Callback")]
        void Get_dsChucNang_By_taikhoanNV_Callback(prjClient.svcRefQLPM.ChucNang[] dsChucNang_By_taikhoanNV);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsChucNang_Callback")]
        void Get_dsChucNang_Callback(prjClient.svcRefQLPM.ChucNang[] dsChucNang);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_PhongKham_Callback")]
        void Get_PhongKham_Callback(prjClient.svcRefQLPM.ThongTinPhongKham phongKham);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsNhanVien_By_taikhoanNV_Callback")]
        void Get_dsNhanVien_By_taikhoanNV_Callback(prjClient.svcRefQLPM.NhanVien[] dsNhanVien_By_taikhoanNV);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Get_dsTrangThaiNV_Callback")]
        void Get_dsTrangThaiNV_Callback(prjClient.svcRefQLPM.TrangThaiNV[] dsTrangThaiNV);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQLPM/Add_NhanVien_Callback")]
        void Add_NhanVien_Callback(string taikhoanNV);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IQLPMChannel : prjClient.svcRefQLPM.IQLPM, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class QLPMClient : System.ServiceModel.DuplexClientBase<prjClient.svcRefQLPM.IQLPM>, prjClient.svcRefQLPM.IQLPM {
        
        public QLPMClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public QLPMClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public QLPMClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public QLPMClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public QLPMClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void DangNhap(string taikhoanNV, string mK) {
            base.Channel.DangNhap(taikhoanNV, mK);
        }
        
        public System.Threading.Tasks.Task DangNhapAsync(string taikhoanNV, string mK) {
            return base.Channel.DangNhapAsync(taikhoanNV, mK);
        }
        
        public void DangXuat(string taikhoanNV) {
            base.Channel.DangXuat(taikhoanNV);
        }
        
        public System.Threading.Tasks.Task DangXuatAsync(string taikhoanNV) {
            return base.Channel.DangXuatAsync(taikhoanNV);
        }
        
        public void Get_dsNhanVien() {
            base.Channel.Get_dsNhanVien();
        }
        
        public System.Threading.Tasks.Task Get_dsNhanVienAsync() {
            return base.Channel.Get_dsNhanVienAsync();
        }
        
        public void Get_dsChucNang_By_taikhoanNV(string taikhoanNV) {
            base.Channel.Get_dsChucNang_By_taikhoanNV(taikhoanNV);
        }
        
        public System.Threading.Tasks.Task Get_dsChucNang_By_taikhoanNVAsync(string taikhoanNV) {
            return base.Channel.Get_dsChucNang_By_taikhoanNVAsync(taikhoanNV);
        }
        
        public void Get_dsChucNang() {
            base.Channel.Get_dsChucNang();
        }
        
        public System.Threading.Tasks.Task Get_dsChucNangAsync() {
            return base.Channel.Get_dsChucNangAsync();
        }
        
        public void Get_PhongKham() {
            base.Channel.Get_PhongKham();
        }
        
        public System.Threading.Tasks.Task Get_PhongKhamAsync() {
            return base.Channel.Get_PhongKhamAsync();
        }
        
        public void Get_dsNhanVien_By_taikhoanNV(string taikhoanNV) {
            base.Channel.Get_dsNhanVien_By_taikhoanNV(taikhoanNV);
        }
        
        public System.Threading.Tasks.Task Get_dsNhanVien_By_taikhoanNVAsync(string taikhoanNV) {
            return base.Channel.Get_dsNhanVien_By_taikhoanNVAsync(taikhoanNV);
        }
        
        public void Get_dsTrangThaiNV() {
            base.Channel.Get_dsTrangThaiNV();
        }
        
        public System.Threading.Tasks.Task Get_dsTrangThaiNVAsync() {
            return base.Channel.Get_dsTrangThaiNVAsync();
        }
        
        public void Add_NhanVien(prjClient.svcRefQLPM.NhanVien newNhanVien, string[] dsChucNang_newNhanVien) {
            base.Channel.Add_NhanVien(newNhanVien, dsChucNang_newNhanVien);
        }
        
        public System.Threading.Tasks.Task Add_NhanVienAsync(prjClient.svcRefQLPM.NhanVien newNhanVien, string[] dsChucNang_newNhanVien) {
            return base.Channel.Add_NhanVienAsync(newNhanVien, dsChucNang_newNhanVien);
        }
        
        public void Mod_NhanVien(prjClient.svcRefQLPM.NhanVien modNhanVien, string[] dsChucNang_modNhanVien) {
            base.Channel.Mod_NhanVien(modNhanVien, dsChucNang_modNhanVien);
        }
        
        public System.Threading.Tasks.Task Mod_NhanVienAsync(prjClient.svcRefQLPM.NhanVien modNhanVien, string[] dsChucNang_modNhanVien) {
            return base.Channel.Mod_NhanVienAsync(modNhanVien, dsChucNang_modNhanVien);
        }
    }
}
