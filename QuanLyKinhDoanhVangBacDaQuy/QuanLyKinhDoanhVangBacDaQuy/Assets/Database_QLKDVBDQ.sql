CREATE DATABASE QuanLyKinhDoanhVangBacDaQuy
USE QuanLyKinhDoanhVangBacDaQuy

Create table PHIEUMUAHANG
(
	MaPhieuMua int,
	MaNhaCungCap int,
	MaSanPham int,
	NgayMua datetime,
	SoLuong int,
	DonGia float,
	ThanhTien float
)


Create table NHACUNGCAP
(
	MaNhaCungCap int identity (1,1) primary key,
	TenNhaCungCap nvarchar(50),
	SoDienThoai nvarchar(50),
	DiaChi  nvarchar(50)
)

Create table SANPHAM
(
	MaSanPham int identity (1,1) primary key,
	TenSanPham nvarchar(50),
	MaLoai int,
	SoLuong int,
	DonGia float,
	TinhTrang bit
)

Create table LICHSUKHO
(
	Ma int identity (1,1) primary key,
	MaSanPham int,
	LoaiGiaoDich nvarchar(50),
	Ngay datetime,
	SoLuongTruoc int,
	SoLuongSau int
)

Create table LOAISANPHAM
(
	MaLoaiSP int identity (1,1) primary key,
	TenLoaiSanPham nvarchar(50),
	DonViTinh nvarchar(20),
	LoiNhuan int
)


Create table PHIEUBANHANG
(
	MaPhieuBan int,
	MaKhachHang int,
	MaNhanVien int,
	MaSanPham int,
	SoLuong int,
	NgayBan datetime,
	DonGia float,
	ThanhTien float
)

Create table KHACHHANG
(
	MaKhachHang int identity (1,1) primary key,
	SoDienThoai nvarchar(50),
	TenKhachHang nvarchar(50)
)

Create table PHIEUDICHVU
(
	MaPhieuDichVu int,
	MaKhachHang int,
	MaNhanVien int,
	MaDichVu int,
	SoLuong int,
	DonGia float,
	TraTruoc float,
	TinhTrang nvarchar(50),
	NgayBan datetime,
	ThanhTien float
)

Create table LOAIDICHVU
(
	MaDichVu int identity (1,1) primary key,
	TenLoaiDichVu nvarchar(50),
	DonGia float
)

Create table NHANVIEN
(
	MaNhanVien int identity (1,1) primary key,
	TenNhanVien nvarchar(50),
	TaiKhoan nvarchar(50),
	MatKhau nvarchar(50),
	ChucVu nvarchar(50)
)
	--Reset lại seed của ID
	--SELECT MaNhanVien, TenNhanVien, TaiKhoan, MatKhau, ChucVu INTO NHANVIEN1 FROM NHANVIEN;
	--DELETE FROM NHANVIEN
	DBCC CHECKIDENT ('SANPHAM', RESEED, 0);
	--INSERT INTO NHANVIEN (TenNhanVien, TaiKhoan, MatKhau, ChucVu) SELECT TenNhanVien, TaiKhoan, MatKhau, ChucVu FROM NHANVIEN1 ORDER BY MaNhanVien ASC;
	--select * from NHANVIEN
/*Foreign key*/

Alter table PHIEUMUAHANG
Add constraint FK_PHIEUMUAHANG_SANPHAM_MaSanPham 
Foreign Key(MaSanPham) References SANPHAM(MaSanPham) ON DELETE CASCADE

Alter table PHIEUMUAHANG
Add constraint FK_PHIEUMUAHANG_NHACUNGCAP_MaNhaCungCap
Foreign Key(MaNhaCungCap) References NHACUNGCAP(MaNhaCungCap) ON DELETE CASCADE

Alter table SANPHAM
Add constraint FK_SANPHAM_LOAISANPHAM_MaLoai
Foreign Key(MaLoai) References LOAISANPHAM(MaLoaiSP) ON DELETE CASCADE

Alter table LICHSUKHO
add constraint FK_LICHSUKHO_SANPHAM_MaSanPham
Foreign Key(MaSanPham) References SANPHAM(MaSanPham) ON DELETE SET NULL

Alter table PHIEUBANHANG
add constraint FK_PHIEUBANHANG_SANPHAM_MaSanPham
Foreign Key(MaSanPham) References SANPHAM(MaSanPham) ON DELETE SET NULL

Alter table PHIEUBANHANG
Add constraint FK_PHIEUBANHANG_KHACHHANG_MaKhachHang
Foreign Key(MaKhachHang) References KHACHHANG(MaKhachHang) ON DELETE CASCADE

Alter table PHIEUDICHVU
Add constraint FK_PHIEUDICHVU_KHACHHANG_MaKhachHang
Foreign Key(MaKhachHang) References KHACHHANG(MaKhachHang) ON DELETE CASCADE

Alter table PHIEUDICHVU
Add constraint FK_PHIEUDICHVU_LOAIDICHVU_MaLoaiDV
Foreign Key(MaDichVu) References LOAIDICHVU(MaDichVu)  ON DELETE CASCADE

Alter table PHIEUDICHVU
Add constraint FK_PHIEUDICHVU_NHANVIEN_MaNhanVien
Foreign Key(MaNhanVien) References NHANVIEN(MaNhanVien) ON DELETE SET NULL

Alter table PHIEUBANHANG
Add constraint FK_PHIEUBANHANG_NHANVIEN_MaNhanVien
Foreign Key(MaNhanVien) References NHANVIEN(MaNhanVien) ON DELETE SET NULL

/*Insert data*/
/*Nhớ sửa lại data bảng PHIEUBANHANG,PHIEUMUAHANG,PHIEUDICHVU */
INSERT INTO NHACUNGCAP (TenNhaCungCap, SoDienThoai, DiaChi)
VALUES
    ('PNJ', '0886134456', N'214 Đường Hồ Gươm, Q.1, TP.HCM'),
    ('DOJI', '0909100900', N'412 Võ Nguyên Giáp, Q.5, TP.HCM'),
    ('SJC','0931224301', N'92 Đường Phan Xích Long, Q.1, TP.HCM'),
    (N'Bảo Tín Minh Châu','0966146979', N'24 Đường Lý Thường Kiệt, Q.9, TP.HCM');


INSERT INTO LOAIDICHVU (TenLoaiDichVu, DonGia)
VALUES
	(N'Dịch vụ định giá và kiểm định', 200000),
    (N'Dịch vụ khôi phục', 400000),
    (N'Dịch vụ vệ sinh', 400000),
    (N'Dịch vụ đánh bóng', 500000);

INSERT INTO NHANVIEN(TenNhanVien, TaiKhoan, MatKhau, ChucVu)
VALUES 
    (N'Nguyễn Thị Ánh', N'nguyenthianh', N'nta', N'Nhân viên bán hàng'),
	(N'Cao Bảo Hà', N'caobaoha', N'cbh', N'Nhân viên thu ngân'),
    (N'Trần Nhật Long', N'trannhatlong', N'tnl', N'Quản lý'),
	(N'aa', N'aa', N'a', N'Quản lý');
INSERT INTO KHACHHANG(SoDienThoai,TenKhachHang)
VALUES
    ('0913987654', N'Nguyễn Hồng Loan'),
    ('0913765432', N'Cao Quang Long'),
    ('0913554321', N'Huỳnh Anh Minh'),
    ('0913123456', N'Trần Minh Hiếu');

INSERT INTO LOAISANPHAM (TenLoaiSanPham, DonViTinh, LoiNhuan)
VALUES
    (N'Dây chuyền kim cương', N'chiếc', 25 ),
    (N'Nhẫn vàng', N'chiếc', 30),
    (N'Vòng tay vàng', N'chiếc', 20),
    (N'Nhẫn kim cương', N'cặp', 35),
    (N'Dây chuyền đá quý', N'chiếc', 40);

INSERT INTO PHIEUDICHVU (MaPhieuDichVu,MaKhachHang, MaNhanVien, MaDichVu, SoLuong,TraTruoc, TinhTrang, NgayBan)
VALUES (1,1, 1, 1, 3, 300000, N'Đã giao', '2024-12-06 04:52:12.000'),
	   (1,1, 1, 2, 2, 400000, N'Đã giao', '2024-12-06 04:52:12.000');

INSERT INTO PHIEUDICHVU (MaPhieuDichVu,MaKhachHang, MaNhanVien, MaDichVu, SoLuong,TraTruoc, TinhTrang, NgayBan)
VALUES (1,1, 1, 3, 1, 10000001, N'Đã giao', '2024-08-11'),
	   (1,1, 1, 4, 2, 5000001, N'Chưa giao', '2024-08-11');

INSERT INTO PHIEUDICHVU (MaKhachHang, MaNhanVien, MaDichVu, SoLuong,TraTruoc, TinhTrang, NgayBan)
VALUES (2, 2, 3, 4, 800000, N'Đã giao', '2024-10-3'),
	   (2, 2, 4, 7, 1750000, N'Chưa giao', '2024-10-3');
 
INSERT INTO PHIEUDICHVU (MaKhachHang, MaNhanVien, MaDichVu, SoLuong,TraTruoc, TinhTrang, NgayBan)
VALUES (2, 2, 3, 4, 800000, N'Đã giao', '2024-10-3'),
	   (2, 2, 4, 7, 1750000, N'Đã giao', '2024-10-3');

INSERT INTO PHIEUDICHVU (MaKhachHang, MaNhanVien, MaDichVu, SoLuong,TraTruoc, TinhTrang, NgayBan)
VALUES (2, 2, 3, 4, 800000, N'Chưa giao', '2024-10-3'),
	   (2, 2, 4, 7, 1750000, N'Chưa giao', '2024-10-3');

INSERT INTO SANPHAM (TenSanPham, MaLoai, SoLuong, TinhTrang)
VALUES
    ( N'Dây chuyền kim cương nam', 1, 11, 1),
    ( N'Nhẫn vàng nam', 2, 6, 1),
    ( N'Vòng tay vàng nam', 3, 18, 1),
    ( N'Nhẫn kim cương nữ', 4, 6, 1),
    ( N'Dây chuyền hồng ngọc', 5, 6, 0);

INSERT INTO PHIEUMUAHANG (MaPhieuMua, MaNhaCungCap, MaSanPham, NgayMua, SoLuong, DonGia) VALUES(1, 1, 1, '2024-12-04', 12,9000000);
INSERT INTO PHIEUMUAHANG (MaPhieuMua, MaNhaCungCap, MaSanPham, NgayMua, SoLuong, DonGia) VALUES(1, 2, 2, '2024-12-04', 8, 1000000);
INSERT INTO PHIEUMUAHANG (MaPhieuMua, MaNhaCungCap, MaSanPham, NgayMua, SoLuong, DonGia) VALUES(1, 3, 3, '2024-12-04', 16, 1000000);
INSERT INTO PHIEUMUAHANG (MaPhieuMua, MaNhaCungCap, MaSanPham, NgayMua, SoLuong, DonGia) VALUES(1, 4, 4, '2024-12-04', 8, 4500000);
INSERT INTO PHIEUMUAHANG (MaPhieuMua, MaNhaCungCap, MaSanPham, NgayMua, SoLuong, DonGia) VALUES(1, 4, 5, '2024-12-04', 6, 5000000);
INSERT INTO PHIEUMUAHANG (MaPhieuMua, MaNhaCungCap, MaSanPham, NgayMua, SoLuong, DonGia) VALUES(1, 1, 6, '2024-12-04', 12,10000000);

INSERT INTO PHIEUBANHANG(MaPhieuBan,MaKhachHang, MaNhanVien, MaSanPham, SoLuong, NgayBan) VALUES (1, 1, 3, 1, 12, '2024-12-05');
INSERT INTO PHIEUBANHANG(MaPhieuBan,MaKhachHang, MaNhanVien, MaSanPham, SoLuong, NgayBan) VALUES (1, 2, 2, 2, 8,  '2024-12-05');
INSERT INTO PHIEUBANHANG(MaPhieuBan,MaKhachHang, MaNhanVien, MaSanPham, SoLuong, NgayBan) VALUES (1, 3, 1, 3, 16, '2026-07-10');
INSERT INTO PHIEUBANHANG(MaPhieuBan,MaKhachHang, MaNhanVien, MaSanPham, SoLuong, NgayBan) VALUES (1, 4, 3, 4, 8,  '2026-07-10');
INSERT INTO PHIEUBANHANG(MaPhieuBan,MaKhachHang, MaNhanVien, MaSanPham, SoLuong, NgayBan) VALUES (1, 4, 3, 5, 6,  '2026-07-10');
INSERT INTO PHIEUBANHANG(MaPhieuBan,MaKhachHang, MaNhanVien, MaSanPham, SoLuong, NgayBan) VALUES (1, 4, 3, 6, 12,  '2026-07-10');

--INSERT INTO PHIEUBANHANG( MaKhachHang, MaNhanVien, MaSanPham, SoLuong, NgayBan)
--VALUES
--    ( 1, 3, 1, 2, '2023-09-10'),
--   ( 2, 2, 2, 3, '2023-10-05'),
--    ( 3, 1, 3, 2, '2023-09-20'),
--    ( 4, 3, 4, 1, '2023-09-25');

DELETE FROM PHIEUBANHANG
DELETE FROM PHIEUDICHVU
DELETE FROM KHACHHANG
DELETE FROM LICHSUKHO
DELETE FROM LOAIDICHVU
DELETE FROM LOAISANPHAM 
DELETE FROM NHACUNGCAP
DELETE FROM NHANVIEN
DELETE FROM PHIEUMUAHANG
DELETE FROM SANPHAM
DELETE FROM SANPHAM WHERE MaSanPham = 2
DELETE FROM SANPHAM WHERE MaSanPham = 8 

select * from PHIEUBANHANG
select * from PHIEUDICHVU
select * from KHACHHANG
select * from LICHSUKHO
select * from LOAIDICHVU
select * from LOAISANPHAM
select * from NHACUNGCAP
select * from NHANVIEN
select * from PHIEUMUAHANG
select * from SANPHAM

UPDATE LOAISANPHAM SET LoiNhuan = 25 WHERE MaLoaiSP = 1;
UPDATE LOAISANPHAM SET TenLoaiSanPham = N'Dây chuyền kim cương' WHERE MaLoaiSP = 1;
UPDATE LOAISANPHAM SET DonViTinh = N'chiếc' WHERE MaLoaiSP = 1;
UPDATE SANPHAM SET SoLuong = 20 WHERE MaSanPham = 11;
UPDATE SANPHAM SET MaLoai = 1 WHERE MaSanPham = 11;
use master
ALTER DATABASE QuanLyKinhDoanhVangBacDaQuy SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE QuanLyKinhDoanhVangBacDaQuy;

GO
CREATE PROC USP_Login
@TaiKhoan nvarchar(50), @MatKhau nvarchar(50)
AS
BEGIN
	SELECT * FROM NHANVIEN WHERE TaiKhoan = @TaiKhoan And MatKhau = @MatKhau
END

--------------------------------------------------------
--NHACUNGCAP
GO
CREATE PROC Danh_Sach_Nha_Cung_Cap @MaNhaCungCap int = NULL
AS 
BEGIN
	IF @MaNhaCungCap IS NULL
	BEGIN
		SELECT MaNhaCungCap AS ID, TenNhaCungCap AS 'Tên nhà cung cấp', SoDienThoai AS 'Số điện thoại', DiaChi AS 'Địa chỉ nhà cung cấp' FROM NHACUNGCAP 
	END
	ELSE 
	BEGIN
		SELECT MaNhaCungCap AS ID, TenNhaCungCap AS 'Tên nhà cung cấp', SoDienThoai AS 'Số điện thoại', DiaChi AS 'Địa chỉ nhà cung cấp' FROM NHACUNGCAP
		WHERE MaNhaCungCap = @MaNhaCungCap and TenNhaCungCap = null
	END
END
EXEC Danh_Sach_Nha_Cung_Cap 2

GO
CREATE PROCEDURE Them_NhaCungCap
    @TenNhaCungCap NVARCHAR(50),
    @SoDienThoai NVARCHAR(50),
    @DiaChi NVARCHAR(50)
AS
BEGIN
    INSERT INTO NHACUNGCAP (TenNhaCungCap, SoDienThoai, DiaChi)
    VALUES (@TenNhaCungCap, @SoDienThoai, @DiaChi);
END

GO
CREATE PROC Xoa_Nha_Cung_Cap @MaNhaCungCap int
AS
BEGIN
	IF EXISTS (SELECT 1 FROM NHACUNGCAP WHERE MaNhaCungCap = @MaNhaCungCap)
	BEGIN
		DELETE FROM NHACUNGCAP WHERE MaNhaCungCap = @MaNhaCungCap;
        RETURN 1;
	END
	ELSE
	BEGIN
		RETURN 0;
	END
END;

GO
CREATE PROC Sua_Nha_Cung_Cap 
@MaNhaCungCap INT,
@TenNhaCungCap NVARCHAR(50),
@SoDienThoai NVARCHAR(50),
@DiaChi NVARCHAR(50)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM NHACUNGCAP WHERE MaNhaCungCap = @MaNhaCungCap)
	BEGIN
		UPDATE NHACUNGCAP
		SET TenNhaCungCap = @TenNhaCungCap,
			SoDienThoai = @SoDienThoai,
			DiaChi = @DiaChi
		WHERE MaNhaCungCap = @MaNhaCungCap;
		RETURN 1;
	END
	ELSE
	BEGIN
		RETURN 0;
	END
END;
/*go
CREATE PROCEDURE TimKiem_NhaCungCap
    @TenNhaCungCap NVARCHAR(50) = NULL,
    @SoDienThoai NVARCHAR(20) = NULL,
    @DiaChi NVARCHAR(100) = NULL
AS
BEGIN
    SELECT *
    FROM NHACUNGCAP
    WHERE (@TenNhaCungCap IS NULL OR TenNhaCungCap = @TenNhaCungCap)
      AND (@SoDienThoai IS NULL OR SoDienThoai = @SoDienThoai)
      AND (@DiaChi IS NULL OR DiaChi = @DiaChi);
END;
EXEC TimKiem_NhaCungCap PNJ , null, null*/

-----------------------------------------------------------
--PHIEUMUAHANG
GO
CREATE PROC Danh_Sach_Phieu_Mua_Hang
AS 
BEGIN
	SELECT * FROM PHIEUMUAHANG 
END
EXEC Danh_Sach_Phieu_Mua_Hang

--THANHTOAN-PHIEUMUAHANG
GO
CREATE PROC Thanh_Toan_Phieu_Mua_Hang
@MaSanPham int
AS
BEGIN
	SELECT  SP.TenSanPham as [Tên sản phẩm],LSP.TenLoaiSanPham as [Loại sản phẩm],
	LSP.DonViTinh as [Đơn vị tính]
	FROM SANPHAM SP,LOAISANPHAM LSP
	WHERE SP.MaSanPham = @MaSanPham and SP.MaLoai = LSP.MaLoaiSP
END

----------------------------------------
--NHACUNGCAP
GO
CREATE PROC Thanh_Toan_Phieu_Mua_Hang_Nha_Cung_Cap
@MaNhaCungCap int
AS
BEGIN
	SELECT TenNhaCungCap as [Tên nhà cung cấp],DiaChi as [Địa chỉ],SoDienThoai as [Số điện thoại]
	FROM NHACUNGCAP
	WHERE MaNhaCungCap = @MaNhaCungCap
END
------------------------------------------------------
--LICHSUKHO
GO
CREATE PROC Show_Lich_Su_Kho
@Thang int,@Nam int
AS BEGIN
	SELECT BCTK.MaSanPham AS [Mã sản phẩm] ,SP.TenSanPham AS [Tên sản phẩm],
	CASE
	 WHEN BCTK.[Tồn đầu] IS NOT NULL THEN BCTK.[Tồn đầu] 
	 ELSE 0
	END AS [Tồn đầu],
	CASE
	 WHEN BCTK.[Số lượng mua vào] IS NOT NULL THEN BCTK.[Số lượng mua vào]
	 ELSE 0
	END AS [Số lượng mua vào],
	CASE
	 WHEN BCTK.[Số lượng bán ra] IS NOT NULL THEN BCTK.[Số lượng bán ra]
	 ELSE 0
	END AS [Số lượng bán ra],
	CASE
	 WHEN BCTK.[Tồn cuối] IS NOT NULL THEN BCTK.[Tồn cuối]
	 ELSE 0
	END AS [Tồn cuối],
	LSP.DonViTinh AS [Đơn vị tính]
	FROM 
	(
		SELECT LSK.MaSanPham,
		(
			SELECT LSK1.SoLuongTruoc		
			FROM LICHSUKHO LSK1
			WHERE LSK1.Ngay = (
							SELECT MIN(LSK2.Ngay) 
							FROM LICHSUKHO LSK2
							WHERE LSK2.MaSanPham = LSK1.MaSanPham AND MONTH(LSK2.Ngay) = @Thang AND YEAR(LSK2.Ngay) = @Nam
							)
				 AND LSK1.MaSanPham = LSK.MaSanPham 
		) as [Tồn đầu],
		(
			SELECT SUM(LSK1.SoLuongSau - LSK1.SoLuongTruoc)
			FROM LICHSUKHO LSK1
			WHERE LSK1.MaSanPham = LSK.MaSanPham AND LSK1.LoaiGiaoDich = 'Mua' AND MONTH(LSK1.Ngay) = @Thang AND YEAR(LSK1.Ngay) = @Nam
		) as [Số lượng mua vào],
		(
			SELECT SUM(LSK1.SoLuongTruoc - LSK1.SoLuongSau)
			FROM LICHSUKHO LSK1
			WHERE LSK1.MaSanPham = LSK.MaSanPham AND LSK1.LoaiGiaoDich = N'Bán' AND MONTH(LSK1.Ngay) = @Thang AND YEAR(LSK1.Ngay) = @Nam
		) as [Số lượng bán ra],
		(
			SELECT LSK1.SoLuongSau		
			FROM LICHSUKHO LSK1
			WHERE LSK1.Ngay = (
							SELECT MAX(LSK2.Ngay) 
							FROM LICHSUKHO LSK2
							WHERE LSK2.MaSanPham = LSK1.MaSanPham AND MONTH(LSK2.Ngay) = @Thang AND YEAR(LSK2.Ngay) = @Nam
							)
				 AND LSK1.MaSanPham = LSK.MaSanPham
		) as [Tồn cuối]
		FROM LICHSUKHO LSK
		GROUP BY LSK.MaSanPham
	) as BCTK,SANPHAM SP,LOAISANPHAM LSP
	WHERE BCTK.MaSanPham = SP.MaSanPham  AND SP.MaLoai = LSP.MaLoaiSP

END

---------------------------------------------------------------
--SANPHAM
GO
CREATE PROC Danh_Sach_San_Pham
AS 
BEGIN
	SELECT MaSanPham AS ID, TenSanPham AS 'Tên sản phẩm', MaLoai AS 'Mã loại', SoLuong AS 'Số lượng', DonGia AS 'Đơn giá', TinhTrang AS 'Tình trạng' FROM SANPHAM
END
EXEC Danh_Sach_San_Pham;

GO
CREATE PROCEDURE Them_SanPham
    @TenSanPham NVARCHAR(50),
    @MaLoai INT,
    @TinhTrang BIT
AS
BEGIN
    INSERT INTO SANPHAM (TenSanPham, MaLoai, TinhTrang)
    VALUES (@TenSanPham, @MaLoai, @TinhTrang);
END;

GO
CREATE PROCEDURE Xoa_SanPham
    @MaSanPham INT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM SANPHAM WHERE MaSanPham = @MaSanPham)
	BEGIN
    DELETE FROM SANPHAM
    WHERE MaSanPham = @MaSanPham;
	RETURN 1;
	END
	RETURN 0;
END;

GO
CREATE PROCEDURE Sua_SanPham
    @MaSanPham INT,
    @TenSanPham NVARCHAR(50),
    @MaLoai INT,
    @TinhTrang BIT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM SANPHAM WHERE MaSanPham = @MaSanPham)
    BEGIN
    UPDATE SANPHAM
    SET TenSanPham = @TenSanPham,
        MaLoai = @MaLoai,
        TinhTrang = @TinhTrang
    WHERE MaSanPham = @MaSanPham;
	RETURN 1;
	END
	RETURN 0;
END;

-----------------------------------------------
--LOAISANPHAM
GO
CREATE PROC Danh_Sach_Loai_San_Pham
AS 
BEGIN
	SELECT MaLoaiSP AS ID, TenLoaiSanPham AS 'Tên loại sản phẩm', DonViTinh AS 'Đơn vị tính', LoiNhuan AS 'Lợi nhuận' FROM LOAISANPHAM 
END
EXEC Danh_Sach_Loai_San_Pham;

GO
CREATE PROCEDURE Them_LoaiSanPham
    @TenLoaiSanPham NVARCHAR(50),
    @DonViTinh NVARCHAR(20),
    @LoiNhuan INT
AS
BEGIN
    INSERT INTO LOAISANPHAM (TenLoaiSanPham, DonViTinh, LoiNhuan)
    VALUES (@TenLoaiSanPham, @DonViTinh, @LoiNhuan)
END

GO
CREATE PROCEDURE Xoa_LoaiSanPham
    @MaLoaiSP INT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM LOAISANPHAM WHERE MaLoaiSP = @MaLoaiSP)
	BEGIN
		DELETE FROM LOAISANPHAM WHERE MaLoaiSP = @MaLoaiSP;
		RETURN 1;
	END
	ELSE
	BEGIN
		RETURN 0;
	END
END

GO
CREATE PROCEDURE Sua_LoaiSanPham
    @MaLoaiSP INT,
    @TenLoaiSanPham NVARCHAR(50),
    @DonViTinh NVARCHAR(20),
    @LoiNhuan INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM LOAISANPHAM WHERE MaLoaiSP = @MaLoaiSP)
    BEGIN
        UPDATE LOAISANPHAM
        SET TenLoaiSanPham = @TenLoaiSanPham,
            DonViTinh = @DonViTinh,
            LoiNhuan = @LoiNhuan
        WHERE MaLoaiSP = @MaLoaiSP;

        RETURN 1;
    END
    ELSE
    BEGIN
        RETURN 0;
    END
END
----------------------------------------------------------------------------------------------
--PHIEUBANHANG

--THANHTOAN-PHIEUBANHANG
--SANPHAM
GO
CREATE PROC Thanh_Toan_Phieu_Ban_Hang
@MaSanPham int
AS
BEGIN
	SELECT  SP.TenSanPham as [Tên sản phẩm],SP.DonGia as [Đơn giá],
	LSP.DonViTinh as [Đơn vị tính],LSP.TenLoaiSanPham as [Tên loại sản phẩm]
	FROM SANPHAM SP,LOAISANPHAM LSP
	WHERE SP.MaSanPham = @MaSanPham and SP.MaLoai = LSP.MaLoaiSP
END

--KHACHHANG
GO
CREATE PROC Thanh_Toan_Phieu_Ban_Hang_Khach_Hang
@MaKhachHang int
AS
BEGIN
	SELECT TenKhachHang as [Tên khách hàng],SoDienThoai as [Số điện thoại]
	FROM KHACHHANG
	WHERE MaKhachHang = @MaKhachHang
END
--NHANVIEN
GO
CREATE PROC Thanh_Toan_Phieu_Ban_Hang_Nhan_Vien
@MaNhanVien int
AS
BEGIN
	SELECT TenNhanVien as [Tên nhân viên]
	FROM NHANVIEN
	WHERE MaNhanVien = @MaNhanVien
END

----------------------------------------------------------------------------------------------
--KHACHHANG
GO
CREATE PROC Danh_Sach_Khach_Hang
AS 
BEGIN
	SELECT MaKhachHang AS ID, TenKhachHang AS 'Họ tên khách hàng', SoDienThoai AS 'Số điện thoại' FROM KHACHHANG
END
EXEC Danh_Sach_Khach_Hang;

GO
CREATE PROCEDURE Them_KhachHang
    @SoDienThoai NVARCHAR(50),
    @TenKhachHang NVARCHAR(50)
AS
BEGIN
    INSERT INTO KHACHHANG (SoDienThoai, TenKhachHang)
    VALUES (@SoDienThoai, @TenKhachHang);
END

GO
CREATE PROCEDURE Xoa_KhachHang
    @MaKhachHang INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM KHACHHANG WHERE MaKhachHang = @MaKhachHang)
    BEGIN
        DELETE FROM KHACHHANG WHERE MaKhachHang = @MaKhachHang;
		RETURN 1;
    END

    RETURN 0;
END

GO
CREATE PROCEDURE Sua_KhachHang
    @MaKhachHang INT,
    @SoDienThoai NVARCHAR(50),
    @TenKhachHang NVARCHAR(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM KHACHHANG WHERE MaKhachHang = @MaKhachHang)
    BEGIN
		UPDATE KHACHHANG
		SET SoDienThoai = @SoDienThoai,
			TenKhachHang = @TenKhachHang
		WHERE MaKhachHang = @MaKhachHang;

        RETURN 1;
    END  
    RETURN 0;
END
---------------------------------------------------------
--NHANVIEN
GO
CREATE PROCEDURE Danh_Sach_Nhan_Vien @MaNhanVien int = NULL
AS
BEGIN
    IF @MaNhanVien IS NULL
    BEGIN
        SELECT MaNhanVien AS ID, TenNhanVien AS Tên, TaiKhoan AS 'Tài khoản', MatKhau AS 'Mật Khẩu', ChucVu AS 'Chức vụ' FROM NHANVIEN
    END
    ELSE
    BEGIN
        SELECT MaNhanVien AS ID, TenNhanVien AS Tên, TaiKhoan AS 'Tài khoản', MatKhau AS 'Mật Khẩu', ChucVu AS 'Chức vụ' FROM NHANVIEN 
		WHERE MaNhanVien = @MaNhanVien
    END
END
EXEC  Danh_Sach_Nhan_Vien;

GO
CREATE PROCEDURE Them_NhanVien
    @TenNhanVien NVARCHAR(50),
    @TaiKhoan NVARCHAR(50),
    @MatKhau NVARCHAR(50),
    @ChucVu NVARCHAR(50)
AS
BEGIN
    INSERT INTO NHANVIEN (TenNhanVien, TaiKhoan, MatKhau, ChucVu)
    VALUES (@TenNhanVien, @TaiKhoan, @MatKhau, @ChucVu);
END

GO
CREATE PROC Xoa_Nhan_Vien @MaNhanVien int
AS
BEGIN
	IF EXISTS (SELECT 1 FROM NHANVIEN WHERE MaNhanVien = @MaNhanVien)
	BEGIN
		DELETE FROM NHANVIEN WHERE MaNhanVien = @MaNhanVien;
        RETURN 1;
	END
	ELSE
	BEGIN
		RETURN 0;
	END
END;

GO
CREATE PROC Sua_Nhan_Vien 
@MaNhanVien INT,
@TenNhanVien NVARCHAR(50),
@TaiKhoan NVARCHAR(50),
@MatKhau NVARCHAR(50),
@ChucVu NVARCHAR(50)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM NHANVIEN WHERE MaNhanVien = @MaNhanVien)
	BEGIN
		UPDATE NHANVIEN
		SET TenNhanVien = @TenNhanVien,
			TaiKhoan = @TaiKhoan,
			MatKhau = @MatKhau,
			ChucVu = @ChucVu
		WHERE MaNhanVien = @MaNhanVien;
		RETURN 1;
	END
	ELSE
	BEGIN
		RETURN 0;
	END
END;

GO
CREATE PROCEDURE Sua_ThongTinCaNhan
    @TaiKhoan NVARCHAR(50),
    @TenNhanVien NVARCHAR(50),
    @MatKhauMoi NVARCHAR(50)
AS
BEGIN
    UPDATE NHANVIEN
    SET TenNhanVien = @TenNhanVien,
        MatKhau = @MatKhauMoi
    WHERE TaiKhoan = @TaiKhoan;
END;

GO
CREATE PROCEDURE ThongTinCaNhan_TK_Ten
	@TaiKhoan NVARCHAR(50)
AS
BEGIN
	SELECT TenNhanVien, TaiKhoan, ChucVu FROM NHANVIEN WHERE TaiKhoan = @TaiKhoan
END

---------------------------------------------------------
--PHIEUDICHVU
GO
CREATE PROC Show_Phieu_Dich_Vu
AS 
BEGIN
SELECT DISTINCT BCDV3.BCDV1MaPhieu AS [Số phiếu] , BCDV3.[Ngày lập],KH.TenKhachHang AS[Khách hàng],BCDV3.[Tổng tiền],
	   BCDV3.[Trả trước],BCDV3.[Tổng tiền] - BCDV3.[Trả trước] AS [Còn lại] , BCDV3.[Tình trạng]
FROM
	(
		SELECT *
		FROM 
		(
			SELECT PDV.MaPhieuDichVu AS [BCDV1MaPhieu],
			(
				SELECT DISTINCT(PDV1.NgayBan)
				FROM PHIEUDICHVU PDV1
				WHERE PDV1.MaPhieuDichVu = PDV.MaPhieuDichVu
			) as [Ngày lập],
			(
				SELECT SUM(PDV1.ThanhTien)
				FROM PHIEUDICHVU PDV1
				WHERE PDV1.MaPhieuDichVu = PDV.MaPhieuDichVu
			)as [Tổng tiền],
			(
				SELECT SUM(PDV1.TraTruoc)
				FROM PHIEUDICHVU PDV1
				WHERE PDV1.MaPhieuDichVu = PDV.MaPhieuDichVu
			)as [Trả trước]
			FROM PHIEUDICHVU PDV
			GROUP BY PDV.MaPhieuDichVu
		) AS BCDV1,
		(	
			SELECT TTDV.MaPhieuDichVu AS [BCDV2MaPhieu],
			CASE
				WHEN TTDV.[Tình trạng] = N'Hoàn thành' THEN 'Hoàn thành'
				ELSE N'Chưa hoàn thành'
			END AS [Tình trạng]
			FROM
			(
				SELECT PDV1.MaPhieuDichVu
				,

				(
					SELECT TRANGTHAI1.[Tình trạng]
					FROM
					(
						SELECT TONG.MaPhieuDichVu, 
						CASE 
							WHEN TONGGIAO.TongDaGiao = TONG.TongSoPhieu THEN 'Hoàn thành'
							ELSE 'Chưa hoàn thành'
						END AS [Tình trạng]
						FROM
							(
								SELECT PDV2.MaPhieuDichVu,COUNT(*) as TongDaGiao
								FROM PHIEUDICHVU PDV2
								WHERE PDV2.TinhTrang = N'Đã giao' 
								GROUP BY PDV2.MaPhieuDichVu
							) AS TONGGIAO,
							(
								SELECT PDV2.MaPhieuDichVu,COUNT(*) as TongSoPhieu
								FROM PHIEUDICHVU PDV2						
								GROUP BY PDV2.MaPhieuDichVu
							) AS TONG
						WHERE TONG.MaPhieuDichVu = TONGGIAO.MaPhieuDichVu 
					) AS TRANGTHAI1
					WHERE TRANGTHAI1.MaPhieuDichVu = PDV1.MaPhieuDichVu
				) AS [Tình trạng]
				FROM PHIEUDICHVU PDV1
				GROUP BY PDV1.MaPhieuDichVu
			) AS TTDV
		) AS BCDV2
		WHERE BCDV1.BCDV1MaPhieu = BCDV2.BCDV2MaPhieu
	) AS BCDV3,KHACHHANG KH,PHIEUDICHVU PDV
WHERE BCDV3.BCDV1MaPhieu = PDV.MaPhieuDichVu AND PDV.MaKhachHang = KH.MaKhachHang
END

--THANH-TOAN-PHIEUDICHVU
GO
CREATE PROC Thanh_Toan_Phieu_Dich_Vu
@MaDichVu int
AS
BEGIN
	SELECT TenLoaiDichVu as [Tên loại dịch vụ],DonGia as [Đơn giá]
	FROM LOAIDICHVU
	WHERE MaDichVu = @MaDichVu
END

----------------------------------------------
--LOAIDICHVU
GO
CREATE PROC Danh_Sach_Loai_Dich_Vu
AS 
BEGIN
	SELECT MaDichVu AS ID, TenLoaiDichVu AS 'Tên loại dịch vụ', DonGia AS 'Đơn giá' FROM LOAIDICHVU
END
EXEC Danh_Sach_Loai_Dich_Vu;

GO
CREATE PROCEDURE Them_LoaiDichVu
    @TenLoaiDichVu NVARCHAR(50),
    @DonGia FLOAT
AS
BEGIN
    INSERT INTO LOAIDICHVU (TenLoaiDichVu, DonGia) VALUES (@TenLoaiDichVu, @DonGia);
END

GO
CREATE PROCEDURE Xoa_LoaiDichVu
    @MaDichVu INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM LOAIDICHVU WHERE MaDichVu = @MaDichVu)
    BEGIN
		DELETE FROM LOAIDICHVU WHERE MaDichVu = @MaDichVu;
        RETURN 1; -- Mã không tồn tại
    END
    RETURN 0;
END

GO
CREATE PROCEDURE Sua_LoaiDichVu
    @MaDichVu INT,
    @TenLoaiDichVu NVARCHAR(50),
    @DonGia FLOAT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM LOAIDICHVU WHERE MaDichVu = @MaDichVu)
    BEGIN
		UPDATE LOAIDICHVU
		SET TenLoaiDichVu = @TenLoaiDichVu,
			DonGia = @DonGia
		WHERE MaDichVu = @MaDichVu;
        RETURN 1;
    END
    RETURN 0;
END
--SEARCH_FUNCTION
GO
CREATE PROC Search_Table
    @TenBang NVARCHAR(50),@ParaJSON NVARCHAR(MAX) -- JSON chứa các cặp {Tên cột, Giá trị}
AS
BEGIN
    DECLARE @TenCot NVARCHAR(50), @GiaTri NVARCHAR(50);
    DECLARE @index INT = 0;
	PRINT @ParaJSON;
	DECLARE @sql NVARCHAR(MAX) = N'SELECT * FROM ' + QUOTENAME(@TenBang) +   N' WHERE 1 = 1';
    WHILE 1 = 1
    BEGIN
        SELECT 
            @TenCot = JSON_VALUE(@ParaJSON, '$[' + CAST(@index AS NVARCHAR) + '].TenCot'),
            @GiaTri = JSON_VALUE(@ParaJSON, '$[' + CAST(@index AS NVARCHAR) + '].GiaTri');
		PRINT @sql + 'SQL:';
        IF @TenCot IS NULL BREAK;
		IF @GiaTri <> ''
		BEGIN
			IF TRY_CAST(@GiaTri AS INT) IS NOT NULL
			BEGIN
				SET @sql = @sql + N' AND CAST(' + QUOTENAME(@TenCot) + N' AS NVARCHAR) = ''' + @GiaTri + '''';
			END
			ELSE
			BEGIN
				SET @sql = @sql + N' AND ' + QUOTENAME(@TenCot) + N' = N''' + @GiaTri + N'''';
			END
		END
        SET @index = @index + 1;
		PRINT @sql + 'SQL:';
    END;
    -- Thực thi câu lệnh SQL động
    EXEC sp_executesql @sql;
END;

--DROP PROCEDURE IF EXISTS Search_Table;

DECLARE @DieuKien NVARCHAR(MAX) = N'[
	{"TenCot": "TenLoaiSanPham", "GiaTri": null},
	{"TenCot": "DonViTinh", "GiaTri": "chiếc" },
    {"TenCot": "LoiNhuan", "GiaTri": "" }
]';
EXEC Search_Table 'LOAISANPHAM',@DieuKien;

--TRIGGER SANPHAM(DONGIA) - PHIEUBANHANG(DONGIA),(THANHTIEN) - LICHSUKHO
GO
CREATE TRIGGER TG_PHIEUBANHANG_SANPHAM_LICHSUKHO_INSERT
ON PHIEUBANHANG
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @SoLuongBan int;
	SELECT @SoLuongBan = SoLuong FROM INSERTED I ;

	IF (@SoLuongBan <= 0) BEGIN
		PRINT 'SO LUONG BAN PHAI LON HON 0'
	END
	ELSE BEGIN
		INSERT INTO PHIEUBANHANG (MaPhieuBan,MaKhachHang, MaNhanVien, MaSanPham, SoLuong,NgayBan, DonGia,ThanhTien)
		SELECT 
			i.MaPhieuBan,
			i.MaKhachHang,
			i.MaNhanVien,
			i.MaSanPham,
			i.SoLuong,
			i.NgayBan,
			sp.DonGia,
			i.SoLuong * sp.DonGia as ThanhTien
			-- Lấy DonGia từ bảng SANPHAM
		FROM
			inserted i,SANPHAM SP
		WHERE i.MaSanPham = SP.MaSanPham;
		DECLARE @SoLuongMoiNhat int;
		SELECT @SoLuongMoiNhat = SP.SoLuong
		FROM SANPHAM SP ,inserted i
		WHERE i.MaSanPham = SP.MaSanPham

		IF (@SoLuongMoiNhat IS NULL  )
		BEGIN
			PRINT 'HẾT HÀNG,KHÔNG THỂ BÁN ĐƯỢC'
		END
		ELSE 
		BEGIN
			IF (@SoLuongMoiNhat - @SoLuongBan > 0 )
			BEGIN
				INSERT INTO LICHSUKHO (MaSanPham,LoaiGiaoDich,Ngay,SoLuongTruoc,SoLuongSau)
				SELECT 
					i.MaSanPham,
					N'Bán',
					i.NgayBan,
					@SoLuongMoiNhat,
					@SoLuongMoiNhat - i.SoLuong
				FROM
					inserted i;
				UPDATE SANPHAM 
				SET SoLuong = @SoLuongMoiNhat - i.SoLuong,TinhTrang = 1
				FROM SANPHAM SP,INSERTED I
				WHERE SP.MaSanPham = I.MaSanPham;
			END
			ELSE IF (@SoLuongMoiNhat - @SoLuongBan = 0 )
			BEGIN
				INSERT INTO LICHSUKHO (MaSanPham,LoaiGiaoDich,Ngay,SoLuongTruoc,SoLuongSau)
				SELECT 
					i.MaSanPham,
					N'Bán',
					i.NgayBan,
					@SoLuongMoiNhat,
					@SoLuongMoiNhat - i.SoLuong
				FROM
					inserted i;
				UPDATE SANPHAM 
				SET SoLuong = @SoLuongMoiNhat - i.SoLuong,TinhTrang = 0
				FROM SANPHAM SP,INSERTED I
				WHERE SP.MaSanPham = I.MaSanPham;
			END
			ELSE
			BEGIN
				PRINT 'KHÔNG THỂ BÁN QUÁ SỐ LƯỢNG TỒN KHO'
			END
		END
	END
END;
--DROP TRIGGER TG_PHIEUBANHANG_SANPHAM_LICHSUKHO_INSERT
--TRIGGER PHIEUMUAHANG(THANHTIEN)-LICHSUKHO (SOLUONGTRUOC,SOLUONGSAU)

GO
CREATE TRIGGER TG_PHIEUMUAHANG_LICHSUKHO_INSERT
ON PHIEUMUAHANG
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @SoLuongMua int;
	SELECT @SoLuongMua = SoLuong FROM INSERTED I ;

	IF (@SoLuongMua <= 0) BEGIN
		PRINT 'SỐ LƯỢNG NHẬP VÀO PHẢI LỚN HƠN 0'
	END
	ELSE BEGIN
	   INSERT INTO PHIEUMUAHANG (MaPhieuMua,MaNhaCungCap, MaSanPham, NgayMua, SoLuong, DonGia,ThanhTien)
		SELECT 
			i.MaPhieuMua,
			i.MaNhaCungCap,
			i.MaSanPham,
			i.NgayMua,
			i.SoLuong,
			i.DonGia,
			i.SoLuong * i.DonGia as ThanhTien
		FROM
			inserted i;
		DECLARE @SoLuongMoiNhat int;
		SELECT @SoLuongMoiNhat = SP.SoLuong
		FROM SANPHAM SP,inserted i
		WHERE SP.MaSanPham = i.MaSanPham;
		IF (@SoLuongMoiNhat IS NULL)
		BEGIN
			INSERT INTO LICHSUKHO (MaSanPham,LoaiGiaoDich,Ngay,SoLuongTruoc,SoLuongSau)
			SELECT 
				i.MaSanPham,
				N'Mua',
				i.NgayMua,
				0,
				i.SoLuong
			FROM
				inserted i;
			UPDATE SANPHAM 
			SET SoLuong = I.SoLuong,TinhTrang = 1,DonGia = I.DonGia + I.DonGia * (LSP.LoiNhuan/CAST(100 AS FLOAT))
			FROM SANPHAM SP,INSERTED I,LOAISANPHAM LSP
			WHERE SP.MaSanPham = I.MaSanPham AND SP.MaLoai = LSP.MaLoaiSP ;
		END
		ELSE 
		BEGIN
			INSERT INTO LICHSUKHO (MaSanPham,LoaiGiaoDich,Ngay,SoLuongTruoc,SoLuongSau)
			SELECT 
				i.MaSanPham,
				N'Mua',
				i.NgayMua,
				@SoLuongMoiNhat,
				@SoLuongMoiNhat + i.SoLuong
			FROM
				inserted i;
			
			UPDATE SANPHAM 
			SET SoLuong = @SoLuongMoiNhat + I.SoLuong ,TinhTrang = 1 , DonGia = I.DonGia + I.DonGia * (LSP.LoiNhuan/CAST(100 AS FLOAT))
			FROM SANPHAM SP,INSERTED I ,LOAISANPHAM LSP
			WHERE SP.MaSanPham = I.MaSanPham AND SP.MaLoai = LSP.MaLoaiSP;
		END
	END
END;
--DROP TRIGGER TG_PHIEUMUAHANG_LICHSUKHO_INSERT
--TG-PHIEUDICHVU-INSERT
GO
CREATE TRIGGER TG_PHIEUDICHVU_INSERT
ON PHIEUDICHVU
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @TraTruoc float,@DonGia float,@SoLuong int,@MaPhieuMoi int;
	SELECT @TraTruoc = I.TraTruoc, @DonGia = LDV.DonGia ,@SoLuong = I.SoLuong
	FROM INSERTED I,LOAIDICHVU LDV
	WHERE I.MaDichVu = LDV.MaDichVu
	DECLARE @ThanhTien float = @DonGia*@SoLuong;


	IF (@TraTruoc >= (50/CAST(100 AS FLOAT))*@ThanhTien)
	BEGIN
		INSERT INTO PHIEUDICHVU (MaPhieuDichVu,MaKhachHang,MaNhanVien,MaDichVu,SoLuong,DonGia,TraTruoc,TinhTrang,NgayBan,ThanhTien)
		SELECT
			i.MaPhieuDichVu,
			i.MaKhachHang,
			i.MaNhanVien,
			i.MaDichVu,
			i.SoLuong,
			LDV.DonGia,
			i.TraTruoc,
			i.TinhTrang,
			i.NgayBan,
			i.SoLuong * LDV.DonGia as ThanhTien
		FROM inserted i,LOAIDICHVU LDV
		WHERE i.MaDichVu = LDV.MaDichVu
	END
	ELSE
	BEGIN
		PRINT 'TRA TRUOC PHAI BANG IT NHAT MOT NUA THANH TIEN'
	END
END
--DROP TRIGGER TG_PHIEUDICHVU_INSERT
--TG_LOAISANPHAM_LOINHUAN_UPDATE

GO
CREATE TRIGGER TG_LOAISANPHAM_LOINHUAN_UPDATE
ON LOAISANPHAM
FOR UPDATE
AS 
BEGIN
	DECLARE @DonGiaCu FLOAT,@LoiNhuan int,@DonGiaMoi FLOAT;
	UPDATE SANPHAM 
	SET DonGia = SANPHAMNEW.DonGiaMoi
	FROM SANPHAM,
		(SELECT SP2.MaSanPham, SP2.TenSanPham,SP2.MaLoai,SP2.SoLuong,BangDonGiaMoi.DonGiaMoi,SP2.TinhTrang
		 FROM
			(SELECT GiaMoiNhat.MaSanPham,GiaMoiNhat.MaLoaiSP,GiaMoiNhat.DonGia,I.LoiNhuan,GiaMoiNhat.DonGia + GiaMoiNhat.DonGia*(I.LoiNhuan/CAST(100 AS FLOAT)) as DonGiaMoi
			 FROM
				(SELECT SP.MaSanPham,LSP.MaLoaiSP,PMH.DonGia
				 FROM LOAISANPHAM LSP,SANPHAM SP,PHIEUMUAHANG PMH
				 WHERE LSP.MaLoaiSP = SP.MaLoai AND SP.MaSanPham = PMH.MaSanPham
				 AND PMH.NgayMua = (
								   SELECT MAX(PMH1.NgayMua)
								   FROM LOAISANPHAM LSP1,SANPHAM SP1,PHIEUMUAHANG PMH1
								   WHERE LSP1.MaLoaiSP = SP1.MaLoai AND SP1.MaSanPham = PMH1.MaSanPham 
								   )
				) as GiaMoiNhat,INSERTED I
			 WHERE GiaMoiNhat.MaLoaiSP = I.MaLoaiSP) AS BangDonGiaMoi,SANPHAM SP2
		WHERE BangDonGiaMoi.MaSanPham = SP2.MaSanPham) AS SANPHAMNEW
	WHERE SANPHAM.MaSanPham = SANPHAMNEW.MaSanPham
	
END
--DROP TRIGGER TG_LOAISANPHAM_LOINHUAN_UPDATE

--TG_SANPHAM_MALOAI_UPDATE

GO
CREATE TRIGGER TG_SANPHAM_MALOAI_SOLUONG_UPDATE
ON SANPHAM
FOR UPDATE
AS
BEGIN
	UPDATE SANPHAM
	SET DonGia = DonGiaMoi.DonGiaVoiMaLoaiMoi
	FROM
	(
		SELECT LoiNhuanMoi.MaSanPham,PMH.DonGia + PMH.DonGia*(LoiNhuanMoi.LoiNhuan/CAST(100 AS FLOAT)) as DonGiaVoiMaLoaiMoi
		FROM
		(	
			SELECT * 
			FROM INSERTED I,LOAISANPHAM LSP
			WHERE I.MaLoai = LSP.MaLoaiSP
		) AS LoiNhuanMoi,PHIEUMUAHANG PMH
		WHERE LoiNhuanMoi.MaSanPham = PMH.MaSanPham AND PMH.NgayMua = (
																		SELECT MAX(PMH1.NgayMua)
																		FROM PHIEUMUAHANG PMH1,INSERTED I1
																		WHERE PMH1.MaSanPham = I1.MaSanPham
																	  )
	) AS DonGiaMoi,SANPHAM 
	WHERE DonGiaMoi.MaSanPham = SANPHAM.MaSanPham

	DECLARE @SoLuongMoi int;
	SELECT @SoLuongMoi = SoLuong
	FROM INSERTED

	IF (@SoLuongMoi = 0)
	BEGIN
		UPDATE
		SANPHAM SET TinhTrang = 0
		FROM SANPHAM SP,INSERTED I
		WHERE SP.MaSanPham = I.MaSanPham

	END
	ELSE IF (@SoLuongMoi < 0)
	BEGIN
		PRINT 'SO LUONG MOI KHONG HOP LE'

	END
END
--DROP TRIGGER TG_SANPHAM_MALOAI_UPDATE

/*DECLARE @sql NVARCHAR(MAX) = '';
-- Tạo danh sách các câu lệnh DROP TRIGGER cho tất cả các trigger
SELECT @sql = @sql + 'DROP TRIGGER IF EXISTS ' + QUOTENAME(t.name) + ';' + CHAR(13)
FROM sys.triggers t
WHERE t.is_ms_shipped = 0; -- Chỉ xóa các trigger người dùng tạo, không xóa trigger hệ thống
-- Thực thi câu lệnh DROP TRIGGER
EXEC sp_executesql @sql;*/

---------------------------------------------------------------------------------------
--SHOW-REVENUE
GO
CREATE PROC Show_Revenue
@Thang int,@Nam int
AS BEGIN
	
SELECT
CASE
 WHEN TongSanPham.TongDoanhThuSanPham IS NOT NULL THEN TongSanPham.TongDoanhThuSanPham
 ELSE 0
END AS DoanhThuSanPham,
CASE
 WHEN TongDichVu.TongDoanhThuDichVu IS NULL  THEN 0
 ELSE  TongDichVu.TongDoanhThuDichVu
END AS DoanhThuDichVu,
CASE
 WHEN TongDichVu.TongDoanhThuDichVu IS NULL OR TongTraTruoc.TongTraTruocDichVu IS NULL OR TongSanPham.TongDoanhThuSanPham IS NULL THEN 0
 ELSE TongDoanhThuSanPham + TongDichVu.TongDoanhThuDichVu -(TongDichVu.TongDoanhThuDichVu - TongTraTruoc.TongTraTruocDichVu)
END AS DoanhThu,
CASE
	WHEN TongDichVu.TongDoanhThuDichVu IS NULL OR TongTraTruoc.TongTraTruocDichVu IS NULL OR TongSanPham.TongDoanhThuSanPham IS NULL OR TongMuaHang.TongNhapHang IS NULL THEN 0 
	ELSE TongDoanhThuSanPham + TongDichVu.TongDoanhThuDichVu -(TongDichVu.TongDoanhThuDichVu - TongTraTruoc.TongTraTruocDichVu) - TongMuaHang.TongNhapHang
END as LoiNhuan,
CASE
 WHEN TongMuaHang.TongNhapHang IS NOT NULL THEN TongMuaHang.TongNhapHang
 ELSE 0
END AS TienVon

FROM
	(
		SELECT SUM(ThanhTien) as  TongDoanhThuSanPham
		FROM PHIEUBANHANG
		WHERE MONTH(NgayBan) = @Thang AND YEAR(NgayBan) = @Nam 
	) as TongSanPham,
	(
		SELECT SUM(ThanhTien) as TongDoanhThuDichVu
		FROM PHIEUDICHVU
		WHERE MONTH(NgayBan) = @Thang AND YEAR(NgayBan) = @Nam 
	) as TongDichVu,
	(
		SELECT SUM(PHIEUDICHVU.TraTruoc) as TongTraTruocDichVu
		FROM PHIEUDICHVU
		WHERE MONTH(NgayBan) = @Thang AND YEAR(NgayBan) = @Nam 
	) as TongTraTruoc,
	(
		SELECT SUM(ThanhTien) as TongNhapHang
		FROM PHIEUMUAHANG
		WHERE MONTH(NgayMua) = @Thang AND YEAR(NgayMua) = @Nam 
	) as TongMuaHang



END