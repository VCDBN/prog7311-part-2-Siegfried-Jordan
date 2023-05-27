CREATE DATABASE PROG7311;

CREATE TABLE [dbo].[FarmerUsers]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(50) NULL,
    [Surname] NVARCHAR(50) NULL,
    [Email] NVARCHAR(50) NULL,
    [Username] NVARCHAR(50) NULL,
    [Password] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[EmployeeUsers]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(50) NULL,
    [Surname] NVARCHAR(50) NULL,
    [Email] NVARCHAR(50) NULL,
    [Username] NVARCHAR(50) NULL,
    [Password] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[FarmerProducts]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Username] NVARCHAR(50) NULL,
    [Type_of_Product] NVARCHAR(100) NULL,
    [Product_Name] NVARCHAR(100) NULL
)

////////////////////////////////////////////////////
////////////////////////////////////////////////////

SELECT * FROM [FarmerUsers];
SELECT * FROM [FarmerProducts];
SELECT * FROM [EmployeeUsers];