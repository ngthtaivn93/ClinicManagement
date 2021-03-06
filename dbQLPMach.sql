USE MASTER
GO
CREATE DATABASE dbQLPM
--Use MASTER
--ALTER database [dbQLPM] set offline with ROLLBACK IMMEDIATE
--DROP database [dbQLPM]
GO
USE dbQLPM
GO
--TAO TABLE
--tbThongTinPhongKham
--tbTrangThaiNV
--tbChucNang
--tbNhanVien
--tbBenhNhan
--tbThuoc
--tbDichVu
--tbNhanVien_ChucNang
--tbHoaDon
--tbChiTietHoaDon
--tbDonThuoc
--tbChiTietDonThuoc
--tbPhieuCDDV
--tbChiTietPhieuCDDV
--tbPhieuXN
--tbPhieuCDHA
CREATE TABLE tbThongTinPhongKham
(
	tenPK NVARCHAR(150) PRIMARY KEY NOT NULL,
	sDTPK VARCHAR(15),
	diaChiPK NVARCHAR(130)
)
GO
CREATE TABLE tbTrangThaiNV
(
	maTrangThaiNV CHAR(2) PRIMARY KEY NOT NULL,
	tenTrangThaiNV NVARCHAR(100)
)
GO
CREATE TABLE tbChucNang
(
	maCN CHAR(5) PRIMARY KEY NOT NULL,
	tenCN NVARCHAR(100)
)
GO
CREATE TABLE tbNhanVien
(
	taiKhoanNV VARCHAR(16) PRIMARY KEY NOT NULL,
	mkNV VARCHAR(16) NOT NULL,
	hoVaTenDemNV NVARCHAR(50),
	tenNV NVARCHAR(30),
	ngaySinhNV DATETIME,
	gioiTinhNV BIT,
	sDTNV VARCHAR(15),
	diaChiNV NVARCHAR(130),
	maTrangThaiNV CHAR(2) NOT NULL, 
)
GO
CREATE TABLE tbBenhNhan
(
	maBN CHAR(14) PRIMARY KEY NOT NULL,
	hoVaTenDemBN NVARCHAR(50),
	tenBN NVARCHAR(30) NOT NULL,
	ngaySinhBN DATETIME,
	gioiTinhBN BIT,
	sDTBN VARCHAR(15),
	diaChiBN NVARCHAR(130),
	trangThaiBN NVARCHAR(100) NOT NULL
)
GO
CREATE TABLE tbThuoc
(
	maThuoc CHAR(7) PRIMARY KEY NOT NULL,
	tenThuoc NVARCHAR(100),
	donViTinh NVARCHAR(20) ,
	soLuongCon INT,
	donGia FLOAT,
	hanSuDung DATETIME,
	trangThaiThuoc NVARCHAR(100) NOT NULL
)
GO
CREATE TABLE tbDichVu
(
	maDV CHAR(6) PRIMARY KEY NOT NULL,
	tenDV NVARCHAR(100),
	maCN CHAR(5),
	giaDV FLOAT
)
GO
CREATE TABLE tbNhanVien_ChucNang
(
	taiKhoanNV VARCHAR(16) NOT NULL,
	maCN CHAR(5) NOT NULL,
	PRIMARY KEY (taiKhoanNV, maCN)
)
GO
CREATE TABLE tbHoaDon
(
	maHoaDon CHAR(9) PRIMARY KEY NOT NULL,
	taiKhoanNV VARCHAR(16),
	maBN CHAR(14),
	ngayLap DATETIME
)
GO
CREATE TABLE tbChiTietHoaDon
(
	maHoaDon CHAR(9) NOT NULL,
	maDV CHAR(6) NOT NULL,
	giaDV FLOAT,
	PRIMARY KEY (maHoaDon, maDV)
)
GO
CREATE TABLE tbDonThuoc
(
	maDonThuoc CHAR(9) PRIMARY KEY NOT NULL,
	taiKhoanNV VARCHAR(16),
	maBN CHAR(14),
	trieuChung NVARCHAR(200),
	chuanDoan NVARCHAR(200),
	loiDan NVARCHAR(200),
	ngayLap DATETIME
)
GO
CREATE TABLE tbChiTietDonThuoc
(
	maDonThuoc CHAR(9) NOT NULL,
	maThuoc CHAR(7) NOT NULL,
	soLuong INT,
	lieuDung NVARCHAR(100),
	cachDung NVARCHAR(100),
	donGia FLOAT,
	PRIMARY KEY (maDonThuoc, maThuoc)
)
GO
CREATE TABLE tbPhieuCDDV
(
	maPhieuCDDV CHAR(9) PRIMARY KEY NOT NULL,
	taiKhoanNV VARCHAR(16),
	maBN CHAR(14),
	ngayLap DATETIME
)
GO
CREATE TABLE tbChiTietPhieuCDDV
(
	maPhieuCDDV CHAR(9) NOT NULL,
	maDV CHAR(6) NOT NULL,
	PRIMARY KEY (maPhieuCDDV, maDV)
)
GO
CREATE TABLE tbPhieuXN
(
	maPhieuXN CHAR(9) PRIMARY KEY NOT NULL,
	taiKhoanNV VARCHAR(16),
	maBN CHAR(14),
	moTa NVARCHAR(200),
	ketLuan NVARCHAR(200),
	loiDan NVARCHAR(200),
	ngayLap DATETIME
)
GO
CREATE TABLE tbPhieuCDHA
(
	maPhieuCDHA CHAR(9) PRIMARY KEY NOT NULL,
	taiKhoanNV VARCHAR(16),
	maBN CHAR(14),
	hinhAnh IMAGE,
	moTa NVARCHAR(200),
	ketLuan NVARCHAR(200),
	loiDan NVARCHAR(200),
	ngayLap DATETIME
)
GO
--TAO CONSTRAINT
--tbNhanVien_ChucNang
ALTER TABLE tbNhanVien_ChucNang
ADD FOREIGN KEY (taiKhoanNV)
REFERENCES tbNhanVien(taiKhoanNV)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE tbNhanVien_ChucNang
ADD FOREIGN KEY (maCN)
REFERENCES tbChucNang(maCN)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--tbHoaDon
ALTER TABLE tbHoaDon
ADD FOREIGN KEY (taiKhoanNV)
REFERENCES tbNhanVien(taiKhoanNV)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE tbHoaDon
ADD FOREIGN KEY (maBN)
REFERENCES tbBenhNhan(maBN)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--tbChiTietHoaDon
ALTER TABLE tbChiTietHoaDon
ADD FOREIGN KEY (maHoaDon)
REFERENCES tbHoaDon(maHoaDon)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE tbChiTietHoaDon
ADD FOREIGN KEY (maDV)
REFERENCES tbDichVu(maDV)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--tbChiTietHoaDon
ALTER TABLE tbDonThuoc
ADD FOREIGN KEY (taiKhoanNV)
REFERENCES tbNhanVien(taiKhoanNV)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE tbDonThuoc
ADD FOREIGN KEY (maBN)
REFERENCES tbBenhNhan(maBN)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--tbChiTietDonThuoc
ALTER TABLE tbChiTietDonThuoc
ADD FOREIGN KEY (maDonThuoc)
REFERENCES tbDonThuoc(maDonThuoc)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE tbChiTietDonThuoc
ADD FOREIGN KEY (maThuoc)
REFERENCES tbThuoc(maThuoc)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--tbPhieuCDDV
ALTER TABLE tbPhieuCDDV
ADD FOREIGN KEY (taiKhoanNV)
REFERENCES tbNhanVien(taiKhoanNV)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE tbPhieuCDDV
ADD FOREIGN KEY (maBN)
REFERENCES tbBenhNhan(maBN)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--tbChiTietPhieuCDDV
ALTER TABLE tbChiTietPhieuCDDV
ADD FOREIGN KEY (maPhieuCDDV)
REFERENCES tbPhieuCDDV(maPhieuCDDV)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE tbChiTietPhieuCDDV
ADD FOREIGN KEY (maDV)
REFERENCES tbDichVu(maDV)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--tbPhieuXN
ALTER TABLE tbPhieuXN
ADD FOREIGN KEY (taiKhoanNV)
REFERENCES tbNhanVien(taiKhoanNV)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE tbPhieuXN
ADD FOREIGN KEY (maBN)
REFERENCES tbBenhNhan(maBN)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--tbPhieuCDHA
ALTER TABLE tbPhieuCDHA
ADD FOREIGN KEY (taiKhoanNV)
REFERENCES tbNhanVien(taiKhoanNV)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE tbPhieuCDHA
ADD FOREIGN KEY (maBN)
REFERENCES tbBenhNhan(maBN)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--tbDichVu
ALTER TABLE tbDichVu
ADD FOREIGN KEY (maCN)
REFERENCES tbChucNang(maCN)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--tbNhanVien
ALTER TABLE tbNhanVien
ADD FOREIGN KEY (maTrangThaiNV)
REFERENCES tbTrangThaiNV(maTrangThaiNV)
ON DELETE CASCADE
ON UPDATE CASCADE
GO

-- Insert du lieu khoi tao
--tbThongTinPhongKham
INSERT INTO tbThongTinPhongKham VALUES(N'Phòng khám đa khoa Bác sĩ X','01489869885',N'12 Nguyễn Văn Bảo, P.4, Q.Gò Vấp, TP. HCM')
--tbTrangThaiNV
INSERT INTO tbTrangThaiNV VALUES('00',N'Đang làm việc')
INSERT INTO tbTrangThaiNV VALUES('01',N'Đã đăng nhập vào hệ thống')
INSERT INTO tbTrangThaiNV VALUES('02',N'Đã nghỉ việc')
--tbChucNang
INSERT INTO tbChucNang VALUES('CN000',N'Tiếp nhận')
INSERT INTO tbChucNang VALUES('CN001',N'Thu ngân')
INSERT INTO tbChucNang VALUES('CN002',N'Quản lý quầy thuốc')
INSERT INTO tbChucNang VALUES('CN003',N'Khám nội')
INSERT INTO tbChucNang VALUES('CN004',N'Khám ngoại')
INSERT INTO tbChucNang VALUES('CN005',N'Khám tai - mũi - họng')
INSERT INTO tbChucNang VALUES('CN006',N'Khám nhi')
INSERT INTO tbChucNang VALUES('CN007',N'Khám phụ sản')
INSERT INTO tbChucNang VALUES('CN008',N'Xét nghiệm')
INSERT INTO tbChucNang VALUES('CN009',N'Chẩn đoán hình ảnh')
INSERT INTO tbChucNang VALUES('CN010',N'Quản trị hệ thống')
--tbNhanVien
INSERT INTO tbNhanVien VALUES('tai','123',N'Nguyễn Thành',N'Tài','19930524','1','01489869885',N'Lê Đức Thọ, Quận Gò Vấp, TP. HCM','00')
INSERT INTO tbNhanVien VALUES('hien','123',N'Lê Thị',N'Hiền','19911013','0',N'01442144146','Quận 2, TP. HCM','00')
INSERT INTO tbNhanVien VALUES('linh','123',N'Cao Huyền',N'Linh','19860117','0','0912145368',N'Quận 3, TP. HCM','00')
INSERT INTO tbNhanVien VALUES('thuan','123',N'Bùi Quang',N'Thuần','19860404','1','0914142689',N'Lê Đức Thọ, Quận Gò Vấp, TP. HCM','00')
INSERT INTO tbNhanVien VALUES('duong','123',N'Phí Thị Mai',N'Dương','19850115','0','01469788679',N'Quận Tân Bình, TP. HCM','00')
INSERT INTO tbNhanVien VALUES('dung','123',N'Phạm Anh',N'Dũng','19880204','1','0978178764',N'12 Trường Chinh, Quận Tân Bình, TP. HCM','00')
INSERT INTO tbNhanVien VALUES('dao','123',N'Nguyễn Thị',N'Đào','19880519','0','0982725726',N'Cộng Hòa, Quận Tân Bình, TP. HCM','00')
INSERT INTO tbNhanVien VALUES('hang','123',N'Hoàng Thu',N'Hằng','19860523','0','01449614718',N'Quận 12, TP. HCM','00')
INSERT INTO tbNhanVien VALUES('quen','123',N'Lưu Thị',N'Quyên','19871211','0','0979006323',N'Quận 5, TP. HCM','00')
INSERT INTO tbNhanVien VALUES('vquen','123',N'Lê Văn',N'Quyến','19881011','1','0984754144',N'Quận 7, TP. HCM','00')
INSERT INTO tbNhanVien VALUES('vanlinh','123',N'Nguyễn Văn',N'Linh','19841214','1','0984512457',N'Nam kỳ khởi nghĩa, Quận 1, TP. HCM','00')
--tbBenhNhan
INSERT INTO tbBenhNhan VALUES('BN01012001-009',N'Lê',N'Minh','19820524','1','01421451444',N'Dương Bá Trạch, Phường 2, Quận 8, TP. Hồ Chí Minh',N'Hoàn thành')
INSERT INTO tbBenhNhan VALUES('BN01012001-010',N'Nguyễn Lưu',N'Huệ','19891014','0','01485745745',N'Nguyễn Đình Chiểu, Quận 1, TP. HCM',N'Hoàn thành')
--tbThuoc
INSERT INTO tbThuoc VALUES('TH00000',N'Bupivacain (hydroclorid)',N'Ống',1000,14000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00001',N'Isofluran',N'Lọ',1000,25000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00002',N'Isoflurane',N'Chai',1200,90000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00003',N'Lidocain',N'Ống',900,70000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00004',N'Aceclofenac',N'Viên',1300,40000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00005',N'Celecoxib',N'Viên',8000,30000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00006',N'Diclofenac',N'Ống',5600,35000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00007',N'Etoricoxib',N'Viên',4500,70000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00008',N'Meloxicam',N'Viên',9000,140000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00009',N'Paracetamol',N'Viên',10000,170000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00010',N'Glucosamin',N'Viên',11100,25000,'20170101',N'Không còn sử dụng')
INSERT INTO tbThuoc VALUES('TH00011',N'Fexofenadin',N'Viên',14500,20000,'20170101',N'Không còn sử dụng')
INSERT INTO tbThuoc VALUES('TH00012',N'Gabapentin',N'Viên',12000,25000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00013',N'Valproat natri',N'Viên',1500,31000,'20170101',N'Đang sử dụng')
INSERT INTO tbThuoc VALUES('TH00014',N'Oxcarbazepin',N'Chai',21000,6000,'20170101',N'Không còn sử dụng')
INSERT INTO tbThuoc VALUES('TH00015',N'Phenobarbital',N'Ống',53000,20000,'20170101',N'Không còn sử dụng')
--tbDichVu
INSERT INTO tbDichVu VALUES('DV0000',N'Khám nội tổng quát','CN003', 150000)
INSERT INTO tbDichVu VALUES('DV0001',N'Khám tim mạch','CN003', 120000)
INSERT INTO tbDichVu VALUES('DV0002',N'Khám hô hấp','CN003', 130000)
INSERT INTO tbDichVu VALUES('DV0003',N'Khám gan mật','CN003', 150000)
INSERT INTO tbDichVu VALUES('DV0004',N'Khám cơ xương khớp','CN003', 140000)
INSERT INTO tbDichVu VALUES('DV0005',N'Khám ngoại tổng quát','CN004', 120000)
INSERT INTO tbDichVu VALUES('DV0006',N'Khám ung bướu','CN004', 80000)
INSERT INTO tbDichVu VALUES('DV0007',N'Khám tai - mũi - họng','CN005', 120000)
INSERT INTO tbDichVu VALUES('DV0008',N'Khám nhi','CN006', 70000)
INSERT INTO tbDichVu VALUES('DV0009',N'Khám phụ sản','CN007', 140000)
INSERT INTO tbDichVu VALUES('DV0010',N'Chụp X-quang','CN009', 90000)
INSERT INTO tbDichVu VALUES('DV0011',N'Siêu âm','CN009', 200000)
INSERT INTO tbDichVu VALUES('DV0012',N'Chụp cộng hưởng từ (MRI)','CN009', 350000)
INSERT INTO tbDichVu VALUES('DV0013',N'Xét nghiệm máu','CN008', 100000)
INSERT INTO tbDichVu VALUES('DV0014',N'Xét nghiệm nước tiểu','CN008', 100000)
INSERT INTO tbDichVu VALUES('DV0015',N'Xét nghiệm chức năng gan','CN008', 100000)
--tbNhanVien_ChucNang
INSERT INTO tbNhanVien_ChucNang VALUES('hien','CN000')
INSERT INTO tbNhanVien_ChucNang VALUES('hien','CN001')
INSERT INTO tbNhanVien_ChucNang VALUES('linh','CN002')
INSERT INTO tbNhanVien_ChucNang VALUES('thuan','CN003')
INSERT INTO tbNhanVien_ChucNang VALUES('duong','CN003')
INSERT INTO tbNhanVien_ChucNang VALUES('dung','CN004')
INSERT INTO tbNhanVien_ChucNang VALUES('dao','CN005')
INSERT INTO tbNhanVien_ChucNang VALUES('hang','CN006')
INSERT INTO tbNhanVien_ChucNang VALUES('quen','CN007')
INSERT INTO tbNhanVien_ChucNang VALUES('vquen','CN008')
INSERT INTO tbNhanVien_ChucNang VALUES('vanlinh','CN009')
INSERT INTO tbNhanVien_ChucNang VALUES('tai','CN010')
--tbHoaDon
--tbChiTietHoaDon
--tbDonThuoc
--tbChiTietDonThuoc
--tbPhieuCDDV
--tbChiTietPhieuCDDV
--tbPhieuXN
--tbPhieuCDHA