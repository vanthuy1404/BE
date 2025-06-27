-- -- Lấy học sinh Họ tên, tổng số tín chỉ đã học (SUM(Credit)),
-- Điểm trung bình (AVG(Score)),
-- Xếp loại: "Giỏi", "Khá", "Trung Bình" theo điều kiện:
-- Giỏi: AVG >= 8
-- Khá: AVG >= 6.5
-- Trung bình: còn lại

-- Kết quả chỉ bao gồm sinh viên có ít nhất 2 môn.
-- Bảng sinh viên
-- CREATE TABLE Students (
--     Id INT PRIMARY KEY,
--     Name NVARCHAR(50),
--     Gender NVARCHAR(10),
--     Phone NVARCHAR(20)
-- );

-- -- Bảng môn học
-- CREATE TABLE Subjects (
--     Id INT PRIMARY KEY,
--     Name NVARCHAR(50),
--     Credit INT
-- );

-- -- Bảng điểm
-- CREATE TABLE Scores (
--     StudentId INT,
--     SubjectId INT,
--     Score FLOAT,
--     CONSTRAINT PK_Score PRIMARY KEY (StudentId, SubjectId)
-- );
Select Students.Name, SUM(Subjects.Credit),Count(Subjects.SubjectId) AS SOMON ,AVG(Scores.Score) AS Trung_Binh,
    CASE
        WHEN AVG(Scores.Score)>= 8 then N'Giỏi'
        WHEN AVG(Scores.Score) >=6.5 then N'Khá'
        ELSE N'Trung bình'
    END AS Xep_Loai
From Students join Scores on Students.StudentId = Scores.StudentId join Subjects on Scores.SubjectId = Subjects.SubjectId
Group by Students.StudentId, Students.Name
HAVING Count(Subjects.SubjectId)>=2
Order by AVG(Scores.Score) DESC

-- Viết FUNCTION: trả về xếp loại học lực theo điểm:
 Create function XepLoai(@score float)
 returns nvarchar(20)
 BEGIN
    Declare @result nvarchar(20)
    if @score>8 
        set @result = N'Giỏi'
    else if @score >=6.5
        set @result = N'Khá'
    else
        set @result = N'Trung bình'
    return @result
 END
-- Viết Procedure tìm kiếm danh sách sinh viên theo tên
Create Procedure TimKiemSinhVien @ten nvarchar(50)
AS
BEGIN
    Select * from Students where Name like '%' + @ten + '%'
END


