create database QLBTSV;
use QLBTSV


create table Accounts( 
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Roll NVARCHAR(50) CHECK (Roll IN ('Student', 'Teacher', 'Admin')) NOT NULL,
    Status BIT DEFAULT 1, 
    DateCreate DATE,
);

select * from Accounts

CREATE TABLE Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdStudent INT UNIQUE,
    FullName NVARCHAR(255) NOT NULL,
    Class NVARCHAR(50),
    FOREIGN KEY (IdStudent) REFERENCES Students(Id)
);

CREATE TABLE Teachers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdTeacher INT UNIQUE,
    FullName NVARCHAR(255) NOT NULL,
    Faculty NVARCHAR(100),
    FOREIGN KEY (IdTeacher) REFERENCES Accounts(Id) ON DELETE CASCADE
);

CREATE TABLE Exercise (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdTeacher INT NOT NULL,
    Tittle NVARCHAR(255) NOT NULL,
    Content TEXT NOT NULL,
    Deadline DATETIME NOT NULL,
    FOREIGN KEY (IdTeacher) REFERENCES Teachers(Id) ON DELETE CASCADE
);

select*from Assignment


CREATE TABLE Assignment (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdStudent INT NOT NULL,
    IdAssignment INT NOT NULL,
    FileAssignment NVARCHAR(255) NOT NULL,
    DateSubmit DATE,
    UNIQUE (IdStudent, IdAssignment), 
    FOREIGN KEY (IdStudent) REFERENCES Students(Id) ON DELETE CASCADE,
    FOREIGN KEY (IdAssignment) REFERENCES Assignment(Id)
);


CREATE TABLE Feedback (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdAssignment INT NOT NULL,
    IdTeacher INT NOT NULL,
    Point FLOAT CHECK (Point BETWEEN 0 AND 10),
    Comment TEXT NOT NULL,
    EvaluationDate DATE,
    FOREIGN KEY (IdAssignment) REFERENCES Assignment(Id),
    FOREIGN KEY (IdTeacher) REFERENCES Teachers(Id) 
);



INSERT INTO Accounts (Email, Password, Roll, Status, DateCreate) 
VALUES 
('bdquys03@mmail.com', '03032003', N'Student', 1, GETDATE()),
('ngothinguyetanh@gmail.com', '12082004', N'Student', 1, GETDATE()),
('daoanhhien@gmail.com', '123456', N'Teacher', 1, GETDATE()),
('admin@gmail.com', '123456', N'Admin', 1, GETDATE())


INSERT INTO Students (IdStudent, FullName, Class) 
VALUES 
(1, N'Bui Quy', '125211'),
(2, N'Ngo Nguyet Anh', '102212');

select*from Students


INSERT INTO Teachers (IdTeacher, FullName, Faculty) 
VALUES 
(1, N'Đào Anh Hiển', N'Information Technology'),
(2, N'Vũ Xuân Thắng', N'Information Technology');


select*from Teachers


INSERT INTO Exercise (IdTeacher, Tittle, Content, Deadline) 
VALUES 
(1, N'Lập trình C#', N'Viết chương trình quản lý sinh viên', '2025-03-21'),
(2, N'Giải tích', N'Giải hệ phương trình tuyến tính', '2025-03-21')


select*from Exercise


INSERT INTO Assignment (IdStudent, IdAssignment, FileAssignment, DateSubmit) 
VALUES 
(1, 1, N'BaiTapCSharp_1.pdf', GETDATE()),
(2, 2, N'Giaitich_NgoThiNguyetAnh.pdf', GETDATE());



select*from Assignment

INSERT INTO Feedback (IdAssignment, IdTeacher, Point, Comment, EvaluationDate) 
VALUES 
(8, 1, 8.5, N'Ok', GETDATE()),
(9, 2, 7.0, N'Cần cải thiện cách trình bày.', GETDATE());


SELECT * FROM Accounts;

SELECT * FROM Students;

SELECT * FROM Teachers;

SELECT * FROM Exercise;

SELECT * FROM Feedback;



//**Account**//
alter proc sp_getaccountbyid(@id int)
as
begin
	select*from Accounts
	where Id = @id
end


alter proc sp_get_all_account
as
begin
	select*from Accounts
end




