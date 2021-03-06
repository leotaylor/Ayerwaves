-- 2 script options, 1 user generated, 2 sql generated.
USE [master]
GO
/****** Object:  Database [Ayerwaves]    Script Date: 1/26/2019 11:20:09 AM ******/
CREATE DATABASE [Ayerwaves]

GO
USE [Ayerwaves]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 1/26/2019 11:20:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Genre] [int] NULL,
	[Description] [varchar](1000) NULL,
	[Stage] [int] NULL,
	[PlayTime] [datetime] NULL,
	[Day] [varchar](20) NULL,
	[imageLink] [varchar](250) NULL,
 CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 1/26/2019 11:20:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [varchar](150) NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stage]    Script Date: 1/26/2019 11:20:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StageName] [varchar](150) NULL,
 CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


-- Seed Data for Genre
DECLARE @genreCount int
		,@GenreName varchar(150);

SET @genreCount = 1;
WHILE @genreCount < 11
BEGIN  
	SET @GenreName = 'Genre-' + CAST(@genreCount AS varchar);
	INSERT INTO Genre (GenreName)
	VALUES (@GenreName)
	SET @genreCount = @genreCount + 1;
END  

-- Seed data for Stages

DECLARE @stageCount int
		,@StageName varchar(150);

SET @stageCount = 1;
WHILE @stageCount < 11
BEGIN  
	SET @StageName = 'Stage-' + CAST(@stageCount AS varchar);
	INSERT INTO Stage (StageName)
	VALUES (@StageName)
	SET @stageCount = @stageCount + 1;
END  

-- Seed data for artist 

DECLARE @artistCount int
		,@Name varchar(100)
		,@Genre int
		,@Description varchar(1000)
		,@Stage int
		,@PlayTime datetime
		,@Day varchar(20)
		,@imageLink varchar(250);
SELECT @artistCount = 1
		,@PlayTime = FORMAT(GETDATE(),'hh:mm');
WHILE @artistCount < 11
BEGIN 
	SET @Name = 'Artist ' + CAST(@artistCount as varchar);
	SET @Genre = @artistCount;
	SET @Description = 'Description  ' + CAST(@artistCount as varchar);
	SET @Stage = @artistCount + 10;
	SET @Day = 'Day ' + CAST(@artistCount as varchar);
	SET @imageLink = 'picture ' + Cast(@artistCount as varchar);
	INSERT INTO Artist (Name, Genre, Description, Stage, PlayTime, [Day], imageLink)
	Values (@Name, @Genre, @Description, @Stage, @Playtime, @Day, @imageLink)
	SET @artistCount = @artistCount + 1;
END


ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [FK_Artist_Genre] FOREIGN KEY([Genre])
REFERENCES [dbo].[Genre] ([id])
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [FK_Artist_Genre]
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [FK_Artist_Stage] FOREIGN KEY([Stage])
REFERENCES [dbo].[Stage] ([id])
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [FK_Artist_Stage]
GO
ALTER TABLE [dbo].[Stage]  WITH CHECK ADD  CONSTRAINT [FK_Stage_Stage] FOREIGN KEY([id])
REFERENCES [dbo].[Stage] ([id])
GO
ALTER TABLE [dbo].[Stage] CHECK CONSTRAINT [FK_Stage_Stage]
GO
USE [master]
GO
ALTER DATABASE [Ayerwaves] SET  READ_WRITE 
GO

-- SQL generated scripts

USE [master]
GO
/****** Object:  Database [Ayerwaves]    Script Date: 1/26/2019 11:20:09 AM ******/
CREATE DATABASE [Ayerwaves]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ayerwaves', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Ayerwaves.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ayerwaves_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Ayerwaves_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Ayerwaves] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ayerwaves].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ayerwaves] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ayerwaves] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ayerwaves] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ayerwaves] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ayerwaves] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ayerwaves] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ayerwaves] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ayerwaves] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ayerwaves] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ayerwaves] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ayerwaves] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ayerwaves] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ayerwaves] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ayerwaves] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ayerwaves] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ayerwaves] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ayerwaves] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ayerwaves] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ayerwaves] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ayerwaves] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ayerwaves] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ayerwaves] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ayerwaves] SET RECOVERY FULL 
GO
ALTER DATABASE [Ayerwaves] SET  MULTI_USER 
GO
ALTER DATABASE [Ayerwaves] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ayerwaves] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ayerwaves] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ayerwaves] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ayerwaves] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ayerwaves', N'ON'
GO
ALTER DATABASE [Ayerwaves] SET QUERY_STORE = OFF
GO
USE [Ayerwaves]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Ayerwaves]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 1/26/2019 11:20:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Genre] [int] NULL,
	[Description] [varchar](1000) NULL,
	[Stage] [int] NULL,
	[PlayTime] [datetime] NULL,
	[Day] [varchar](20) NULL,
	[imageLink] [varchar](250) NULL,
 CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 1/26/2019 11:20:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [varchar](150) NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stage]    Script Date: 1/26/2019 11:20:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StageName] [varchar](150) NULL,
 CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Artist] ON 

INSERT [dbo].[Artist] ([id], [Name], [Genre], [Description], [Stage], [PlayTime], [Day], [imageLink]) VALUES (71, N'Artist 1', 1, N'Description  1', 11, CAST(N'1900-01-01T11:13:00.000' AS DateTime), N'Day 1', N'picture 1')
INSERT [dbo].[Artist] ([id], [Name], [Genre], [Description], [Stage], [PlayTime], [Day], [imageLink]) VALUES (72, N'Artist 2', 2, N'Description  2', 12, CAST(N'1900-01-01T11:13:00.000' AS DateTime), N'Day 2', N'picture 2')
INSERT [dbo].[Artist] ([id], [Name], [Genre], [Description], [Stage], [PlayTime], [Day], [imageLink]) VALUES (73, N'Artist 3', 3, N'Description  3', 13, CAST(N'1900-01-01T11:13:00.000' AS DateTime), N'Day 3', N'picture 3')
INSERT [dbo].[Artist] ([id], [Name], [Genre], [Description], [Stage], [PlayTime], [Day], [imageLink]) VALUES (74, N'Artist 4', 4, N'Description  4', 14, CAST(N'1900-01-01T11:13:00.000' AS DateTime), N'Day 4', N'picture 4')
INSERT [dbo].[Artist] ([id], [Name], [Genre], [Description], [Stage], [PlayTime], [Day], [imageLink]) VALUES (75, N'Artist 5', 5, N'Description  5', 15, CAST(N'1900-01-01T11:13:00.000' AS DateTime), N'Day 5', N'picture 5')
INSERT [dbo].[Artist] ([id], [Name], [Genre], [Description], [Stage], [PlayTime], [Day], [imageLink]) VALUES (76, N'Artist 6', 6, N'Description  6', 16, CAST(N'1900-01-01T11:13:00.000' AS DateTime), N'Day 6', N'picture 6')
INSERT [dbo].[Artist] ([id], [Name], [Genre], [Description], [Stage], [PlayTime], [Day], [imageLink]) VALUES (77, N'Artist 7', 7, N'Description  7', 17, CAST(N'1900-01-01T11:13:00.000' AS DateTime), N'Day 7', N'picture 7')
INSERT [dbo].[Artist] ([id], [Name], [Genre], [Description], [Stage], [PlayTime], [Day], [imageLink]) VALUES (78, N'Artist 8', 8, N'Description  8', 18, CAST(N'1900-01-01T11:13:00.000' AS DateTime), N'Day 8', N'picture 8')
INSERT [dbo].[Artist] ([id], [Name], [Genre], [Description], [Stage], [PlayTime], [Day], [imageLink]) VALUES (79, N'Artist 9', 9, N'Description  9', 19, CAST(N'1900-01-01T11:13:00.000' AS DateTime), N'Day 9', N'picture 9')
INSERT [dbo].[Artist] ([id], [Name], [Genre], [Description], [Stage], [PlayTime], [Day], [imageLink]) VALUES (80, N'Artist 10', 10, N'Description  10', 20, CAST(N'1900-01-01T11:13:00.000' AS DateTime), N'Day 10', N'picture 10')
SET IDENTITY_INSERT [dbo].[Artist] OFF
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([id], [GenreName]) VALUES (1, N'Genre-1')
INSERT [dbo].[Genre] ([id], [GenreName]) VALUES (2, N'Genre-2')
INSERT [dbo].[Genre] ([id], [GenreName]) VALUES (3, N'Genre-3')
INSERT [dbo].[Genre] ([id], [GenreName]) VALUES (4, N'Genre-4')
INSERT [dbo].[Genre] ([id], [GenreName]) VALUES (5, N'Genre-5')
INSERT [dbo].[Genre] ([id], [GenreName]) VALUES (6, N'Genre-6')
INSERT [dbo].[Genre] ([id], [GenreName]) VALUES (7, N'Genre-7')
INSERT [dbo].[Genre] ([id], [GenreName]) VALUES (8, N'Genre-8')
INSERT [dbo].[Genre] ([id], [GenreName]) VALUES (9, N'Genre-9')
INSERT [dbo].[Genre] ([id], [GenreName]) VALUES (10, N'Genre-10')
SET IDENTITY_INSERT [dbo].[Genre] OFF
SET IDENTITY_INSERT [dbo].[Stage] ON 

INSERT [dbo].[Stage] ([id], [StageName]) VALUES (11, N'Stage-1')
INSERT [dbo].[Stage] ([id], [StageName]) VALUES (12, N'Stage-2')
INSERT [dbo].[Stage] ([id], [StageName]) VALUES (13, N'Stage-3')
INSERT [dbo].[Stage] ([id], [StageName]) VALUES (14, N'Stage-4')
INSERT [dbo].[Stage] ([id], [StageName]) VALUES (15, N'Stage-5')
INSERT [dbo].[Stage] ([id], [StageName]) VALUES (16, N'Stage-6')
INSERT [dbo].[Stage] ([id], [StageName]) VALUES (17, N'Stage-7')
INSERT [dbo].[Stage] ([id], [StageName]) VALUES (18, N'Stage-8')
INSERT [dbo].[Stage] ([id], [StageName]) VALUES (19, N'Stage-9')
INSERT [dbo].[Stage] ([id], [StageName]) VALUES (20, N'Stage-10')
SET IDENTITY_INSERT [dbo].[Stage] OFF
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [FK_Artist_Genre] FOREIGN KEY([Genre])
REFERENCES [dbo].[Genre] ([id])
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [FK_Artist_Genre]
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [FK_Artist_Stage] FOREIGN KEY([Stage])
REFERENCES [dbo].[Stage] ([id])
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [FK_Artist_Stage]
GO
ALTER TABLE [dbo].[Stage]  WITH CHECK ADD  CONSTRAINT [FK_Stage_Stage] FOREIGN KEY([id])
REFERENCES [dbo].[Stage] ([id])
GO
ALTER TABLE [dbo].[Stage] CHECK CONSTRAINT [FK_Stage_Stage]
GO
USE [master]
GO
ALTER DATABASE [Ayerwaves] SET  READ_WRITE 
GO
