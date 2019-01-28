USE [AdminERP]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserSecurityAnswer_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserSecurityAnswer]'))
ALTER TABLE [dbo].[UserSecurityAnswer] DROP CONSTRAINT [FK_UserSecurityAnswer_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserSecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserSecurityAnswer]'))
ALTER TABLE [dbo].[UserSecurityAnswer] DROP CONSTRAINT [FK_UserSecurityAnswer_SecurityQuestion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserCredential_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserCredential]'))
ALTER TABLE [dbo].[UserCredential] DROP CONSTRAINT [FK_UserCredential_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Role]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleMenu_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleMenu]'))
ALTER TABLE [dbo].[RoleMenu] DROP CONSTRAINT [FK_RoleMenu_Roles]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleMenu_Menu]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleMenu]'))
ALTER TABLE [dbo].[RoleMenu] DROP CONSTRAINT [FK_RoleMenu_Menu]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleFunction_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleFunction]'))
ALTER TABLE [dbo].[RoleFunction] DROP CONSTRAINT [FK_RoleFunction_Role]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleFunction_Function]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleFunction]'))
ALTER TABLE [dbo].[RoleFunction] DROP CONSTRAINT [FK_RoleFunction_Function]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Department_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Department]'))
ALTER TABLE [dbo].[Department] DROP CONSTRAINT [FK_Department_User1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Department_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Department]'))
ALTER TABLE [dbo].[Department] DROP CONSTRAINT [FK_Department_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Company_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Company]'))
ALTER TABLE [dbo].[Company] DROP CONSTRAINT [FK_Company_User1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Company_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Company]'))
ALTER TABLE [dbo].[Company] DROP CONSTRAINT [FK_Company_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassSenderDetail_AssetGatePass]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassSenderDetail]'))
ALTER TABLE [dbo].[AssetGatePassSenderDetail] DROP CONSTRAINT [FK_AssetGatePassSenderDetail_AssetGatePass]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_QuantityUnit1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail] DROP CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_QuantityUnit]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail] DROP CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_GatePassStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail] DROP CONSTRAINT [FK_AssetGatePassDetail_GatePassStatus]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_AssetGatePass]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail] DROP CONSTRAINT [FK_AssetGatePassDetail_AssetGatePass]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_Asset]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail] DROP CONSTRAINT [FK_AssetGatePassDetail_Asset]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_User2]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass] DROP CONSTRAINT [FK_AssetGatePass_User2]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass] DROP CONSTRAINT [FK_AssetGatePass_User1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass] DROP CONSTRAINT [FK_AssetGatePass_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_Type]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass] DROP CONSTRAINT [FK_AssetGatePass_Type]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_Status]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass] DROP CONSTRAINT [FK_AssetGatePass_Status]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetDetail_Vendor]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetDetail]'))
ALTER TABLE [dbo].[AssetDetail] DROP CONSTRAINT [FK_AssetDetail_Vendor]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetDetail_Asset]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetDetail]'))
ALTER TABLE [dbo].[AssetDetail] DROP CONSTRAINT [FK_AssetDetail_Asset]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetCategory_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetCategory]'))
ALTER TABLE [dbo].[AssetCategory] DROP CONSTRAINT [FK_AssetCategory_User1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetCategory_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetCategory]'))
ALTER TABLE [dbo].[AssetCategory] DROP CONSTRAINT [FK_AssetCategory_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Asset_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Asset]'))
ALTER TABLE [dbo].[Asset] DROP CONSTRAINT [FK_Asset_User1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Asset_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Asset]'))
ALTER TABLE [dbo].[Asset] DROP CONSTRAINT [FK_Asset_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Asset_AssetCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Asset]'))
ALTER TABLE [dbo].[Asset] DROP CONSTRAINT [FK_Asset_AssetCategory]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vendor]') AND type in (N'U'))
DROP TABLE [dbo].[Vendor]
GO
/****** Object:  Table [dbo].[UserSecurityAnswer]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserSecurityAnswer]') AND type in (N'U'))
DROP TABLE [dbo].[UserSecurityAnswer]
GO
/****** Object:  Table [dbo].[UserCredential]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserCredential]') AND type in (N'U'))
DROP TABLE [dbo].[UserCredential]
GO
/****** Object:  Table [dbo].[User]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Status]') AND type in (N'U'))
DROP TABLE [dbo].[Status]
GO
/****** Object:  Table [dbo].[SecurityQuestion]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestion]') AND type in (N'U'))
DROP TABLE [dbo].[SecurityQuestion]
GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleMenu]') AND type in (N'U'))
DROP TABLE [dbo].[RoleMenu]
GO
/****** Object:  Table [dbo].[RoleFunction]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleFunction]') AND type in (N'U'))
DROP TABLE [dbo].[RoleFunction]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[QuantityUnit]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuantityUnit]') AND type in (N'U'))
DROP TABLE [dbo].[QuantityUnit]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu]') AND type in (N'U'))
DROP TABLE [dbo].[Menu]
GO
/****** Object:  Table [dbo].[GatePassType]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GatePassType]') AND type in (N'U'))
DROP TABLE [dbo].[GatePassType]
GO
/****** Object:  Table [dbo].[Function]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Function]') AND type in (N'U'))
DROP TABLE [dbo].[Function]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
DROP TABLE [dbo].[Department]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Company]') AND type in (N'U'))
DROP TABLE [dbo].[Company]
GO
/****** Object:  Table [dbo].[AssetGatePassSenderDetail]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetGatePassSenderDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AssetGatePassSenderDetail]
GO
/****** Object:  Table [dbo].[AssetGatePassDetail]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AssetGatePassDetail]
GO
/****** Object:  Table [dbo].[AssetGatePass]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetGatePass]') AND type in (N'U'))
DROP TABLE [dbo].[AssetGatePass]
GO
/****** Object:  Table [dbo].[AssetDetail]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AssetDetail]
GO
/****** Object:  Table [dbo].[AssetCategory]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetCategory]') AND type in (N'U'))
DROP TABLE [dbo].[AssetCategory]
GO
/****** Object:  Table [dbo].[Asset]    Script Date: 28-Jan-19 7:12:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Asset]') AND type in (N'U'))
DROP TABLE [dbo].[Asset]
GO
/****** Object:  Table [dbo].[Asset]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Asset]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssetCategory]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetCategory]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssetDetail]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetDetail]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssetGatePass]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetGatePass]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AssetGatePass](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GatePassNo] [varchar](100) NOT NULL,
	[GatePassDate] [datetime] NOT NULL,
	[GatePassTypeId] [int] NOT NULL,
	[ReceivedBy] [int] NULL,
	[Remarks] [varchar](800) NULL,
	[IsActive] [bit] NOT NULL,
	[GatePassStatusId] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AssetGatePass] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssetGatePassDetail]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AssetGatePassDetail](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AssetGatePassID] [bigint] NULL,
	[AssetID] [bigint] NULL,
	[SendQty] [decimal](18, 3) NULL,
	[SendQtyUnitID] [int] NULL,
	[ReceivedQty] [decimal](18, 3) NULL,
	[ReceivedQtyUnitID] [int] NULL,
	[AssetTypeID] [int] NULL,
 CONSTRAINT [PK_AssetGatePassDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AssetGatePassSenderDetail]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssetGatePassSenderDetail]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Company]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Function]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Function]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GatePassType]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GatePassType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GatePassType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](100) NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuantityUnit]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuantityUnit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[QuantityUnit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Unit] [varchar](50) NOT NULL,
 CONSTRAINT [PK_QuantityUnit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[RoleFunction]    Script Date: 28-Jan-19 7:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleFunction]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 28-Jan-19 7:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleMenu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RoleMenu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[MenuID] [smallint] NOT NULL,
 CONSTRAINT [PK_RoleMenu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SecurityQuestion]    Script Date: 28-Jan-19 7:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SecurityQuestion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Question] [varchar](300) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_SecurityQuestion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Status]    Script Date: 28-Jan-19 7:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Status]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](50) NULL,
 CONSTRAINT [PK_GatePassStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 28-Jan-19 7:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserCredential]    Script Date: 28-Jan-19 7:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserCredential]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserSecurityAnswer]    Script Date: 28-Jan-19 7:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserSecurityAnswer]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 28-Jan-19 7:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vendor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Vendor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [varchar](200) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Asset] ON 

INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (86, N'Tag001', N'Desktop', 7, NULL, 1, 1, CAST(N'2019-01-18 17:57:53.610' AS DateTime), 1, CAST(N'2019-01-18 17:57:53.610' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (87, N'Tag002', N'Desktop', 4, N'Xyz', 1, 1, CAST(N'2019-01-18 18:00:24.610' AS DateTime), 1, CAST(N'2019-01-18 18:00:24.610' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (88, N'Tag003', N'Desktop', 4, N'abc', 1, 1, CAST(N'2019-01-18 18:03:20.673' AS DateTime), 1, CAST(N'2019-01-18 18:03:20.673' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (89, N'Tag004', N'as', 4, NULL, 1, 1, CAST(N'2019-01-18 18:04:55.893' AS DateTime), 1, CAST(N'2019-01-18 18:04:55.893' AS DateTime))
INSERT [dbo].[Asset] ([ID], [AssetTagID], [AssetName], [AssetCategoryID], [AssetDescription], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (90, N'Tag0013', N'Desktop', 4, N'zxc', 1, 1, CAST(N'2019-01-19 01:18:00.973' AS DateTime), 1, CAST(N'2019-01-19 01:18:00.973' AS DateTime))
SET IDENTITY_INSERT [dbo].[Asset] OFF
SET IDENTITY_INSERT [dbo].[AssetCategory] ON 

INSERT [dbo].[AssetCategory] ([ID], [CategoryName], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Computer', 1, 1, CAST(N'2018-12-25 20:49:41.870' AS DateTime), 1, CAST(N'2018-12-25 20:49:41.870' AS DateTime))
INSERT [dbo].[AssetCategory] ([ID], [CategoryName], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'Phone', 1, 1, CAST(N'2018-12-26 10:03:37.037' AS DateTime), 1, CAST(N'2018-12-26 10:03:37.037' AS DateTime))
SET IDENTITY_INSERT [dbo].[AssetCategory] OFF
SET IDENTITY_INSERT [dbo].[AssetDetail] ON 

INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (59, 86, NULL, NULL, NULL, NULL, N'e736fc4b-2d1a-41cc-a8c0-0815bea6f38d', N'd87e9dbf-1451-4dce-a5c2-8f72c17a777f', N'Dell', N'345345', N'233')
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (60, 87, NULL, 1, NULL, NULL, N'4113aadd-76b1-46fa-848d-96f8e5778252', N'f7ee12f5-1128-4b9e-bfe4-0b1f44917fe6', N'Dell', N'sddsd', N'233')
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (61, 88, CAST(N'2019-01-20' AS Date), 1, CAST(45.00 AS Decimal(18, 2)), CAST(N'2019-01-30' AS Date), N'93069fa6-4c22-4aa6-9740-cb1ef6e6cc95', N'c242a107-79c1-4838-a364-a8b7da7278ea', N'Dell', N'345345', N'233')
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (62, 89, CAST(N'2018-12-17' AS Date), 1, CAST(23.00 AS Decimal(18, 2)), CAST(N'2019-01-06' AS Date), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AssetDetail] ([ID], [AssetID], [PurchaseDate], [VendorID], [Cost], [WarrantyExpireDate], [WarrantyDocumentId], [AssetImageId], [BrandName], [ModelNumber], [SerialNumber]) VALUES (63, 90, CAST(N'2018-12-10' AS Date), 1, CAST(45.00 AS Decimal(18, 2)), CAST(N'2019-01-19' AS Date), N'f83bd8dc-deb3-47c6-be2a-d7083735a05b', NULL, N'Dell', N'sd111111', N'3434343434')
SET IDENTITY_INSERT [dbo].[AssetDetail] OFF
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([ID], [CompanyName], [Address1], [Phone], [Email], [Country], [WebSiteURL], [CompanyLogoId], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'GLOBAL EXPORTS', N'Noida', N'9998989898', N'export@export.com', N'India', N'www.GlobalExport.com', NULL, 1, 1, CAST(N'2019-01-26 00:00:00.000' AS DateTime), 1, CAST(N'2019-01-26 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([ID], [DepartmentName], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Finance', 1, NULL, CAST(N'2018-12-25 20:46:14.327' AS DateTime), NULL, CAST(N'2018-12-25 20:46:14.327' AS DateTime))
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Function] ON 

INSERT [dbo].[Function] ([ID], [FunctionCode], [FunctionName], [FunctionDescription]) VALUES (1, N'ADDASSET', N'AddAsset', NULL)
SET IDENTITY_INSERT [dbo].[Function] OFF
SET IDENTITY_INSERT [dbo].[GatePassType] ON 

INSERT [dbo].[GatePassType] ([ID], [TypeName]) VALUES (1, N'Returnable')
INSERT [dbo].[GatePassType] ([ID], [TypeName]) VALUES (2, N'Non-Returnable')
SET IDENTITY_INSERT [dbo].[GatePassType] OFF
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
SET IDENTITY_INSERT [dbo].[QuantityUnit] ON 

INSERT [dbo].[QuantityUnit] ([ID], [Unit]) VALUES (1, N'No.')
INSERT [dbo].[QuantityUnit] ([ID], [Unit]) VALUES (2, N'Kg')
INSERT [dbo].[QuantityUnit] ([ID], [Unit]) VALUES (3, N'gm')
INSERT [dbo].[QuantityUnit] ([ID], [Unit]) VALUES (4, N'Mtr.')
SET IDENTITY_INSERT [dbo].[QuantityUnit] OFF
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
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([ID], [StatusName]) VALUES (1, N'Pending')
INSERT [dbo].[Status] ([ID], [StatusName]) VALUES (2, N'Approved')
INSERT [dbo].[Status] ([ID], [StatusName]) VALUES (3, N'Reject')
INSERT [dbo].[Status] ([ID], [StatusName]) VALUES (4, N'Auto Approved')
SET IDENTITY_INSERT [dbo].[Status] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Title], [FirstName], [LastName], [EmpId], [Phone], [Email], [DeptId], [RoleId], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Mr', N'Vishal', N'Tyagi', N'123456', N'99999999', N'vishal@abc.com', 1, 1, 1, NULL, CAST(N'2018-12-25 20:47:11.140' AS DateTime), NULL, CAST(N'2018-12-25 20:47:11.140' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserCredential] ON 

INSERT [dbo].[UserCredential] ([ID], [UserID], [Password], [PasswordKey], [Attempted]) VALUES (2, 1, N'a', N'a', 1)
SET IDENTITY_INSERT [dbo].[UserCredential] OFF
SET IDENTITY_INSERT [dbo].[Vendor] ON 

INSERT [dbo].[Vendor] ([ID], [VendorName], [IsActive]) VALUES (1, N'Dell Computer', 1)
SET IDENTITY_INSERT [dbo].[Vendor] OFF
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Asset_AssetCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Asset]'))
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_AssetCategory] FOREIGN KEY([AssetCategoryID])
REFERENCES [dbo].[AssetCategory] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Asset_AssetCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Asset]'))
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_AssetCategory]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Asset_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Asset]'))
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Asset_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Asset]'))
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Asset_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Asset]'))
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Asset_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Asset]'))
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_User1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetCategory_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetCategory]'))
ALTER TABLE [dbo].[AssetCategory]  WITH CHECK ADD  CONSTRAINT [FK_AssetCategory_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetCategory_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetCategory]'))
ALTER TABLE [dbo].[AssetCategory] CHECK CONSTRAINT [FK_AssetCategory_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetCategory_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetCategory]'))
ALTER TABLE [dbo].[AssetCategory]  WITH CHECK ADD  CONSTRAINT [FK_AssetCategory_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetCategory_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetCategory]'))
ALTER TABLE [dbo].[AssetCategory] CHECK CONSTRAINT [FK_AssetCategory_User1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetDetail_Asset]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetDetail]'))
ALTER TABLE [dbo].[AssetDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetDetail_Asset] FOREIGN KEY([AssetID])
REFERENCES [dbo].[Asset] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetDetail_Asset]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetDetail]'))
ALTER TABLE [dbo].[AssetDetail] CHECK CONSTRAINT [FK_AssetDetail_Asset]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetDetail_Vendor]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetDetail]'))
ALTER TABLE [dbo].[AssetDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetDetail_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetDetail_Vendor]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetDetail]'))
ALTER TABLE [dbo].[AssetDetail] CHECK CONSTRAINT [FK_AssetDetail_Vendor]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_Status]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePass_Status] FOREIGN KEY([GatePassStatusId])
REFERENCES [dbo].[Status] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_Status]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass] CHECK CONSTRAINT [FK_AssetGatePass_Status]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_Type]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePass_Type] FOREIGN KEY([GatePassTypeId])
REFERENCES [dbo].[GatePassType] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_Type]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass] CHECK CONSTRAINT [FK_AssetGatePass_Type]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePass_User] FOREIGN KEY([ReceivedBy])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass] CHECK CONSTRAINT [FK_AssetGatePass_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePass_User1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass] CHECK CONSTRAINT [FK_AssetGatePass_User1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_User2]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePass_User2] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePass_User2]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePass]'))
ALTER TABLE [dbo].[AssetGatePass] CHECK CONSTRAINT [FK_AssetGatePass_User2]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_Asset]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePassDetail_Asset] FOREIGN KEY([AssetID])
REFERENCES [dbo].[Asset] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_Asset]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail] CHECK CONSTRAINT [FK_AssetGatePassDetail_Asset]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_AssetGatePass]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePassDetail_AssetGatePass] FOREIGN KEY([AssetGatePassID])
REFERENCES [dbo].[AssetGatePass] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_AssetGatePass]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail] CHECK CONSTRAINT [FK_AssetGatePassDetail_AssetGatePass]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_GatePassStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePassDetail_GatePassStatus] FOREIGN KEY([AssetTypeID])
REFERENCES [dbo].[GatePassType] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_GatePassStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail] CHECK CONSTRAINT [FK_AssetGatePassDetail_GatePassStatus]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_QuantityUnit]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit] FOREIGN KEY([SendQtyUnitID])
REFERENCES [dbo].[QuantityUnit] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_QuantityUnit]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail] CHECK CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_QuantityUnit1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit1] FOREIGN KEY([ReceivedQtyUnitID])
REFERENCES [dbo].[QuantityUnit] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassDetail_QuantityUnit1]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassDetail]'))
ALTER TABLE [dbo].[AssetGatePassDetail] CHECK CONSTRAINT [FK_AssetGatePassDetail_QuantityUnit1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassSenderDetail_AssetGatePass]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassSenderDetail]'))
ALTER TABLE [dbo].[AssetGatePassSenderDetail]  WITH CHECK ADD  CONSTRAINT [FK_AssetGatePassSenderDetail_AssetGatePass] FOREIGN KEY([AssetGatePassID])
REFERENCES [dbo].[AssetGatePass] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AssetGatePassSenderDetail_AssetGatePass]') AND parent_object_id = OBJECT_ID(N'[dbo].[AssetGatePassSenderDetail]'))
ALTER TABLE [dbo].[AssetGatePassSenderDetail] CHECK CONSTRAINT [FK_AssetGatePassSenderDetail_AssetGatePass]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Company_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Company]'))
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Company_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Company]'))
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Company_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Company]'))
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Company_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Company]'))
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_User1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Department_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Department]'))
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Department_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Department]'))
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Department_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Department]'))
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Department_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Department]'))
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_User1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleFunction_Function]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleFunction]'))
ALTER TABLE [dbo].[RoleFunction]  WITH CHECK ADD  CONSTRAINT [FK_RoleFunction_Function] FOREIGN KEY([FunctionID])
REFERENCES [dbo].[Function] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleFunction_Function]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleFunction]'))
ALTER TABLE [dbo].[RoleFunction] CHECK CONSTRAINT [FK_RoleFunction_Function]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleFunction_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleFunction]'))
ALTER TABLE [dbo].[RoleFunction]  WITH CHECK ADD  CONSTRAINT [FK_RoleFunction_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleFunction_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleFunction]'))
ALTER TABLE [dbo].[RoleFunction] CHECK CONSTRAINT [FK_RoleFunction_Role]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleMenu_Menu]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleMenu]'))
ALTER TABLE [dbo].[RoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenu_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleMenu_Menu]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleMenu]'))
ALTER TABLE [dbo].[RoleMenu] CHECK CONSTRAINT [FK_RoleMenu_Menu]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleMenu_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleMenu]'))
ALTER TABLE [dbo].[RoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenu_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RoleMenu_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleMenu]'))
ALTER TABLE [dbo].[RoleMenu] CHECK CONSTRAINT [FK_RoleMenu_Roles]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserCredential_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserCredential]'))
ALTER TABLE [dbo].[UserCredential]  WITH CHECK ADD  CONSTRAINT [FK_UserCredential_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserCredential_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserCredential]'))
ALTER TABLE [dbo].[UserCredential] CHECK CONSTRAINT [FK_UserCredential_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserSecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserSecurityAnswer]'))
ALTER TABLE [dbo].[UserSecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UserSecurityAnswer_SecurityQuestion] FOREIGN KEY([SecurityQuestionID])
REFERENCES [dbo].[SecurityQuestion] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserSecurityAnswer_SecurityQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserSecurityAnswer]'))
ALTER TABLE [dbo].[UserSecurityAnswer] CHECK CONSTRAINT [FK_UserSecurityAnswer_SecurityQuestion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserSecurityAnswer_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserSecurityAnswer]'))
ALTER TABLE [dbo].[UserSecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UserSecurityAnswer_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserSecurityAnswer_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserSecurityAnswer]'))
ALTER TABLE [dbo].[UserSecurityAnswer] CHECK CONSTRAINT [FK_UserSecurityAnswer_User]
GO
