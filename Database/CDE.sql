USE master
GO

DROP DATABASE IF EXISTS CDE
CREATE DATABASE CDE
GO

USE CDE
GO

--người dùng
DROP TABLE IF EXISTS Account
CREATE TABLE Account
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Password] nvarchar(150) NOT NULL,
	Fullname nvarchar(50) NULL,
	Email nvarchar(50) NULL,
	Phone nvarchar(50) NULL,
	[Address] nvarchar(50) NULL,
	Photo nvarchar(250) NULL,
	[Description] nvarchar(250),
	[Status] bit NULL,
	Created date NULL,
	Area_id INT NOT NULL,
	Position_group INT NOT NULL,
)
GO

--List user
DROP TABLE IF EXISTS User_list
CREATE TABLE User_list
(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name_file nvarchar(250),
) 
GO

--List user
DROP TABLE IF EXISTS Media
CREATE TABLE Media
(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name_file nvarchar(250),
) 
GO

--Khu vực
DROP TABLE IF EXISTS Area
CREATE TABLE Area
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Area_code NVARCHAR(50) NOT NULL,
	Area NVARCHAR(50) NOT NULL,
) 
GO

--Chức vụ
DROP TABLE IF EXISTS Position_group
CREATE TABLE Position_group
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(250),
)
GO

--Tên chức vụ
DROP TABLE IF EXISTS Position_title
CREATE TABLE Position_title
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(250) NOT NULL,
	Position_group INT NOT NULL,
)
GO

--Quyền được phép
DROP TABLE IF EXISTS Permission
CREATE TABLE Permission
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(250),
	Position_group int NOT NULL,
)
GO

--Viếng thăm
DROP TABLE IF EXISTS Visit
CREATE TABLE Visit
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Time] smallint, --thời gian viếng thăm
	[DateTime] date, --ngày viếng thăm
	Intent nvarchar(250), -- mục đích
	[Status] smallint, 
	Creator int not null, --người tạo
	Guest int, --khach moi
	Distributor_id int NOT NULL,-- nhà phân phối,
	Task_id int NOT NULL,
)
GO

--Nhà phân phối
DROP TABLE IF EXISTS Distributor
CREATE TABLE Distributor
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(250),
	[Address] nvarchar(250),
	Email nvarchar(250),
	Phone nvarchar(250),
	Area_id INT NOT NULL,
	Position_group int NOT NULL,
)
GO

--bảng công việc
DROP TABLE IF EXISTS Task
CREATE TABLE Task
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Title nvarchar(250),
	[File] nvarchar(250),
	[Description] nvarchar(1000),
	[Status] smallint, --trạng thái xử lý công việc
	Date_start date,
	Date_end date,--ngày gửi công việc
	Report int NOT NULL, --người báo cáo
	Implement int NOT NULL, --người thực hiện
	CategoryId int,

)
GO

DROP TABLE IF EXISTS Category
CREATE TABLE Category
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(250),
)
GO

--Thông báo
DROP TABLE IF EXISTS [Notification]
CREATE TABLE [Notification] (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Title NVARCHAR(250),
	Content NVARCHAR(250),
	Created DATE,
)
GO

--gửi thông báo cho người nhận
DROP TABLE IF EXISTS Notifi_user
CREATE TABLE Notifi_user (
    Notification_id INT,
	Staff INT,
)
GO

--Khảo sát
DROP TABLE IF EXISTS Survey
CREATE TABLE Survey (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250),
)
GO

--Xem ai đã trả lời
DROP TABLE IF EXISTS Survey_detail
CREATE TABLE Survey_detail (
    Survey_id INT NOT NULL,
	[User] INT NOT NULL
)
GO

--Gửi yêu cầu khảo sát
DROP TABLE IF EXISTS Survey_request
CREATE TABLE Survey_request (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Title NVARCHAR(250),
	Date_start DATE,
	Date_end DATE,
    [Status] BIT,
	Survey_id INT,
	Receiver int, --Người nhận
)
GO

--Câu trả lời
DROP TABLE IF EXISTS Answer
CREATE TABLE Answer (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(250),
	Survey_id int,
)
GO

--bảng đánh giá và bl
DROP TABLE IF EXISTS Rate
CREATE TABLE Rate
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Rate smallint, --sô sao đánh giá
	Comment nvarchar(250), --comment
	Created date, --ngay đánh giá
	Rater int NOT NULL, --người đánh giá
	Task_id int NOT NULL,--
)
GO

DROP TABLE IF EXISTS CMS
CREATE TABLE CMS
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Title NVARCHAR(250),
	[Description] nvarchar(250),
	Photo NVARCHAR(250),
	Link NVARCHAR(250),
	Created date, --ngày tạo
	[Status] BIT,
	Creator INT, --người tạo
)
GO

ALTER TABLE Account  
ADD CONSTRAINT [FK_Account_Area] 
FOREIGN KEY (Area_id)
REFERENCES Area(Id)
GO

ALTER TABLE Account  
ADD CONSTRAINT [FK_Account_Position] 
FOREIGN KEY (Position_group)
REFERENCES Position_group(Id)
GO

ALTER TABLE Position_title  
ADD CONSTRAINT [FK_Position_title_Position_group] 
FOREIGN KEY (Position_group)
REFERENCES Position_group(Id)
GO

ALTER TABLE Permission  
ADD CONSTRAINT [FK_Permission_Position_group] 
FOREIGN KEY (Position_group)
REFERENCES Position_group(Id)
GO

ALTER TABLE Visit  
ADD CONSTRAINT [FK_Visit_Guest] 
FOREIGN KEY (Guest)
REFERENCES Account(Id)
GO

ALTER TABLE Visit  
ADD CONSTRAINT [FK_Visit_Creator] 
FOREIGN KEY (Creator)
REFERENCES Account(Id)
GO

ALTER TABLE Visit  
ADD CONSTRAINT [FK_Visit_Distributor] 
FOREIGN KEY (Distributor_id)
REFERENCES Distributor(Id)
GO

ALTER TABLE Visit  
ADD CONSTRAINT [FK_Visit_Task] 
FOREIGN KEY (Task_id)
REFERENCES Task(Id)
GO

ALTER TABLE Distributor  
ADD CONSTRAINT [FK_Distributor_Area] 
FOREIGN KEY (Area_id)
REFERENCES Area(Id)
GO

ALTER TABLE Distributor  
ADD CONSTRAINT [FK_Distributor_Position] 
FOREIGN KEY (Position_group)
REFERENCES Position_group(Id)
GO

ALTER TABLE Task  
ADD CONSTRAINT [FK_Task_Report] 
FOREIGN KEY (Report)
REFERENCES Account(Id)
GO

ALTER TABLE Task  
ADD CONSTRAINT [FK_Task_Implement] 
FOREIGN KEY (Implement)
REFERENCES Account(Id)
GO

ALTER TABLE Task  
ADD CONSTRAINT [FK_Task_Category] 
FOREIGN KEY (CategoryId)
REFERENCES Category(Id)
GO

ALTER TABLE Notifi_User  
ADD CONSTRAINT [FK_Notifi_User_Notification]
FOREIGN KEY (Staff)
REFERENCES [Notification](Id)
GO

ALTER TABLE Notifi_User  
ADD CONSTRAINT [FK_Notifi_Notification]
FOREIGN KEY (Notification_id)
REFERENCES [Notification](Id)
GO

ALTER TABLE Survey_detail
ADD CONSTRAINT [FK_Survey_User]
FOREIGN KEY ([User])
REFERENCES Account(Id)
GO

ALTER TABLE Survey_detail
ADD CONSTRAINT [FK_Survey_detail_Survey]
FOREIGN KEY (Survey_id)
REFERENCES Survey(Id)
GO

ALTER TABLE Survey_request
ADD CONSTRAINT [FK_Survey_request_Receiver]
FOREIGN KEY (Receiver)
REFERENCES Account(Id)
GO

ALTER TABLE Survey_request
ADD CONSTRAINT [FK_Survey_request_Survey]
FOREIGN KEY (Survey_id)
REFERENCES Survey(Id)
GO

ALTER TABLE Answer
ADD CONSTRAINT [FK_Answer_Survey]
FOREIGN KEY (Survey_id)
REFERENCES Survey(Id)
GO

ALTER TABLE Rate
ADD CONSTRAINT [FK_Rate_Rater]
FOREIGN KEY (Rater)
REFERENCES Account(Id)
GO

ALTER TABLE Rate
ADD CONSTRAINT [FK_Rate_Task]
FOREIGN KEY (Task_id)
REFERENCES Task(Id)
GO

ALTER TABLE CMS
ADD CONSTRAINT [FK_CMS_Creator]
FOREIGN KEY (Creator)
REFERENCES Account(Id)
GO