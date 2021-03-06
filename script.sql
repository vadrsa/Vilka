USE [master]
GO
/****** Object:  Database [SportCompare]    Script Date: 8/8/2018 6:50:21 PM ******/
CREATE DATABASE [SportCompare]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SportCompare', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SportCompare.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SportCompare_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SportCompare_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SportCompare] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SportCompare].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SportCompare] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SportCompare] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SportCompare] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SportCompare] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SportCompare] SET ARITHABORT OFF 
GO
ALTER DATABASE [SportCompare] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SportCompare] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SportCompare] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SportCompare] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SportCompare] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SportCompare] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SportCompare] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SportCompare] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SportCompare] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SportCompare] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SportCompare] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SportCompare] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SportCompare] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SportCompare] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SportCompare] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SportCompare] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SportCompare] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SportCompare] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SportCompare] SET  MULTI_USER 
GO
ALTER DATABASE [SportCompare] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SportCompare] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SportCompare] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SportCompare] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SportCompare] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SportCompare]
GO
/****** Object:  Table [dbo].[IdentityRole]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityRole](
	[Id] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_IdentityRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityRoleClaim`1]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityRoleClaim`1](
	[Id] [int] NOT NULL,
	[RoleId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserClaim`1]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserClaim`1](
	[Id] [int] NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserLogin`1]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserLogin`1](
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserRole`1]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserRole`1](
	[UserId] [nvarchar](max) NULL,
	[RoleId] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdentityUserToken`1]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserToken`1](
	[UserId] [nvarchar](max) NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegionDictionary]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionDictionary](
	[RegionDictionaryItemID] [int] IDENTITY(1,1) NOT NULL,
	[RegionID] [int] NOT NULL,
	[SiteID] [int] NOT NULL,
	[Value] [nvarchar](150) NULL,
 CONSTRAINT [PK_RegionDictionary] PRIMARY KEY CLUSTERED 
(
	[RegionDictionaryItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegionHistory]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionHistory](
	[RegionHistoryItemID] [int] IDENTITY(1,1) NOT NULL,
	[RegionQuestionID] [int] NOT NULL,
	[Answer] [int] NOT NULL,
	[UserID] [nvarchar](255) NOT NULL,
	[AnsweredOn] [datetime] NOT NULL,
 CONSTRAINT [PK_RegionHistory] PRIMARY KEY CLUSTERED 
(
	[RegionHistoryItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegionPool]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionPool](
	[RegionPoolItemID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[TransactionNumber] [int] NOT NULL CONSTRAINT [DF_RegionPool_TransactionNumber]  DEFAULT ((1)),
 CONSTRAINT [PK_RegionPool] PRIMARY KEY CLUSTERED 
(
	[RegionPoolItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegionQuestions]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionQuestions](
	[RegionQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[RegionPoolItemID] [int] NOT NULL,
	[RegionID] [int] NOT NULL,
 CONSTRAINT [PK_Table_2] PRIMARY KEY CLUSTERED 
(
	[RegionQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Regions]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[RegionID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[RegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sites]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sites](
	[SiteID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Link] [nvarchar](500) NULL,
 CONSTRAINT [PK_SItes] PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [nvarchar](255) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[RegionHistory] ON 

INSERT [dbo].[RegionHistory] ([RegionHistoryItemID], [RegionQuestionID], [Answer], [UserID], [AnsweredOn]) VALUES (1, 8, 2, N'bcd82dcd-d4ef-427b-b4da-08fd1889b1ac', CAST(N'2018-08-08 18:44:46.913' AS DateTime))
INSERT [dbo].[RegionHistory] ([RegionHistoryItemID], [RegionQuestionID], [Answer], [UserID], [AnsweredOn]) VALUES (2, 7, 2, N'bcd82dcd-d4ef-427b-b4da-08fd1889b1ac', CAST(N'2018-08-08 18:44:59.120' AS DateTime))
INSERT [dbo].[RegionHistory] ([RegionHistoryItemID], [RegionQuestionID], [Answer], [UserID], [AnsweredOn]) VALUES (3, 6, 2, N'bcd82dcd-d4ef-427b-b4da-08fd1889b1ac', CAST(N'2018-08-08 18:45:01.330' AS DateTime))
INSERT [dbo].[RegionHistory] ([RegionHistoryItemID], [RegionQuestionID], [Answer], [UserID], [AnsweredOn]) VALUES (4, 5, 1, N'bcd82dcd-d4ef-427b-b4da-08fd1889b1ac', CAST(N'2018-08-08 18:45:03.350' AS DateTime))
SET IDENTITY_INSERT [dbo].[RegionHistory] OFF
SET IDENTITY_INSERT [dbo].[RegionPool] ON 

INSERT [dbo].[RegionPool] ([RegionPoolItemID], [SiteID], [Name], [TransactionNumber]) VALUES (13, 1, N'Argentina', 1)
INSERT [dbo].[RegionPool] ([RegionPoolItemID], [SiteID], [Name], [TransactionNumber]) VALUES (14, 1, N'Argentina', 1)
INSERT [dbo].[RegionPool] ([RegionPoolItemID], [SiteID], [Name], [TransactionNumber]) VALUES (15, 1, N'Armenia', 1)
INSERT [dbo].[RegionPool] ([RegionPoolItemID], [SiteID], [Name], [TransactionNumber]) VALUES (16, 1, N'Spain', 1)
INSERT [dbo].[RegionPool] ([RegionPoolItemID], [SiteID], [Name], [TransactionNumber]) VALUES (17, 1, N'Spain', 1)
INSERT [dbo].[RegionPool] ([RegionPoolItemID], [SiteID], [Name], [TransactionNumber]) VALUES (18, 1, N'Spain', 1)
INSERT [dbo].[RegionPool] ([RegionPoolItemID], [SiteID], [Name], [TransactionNumber]) VALUES (19, 1, N'Ispania', 1)
SET IDENTITY_INSERT [dbo].[RegionPool] OFF
SET IDENTITY_INSERT [dbo].[RegionQuestions] ON 

INSERT [dbo].[RegionQuestions] ([RegionQuestionID], [RegionPoolItemID], [RegionID]) VALUES (5, 13, 1)
INSERT [dbo].[RegionQuestions] ([RegionQuestionID], [RegionPoolItemID], [RegionID]) VALUES (6, 15, 1)
INSERT [dbo].[RegionQuestions] ([RegionQuestionID], [RegionPoolItemID], [RegionID]) VALUES (7, 16, 1)
INSERT [dbo].[RegionQuestions] ([RegionQuestionID], [RegionPoolItemID], [RegionID]) VALUES (8, 19, 1)
SET IDENTITY_INSERT [dbo].[RegionQuestions] OFF
SET IDENTITY_INSERT [dbo].[Regions] ON 

INSERT [dbo].[Regions] ([RegionID], [Name]) VALUES (1, N'Argentina')
SET IDENTITY_INSERT [dbo].[Regions] OFF
SET IDENTITY_INSERT [dbo].[Sites] ON 

INSERT [dbo].[Sites] ([SiteID], [Name], [Link]) VALUES (1, N'Vivaro', NULL)
SET IDENTITY_INSERT [dbo].[Sites] OFF
INSERT [dbo].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'07b55a42-ca9d-460f-bcb7-25d6e8bb3439', N'me@ozgur.dk', N'ME@OZGUR.DK', N'me@ozgur.dk', N'ME@OZGUR.DK', 0, N'AQAAAAEAACcQAAAAEC8qgpREsIXCYTYP8+zlWseWL7jY1/EozBE7z7iYtobbiI81gTTxodT/BmL6nh23zA==', N'2GTZTI3QJYDSXP5XQHQ45ZIJSTVX2HYR', N'12a34b86-3a8a-4a91-956c-63d05a4d912e', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'16fa1eb7-2598-4265-b381-77ac01d6501e', N'dav', N'DAV@A.A', N'dav@a.a', N'DAV@A.A', 0, N'AQAAAAEAACcQAAAAEFdNI3iUAuUSrrUYodnXjRi//71mH1OPZuSrvZsHW/+GtE1Un4QBKQJv9ZJYLN1K8A==', N'TPRCWWNGUNY5V6VCF5RIRKBKYVITRKKU', N'710313b7-7564-42c9-8071-5145b467728c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bcd82dcd-d4ef-427b-b4da-08fd1889b1ac', N'smb', N'SMB@A.A', N'smb@a.a', N'SMB@A.A', 0, N'AQAAAAEAACcQAAAAELFNggPy3t4RAFfcf2bOjtl/hB8vrxgJrkZ7dWhkmGwwgaTjaI6Xtqv6xeM/370+vw==', N'OWZOPKFSH73LM4ESNYYWSI2TLAFCEDSD', N'24609b60-5687-404e-a20d-8d410dbb7c00', NULL, 0, 0, NULL, 1, 0)
ALTER TABLE [dbo].[RegionDictionary]  WITH CHECK ADD  CONSTRAINT [FK_RegionDictionary_Regions] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Regions] ([RegionID])
GO
ALTER TABLE [dbo].[RegionDictionary] CHECK CONSTRAINT [FK_RegionDictionary_Regions]
GO
ALTER TABLE [dbo].[RegionDictionary]  WITH CHECK ADD  CONSTRAINT [FK_RegionDictionary_SItes] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
ALTER TABLE [dbo].[RegionDictionary] CHECK CONSTRAINT [FK_RegionDictionary_SItes]
GO
ALTER TABLE [dbo].[RegionHistory]  WITH CHECK ADD  CONSTRAINT [FK_RegionHistory_RegionQuestions] FOREIGN KEY([RegionQuestionID])
REFERENCES [dbo].[RegionQuestions] ([RegionQuestionID])
GO
ALTER TABLE [dbo].[RegionHistory] CHECK CONSTRAINT [FK_RegionHistory_RegionQuestions]
GO
ALTER TABLE [dbo].[RegionHistory]  WITH CHECK ADD  CONSTRAINT [FK_RegionHistory_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[RegionHistory] CHECK CONSTRAINT [FK_RegionHistory_User]
GO
ALTER TABLE [dbo].[RegionPool]  WITH CHECK ADD  CONSTRAINT [FK_RegionPool_SItes] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
ALTER TABLE [dbo].[RegionPool] CHECK CONSTRAINT [FK_RegionPool_SItes]
GO
ALTER TABLE [dbo].[RegionQuestions]  WITH NOCHECK ADD  CONSTRAINT [FK_RegionQuestions_RegionPool] FOREIGN KEY([RegionPoolItemID])
REFERENCES [dbo].[RegionPool] ([RegionPoolItemID])
GO
ALTER TABLE [dbo].[RegionQuestions] CHECK CONSTRAINT [FK_RegionQuestions_RegionPool]
GO
ALTER TABLE [dbo].[RegionQuestions]  WITH NOCHECK ADD  CONSTRAINT [FK_RegionQuestions_Regions] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Regions] ([RegionID])
GO
ALTER TABLE [dbo].[RegionQuestions] CHECK CONSTRAINT [FK_RegionQuestions_Regions]
GO
/****** Object:  StoredProcedure [dbo].[regionGetPoolLargestTransactionNumber]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[regionGetPoolLargestTransactionNumber]
AS
BEGIN
	SELECT MAX(TransactionNumber)
	FROM RegionPool
END

GO
/****** Object:  StoredProcedure [dbo].[regionGetQuestionAnswers]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[regionGetQuestionAnswers]
	@poolItemID int
AS
BEGIN
	SELECT
	  RegionQuestions.RegionQuestionID,
	  RegionHistory.Answer,
	  RegionHistory.UserID
  FROM RegionPool
	LEFT JOIN RegionQuestions 
		ON RegionQuestions.RegionPoolItemID = RegionPool.RegionPoolItemID
	RIGHT JOIN RegionHistory
		ON RegionHistory.RegionQuestionID = RegionQuestions.RegionQuestionID
	WHERE
		RegionPool.RegionPoolItemID = @poolItemID
END

GO
/****** Object:  StoredProcedure [dbo].[regionGetQuestionPoolUniqueIDs]    Script Date: 8/8/2018 6:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[regionGetQuestionPoolUniqueIDs]
AS
BEGIN
	/****** Script for SelectTopNRows command from SSMS  ******/
SELECT
      [RegionPoolItemID]
	  FROM [RegionQuestions]
	  GROUP BY [RegionPoolItemID]
	  ORDER BY [RegionPoolItemID] DESC
END


GO
USE [master]
GO
ALTER DATABASE [SportCompare] SET  READ_WRITE 
GO
