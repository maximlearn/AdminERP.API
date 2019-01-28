USE [AdminERP]
GO
ALTER TABLE [dbo].[UserSecurityAnswer] DROP CONSTRAINT [FK_UserSecurityAnswer_User]
GO
ALTER TABLE [dbo].[UserSecurityAnswer] DROP CONSTRAINT [FK_UserSecurityAnswer_SecurityQuestion]
GO
ALTER TABLE [dbo].[UserCredential] DROP CONSTRAINT [FK_UserCredential_User]
GO
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[RoleMenu] DROP CONSTRAINT [FK_RoleMenu_Roles]
GO
ALTER TABLE [dbo].[RoleMenu] DROP CONSTRAINT [FK_RoleMenu_Menu]
GO
ALTER TABLE [dbo].[RoleFunction] DROP CONSTRAINT [FK_RoleFunction_Role]
GO
ALTER TABLE [dbo].[RoleFunction] DROP CONSTRAINT [FK_RoleFunction_Function]
GO
ALTER TABLE [dbo].[Department] DROP CONSTRAINT [FK_Department_User1]
GO
ALTER TABLE [dbo].[Department] DROP CONSTRAINT [FK_Department_User]
GO
ALTER TABLE [dbo].[Company] DROP CONSTRAINT [FK_Company_User1]
GO
ALTER TABLE [dbo].[Company] DROP CONSTRAINT [FK_Company_User]
GO
ALTER TABLE [dbo].[AssetGatePassSenderDetail] DROP CONSTRAINT [FK_AssetGatePassSenderDetail_AssetGatePass]
GO
ALTER TABLE [dbo].[AssetGatePassDetail] DROP CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit1]
GO
ALTER TABLE [dbo].[AssetGatePassDetail] DROP CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit]
GO
ALTER TABLE [dbo].[AssetGatePassDetail] DROP CONSTRAINT [FK_AssetGatePassDetail_AssetGatePass]
GO
ALTER TABLE [dbo].[AssetGatePassDetail] DROP CONSTRAINT [FK_AssetGatePassDetail_Asset]
GO
ALTER TABLE [dbo].[AssetGatePass] DROP CONSTRAINT [FK_AssetGatePass_User2]
GO
ALTER TABLE [dbo].[AssetGatePass] DROP CONSTRAINT [FK_AssetGatePass_User1]
GO
ALTER TABLE [dbo].[AssetGatePass] DROP CONSTRAINT [FK_AssetGatePass_User]
GO
ALTER TABLE [dbo].[AssetGatePass] DROP CONSTRAINT [FK_AssetGatePass_GatePassStatus]
GO
ALTER TABLE [dbo].[AssetDetail] DROP CONSTRAINT [FK_AssetDetail_Vendor]
GO
ALTER TABLE [dbo].[AssetDetail] DROP CONSTRAINT [FK_AssetDetail_Asset]
GO
ALTER TABLE [dbo].[AssetCategory] DROP CONSTRAINT [FK_AssetCategory_User1]
GO
ALTER TABLE [dbo].[AssetCategory] DROP CONSTRAINT [FK_AssetCategory_User]
GO
ALTER TABLE [dbo].[Asset] DROP CONSTRAINT [FK_Asset_User1]
GO
ALTER TABLE [dbo].[Asset] DROP CONSTRAINT [FK_Asset_User]
GO
ALTER TABLE [dbo].[Asset] DROP CONSTRAINT [FK_Asset_AssetCategory]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[Vendor]
GO
/****** Object:  Table [dbo].[UserSecurityAnswer]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[UserSecurityAnswer]
GO
/****** Object:  Table [dbo].[UserCredential]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[UserCredential]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[SecurityQuestion]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[SecurityQuestion]
GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[RoleMenu]
GO
/****** Object:  Table [dbo].[RoleFunction]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[RoleFunction]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[QuantityUnit]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[QuantityUnit]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[Menu]
GO
/****** Object:  Table [dbo].[GatePassStatus]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[GatePassStatus]
GO
/****** Object:  Table [dbo].[Function]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[Function]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[Department]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[Company]
GO
/****** Object:  Table [dbo].[AssetGatePassSenderDetail]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[AssetGatePassSenderDetail]
GO
/****** Object:  Table [dbo].[AssetGatePassDetail]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[AssetGatePassDetail]
GO
/****** Object:  Table [dbo].[AssetGatePass]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[AssetGatePass]
GO
/****** Object:  Table [dbo].[AssetDetail]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[AssetDetail]
GO
/****** Object:  Table [dbo].[AssetCategory]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[AssetCategory]
GO
/****** Object:  Table [dbo].[Asset]    Script Date: 10-Jan-19 6:00:05 PM ******/
DROP TABLE [dbo].[Asset]
GO
/****** Object:  Table [dbo].[Asset]    Script Date: 10-Jan-19 6:00:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Asset](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AssetTagID] [varchar](100) NOT NULL,
	[AssetName] [varchar](300) NOT NULL,
	[AssetCategoryID] [int] NOT NULL,
	[AssetDescription] [varchar](500) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Asset_CreatedDate]  DEFAULT (getdate()),
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_Asset_ModifiedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Asset] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssetCategory]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssetCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](100) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_AssetCategory_CreatedDate]  DEFAULT (getdate()),
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_AssetCategory_ModifiedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_AssetCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssetDetail]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssetDetail](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AssetID] [bigint] NOT NULL,
	[PurchaseDate] [date] NULL,
	[VendorID] [int] NULL,
	[Cost] [decimal](18, 2) NULL,
	[WarrantyExpireDate] [date] NULL,
	[WarrantyDocumentId] [varchar](100) NULL,
	[AssetImageId] [varchar](100) NULL,
	[BrandName] [varchar](100) NULL,
	[ModelNumber] [varchar](100) NULL,
	[SerialNumber] [varchar](100) NULL,
 CONSTRAINT [PK_AssetDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssetGatePass]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssetGatePass](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GatePassNo] [varchar](100) NOT NULL,
	[GatePassDate] [datetime] NOT NULL,
	[IsReturnable] [bit] NULL,
	[GatePassStatusID] [int] NOT NULL,
	[ReceivedBy] [int] NULL,
	[Remarks] [varchar](800) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AssetGatePass] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssetGatePassDetail]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetGatePassDetail](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AssetGatePassID] [bigint] NULL,
	[AssetID] [bigint] NULL,
	[SendQty] [decimal](18, 3) NULL,
	[SendQtyUnitID] [int] NULL,
	[ReceivedQty] [decimal](18, 3) NULL,
	[ReceivedQtyUnitID] [int] NULL,
	[IsReturnable] [bit] NULL,
 CONSTRAINT [PK_AssetGatePassDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssetGatePassSenderDetail]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssetGatePassSenderDetail](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AssetGatePassID] [bigint] NOT NULL,
	[Name] [varchar](100) NULL,
	[CompanyName] [varchar](100) NULL,
	[Address] [varchar](500) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK_AssetGatePassSenderDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[Address1] [varchar](500) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Country] [varchar](50) NULL,
	[WebSiteURL] [varchar](100) NULL,
	[CompanyLogoId] [uniqueidentifier] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Department_CreatedDate]  DEFAULT (getdate()),
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_Department_ModifiedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Function]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Function](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FunctionCode] [varchar](500) NOT NULL,
	[FunctionName] [varchar](500) NOT NULL,
	[FunctionDescription] [varchar](500) NULL,
 CONSTRAINT [PK_Function] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GatePassStatus]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GatePassStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GatePassStatus] [varchar](50) NULL,
 CONSTRAINT [PK_GatePassStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[MenuTitle] [varchar](100) NULL,
	[ParentMenuId] [smallint] NULL,
	[MenuLink] [nvarchar](255) NULL,
	[TemplateUrl] [nvarchar](150) NULL,
	[Controller] [nvarchar](150) NULL,
	[ControllerAs] [nvarchar](50) NULL,
	[IsDisabled] [bit] NOT NULL,
	[IsStateRequired] [bit] NOT NULL CONSTRAINT [DF_Menu_IsStateRequired]  DEFAULT ((0)),
	[DisplayOrder] [smallint] NOT NULL,
	[Tag] [nvarchar](20) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuantityUnit]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuantityUnit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Unit] [varchar](50) NOT NULL,
 CONSTRAINT [PK_QuantityUnit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](250) NOT NULL,
	[RoleDescription] [nvarchar](250) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Role_CreatedDate]  DEFAULT (getdate()),
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_Role_ModifiedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleFunction]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleFunction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[FunctionID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_RoleFunction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[MenuID] [smallint] NOT NULL,
 CONSTRAINT [PK_RoleMenu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityQuestion]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SecurityQuestion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Question] [varchar](300) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_SecurityQuestion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](15) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NULL,
	[EmpId] [varchar](100) NOT NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[DeptId] [int] NULL,
	[RoleId] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()),
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_User_ModifiedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserCredential]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserCredential](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[PasswordKey] [varchar](500) NOT NULL,
	[Attempted] [int] NULL,
 CONSTRAINT [PK_UserCredential] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserSecurityAnswer]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserSecurityAnswer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[SecurityQuestionID] [int] NOT NULL,
	[Answer] [varchar](100) NOT NULL,
 CONSTRAINT [PK_UserSecurityAnswer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 10-Jan-19 6:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [varchar](200) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Asset] ON 

INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Tag123', N'Laptop', 4, N'Laptop Computer', 1, 1, CAST(N'2018-12-25 20:50:02.100' AS DateTime), 1, CAST(N'2018-12-25 20:50:02.100' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (44, N'Tag001', N'Laptop', 7, NULL, 1, 1, CAST(N'2018-12-29 12:04:41.730' AS DateTime), 1, CAST(N'2018-12-29 12:04:41.730' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (45, N'Tag003', N'Table', 4, NULL, 1, 1, CAST(N'2018-12-29 12:06:14.027' AS DateTime), 1, CAST(N'2018-12-29 12:06:14.027' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (46, N'Tag001', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-29 15:33:49.933' AS DateTime), 1, CAST(N'2018-12-29 15:33:49.933' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (47, N'Tag001', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-29 15:34:16.347' AS DateTime), 1, CAST(N'2018-12-29 15:34:16.347' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (48, N'Tag001', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-29 15:39:42.713' AS DateTime), 1, CAST(N'2018-12-29 15:39:42.713' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (49, N'Tag001', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-29 15:41:34.947' AS DateTime), 1, CAST(N'2018-12-29 15:41:34.947' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (50, N'Tag001', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-29 15:44:43.647' AS DateTime), 1, CAST(N'2018-12-29 15:44:43.647' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (51, N'Tag001', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-29 15:53:20.640' AS DateTime), 1, CAST(N'2018-12-29 15:53:20.640' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (52, N'Tag001', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-29 15:54:59.790' AS DateTime), 1, CAST(N'2018-12-29 15:54:59.790' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (53, N'Tag001', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-29 15:55:20.957' AS DateTime), 1, CAST(N'2018-12-29 15:55:20.957' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (54, N'Tag001', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-29 15:56:23.610' AS DateTime), 1, CAST(N'2018-12-29 15:56:23.610' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (55, N'Tag001', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-29 15:59:34.683' AS DateTime), 1, CAST(N'2018-12-29 15:59:34.683' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (56, N'Tag001', N'as', 4, NULL, 1, 1, CAST(N'2018-12-29 16:00:35.993' AS DateTime), 1, CAST(N'2018-12-29 16:00:35.993' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (57, N'Tag001', N'as', 4, NULL, 1, 1, CAST(N'2018-12-29 16:00:49.067' AS DateTime), 1, CAST(N'2018-12-29 16:00:49.067' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (58, N'Tag010', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-29 20:54:36.627' AS DateTime), 1, CAST(N'2018-12-29 20:54:36.627' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (59, N'Tag0011', N'Desktop', 4, N'ads', 1, 1, CAST(N'2018-12-29 21:04:22.403' AS DateTime), 1, CAST(N'2018-12-29 21:04:22.403' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (60, N'Tag0012', N'Desktop', 4, N'Asset Tag', 1, 1, CAST(N'2018-12-29 21:06:01.780' AS DateTime), 1, CAST(N'2018-12-29 21:06:01.780' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (61, N'2323', N'as', 4, NULL, 1, 1, CAST(N'2018-12-30 12:04:48.463' AS DateTime), 1, CAST(N'2018-12-30 12:04:48.463' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (62, N'Tag00123', N'as', 4, NULL, 1, 1, CAST(N'2018-12-30 15:09:58.633' AS DateTime), 1, CAST(N'2018-12-30 15:09:58.633' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (63, N'Tag001235', N'as', 4, NULL, 1, 1, CAST(N'2018-12-30 15:14:24.063' AS DateTime), 1, CAST(N'2018-12-30 15:14:24.617' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (64, N'ta1', N'as', 4, NULL, 1, 1, CAST(N'2018-12-30 15:16:39.963' AS DateTime), 1, CAST(N'2018-12-30 15:16:39.963' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (65, N'sds', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-30 15:19:16.203' AS DateTime), 1, CAST(N'2018-12-30 15:19:16.203' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (66, N'sds', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-30 15:19:16.193' AS DateTime), 1, CAST(N'2018-12-30 15:19:16.193' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (67, N'sds343', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-30 15:19:29.773' AS DateTime), 1, CAST(N'2018-12-30 15:19:29.773' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (68, N'sds34378', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-30 15:19:49.283' AS DateTime), 1, CAST(N'2018-12-30 15:19:49.283' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (72, N'12', N'Desktop', 4, NULL, 1, 1, CAST(N'2018-12-30 17:26:19.590' AS DateTime), 1, CAST(N'2018-12-30 17:26:19.590' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (73, N'sd', N'as', 4, NULL, 1, 1, CAST(N'2018-12-30 21:52:24.840' AS DateTime), 1, CAST(N'2018-12-30 21:52:24.840' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (74, N'Tag00167', N'Desktop', 4, NULL, 1, 1, CAST(N'2019-01-02 12:20:31.020' AS DateTime), 1, CAST(N'2019-01-02 12:20:31.020' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (75, N'Tag0011111', N'Desktop', 4, NULL, 1, 1, CAST(N'2019-01-02 13:41:56.113' AS DateTime), 1, CAST(N'2019-01-02 13:41:56.113' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (76, N'Tag001789', N'as', 7, NULL, 1, 1, CAST(N'2019-01-02 18:06:51.043' AS DateTime), 1, CAST(N'2019-01-02 18:06:51.043' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (77, N'Tag001789999', N'Chair', 4, N'Assect Description', 1, 1, CAST(N'2019-01-02 18:07:48.843' AS DateTime), 1, CAST(N'2019-01-02 18:07:48.843' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (78, N'Tag0011234', N'as', 4, NULL, 1, 1, CAST(N'2019-01-09 23:19:55.827' AS DateTime), 1, CAST(N'2019-01-09 23:19:55.827' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (79, N'Tag001112', N'as', 4, NULL, 1, 1, CAST(N'2019-01-09 23:43:01.317' AS DateTime), 1, CAST(N'2019-01-09 23:43:01.320' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (80, N'Tag001121', N'as', 4, NULL, 1, 1, CAST(N'2019-01-09 23:43:37.110' AS DateTime), 1, CAST(N'2019-01-09 23:43:37.110' AS DateTime))
SET IDENTITY_INSERT [dbo].[Asset] OFF
SET IDENTITY_INSERT [dbo].[AssetCategory] ON 

INSERT [dbo].[AssetCategory] ([ID], [CategoryName], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Computer', 1, 1, CAST(N'2018-12-25 20:49:41.870' AS DateTime), 1, CAST(N'2018-12-25 20:49:41.870' AS DateTime))
INSERT [dbo].[AssetCategory] ([ID], [CategoryName], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'Phone', 1, 1, CAST(N'2018-12-26 10:03:37.037' AS DateTime), 1, CAST(N'2018-12-26 10:03:37.037' AS DateTime))
SET IDENTITY_INSERT [dbo].[AssetCategory] OFF
SET IDENTITY_INSERT [dbo].[AssetDetail] ON 

INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (1, 4, CAST(N'2018-04-03' AS Date), 1, CAST(35000.00 AS Decimal(18, 2)), CAST(N'2022-05-03' AS Date), NULL, NULL, N'Dell', N'M2323232', N'SR232323')
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (20, 44, CAST(N'2018-12-11' AS Date), NULL, CAST(35.00 AS Decimal(18, 2)), CAST(N'2018-12-07' AS Date), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (21, 45, NULL, NULL, CAST(23.55 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (22, 46, NULL, NULL, CAST(23.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (23, 47, NULL, NULL, CAST(23.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (24, 48, NULL, NULL, CAST(23.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (25, 49, NULL, NULL, CAST(45.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (26, 50, NULL, NULL, CAST(45.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (27, 51, NULL, NULL, CAST(34.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (28, 52, NULL, NULL, CAST(45.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (29, 53, NULL, NULL, CAST(45.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (30, 54, NULL, NULL, CAST(34.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (31, 55, NULL, NULL, CAST(34.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (32, 56, NULL, NULL, CAST(23.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (33, 57, NULL, NULL, CAST(23.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (34, 58, NULL, NULL, CAST(67.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (35, 59, CAST(N'2018-12-10' AS Date), 1, CAST(34.00 AS Decimal(18, 2)), CAST(N'2018-12-11' AS Date), NULL, NULL, N'Dell', N'sddsd', N'233')
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (36, 60, CAST(N'2018-12-10' AS Date), 1, CAST(23.00 AS Decimal(18, 2)), CAST(N'2018-12-11' AS Date), NULL, NULL, N'Dell', N'345345', N'233')
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (40, 64, NULL, NULL, CAST(23.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (41, 66, NULL, NULL, CAST(67.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (42, 65, NULL, NULL, CAST(67.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (43, 67, NULL, NULL, CAST(67.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (44, 68, NULL, 1, CAST(67.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (45, 72, NULL, NULL, CAST(34.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (46, 73, NULL, NULL, CAST(45.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (47, 74, NULL, NULL, CAST(45.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (48, 75, NULL, NULL, CAST(56.00 AS Decimal(18, 2)), NULL, N'285566a9-25a2-4948-ad8d-d5240a3a4cd3', N'f23537cc-fa12-4eb0-a50f-9da649a33573', NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (49, 76, CAST(N'2018-12-17' AS Date), NULL, CAST(34.00 AS Decimal(18, 2)), CAST(N'2018-12-20' AS Date), N'0370fb30-091f-4ced-a20a-931b464033b8', N'66c56d49-7838-4323-aa7f-eeca196dcd25', NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (50, 77, CAST(N'2018-12-17' AS Date), 1, CAST(34.00 AS Decimal(18, 2)), CAST(N'2018-12-20' AS Date), N'f41ab3a3-ef67-4e3c-9b14-b2c988933b12', N'50d02ab7-a6da-4092-b95f-6ea7bfc7f71f', N'Dell', N'1234567', N'78907666')
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (51, 78, NULL, NULL, CAST(34.00 AS Decimal(18, 2)), NULL, N'1368ee15-c64e-450c-84ff-65d28a205536', N'd53e3353-db2a-4532-8e4b-223df456eca1', NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (52, 79, NULL, NULL, CAST(23.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (53, 80, NULL, NULL, CAST(23.00 AS Decimal(18, 2)), NULL, N'6c04f4e8-1558-4483-9fd0-bfb96040d77a', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AssetDetail] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([ID], [DepartmentName], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Finance', 1, NULL, CAST(N'2018-12-25 20:46:14.327' AS DateTime), NULL, CAST(N'2018-12-25 20:46:14.327' AS DateTime))
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Function] ON 

INSERT [dbo].[Function] ([ID], [FunctionCode], [FunctionName], [FunctionDescription]) VALUES (1, N'ADDASSET', N'AddAsset', NULL)
SET IDENTITY_INSERT [dbo].[Function] OFF
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (3, N'Asset Managment', 0, NULL, NULL, NULL, NULL, 0, 0, 1, N'menu1')
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (6, N'Add Asset', 3, N'/assets/addasset', NULL, NULL, NULL, 0, 0, 2, NULL)
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (7, N'List Asset', 3, N'/assets/listasset', NULL, NULL, NULL, 0, 0, 3, NULL)
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (9, N'Gate Pass Management', 0, NULL, NULL, NULL, NULL, 0, 0, 4, N'menu2')
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (10, N'Create Gate Pass', 9, N'/gatepass/creategatepass', NULL, NULL, NULL, 0, 0, 5, NULL)
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (11, N'List Gate Pass', 9, N'/gatepass/listgatepass', NULL, NULL, NULL, 0, 0, 6, NULL)
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (12, N'User Management', 0, NULL, NULL, NULL, NULL, 0, 0, 7, N'menu3')
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (13, N'Manage User', 12, N'/user/adduser', NULL, NULL, NULL, 0, 0, 8, NULL)
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (14, N'Role Management', 0, NULL, NULL, NULL, NULL, 0, 0, 9, N'menu4')
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (15, N'Manage Role', 14, N'/role/addrole', NULL, NULL, NULL, 0, 0, 10, NULL)
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (16, N'Basic Configuration', 0, NULL, NULL, NULL, NULL, 0, 0, 11, N'menu5')
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (17, N'Configuration', 16, N'/basicconfig/configuration', NULL, NULL, NULL, 0, 0, 12, NULL)
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (18, N'Report Management', 0, NULL, NULL, NULL, NULL, 0, 0, 13, NULL)
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (19, N'Gate Pass Report', 18, N'/report/gatepassreport', NULL, NULL, NULL, 0, 0, 14, NULL)
INSERT [dbo].[Menu] ([ID], [MenuTitle], [ParentMenuId], [MenuLink], [TemplateUrl], [Controller], [ControllerAs], [IsDisabled], [IsStateRequired], [DisplayOrder], [Tag]) VALUES (20, N'Asset Report', 18, N'/report/assetreport', NULL, NULL, NULL, 0, 0, 15, NULL)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleName], [RoleDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Admin', N'Admin', NULL, CAST(N'2018-12-25 20:43:43.507' AS DateTime), NULL, CAST(N'2018-12-25 20:43:43.507' AS DateTime))
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[RoleFunction] ON 

INSERT [dbo].[RoleFunction] ([ID], [RoleID], [FunctionID], [IsActive]) VALUES (1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[RoleFunction] OFF
SET IDENTITY_INSERT [dbo].[RoleMenu] ON 

INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (1, 1, 3)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (2, 1, 6)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (3, 1, 7)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (4, 1, 9)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (5, 1, 10)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (6, 1, 11)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (7, 1, 12)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (8, 1, 13)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (9, 1, 14)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (10, 1, 15)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (11, 1, 16)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (12, 1, 17)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (13, 1, 18)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (14, 1, 19)
INSERT [dbo].[RoleMenu] ([ID], [RoleID], [MenuID]) VALUES (15, 1, 20)
SET IDENTITY_INSERT [dbo].[RoleMenu] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Title], [FirstName], [LastName], [EmpId], [Phone], [Email], [DeptId], [RoleId], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Mr', N'Vishal', N'Tyagi', N'123456', N'99999999', N'vishal@abc.com', 1, 1, 1, NULL, CAST(N'2018-12-25 20:47:11.140' AS DateTime), NULL, CAST(N'2018-12-25 20:47:11.140' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserCredential] ON 

INSERT [dbo].[UserCredential] ([ID], [UserID], [Password], [PasswordKey], [Attempted]) VALUES (2, 1, N'a', N'a', 1)
SET IDENTITY_INSERT [dbo].[UserCredential] OFF
SET IDENTITY_INSERT [dbo].[Vendor] ON 

INSERT [dbo].[Vendor] ([ID], [VendorName], [IsActive]) VALUES (1, N'Dell Computer', 1)
SET IDENTITY_INSERT [dbo].[Vendor] OFF
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_AssetCategory] FOREIGN KEY([AssetCategoryID])
REFERENCES [dbo].[AssetCategory] ([ID])
GO
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_AssetCategory]
GO
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_User]
GO
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_User1]
GO
ALTER TABLE [dbo].[AssetCategory]  WITH CHECK ADD  CONSTRAINT [FK_AssetCategory_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[AssetCategory] CHECK CONSTRAINT [FK_AssetCategory_User]
GO
ALTER TABLE [dbo].[AssetCategory]  WITH CHECK ADD  CONSTRAINT [FK_AssetCategory_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[AssetCategory] CHECK CONSTRAINT [FK_AssetCategory_User1]
GO
ALTER TABLE [dbo].[AssetDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetDetail_Asset] FOREIGN KEY([AssetID])
REFERENCES [dbo].[Asset] ([ID])
GO
ALTER TABLE [dbo].[AssetDetail] CHECK CONSTRAINT [FK_AssetDetail_Asset]
GO
ALTER TABLE [dbo].[AssetDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetDetail_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([ID])
GO
ALTER TABLE [dbo].[AssetDetail] CHECK CONSTRAINT [FK_AssetDetail_Vendor]
GO
ALTER TABLE [dbo].[AssetGatePass]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePass_GatePassStatus] FOREIGN KEY([GatePassStatusID])
REFERENCES [dbo].[GatePassStatus] ([ID])
GO
ALTER TABLE [dbo].[AssetGatePass] CHECK CONSTRAINT [FK_AssetGatePass_GatePassStatus]
GO
ALTER TABLE [dbo].[AssetGatePass]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePass_User] FOREIGN KEY([ReceivedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[AssetGatePass] CHECK CONSTRAINT [FK_AssetGatePass_User]
GO
ALTER TABLE [dbo].[AssetGatePass]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePass_User1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[AssetGatePass] CHECK CONSTRAINT [FK_AssetGatePass_User1]
GO
ALTER TABLE [dbo].[AssetGatePass]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePass_User2] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[AssetGatePass] CHECK CONSTRAINT [FK_AssetGatePass_User2]
GO
ALTER TABLE [dbo].[AssetGatePassDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePassDetail_Asset] FOREIGN KEY([AssetID])
REFERENCES [dbo].[Asset] ([ID])
GO
ALTER TABLE [dbo].[AssetGatePassDetail] CHECK CONSTRAINT [FK_AssetGatePassDetail_Asset]
GO
ALTER TABLE [dbo].[AssetGatePassDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePassDetail_AssetGatePass] FOREIGN KEY([AssetGatePassID])
REFERENCES [dbo].[AssetGatePass] ([ID])
GO
ALTER TABLE [dbo].[AssetGatePassDetail] CHECK CONSTRAINT [FK_AssetGatePassDetail_AssetGatePass]
GO
ALTER TABLE [dbo].[AssetGatePassDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit] FOREIGN KEY([SendQtyUnitID])
REFERENCES [dbo].[QuantityUnit] ([ID])
GO
ALTER TABLE [dbo].[AssetGatePassDetail] CHECK CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit]
GO
ALTER TABLE [dbo].[AssetGatePassDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit1] FOREIGN KEY([ReceivedQtyUnitID])
REFERENCES [dbo].[QuantityUnit] ([ID])
GO
ALTER TABLE [dbo].[AssetGatePassDetail] CHECK CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit1]
GO
ALTER TABLE [dbo].[AssetGatePassSenderDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePassSenderDetail_AssetGatePass] FOREIGN KEY([AssetGatePassID])
REFERENCES [dbo].[AssetGatePass] ([ID])
GO
ALTER TABLE [dbo].[AssetGatePassSenderDetail] CHECK CONSTRAINT [FK_AssetGatePassSenderDetail_AssetGatePass]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_User]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_User1]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_User]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_User1]
GO
ALTER TABLE [dbo].[RoleFunction]  WITH CHECK ADD  CONSTRAINT [FK_RoleFunction_Function] FOREIGN KEY([FunctionID])
REFERENCES [dbo].[Function] ([ID])
GO
ALTER TABLE [dbo].[RoleFunction] CHECK CONSTRAINT [FK_RoleFunction_Function]
GO
ALTER TABLE [dbo].[RoleFunction]  WITH CHECK ADD  CONSTRAINT [FK_RoleFunction_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[RoleFunction] CHECK CONSTRAINT [FK_RoleFunction_Role]
GO
ALTER TABLE [dbo].[RoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenu_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([ID])
GO
ALTER TABLE [dbo].[RoleMenu] CHECK CONSTRAINT [FK_RoleMenu_Menu]
GO
ALTER TABLE [dbo].[RoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenu_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[RoleMenu] CHECK CONSTRAINT [FK_RoleMenu_Roles]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[UserCredential]  WITH CHECK ADD  CONSTRAINT [FK_UserCredential_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserCredential] CHECK CONSTRAINT [FK_UserCredential_User]
GO
ALTER TABLE [dbo].[UserSecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UserSecurityAnswer_SecurityQuestion] FOREIGN KEY([SecurityQuestionID])
REFERENCES [dbo].[SecurityQuestion] ([ID])
GO
ALTER TABLE [dbo].[UserSecurityAnswer] CHECK CONSTRAINT [FK_UserSecurityAnswer_SecurityQuestion]
GO
ALTER TABLE [dbo].[UserSecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UserSecurityAnswer_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserSecurityAnswer] CHECK CONSTRAINT [FK_UserSecurityAnswer_User]
GO
