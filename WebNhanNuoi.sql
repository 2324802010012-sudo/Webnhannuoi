Create database WebNhanNuoi
go 
Use WebNhanNuoi
go
CREATE TABLE NguoiDung (
    MaNguoiDung INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    MatKhau NVARCHAR(100) NOT NULL,
    VaiTro NVARCHAR(50) CHECK (VaiTro IN (N'Admin', N'Lễ tân', N'Chăm sóc', N'Shipper', N'Người dùng')) DEFAULT N'Người dùng',
    SoDienThoai NVARCHAR(20),
    DiaChi NVARCHAR(200),
    AnhDaiDien NVARCHAR(255),
    NgayDangKy DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(30) DEFAULT N'Hoạt động'
)
CREATE TABLE DanhMucLoai (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(50) NOT NULL
)
INSERT INTO DanhMucLoai (TenLoai)
VALUES (N'Chó'), (N'Mèo');

CREATE TABLE ThuCung (
    MaThuCung INT IDENTITY(1,1) PRIMARY KEY,
    TenThuCung NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    Tuoi INT,
    MoTa NVARCHAR(500),
    Anh NVARCHAR(255),
    TrangThai NVARCHAR(50) DEFAULT N'Đang được chăm sóc',
    MaLoai INT FOREIGN KEY REFERENCES DanhMucLoai(MaLoai)
)
CREATE TABLE ChamSocThuCung (
    MaChamSoc INT IDENTITY(1,1) PRIMARY KEY,
    MaThuCung INT FOREIGN KEY REFERENCES ThuCung(MaThuCung),
    MaNhanVien INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung),
    NgayKiemTra DATETIME DEFAULT GETDATE(),
    TinhTrangSucKhoe NVARCHAR(200),
    TiemPhong BIT DEFAULT 0,
    GhiChu NVARCHAR(200)
)
CREATE TABLE BaiDang (
    MaBaiDang INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung),
    MaThuCung INT FOREIGN KEY REFERENCES ThuCung(MaThuCung),
    NgayDang DATETIME DEFAULT GETDATE(),
    TieuDe NVARCHAR(200),
    NoiDung NVARCHAR(1000),
    TrangThai NVARCHAR(50) DEFAULT N'Chờ duyệt'
)
CREATE TABLE DonNhanNuoi (
    MaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung),
    MaThuCung INT FOREIGN KEY REFERENCES ThuCung(MaThuCung),
    NgayGui DATETIME DEFAULT GETDATE(),
    LyDo NVARCHAR(500),
    DiaChiNhan NVARCHAR(200),
    TrangThai NVARCHAR(50) DEFAULT N'Chờ lễ tân xử lý'
)
CREATE TABLE GiaoHang (
    MaGiaoHang INT IDENTITY(1,1) PRIMARY KEY,
    MaDon INT FOREIGN KEY REFERENCES DonNhanNuoi(MaDon),
    MaShipper INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung),
    NgayGiao DATETIME,
    TrangThaiGiao NVARCHAR(50) DEFAULT N'Đang chờ giao',
    GhiChu NVARCHAR(200)
)
CREATE TABLE ThongBao (
    MaThongBao INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung),
    NoiDung NVARCHAR(500),
    NgayGui DATETIME DEFAULT GETDATE(),
    DaDoc BIT DEFAULT 0
	)

-- Người dùng & nhân viên
INSERT INTO NguoiDung (HoTen, Email, MatKhau, VaiTro, SoDienThoai, DiaChi)
VALUES 
(N'Admin ', 'admin@pet.com', '123456', N'Admin', '0909000001', N'Thủ Dầu Một'),
(N'Nguyễn Thư', 'letan@pet.com', '123456', N'Lễ tân', '0909000002', N'Thủ Dầu Một'),
(N'Bùi Nhi', 'chamsoc@petc.com', '123456', N'Chăm sóc', '0909000003', N'Tân Uyên'),
(N'Lê Huy', 'shipper@pet.com', '123456', N'Shipper', '0909000004', N'Bến Cát')

