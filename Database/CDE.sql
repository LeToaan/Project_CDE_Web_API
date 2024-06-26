USE [master]
GO
/****** Object:  Database [CDE]    Script Date: 4/28/2024 7:03:04 PM ******/
CREATE DATABASE [CDE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CDE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CDE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CDE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CDE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CDE] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CDE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CDE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CDE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CDE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CDE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CDE] SET ARITHABORT OFF 
GO
ALTER DATABASE [CDE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CDE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CDE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CDE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CDE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CDE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CDE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CDE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CDE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CDE] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CDE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CDE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CDE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CDE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CDE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CDE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CDE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CDE] SET RECOVERY FULL 
GO
ALTER DATABASE [CDE] SET  MULTI_USER 
GO
ALTER DATABASE [CDE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CDE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CDE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CDE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CDE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CDE] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CDE', N'ON'
GO
ALTER DATABASE [CDE] SET QUERY_STORE = OFF
GO
USE [CDE]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Fullname] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Photo] [nvarchar](250) NULL,
	[Reporter] [int] NULL,
	[Status] [bit] NULL,
	[Created] [datetime2](7) NULL,
	[SuperiorId] [int] NULL,
	[Inferior] [nvarchar](max) NULL,
	[PermissionId] [nvarchar](max) NULL,
	[DistributorId] [nvarchar](max) NULL,
	[AreaId] [int] NULL,
	[PositionTitleId] [int] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[SurveyId] [int] NOT NULL,
	[SurveyRequestId] [int] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaCode] [nvarchar](50) NOT NULL,
	[AreaName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMSs]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMSs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[Photo] [nvarchar](250) NOT NULL,
	[Link] [nvarchar](250) NOT NULL,
	[Created] [datetime2](7) NULL,
	[Status] [bit] NOT NULL,
	[Creator] [int] NOT NULL,
	[CreatorAccountId] [int] NOT NULL,
 CONSTRAINT [PK_CMSs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distributors]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distributors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[SaleManagement] [int] NOT NULL,
	[Sales] [nvarchar](max) NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](250) NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[AccountId] [int] NOT NULL,
 CONSTRAINT [PK_Distributors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileTasks]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileTasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[Reporter] [int] NULL,
	[Implementer] [int] NULL,
	[TaskId] [int] NOT NULL,
 CONSTRAINT [PK_FileTasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuestVisits]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuestVisits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuestId] [int] NOT NULL,
	[Refuse] [bit] NULL,
	[Reason] [nvarchar](max) NULL,
	[VisitId] [int] NOT NULL,
 CONSTRAINT [PK_GuestVisits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medias]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameFile] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Medias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Content] [nvarchar](250) NOT NULL,
	[Created] [datetime2](7) NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotifiUsers]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotifiUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NotificationId] [int] NOT NULL,
	[Staff] [int] NOT NULL,
	[StaffAccountId] [int] NOT NULL,
 CONSTRAINT [PK_NotifiUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionModules]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionModules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[PermissionIds] [nvarchar](max) NULL,
 CONSTRAINT [PK_PermissionModules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[PermissionMuduleId] [int] NOT NULL,
	[PermissionModulesId] [int] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionGroups]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_PositionGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionTitles]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionTitles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[created] [datetime2](7) NULL,
	[PermissionIds] [nvarchar](max) NULL,
	[PositionGroupId] [int] NOT NULL,
 CONSTRAINT [PK_PositionTitles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rates]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rates](
	[Id] [int] NOT NULL,
	[RateValue] [smallint] NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Created] [datetime2](7) NULL,
	[RaterAccountId] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
 CONSTRAINT [PK_Rates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurveyDetails]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyDetails](
	[Id] [int] NOT NULL,
	[SurveyId] [int] NOT NULL,
	[User] [int] NOT NULL,
	[UserAccountId] [int] NOT NULL,
 CONSTRAINT [PK_SurveyDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurveyRequests]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyRequests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[DateStart] [datetime2](7) NULL,
	[DateEnd] [datetime2](7) NULL,
	[Status] [bit] NOT NULL,
	[Receiver] [int] NOT NULL,
	[ReceiverAccountId] [int] NOT NULL,
 CONSTRAINT [PK_SurveyRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[Status] [smallint] NULL,
	[DateStart] [datetime2](7) NULL,
	[DateEnd] [datetime2](7) NULL,
	[Report] [int] NOT NULL,
	[Implement] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[VisitId] [int] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tokents]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PasswordResetToken] [nvarchar](max) NULL,
	[ResetTokenExpires] [datetime2](7) NULL,
	[AccountId] [int] NULL,
 CONSTRAINT [PK_Tokents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLists]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameFile] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_UserLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visits]    Script Date: 4/28/2024 7:03:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [smallint] NULL,
	[DateTime] [datetime2](7) NULL,
	[Intent] [nvarchar](250) NOT NULL,
	[Status] [smallint] NULL,
	[Creator] [int] NOT NULL,
	[DistributorId] [int] NOT NULL,
 CONSTRAINT [PK_Visits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428114033_CDEMigration', N'6.0.25')
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (1, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'[3, 4, 5]', NULL, NULL, 1)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (2, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user1@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'[3, 4, 5]', NULL, NULL, 2)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (3, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user2@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'', NULL, NULL, 3)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (5, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user3@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'', NULL, NULL, 4)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (6, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user4@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'', NULL, NULL, 5)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (7, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user5@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'', NULL, NULL, 6)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (8, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user6@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'', NULL, NULL, 7)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (9, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user7@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'', NULL, NULL, 8)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (10, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user8@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'', NULL, NULL, 9)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (11, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user9@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'', NULL, NULL, 9)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (12, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user10@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'', NULL, NULL, 11)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (13, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user11@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'', NULL, NULL, 12)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (14, N'$2a$11$B34LaUKWOeRxC7iWbMllrutclLcb/DV4Zyu92AE/E4aLFiLG3qHYy', N'string', N'string', N'string', N'string', NULL, 1, 1, CAST(N'2024-04-28T18:47:58.5511675' AS DateTime2), NULL, NULL, NULL, NULL, 1, 10)
INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Reporter], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [DistributorId], [AreaId], [PositionTitleId]) VALUES (15, N'$2a$11$sm891spttmxDJm6Gu5ZtZegpI6zg9DS//BqvzMuEu0rUbM2gugkwW', N'string', N'stringDistri', N'string', N'string', NULL, 1, 1, CAST(N'2024-04-28T18:48:16.0239284' AS DateTime2), NULL, NULL, NULL, NULL, 1, 10)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Areas] ON 

INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (1, N'VTT', N'VTT')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (2, N'ALTASOFTWARE', N'ALT')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (3, N'PRODUCT_QA', N'ALTA_QA')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (4, N'TEXT', N'TEST')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (5, N'ALTA', N'ALTA_QA')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (6, N'HCM', N'Hồ Chí Minh')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (7, N'Test', N'string')
SET IDENTITY_INSERT [dbo].[Areas] OFF
GO
SET IDENTITY_INSERT [dbo].[Distributors] ON 

INSERT [dbo].[Distributors] ([Id], [Name], [SaleManagement], [Sales], [Email], [Phone], [Address], [Status], [AccountId]) VALUES (1, N'string', 3, N'[10]', N'string', N'string', N'string', 1, 14)
INSERT [dbo].[Distributors] ([Id], [Name], [SaleManagement], [Sales], [Email], [Phone], [Address], [Status], [AccountId]) VALUES (2, N'string', 3, N'[11]', N'stringDistri', N'string', N'string', 1, 15)
SET IDENTITY_INSERT [dbo].[Distributors] OFF
GO
SET IDENTITY_INSERT [dbo].[GuestVisits] ON 

INSERT [dbo].[GuestVisits] ([Id], [GuestId], [Refuse], [Reason], [VisitId]) VALUES (1, 12, NULL, NULL, 1)
INSERT [dbo].[GuestVisits] ([Id], [GuestId], [Refuse], [Reason], [VisitId]) VALUES (2, 13, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[GuestVisits] OFF
GO
SET IDENTITY_INSERT [dbo].[PermissionModules] ON 

INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (1, N'Visit plans', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (2, N'Notification', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (3, N'Survey', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (4, N'CMS', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (5, N'Users', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (6, N'Areas', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (7, N'Distributors', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (8, N'System configuration', NULL)
SET IDENTITY_INSERT [dbo].[PermissionModules] OFF
GO
SET IDENTITY_INSERT [dbo].[Permissions] ON 

INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (1, N'View all visit plans', 1, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (2, N'Create new visit plan', 1, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (3, N'View all existing tasks', 1, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (4, N'Create Notification', 2, 2)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (5, N'Create new survey', 3, 3)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (6, N'Send survey request', 3, 3)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (7, N'Create new article', 4, 4)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (8, N'Update article detail', 4, 4)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (9, N'Publish existing article
', 4, 4)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (10, N'Remove unpublish articles', 4, 4)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (11, N'Add new users', 5, 5)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (12, N'Update user detail', 5, 5)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (13, N'Reset password', 5, 5)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (14, N'Permission setting', 5, 5)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (15, N'Create new area', 6, 6)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (16, N'Update area detail', 6, 6)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (17, N'Delete areas', 6, 6)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (18, N'Create new distributor', 7, 7)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (19, N'Update detail distributor', 7, 7)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (20, N'Delete distributor', 7, 7)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (21, N'Edit system configuration', 8, 8)
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
SET IDENTITY_INSERT [dbo].[PositionGroups] ON 

INSERT [dbo].[PositionGroups] ([Id], [Name]) VALUES (1, N'System')
INSERT [dbo].[PositionGroups] ([Id], [Name]) VALUES (2, N'Sales')
INSERT [dbo].[PositionGroups] ([Id], [Name]) VALUES (3, N'Distributor')
INSERT [dbo].[PositionGroups] ([Id], [Name]) VALUES (4, N'Guest')
SET IDENTITY_INSERT [dbo].[PositionGroups] OFF
GO
SET IDENTITY_INSERT [dbo].[PositionTitles] ON 

INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (1, N'Administrator', CAST(N'2024-03-26T17:14:18.5961758' AS DateTime2), NULL, 1)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (2, N'Owner', CAST(N'2024-03-26T17:14:36.3672619' AS DateTime2), NULL, 1)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (3, N'VPCD', CAST(N'2024-03-26T17:14:51.4235618' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (4, N'BM', CAST(N'2024-03-26T17:14:56.7506494' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (5, N'Chanel Activation Head', CAST(N'2024-03-26T17:15:11.1869608' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (6, N'ASM', CAST(N'2024-03-26T17:15:19.3316762' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (7, N'BAM', CAST(N'2024-03-26T17:15:23.8334411' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (8, N'CE – Capability Executive', CAST(N'2024-03-26T17:15:36.2295437' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (9, N'Sale SUP – Sale Supervisor', CAST(N'2024-03-26T17:15:46.3446364' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (10, N'Distributor - OM/TL', CAST(N'2024-03-26T17:15:58.9088163' AS DateTime2), NULL, 3)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (11, N'Other Department', CAST(N'2024-03-26T17:16:18.2700234' AS DateTime2), NULL, 4)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (12, N'Guest', CAST(N'2024-03-26T17:16:25.8445029' AS DateTime2), NULL, 4)
SET IDENTITY_INSERT [dbo].[PositionTitles] OFF
GO
SET IDENTITY_INSERT [dbo].[Visits] ON 

INSERT [dbo].[Visits] ([Id], [Time], [DateTime], [Intent], [Status], [Creator], [DistributorId]) VALUES (1, 0, CAST(N'2024-04-28T11:50:03.9520000' AS DateTime2), N'string', 1, 1, 1)
INSERT [dbo].[Visits] ([Id], [Time], [DateTime], [Intent], [Status], [Creator], [DistributorId]) VALUES (2, 0, CAST(N'2024-04-28T11:50:03.9520000' AS DateTime2), N'string', 1, 1, 2)
SET IDENTITY_INSERT [dbo].[Visits] OFF
GO
/****** Object:  Index [IX_Accounts_AreaId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Accounts_AreaId] ON [dbo].[Accounts]
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Accounts_PositionTitleId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Accounts_PositionTitleId] ON [dbo].[Accounts]
(
	[PositionTitleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Accounts_SuperiorId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Accounts_SuperiorId] ON [dbo].[Accounts]
(
	[SuperiorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Answers_SurveyRequestId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Answers_SurveyRequestId] ON [dbo].[Answers]
(
	[SurveyRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CMSs_CreatorAccountId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_CMSs_CreatorAccountId] ON [dbo].[CMSs]
(
	[CreatorAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Distributors_AccountId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Distributors_AccountId] ON [dbo].[Distributors]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FileTasks_TaskId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_FileTasks_TaskId] ON [dbo].[FileTasks]
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GuestVisits_GuestId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_GuestVisits_GuestId] ON [dbo].[GuestVisits]
(
	[GuestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GuestVisits_VisitId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_GuestVisits_VisitId] ON [dbo].[GuestVisits]
(
	[VisitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NotifiUsers_NotificationId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_NotifiUsers_NotificationId] ON [dbo].[NotifiUsers]
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NotifiUsers_StaffAccountId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_NotifiUsers_StaffAccountId] ON [dbo].[NotifiUsers]
(
	[StaffAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Permissions_PermissionModulesId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Permissions_PermissionModulesId] ON [dbo].[Permissions]
(
	[PermissionModulesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PositionTitles_PositionGroupId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_PositionTitles_PositionGroupId] ON [dbo].[PositionTitles]
(
	[PositionGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rates_RaterAccountId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Rates_RaterAccountId] ON [dbo].[Rates]
(
	[RaterAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SurveyDetails_UserAccountId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_SurveyDetails_UserAccountId] ON [dbo].[SurveyDetails]
(
	[UserAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SurveyRequests_ReceiverAccountId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_SurveyRequests_ReceiverAccountId] ON [dbo].[SurveyRequests]
(
	[ReceiverAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tasks_CategoryId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_CategoryId] ON [dbo].[Tasks]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tasks_Implement]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_Implement] ON [dbo].[Tasks]
(
	[Implement] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tasks_Report]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_Report] ON [dbo].[Tasks]
(
	[Report] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tasks_VisitId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_VisitId] ON [dbo].[Tasks]
(
	[VisitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tokents_AccountId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tokents_AccountId] ON [dbo].[Tokents]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Visits_DistributorId]    Script Date: 4/28/2024 7:03:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Visits_DistributorId] ON [dbo].[Visits]
(
	[DistributorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Accounts_SuperiorId] FOREIGN KEY([SuperiorId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Accounts_SuperiorId]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Areas_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Areas] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Areas_AreaId]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_PositionTitles_PositionTitleId] FOREIGN KEY([PositionTitleId])
REFERENCES [dbo].[PositionTitles] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_PositionTitles_PositionTitleId]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_SurveyRequests_SurveyRequestId] FOREIGN KEY([SurveyRequestId])
REFERENCES [dbo].[SurveyRequests] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_SurveyRequests_SurveyRequestId]
GO
ALTER TABLE [dbo].[CMSs]  WITH CHECK ADD  CONSTRAINT [FK_CMSs_Accounts_CreatorAccountId] FOREIGN KEY([CreatorAccountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CMSs] CHECK CONSTRAINT [FK_CMSs_Accounts_CreatorAccountId]
GO
ALTER TABLE [dbo].[Distributors]  WITH CHECK ADD  CONSTRAINT [FK_Distributors_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Distributors] CHECK CONSTRAINT [FK_Distributors_Accounts_AccountId]
GO
ALTER TABLE [dbo].[FileTasks]  WITH CHECK ADD  CONSTRAINT [FK_FileTasks_Tasks_TaskId] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FileTasks] CHECK CONSTRAINT [FK_FileTasks_Tasks_TaskId]
GO
ALTER TABLE [dbo].[GuestVisits]  WITH CHECK ADD  CONSTRAINT [FK_GuestVisits_Accounts_GuestId] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GuestVisits] CHECK CONSTRAINT [FK_GuestVisits_Accounts_GuestId]
GO
ALTER TABLE [dbo].[GuestVisits]  WITH CHECK ADD  CONSTRAINT [FK_GuestVisits_Visits_VisitId] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visits] ([Id])
GO
ALTER TABLE [dbo].[GuestVisits] CHECK CONSTRAINT [FK_GuestVisits_Visits_VisitId]
GO
ALTER TABLE [dbo].[NotifiUsers]  WITH CHECK ADD  CONSTRAINT [FK_NotifiUsers_Accounts_StaffAccountId] FOREIGN KEY([StaffAccountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NotifiUsers] CHECK CONSTRAINT [FK_NotifiUsers_Accounts_StaffAccountId]
GO
ALTER TABLE [dbo].[NotifiUsers]  WITH CHECK ADD  CONSTRAINT [FK_NotifiUsers_Notifications_NotificationId] FOREIGN KEY([NotificationId])
REFERENCES [dbo].[Notifications] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NotifiUsers] CHECK CONSTRAINT [FK_NotifiUsers_Notifications_NotificationId]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_PermissionModules_PermissionModulesId] FOREIGN KEY([PermissionModulesId])
REFERENCES [dbo].[PermissionModules] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_PermissionModules_PermissionModulesId]
GO
ALTER TABLE [dbo].[PositionTitles]  WITH CHECK ADD  CONSTRAINT [FK_PositionTitles_PositionGroups_PositionGroupId] FOREIGN KEY([PositionGroupId])
REFERENCES [dbo].[PositionGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PositionTitles] CHECK CONSTRAINT [FK_PositionTitles_PositionGroups_PositionGroupId]
GO
ALTER TABLE [dbo].[Rates]  WITH CHECK ADD  CONSTRAINT [FK_Rates_Accounts_RaterAccountId] FOREIGN KEY([RaterAccountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rates] CHECK CONSTRAINT [FK_Rates_Accounts_RaterAccountId]
GO
ALTER TABLE [dbo].[Rates]  WITH CHECK ADD  CONSTRAINT [FK_Rates_Tasks_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Tasks] ([Id])
GO
ALTER TABLE [dbo].[Rates] CHECK CONSTRAINT [FK_Rates_Tasks_Id]
GO
ALTER TABLE [dbo].[SurveyDetails]  WITH CHECK ADD  CONSTRAINT [FK_SurveyDetails_Accounts_UserAccountId] FOREIGN KEY([UserAccountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SurveyDetails] CHECK CONSTRAINT [FK_SurveyDetails_Accounts_UserAccountId]
GO
ALTER TABLE [dbo].[SurveyDetails]  WITH CHECK ADD  CONSTRAINT [FK_SurveyDetails_SurveyRequests_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[SurveyRequests] ([Id])
GO
ALTER TABLE [dbo].[SurveyDetails] CHECK CONSTRAINT [FK_SurveyDetails_SurveyRequests_Id]
GO
ALTER TABLE [dbo].[SurveyRequests]  WITH CHECK ADD  CONSTRAINT [FK_SurveyRequests_Accounts_ReceiverAccountId] FOREIGN KEY([ReceiverAccountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SurveyRequests] CHECK CONSTRAINT [FK_SurveyRequests_Accounts_ReceiverAccountId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Accounts_Implement] FOREIGN KEY([Implement])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Accounts_Implement]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Accounts_Report] FOREIGN KEY([Report])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Accounts_Report]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Visits_VisitId] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visits] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Visits_VisitId]
GO
ALTER TABLE [dbo].[Tokents]  WITH CHECK ADD  CONSTRAINT [FK_Tokents_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Tokents] CHECK CONSTRAINT [FK_Tokents_Accounts_AccountId]
GO
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visits_Distributors_DistributorId] FOREIGN KEY([DistributorId])
REFERENCES [dbo].[Distributors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visits_Distributors_DistributorId]
GO
USE [master]
GO
ALTER DATABASE [CDE] SET  READ_WRITE 
GO
