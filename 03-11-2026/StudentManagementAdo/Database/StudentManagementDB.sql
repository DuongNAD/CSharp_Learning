IF DB_ID('StudentManagementDB') IS NULL
    CREATE DATABASE StudentManagementDB;
GO

USE StudentManagementDB;
GO

IF OBJECT_ID('dbo.Student', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Student
    (
        StudentId   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Student PRIMARY KEY,
        StudentCode NVARCHAR(20)  NOT NULL CONSTRAINT UQ_Student_StudentCode UNIQUE,
        FullName    NVARCHAR(100) NOT NULL,
        DateOfBirth DATE          NOT NULL,
        Email       NVARCHAR(100) NOT NULL,
        Phone       NVARCHAR(15)  NOT NULL
    );

    INSERT INTO dbo.Student (StudentCode, FullName, DateOfBirth, Email, Phone) VALUES
    (N'SV001', N'Nguyễn Văn An',  '2004-03-15', N'an.nguyen@example.com',  N'0912345678'),
    (N'SV002', N'Trần Thị Bình',  '2004-07-22', N'binh.tran@example.com',  N'0987654321'),
    (N'SV003', N'Lê Hoàng Cường', '2003-11-05', N'cuong.le@example.com',   N'0901234567');
END
GO
