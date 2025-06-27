-- Cài đặt SQL Server, SQL Server Management Studio Tool. - Tạo CSDL QLSINHVIEN. Tạo các bảng dữ liệu: 
--   1) SINH_VIEN (SINH_VIEN_ID Auto Increment PK, MA_SINH_VIEN, TEN_SINH_VIEN, 
-- NGAY_SINH, GIOI_TINH, KHOA_ID FK); 
--   2) KHOA (KHOA_ID Auto Increment PK, SO_HIEU_KHOA, TEN_KHOA). - Nhập dữ liệu demo cho 2 Khoa CNTT và Điện tử viễn thông, nhập dữ liệu 20 sinh viên 
-- trong đó 15 sinh viên thuộc khoa CNTT và 5 sinh viên thuộc khoa Điện tử viễn thông- Viết query: Đếm số lượng sinh viên trong bảng SINH_VIÊN; Đếm số lượng sinh viên theo 
-- KHOA; Lấy danh sách sinh viên khoa CNTT; Lấy danh sách sinh viên khoa CNTT là nữ; Lấy 
-- danh sách sinh viên khoa CNTT là nữ và sinh từ tháng 7 trở ra; Lấy danh sách sinh viên 
-- nhóm theo hai khoa (GROUP BY) với điều kiện chung GIOI_TINH là Nam- Viết function: Tạo hàm fn_LayMaVaTenSinhVien (gộp MA_SINH_VIEN và 
-- TEN_SINH_VIEN có dấu " - " phân cách.- Viết stored procedure: Tạo các thủ tục sp_ThemSinhVien; sp_SuaTTSinhVien; 
-- sp_XoaSinhVien (xóa 1 sinh viên theo SINH_VIEN_ID); sp_TimKiemSinhVien (với điều kiên 
-- tìm gần đúng MA_SINH_VIEN, TEN_SINH_VIEN, GIOI_TINH, NGAY_SINH từ ngày - đến 
-- ngày)
Create Database QLSINHVIEN;
use QLSINHVIEN;
Go
Create Table SINH_VIEN (
    SINH_VIEN_ID INT PRIMARY KEY AUTOINCREMENT,
    MA_SINH_VIEN NVARCHAR(20) UNIQUE NOT NULL,
    TEN_SINH_VIEN NVARCHAR(50) NOT NULL,
    NGAY_SINH DATE NOT NULL,
    GIOI_TINH NVARCHAR(10) NOT NULL,
    KHOA_ID INT NOT NULL,
    FOREIGN KEY (KHOA_ID) REFERENCES KHOA(KHOA_ID)
);
Create Table KHOA (
    KHOA_ID INT PRIMARY KEY AUTOINCREMENT,
    SO_HIEU_KHOA NVARCHAR(20) UNIQUE NOT NULL,
    TEN_KHOA NVARCHAR(50) NOT NULL
);
-- Nhập dữ liệu demo cho 2 Khoa CNTT và Điện tử viễn thông, nhập dữ liệu 20 sinh viên 
-- trong đó 15 sinh viên thuộc khoa CNTT và 5 sinh viên thuộc khoa Điện tử viễn thông

Insert Into KHOA (SO_HIEU_KHOA, TEN_KHOA) Values
('CNTT', 'Công nghệ thông tin'),
('DTVT', 'Điện tử viễn thông');
Insert Into SINH_VIEN (MA_SINH_VIEN, TEN_SINH_VIEN, NGAY_SINH, GIOI_TINH, KHOA_ID) Values
('SV001', 'Nguyen Van A', '2000-01-01', 'Nam', 1),
('SV002', 'Tran Thi B', '2000-02-02', 'Nu', 1),
('SV003', 'Le Van C', '2000-03-03', 'Nam', 1),
('SV004', 'Pham Thi D', '2000-04-04', 'Nu', 1),
('SV005', 'Nguyen Van E', '2000-05-05', 'Nam', 1),
('SV006', 'Tran Thi F', '2000-06-06', 'Nu', 1),
('SV007', 'Le Van G', '2000-07-07', 'Nam', 1),
('SV008', 'Pham Thi H', '2000-08-08', 'Nu', 1),
('SV009', 'Nguyen Van I', '2000-09-09', 'Nam', 1),
('SV010', 'Tran Thi J', '2000-10-10', 'Nu', 1),
('SV011', 'Le Van K', '2000-11-11', 'Nam', 2),
('SV012', 'Pham Thi L', '2000-12-12', 'Nu', 2),
('SV013', 'Nguyen Van M', '2001-01-13', 'Nam', 2),
('SV014', 'Tran Thi N', '2001-02-14', 'Nu', 2),
('SV015', 'Le Van O', '2001-03-15', 'Nam', 2),
('SV016', 'Pham Thi P', '2001-04-16', 'Nu', 2),
('SV017','Nguyen Van Q','2001-05-17','Nam' ,2),
('SV018','Tran Thi R','2001-06-18','Nu' ,2),
('SV019','Le Van S','2001-07-19','Nam' ,2),
('SV020','Pham Thi T','2001-08-20','Nu' ,2);
-- Số lượng sinh viên trong bảng SINH_VIEN
Select COUNT(SINH_VIEN_ID) AS SO_LUONG_SINH_VIEN FROM SINH_VIEN
-- Đếm sl sinh viên theo khoa
Select Count(SINH_VIEN.SINH_VIEN_ID) AS SO_LUONG_SV, KHOA.TEN_KHOA 
From SINH_VIEN join KHOA on SINH_VIEN.KHOA_ID = KHOA.KHOA_ID
Group by KHOA.KHOA_ID, KHOA.TEN_KHOA
-- Lấy danh sách sinh viên khoa CNTT
Select * 
From SINH_VIEN join KHOA on SINH_VIEN.KHOA_ID = KHOA.KHOA_ID
WHERE SO_HIEU_KHOA ='CNTT'
-- Lấy danh sách sinh viên khoa CNTT là nữ
Select * 
From SINH_VIEN join KHOA on SINH_VIEN.KHOA_ID = KHOA.KHOA_ID
WHERE KHOA.SO_HIEU_KHOA ='CNTT' AND SINH_VIEN.GIOI_TINH = 'Nu'

-- danh sách sinh viên khoa CNTT là nữ và sinh từ tháng 7 trở ra
SELECT * FROM SINH_VIEN join KHOA on SINH_VIEN.KHOA_ID = KHOA.KHOA_ID
WHERE KHOA.SO_HIEU_KHOA ='CNTT' AND SINH_VIEN.GIOI_TINH = 'Nu' AND MONTH(SINH_VIEN.NGAY_SINH)>=7
-- Lấy danh sách sinh viên nhóm theo hai khoa (GROUP BY) với điều kiện chung GIOI_TINH là Nam
SELECT COUNT(SINH_VIEN.SINH_VIEN_ID) AS SL_SV, KHOA.TEN_KHOA
FROM SINH_VIEN join KHOA on SINH_VIEN.KHOA_ID = KHOA.KHOA_ID
WHERE SINH_VIEN.GIOI_TINH = 'Nam'
Group BY KHOA.KHOA_ID, KHOA.TEN_KHOA

-- store procedure sp_ThemSinhVien
CREATE PROCEDURE sp_ThemSinhVien
    @MA_SINH_VIEN NVARCHAR(20),
    @TEN_SINH_VIEN NVARCHAR(50),
    @NGAY_SINH DATE,
    @GIOI_TINH NVARCHAR(10),
    @KHOA_ID INT
AS
BEGIN
    INSERT INTO SINH_VIEN (MA_SINH_VIEN, TEN_SINH_VIEN, NGAY_SINH, GIOI_TINH, KHOA_ID)
    VALUES (@MA_SINH_VIEN, @TEN_SINH_VIEN, @NGAY_SINH, @GIOI_TINH, @KHOA_ID);
END;
-- store procedure sp_SuaTTSinhVien
Create Procedure sp_SuaTTSinhVien
    @SINH_VIEN_ID INT,
    @MA_SINH_VIEN NVARCHAR(20),
    @TEN_SINH_VIEN NVARCHAR(50),
    @NGAY_SINH DATE,
    @GIOI_TINH NVARCHAR(10),
    @KHOA_ID INT
AS
BEGIN
    UPDATE SINH_VIEN
    SET MA_SINH_VIEN = @MA_SINH_VIEN,
        TEN_SINH_VIEN = @TEN_SINH_VIEN,
        NGAY_SINH = @NGAY_SINH,
        GIOI_TINH = @GIOI_TINH,
        KHOA_ID = @KHOA_ID
    WHERE SINH_VIEN_ID = @SINH_VIEN_ID;
END;
-- store procedure sp_XoaSinhVien
Create Procedure sp_XoaSinhVien
    @SINH_VIEN_ID INT
    AS
    BEGIN
        DELETE FROM SINH_VIEN
        WHERE SINH_VIEN_ID = @SINH_VIEN_ID;
    END;
-- store procedure sp_TimKiemSinhVien
Create Procedure sp_TimKiemSinhVien
    @MA_SINH_VIEN NVARCHAR(20) = NULL,
    @TEN_SINH_VIEN NVARCHAR(50) = NULL,
    @GIOI_TINH NVARCHAR(10) = NULL,
    @NGAY_SINH_FROM DATE = NULL,
    @NGAY_SINH_TO DATE = NULL
AS
BEGIN
    SELECT * FROM SINH_VIEN
    WHERE (@MA_SINH_VIEN IS NULL OR MA_SINH_VIEN LIKE '%' + @MA_SINH_VIEN + '%')
      AND (@TEN_SINH_VIEN IS NULL OR TEN_SINH_VIEN LIKE '%' + @TEN_SINH_VIEN + '%')
      AND (@GIOI_TINH IS NULL OR GIOI_TINH = @GIOI_TINH)
      AND (@NGAY_SINH_FROM IS NULL OR NGAY_SINH >= @NGAY_SINH_FROM)
      AND (@NGAY_SINH_TO IS NULL OR NGAY_SINH <= @NGAY_SINH_TO);
END;