USE [master]
GO
/****** Object:  Database [160048]    Script Date: 18.2.2021. 23.24.15 ******/
CREATE DATABASE [160048]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'160048', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\160048.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'160048_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\160048_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [160048] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [160048].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [160048] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [160048] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [160048] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [160048] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [160048] SET ARITHABORT OFF 
GO
ALTER DATABASE [160048] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [160048] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [160048] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [160048] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [160048] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [160048] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [160048] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [160048] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [160048] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [160048] SET  DISABLE_BROKER 
GO
ALTER DATABASE [160048] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [160048] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [160048] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [160048] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [160048] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [160048] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [160048] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [160048] SET RECOVERY FULL 
GO
ALTER DATABASE [160048] SET  MULTI_USER 
GO
ALTER DATABASE [160048] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [160048] SET DB_CHAINING OFF 
GO
ALTER DATABASE [160048] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [160048] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [160048] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'160048', N'ON'
GO
ALTER DATABASE [160048] SET QUERY_STORE = OFF
GO
USE [160048]
GO
/****** Object:  Table [dbo].[AttributeOptions]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeOptions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttributeId] [int] NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_AttributeOptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attributes]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PharmacyBranchId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillItems]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_BillItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddUserId] [int] NOT NULL,
	[PharmacyBranchId] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[CancelDateTime] [datetime2](7) NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PharmacyBranchId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CountryId] [int] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventories]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PharmacyBranchId] [int] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryEntries]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryEntries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InventoryId] [int] NOT NULL,
	[EntryDateTime] [datetime2](7) NOT NULL,
	[UserId] [int] NOT NULL,
	[EntryNumber] [nvarchar](max) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_InventoryEntries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryEntryProducts]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryEntryProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InventoryEntryId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_InventoryEntryProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryIntermediateProducts]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryIntermediateProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InventoryIntermediateId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_InventoryIntermediateProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryIntermediates]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryIntermediates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromInventoryId] [int] NOT NULL,
	[ToInventoryId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_InventoryIntermediates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryProducts]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InventoryId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_InventoryProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasurementUnits]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasurementUnits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ShortName] [nvarchar](max) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_MeasurementUnits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[CountryId] [int] NULL,
	[CityId] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pharmacies]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pharmacies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PharmacyUniqueIdentifier] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[OwnerUserId] [int] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Pharmacies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PharmacyBranchUsers]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PharmacyBranchUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PharmacyBranchId] [int] NOT NULL,
	[StartDateTime] [datetime2](7) NOT NULL,
	[EndDateTime] [datetime2](7) NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_PharmacyBranchUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PharmacyBranches]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PharmacyBranches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PharmacyId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[BranchIdentifier] [nvarchar](max) NOT NULL,
	[Central] [bit] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_PharmacyBranches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttributes]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[AttributeId] [int] NOT NULL,
	[AttributeOptionId] [int] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_ProductAttributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSubstances]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSubstances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubstanceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_ProductSubstances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PharmacyBranchId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[MeasurementUnitId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProhibitedSubstances]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProhibitedSubstances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubstanceId] [int] NOT NULL,
	[ProhibitedSubstanceId] [int] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_ProhibitedSubstances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[RoleLevel] [int] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Substances]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Substances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PharmacyBranchId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Substances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PharmacyId] [int] NOT NULL,
	[PharmacyBranchId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](100) NOT NULL,
	[PasswordSalt] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DeletedDateTime] [datetime2](7) NULL,
	[AccessToken] [nvarchar](max) NULL,
	[TokenExpirationDateTime] [datetime2](7) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpirationDateTime] [datetime2](7) NULL,
	[CreatedTokenDateTime] [datetime2](7) NULL,
	[UpdateDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WriteOffInventoryDocuments]    Script Date: 18.2.2021. 23.24.15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WriteOffInventoryDocuments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InventoryProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[WriteOffDateTime] [datetime2](7) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Reason] [nvarchar](max) NULL,
	[DeletedDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_WriteOffInventoryDocuments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18.2.2021. 23.24.15 ******/
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
SET IDENTITY_INSERT [dbo].[AttributeOptions] ON 

INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (1, 7, N'Plava', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (2, 7, N'Zuta', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (3, 6, N'Prah', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (4, 6, N'Mast', CAST(N'2020-08-20T13:29:17.8981860' AS DateTime2))
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (5, 6, N'Tecnost', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (6, 6, N'Kapsule', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (7, 3, N'Pilula', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (8, 3, N'Ampula', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (9, 7, N'Tecnost', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (10, 7, N'Mast', CAST(N'2020-08-20T13:29:17.8981860' AS DateTime2))
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (11, 7, N'Prah', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (12, 7, N'Zuta', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (13, 7, N'Plava', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (14, 7, N'Kapsule', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (15, 8, N'Tip 1', CAST(N'2021-02-08T20:24:25.6491591' AS DateTime2))
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (16, 1, N'Bijela', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (17, 1, N'Zuta', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (18, 2, N'Tecno', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (19, 2, N'Cvrsto', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (20, 2, N'Polucvrsto', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (21, 8, N'Jednokratno', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (22, 8, N'Dnevno', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (23, 8, N'Mjesecno', NULL)
INSERT [dbo].[AttributeOptions] ([Id], [AttributeId], [Value], [DeletedDateTime]) VALUES (24, 8, N'Oralno', NULL)
SET IDENTITY_INSERT [dbo].[AttributeOptions] OFF
SET IDENTITY_INSERT [dbo].[Attributes] ON 

INSERT [dbo].[Attributes] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (1, 2, N'Boja', NULL)
INSERT [dbo].[Attributes] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (2, 2, N'Prirodno stanje', NULL)
INSERT [dbo].[Attributes] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (3, 4, N'Oblik lijeka', NULL)
INSERT [dbo].[Attributes] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (6, 10, N'Prirodno stanje', NULL)
INSERT [dbo].[Attributes] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (7, 10, N'Boja', NULL)
INSERT [dbo].[Attributes] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (8, 2, N'Tip konzumacije', NULL)
SET IDENTITY_INSERT [dbo].[Attributes] OFF
SET IDENTITY_INSERT [dbo].[BillItems] ON 

INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (1, 1, 1, 3, CAST(7.50 AS Decimal(18, 2)), CAST(22.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (2, 2, 2, 1, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (3, 3, 3, 2, CAST(2.50 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (4, 3, 2, 2, CAST(5.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (5, 3, 1, 1, CAST(7.50 AS Decimal(18, 2)), CAST(7.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (6, 4, 1, 1, CAST(7.50 AS Decimal(18, 2)), CAST(7.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (7, 4, 2, 3, CAST(5.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (8, 5, 1, 1, CAST(7.50 AS Decimal(18, 2)), CAST(7.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (9, 5, 3, 10, CAST(2.50 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (10, 6, 4, 5, CAST(9.00 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (11, 7, 19, 3, CAST(7.50 AS Decimal(18, 2)), CAST(22.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (12, 8, 1, 1, CAST(7.50 AS Decimal(18, 2)), CAST(7.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (13, 9, 22, 4, CAST(9.50 AS Decimal(18, 2)), CAST(38.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[BillItems] ([Id], [BillId], [ProductId], [Quantity], [UnitPrice], [Total], [DeletedDateTime]) VALUES (14, 9, 23, 1, CAST(75.00 AS Decimal(18, 2)), CAST(75.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[BillItems] OFF
SET IDENTITY_INSERT [dbo].[Bills] ON 

INSERT [dbo].[Bills] ([Id], [AddUserId], [PharmacyBranchId], [Number], [CreatedDateTime], [CancelDateTime], [Total], [DeletedDateTime]) VALUES (1, 3, 2, 0, CAST(N'2021-01-13T17:44:15.7982263' AS DateTime2), NULL, CAST(22.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Bills] ([Id], [AddUserId], [PharmacyBranchId], [Number], [CreatedDateTime], [CancelDateTime], [Total], [DeletedDateTime]) VALUES (2, 3, 2, 1, CAST(N'2021-01-13T18:03:01.2930893' AS DateTime2), NULL, CAST(5.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Bills] ([Id], [AddUserId], [PharmacyBranchId], [Number], [CreatedDateTime], [CancelDateTime], [Total], [DeletedDateTime]) VALUES (3, 3, 2, 2, CAST(N'2021-01-17T13:59:55.0544043' AS DateTime2), NULL, CAST(22.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Bills] ([Id], [AddUserId], [PharmacyBranchId], [Number], [CreatedDateTime], [CancelDateTime], [Total], [DeletedDateTime]) VALUES (4, 3, 2, 3, CAST(N'2021-01-17T14:00:04.6919786' AS DateTime2), NULL, CAST(22.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Bills] ([Id], [AddUserId], [PharmacyBranchId], [Number], [CreatedDateTime], [CancelDateTime], [Total], [DeletedDateTime]) VALUES (5, 3, 2, 4, CAST(N'2021-01-17T15:01:54.7287176' AS DateTime2), NULL, CAST(32.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Bills] ([Id], [AddUserId], [PharmacyBranchId], [Number], [CreatedDateTime], [CancelDateTime], [Total], [DeletedDateTime]) VALUES (6, 9, 4, 0, CAST(N'2021-01-17T20:05:10.5236789' AS DateTime2), NULL, CAST(45.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Bills] ([Id], [AddUserId], [PharmacyBranchId], [Number], [CreatedDateTime], [CancelDateTime], [Total], [DeletedDateTime]) VALUES (7, 15, 10, 5, CAST(N'2021-01-17T21:21:11.0256841' AS DateTime2), NULL, CAST(22.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Bills] ([Id], [AddUserId], [PharmacyBranchId], [Number], [CreatedDateTime], [CancelDateTime], [Total], [DeletedDateTime]) VALUES (8, 3, 2, 6, CAST(N'2021-02-17T19:44:07.9265662' AS DateTime2), NULL, CAST(7.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Bills] ([Id], [AddUserId], [PharmacyBranchId], [Number], [CreatedDateTime], [CancelDateTime], [Total], [DeletedDateTime]) VALUES (9, 3, 2, 7, CAST(N'2021-02-17T22:09:41.1672734' AS DateTime2), NULL, CAST(113.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[Bills] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (1, 2, N'Kreme', NULL)
INSERT [dbo].[Categories] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (2, 2, N'Maze', NULL)
INSERT [dbo].[Categories] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (3, 4, N'Vitamini', NULL)
INSERT [dbo].[Categories] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (4, 2, N'Pomagala', NULL)
INSERT [dbo].[Categories] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (5, 2, N'Antibiotici', NULL)
INSERT [dbo].[Categories] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (6, 2, N'Ostalo', NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([Id], [Name], [CountryId], [DeletedDateTime]) VALUES (1, N'Sarajevo', 1, NULL)
SET IDENTITY_INSERT [dbo].[Cities] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name], [DeletedDateTime]) VALUES (1, N'Bosna i Hercegovina', NULL)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Inventories] ON 

INSERT [dbo].[Inventories] ([Id], [PharmacyBranchId], [DeletedDateTime]) VALUES (1, 2, NULL)
INSERT [dbo].[Inventories] ([Id], [PharmacyBranchId], [DeletedDateTime]) VALUES (2, 4, NULL)
INSERT [dbo].[Inventories] ([Id], [PharmacyBranchId], [DeletedDateTime]) VALUES (8, 10, NULL)
SET IDENTITY_INSERT [dbo].[Inventories] OFF
SET IDENTITY_INSERT [dbo].[InventoryEntries] ON 

INSERT [dbo].[InventoryEntries] ([Id], [InventoryId], [EntryDateTime], [UserId], [EntryNumber], [DeletedDateTime]) VALUES (4, 1, CAST(N'2020-09-13T15:15:48.7826340' AS DateTime2), 3, N'1234', NULL)
INSERT [dbo].[InventoryEntries] ([Id], [InventoryId], [EntryDateTime], [UserId], [EntryNumber], [DeletedDateTime]) VALUES (5, 1, CAST(N'2020-09-13T15:18:51.4618790' AS DateTime2), 3, N'153548', NULL)
INSERT [dbo].[InventoryEntries] ([Id], [InventoryId], [EntryDateTime], [UserId], [EntryNumber], [DeletedDateTime]) VALUES (6, 2, CAST(N'2021-01-17T20:02:36.4692272' AS DateTime2), 9, N'258', NULL)
INSERT [dbo].[InventoryEntries] ([Id], [InventoryId], [EntryDateTime], [UserId], [EntryNumber], [DeletedDateTime]) VALUES (7, 1, CAST(N'2021-01-18T21:59:52.7998596' AS DateTime2), 5, N'5599', NULL)
INSERT [dbo].[InventoryEntries] ([Id], [InventoryId], [EntryDateTime], [UserId], [EntryNumber], [DeletedDateTime]) VALUES (1007, 1, CAST(N'2021-02-17T20:44:02.7166994' AS DateTime2), 5, N'56484', NULL)
INSERT [dbo].[InventoryEntries] ([Id], [InventoryId], [EntryDateTime], [UserId], [EntryNumber], [DeletedDateTime]) VALUES (1008, 1, CAST(N'2021-02-17T21:46:32.2285938' AS DateTime2), 5, N'555666', NULL)
INSERT [dbo].[InventoryEntries] ([Id], [InventoryId], [EntryDateTime], [UserId], [EntryNumber], [DeletedDateTime]) VALUES (1009, 1, CAST(N'2021-02-17T22:00:05.2938007' AS DateTime2), 5, N'584899 - 8', NULL)
SET IDENTITY_INSERT [dbo].[InventoryEntries] OFF
SET IDENTITY_INSERT [dbo].[InventoryEntryProducts] ON 

INSERT [dbo].[InventoryEntryProducts] ([Id], [InventoryEntryId], [Quantity], [ProductId], [DeletedDateTime]) VALUES (3, 4, 25, 3, NULL)
INSERT [dbo].[InventoryEntryProducts] ([Id], [InventoryEntryId], [Quantity], [ProductId], [DeletedDateTime]) VALUES (4, 5, 15, 1, NULL)
INSERT [dbo].[InventoryEntryProducts] ([Id], [InventoryEntryId], [Quantity], [ProductId], [DeletedDateTime]) VALUES (5, 4, 10, 2, NULL)
INSERT [dbo].[InventoryEntryProducts] ([Id], [InventoryEntryId], [Quantity], [ProductId], [DeletedDateTime]) VALUES (6, 6, 200, 4, NULL)
INSERT [dbo].[InventoryEntryProducts] ([Id], [InventoryEntryId], [Quantity], [ProductId], [DeletedDateTime]) VALUES (7, 7, 22, 22, NULL)
INSERT [dbo].[InventoryEntryProducts] ([Id], [InventoryEntryId], [Quantity], [ProductId], [DeletedDateTime]) VALUES (8, 7, 20, 2, NULL)
INSERT [dbo].[InventoryEntryProducts] ([Id], [InventoryEntryId], [Quantity], [ProductId], [DeletedDateTime]) VALUES (9, 7, 10, 1, NULL)
INSERT [dbo].[InventoryEntryProducts] ([Id], [InventoryEntryId], [Quantity], [ProductId], [DeletedDateTime]) VALUES (1007, 1007, 25, 22, NULL)
INSERT [dbo].[InventoryEntryProducts] ([Id], [InventoryEntryId], [Quantity], [ProductId], [DeletedDateTime]) VALUES (1008, 1008, 15, 2, NULL)
INSERT [dbo].[InventoryEntryProducts] ([Id], [InventoryEntryId], [Quantity], [ProductId], [DeletedDateTime]) VALUES (1009, 1008, 5, 23, NULL)
INSERT [dbo].[InventoryEntryProducts] ([Id], [InventoryEntryId], [Quantity], [ProductId], [DeletedDateTime]) VALUES (1010, 1009, 10, 3, NULL)
SET IDENTITY_INSERT [dbo].[InventoryEntryProducts] OFF
SET IDENTITY_INSERT [dbo].[InventoryProducts] ON 

INSERT [dbo].[InventoryProducts] ([Id], [InventoryId], [ProductId], [Quantity], [DeletedDateTime]) VALUES (1, 1, 2, CAST(39.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[InventoryProducts] ([Id], [InventoryId], [ProductId], [Quantity], [DeletedDateTime]) VALUES (2, 1, 3, CAST(17.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[InventoryProducts] ([Id], [InventoryId], [ProductId], [Quantity], [DeletedDateTime]) VALUES (3, 1, 1, CAST(18.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[InventoryProducts] ([Id], [InventoryId], [ProductId], [Quantity], [DeletedDateTime]) VALUES (4, 2, 4, CAST(195.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[InventoryProducts] ([Id], [InventoryId], [ProductId], [Quantity], [DeletedDateTime]) VALUES (8, 8, 19, CAST(6.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[InventoryProducts] ([Id], [InventoryId], [ProductId], [Quantity], [DeletedDateTime]) VALUES (9, 8, 19, CAST(4.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[InventoryProducts] ([Id], [InventoryId], [ProductId], [Quantity], [DeletedDateTime]) VALUES (10, 8, 19, CAST(1.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[InventoryProducts] ([Id], [InventoryId], [ProductId], [Quantity], [DeletedDateTime]) VALUES (11, 1, 22, CAST(36.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[InventoryProducts] ([Id], [InventoryId], [ProductId], [Quantity], [DeletedDateTime]) VALUES (12, 1, 23, CAST(4.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[InventoryProducts] ([Id], [InventoryId], [ProductId], [Quantity], [DeletedDateTime]) VALUES (13, 1, 24, CAST(0.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[InventoryProducts] OFF
SET IDENTITY_INSERT [dbo].[MeasurementUnits] ON 

INSERT [dbo].[MeasurementUnits] ([Id], [Name], [ShortName], [DeletedDateTime]) VALUES (1, N'Mililiters', N'ml', NULL)
INSERT [dbo].[MeasurementUnits] ([Id], [Name], [ShortName], [DeletedDateTime]) VALUES (2, N'Komad', N'kom', NULL)
INSERT [dbo].[MeasurementUnits] ([Id], [Name], [ShortName], [DeletedDateTime]) VALUES (3, N'Metar', N'm', NULL)
INSERT [dbo].[MeasurementUnits] ([Id], [Name], [ShortName], [DeletedDateTime]) VALUES (4, N'Miligram', N'mg', NULL)
INSERT [dbo].[MeasurementUnits] ([Id], [Name], [ShortName], [DeletedDateTime]) VALUES (5, N'Kilogram', N'kg', NULL)
INSERT [dbo].[MeasurementUnits] ([Id], [Name], [ShortName], [DeletedDateTime]) VALUES (6, N'Litar', N'l', NULL)
SET IDENTITY_INSERT [dbo].[MeasurementUnits] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [DateOfBirth], [CountryId], [CityId], [Address], [Note], [DeletedDateTime]) VALUES (1, N'Test', N'Test', CAST(N'2020-08-12T17:41:28.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [DateOfBirth], [CountryId], [CityId], [Address], [Note], [DeletedDateTime]) VALUES (3, N'Su', N'Admin', CAST(N'2020-08-12T09:41:00.0000000' AS DateTime2), 1, 1, N'josanica', N'', NULL)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [DateOfBirth], [CountryId], [CityId], [Address], [Note], [DeletedDateTime]) VALUES (4, N'Prodavac', N'Apotekar', CAST(N'2020-09-14T12:31:00.0000000' AS DateTime2), NULL, 1, N'test', N'test', NULL)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [DateOfBirth], [CountryId], [CityId], [Address], [Note], [DeletedDateTime]) VALUES (5, N'Mobile', N'Skladistar', CAST(N'2020-09-14T08:33:00.0000000' AS DateTime2), 1, 1, N'teeeest', N'dddd', NULL)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [DateOfBirth], [CountryId], [CityId], [Address], [Note], [DeletedDateTime]) VALUES (6, N'Admin', N'Poslovnice', CAST(N'2020-09-14T14:33:24.8074620' AS DateTime2), 1, 1, N'teeeest', N'dddd', NULL)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [DateOfBirth], [CountryId], [CityId], [Address], [Note], [DeletedDateTime]) VALUES (9, N'Admin', N'Apoteka 2', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [DateOfBirth], [CountryId], [CityId], [Address], [Note], [DeletedDateTime]) VALUES (15, N'Farmacija', N'Treća', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Pharmacies] ON 

INSERT [dbo].[Pharmacies] ([Id], [PharmacyUniqueIdentifier], [Name], [OwnerUserId], [DeletedDateTime]) VALUES (2, N'0', N'Apoteka demo', 3, NULL)
SET IDENTITY_INSERT [dbo].[Pharmacies] OFF
SET IDENTITY_INSERT [dbo].[PharmacyBranchUsers] ON 

INSERT [dbo].[PharmacyBranchUsers] ([Id], [UserId], [PharmacyBranchId], [StartDateTime], [EndDateTime], [DeletedDateTime]) VALUES (1, 3, 2, CAST(N'2020-08-14T16:30:20.7797590' AS DateTime2), NULL, NULL)
INSERT [dbo].[PharmacyBranchUsers] ([Id], [UserId], [PharmacyBranchId], [StartDateTime], [EndDateTime], [DeletedDateTime]) VALUES (2, 4, 2, CAST(N'2020-09-14T14:33:17.1644280' AS DateTime2), NULL, NULL)
INSERT [dbo].[PharmacyBranchUsers] ([Id], [UserId], [PharmacyBranchId], [StartDateTime], [EndDateTime], [DeletedDateTime]) VALUES (3, 5, 2, CAST(N'2020-09-14T14:34:32.2465950' AS DateTime2), NULL, NULL)
INSERT [dbo].[PharmacyBranchUsers] ([Id], [UserId], [PharmacyBranchId], [StartDateTime], [EndDateTime], [DeletedDateTime]) VALUES (4, 6, 2, CAST(N'2020-09-14T14:35:41.9999600' AS DateTime2), NULL, NULL)
INSERT [dbo].[PharmacyBranchUsers] ([Id], [UserId], [PharmacyBranchId], [StartDateTime], [EndDateTime], [DeletedDateTime]) VALUES (5, 9, 4, CAST(N'2020-09-14T21:08:08.6771130' AS DateTime2), NULL, NULL)
INSERT [dbo].[PharmacyBranchUsers] ([Id], [UserId], [PharmacyBranchId], [StartDateTime], [EndDateTime], [DeletedDateTime]) VALUES (11, 15, 10, CAST(N'2021-01-17T21:19:17.1340411' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[PharmacyBranchUsers] OFF
SET IDENTITY_INSERT [dbo].[PharmacyBranches] ON 

INSERT [dbo].[PharmacyBranches] ([Id], [PharmacyId], [CountryId], [CityId], [Address], [BranchIdentifier], [Central], [DeletedDateTime]) VALUES (2, 2, 1, 1, N'adresa demo', N'000-1', 1, NULL)
INSERT [dbo].[PharmacyBranches] ([Id], [PharmacyId], [CountryId], [CityId], [Address], [BranchIdentifier], [Central], [DeletedDateTime]) VALUES (4, 2, 1, 1, N'test', N'000 - 2', 0, NULL)
INSERT [dbo].[PharmacyBranches] ([Id], [PharmacyId], [CountryId], [CityId], [Address], [BranchIdentifier], [Central], [DeletedDateTime]) VALUES (10, 2, 1, 1, N'adresa', N'000-3', 0, NULL)
SET IDENTITY_INSERT [dbo].[PharmacyBranches] OFF
SET IDENTITY_INSERT [dbo].[ProductAttributes] ON 

INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeOptionId], [DeletedDateTime]) VALUES (1, 1, 1, 1, NULL)
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeOptionId], [DeletedDateTime]) VALUES (2, 2, 1, 1, CAST(N'2020-08-20T12:31:10.1098810' AS DateTime2))
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeOptionId], [DeletedDateTime]) VALUES (3, 2, 1, 2, NULL)
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeOptionId], [DeletedDateTime]) VALUES (4, 3, 1, 2, NULL)
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeOptionId], [DeletedDateTime]) VALUES (5, 4, 3, 7, NULL)
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeOptionId], [DeletedDateTime]) VALUES (6, 19, 7, 13, NULL)
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeOptionId], [DeletedDateTime]) VALUES (7, 19, 7, 13, NULL)
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeOptionId], [DeletedDateTime]) VALUES (8, 19, 7, 13, CAST(N'2020-08-20T12:31:10.1098810' AS DateTime2))
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeOptionId], [DeletedDateTime]) VALUES (9, 19, 7, 13, NULL)
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeOptionId], [DeletedDateTime]) VALUES (10, 23, 1, 16, NULL)
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeOptionId], [DeletedDateTime]) VALUES (11, 23, 2, 19, NULL)
SET IDENTITY_INSERT [dbo].[ProductAttributes] OFF
SET IDENTITY_INSERT [dbo].[ProductCategories] ON 

INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (1, 1, 1, NULL)
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (2, 2, 2, CAST(N'2020-08-20T12:14:00.7180860' AS DateTime2))
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (3, 1, 2, CAST(N'2020-08-20T12:22:18.7573440' AS DateTime2))
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (4, 1, 3, NULL)
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (5, 2, 3, NULL)
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (6, 3, 4, NULL)
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (12, 1, 19, NULL)
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (13, 1, 19, CAST(N'2020-08-20T12:22:18.7573440' AS DateTime2))
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (14, 2, 19, CAST(N'2020-08-20T12:14:00.7180860' AS DateTime2))
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (15, 1, 19, NULL)
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (16, 2, 19, NULL)
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (17, 4, 23, NULL)
INSERT [dbo].[ProductCategories] ([Id], [CategoryId], [ProductId], [DeletedDateTime]) VALUES (18, 4, 23, NULL)
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF
SET IDENTITY_INSERT [dbo].[ProductSubstances] ON 

INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (1, 1, 19, NULL)
INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (2, 1, 18, CAST(N'2020-08-20T12:14:04.2857170' AS DateTime2))
INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (3, 1, 18, NULL)
INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (4, 1, 17, NULL)
INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (5, 1, 17, NULL)
INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (6, 5, 4, NULL)
INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (7, 1, 23, NULL)
INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (8, 2, 23, NULL)
INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (9, 3, 23, NULL)
INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (10, 4, 23, NULL)
INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (11, 2, 24, NULL)
INSERT [dbo].[ProductSubstances] ([Id], [SubstanceId], [ProductId], [DeletedDateTime]) VALUES (12, 3, 24, NULL)
SET IDENTITY_INSERT [dbo].[ProductSubstances] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [PharmacyBranchId], [Name], [Code], [Description], [MeasurementUnitId], [Price], [DeletedDateTime]) VALUES (1, 2, N'Tablete', N'1', N'tabletice', 1, CAST(7.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Products] ([Id], [PharmacyBranchId], [Name], [Code], [Description], [MeasurementUnitId], [Price], [DeletedDateTime]) VALUES (2, 2, N'Lakaluk', N'"Code" 0012', N'desc', 1, CAST(5.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Products] ([Id], [PharmacyBranchId], [Name], [Code], [Description], [MeasurementUnitId], [Price], [DeletedDateTime]) VALUES (3, 2, N'Paracetamol', N'PC', N'desc', 1, CAST(2.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Products] ([Id], [PharmacyBranchId], [Name], [Code], [Description], [MeasurementUnitId], [Price], [DeletedDateTime]) VALUES (4, 4, N'Vitamin D', N'VIT D', N'vitamincic', 1, CAST(9.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Products] ([Id], [PharmacyBranchId], [Name], [Code], [Description], [MeasurementUnitId], [Price], [DeletedDateTime]) VALUES (17, 10, N'Paracetamol', N'PC', N'desc', 1, CAST(2.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Products] ([Id], [PharmacyBranchId], [Name], [Code], [Description], [MeasurementUnitId], [Price], [DeletedDateTime]) VALUES (18, 10, N'Lakaluk', N'"Code" 0012', N'desc', 1, CAST(5.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Products] ([Id], [PharmacyBranchId], [Name], [Code], [Description], [MeasurementUnitId], [Price], [DeletedDateTime]) VALUES (19, 10, N'Tablete', N'1', N'tabletice', 1, CAST(7.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Products] ([Id], [PharmacyBranchId], [Name], [Code], [Description], [MeasurementUnitId], [Price], [DeletedDateTime]) VALUES (22, 2, N'Zink', N'zink', N'', 1, CAST(9.50 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Products] ([Id], [PharmacyBranchId], [Name], [Code], [Description], [MeasurementUnitId], [Price], [DeletedDateTime]) VALUES (23, 2, N'Tlakomjer', N'TLK 2548', N'', 2, CAST(75.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Products] ([Id], [PharmacyBranchId], [Name], [Code], [Description], [MeasurementUnitId], [Price], [DeletedDateTime]) VALUES (24, 2, N'Ibuprofen', N'IBUP', N'', 2, CAST(1.50 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[ProhibitedSubstances] ON 

INSERT [dbo].[ProhibitedSubstances] ([Id], [SubstanceId], [ProhibitedSubstanceId], [DeletedDateTime]) VALUES (1, 22, 23, CAST(N'2020-09-14T14:12:17.4653870' AS DateTime2))
INSERT [dbo].[ProhibitedSubstances] ([Id], [SubstanceId], [ProhibitedSubstanceId], [DeletedDateTime]) VALUES (2, 22, 23, NULL)
INSERT [dbo].[ProhibitedSubstances] ([Id], [SubstanceId], [ProhibitedSubstanceId], [DeletedDateTime]) VALUES (3, 23, 22, NULL)
INSERT [dbo].[ProhibitedSubstances] ([Id], [SubstanceId], [ProhibitedSubstanceId], [DeletedDateTime]) VALUES (4, 1, 1, NULL)
INSERT [dbo].[ProhibitedSubstances] ([Id], [SubstanceId], [ProhibitedSubstanceId], [DeletedDateTime]) VALUES (5, 3, 2, NULL)
SET IDENTITY_INSERT [dbo].[ProhibitedSubstances] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Code], [Name], [RoleLevel], [DeletedDateTime]) VALUES (1, 1, N'Super administrator', 1, NULL)
INSERT [dbo].[Roles] ([Id], [Code], [Name], [RoleLevel], [DeletedDateTime]) VALUES (2, 2, N'Administrator', 1, NULL)
INSERT [dbo].[Roles] ([Id], [Code], [Name], [RoleLevel], [DeletedDateTime]) VALUES (3, 3, N'Seller', 1, NULL)
INSERT [dbo].[Roles] ([Id], [Code], [Name], [RoleLevel], [DeletedDateTime]) VALUES (4, 4, N'Stockman', 1, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Substances] ON 

INSERT [dbo].[Substances] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (1, 2, N'Substanca test', NULL)
INSERT [dbo].[Substances] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (2, 2, N'Sulfat', NULL)
INSERT [dbo].[Substances] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (3, 2, N'Nitrat', NULL)
INSERT [dbo].[Substances] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (4, 2, N'Aminokiselina C193', NULL)
INSERT [dbo].[Substances] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (5, 4, N'Substanca vitaminska', NULL)
INSERT [dbo].[Substances] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (22, 10, N'Aminokiselina C193', NULL)
INSERT [dbo].[Substances] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (23, 10, N'Nitrat', NULL)
INSERT [dbo].[Substances] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (24, 10, N'Substanca test', NULL)
INSERT [dbo].[Substances] ([Id], [PharmacyBranchId], [Name], [DeletedDateTime]) VALUES (25, 10, N'Sulfat', NULL)
SET IDENTITY_INSERT [dbo].[Substances] OFF
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([Id], [UserId], [PharmacyId], [PharmacyBranchId], [RoleId], [DeletedDateTime]) VALUES (3, 3, 2, 2, 1, NULL)
INSERT [dbo].[UserRoles] ([Id], [UserId], [PharmacyId], [PharmacyBranchId], [RoleId], [DeletedDateTime]) VALUES (4, 4, 2, 2, 3, NULL)
INSERT [dbo].[UserRoles] ([Id], [UserId], [PharmacyId], [PharmacyBranchId], [RoleId], [DeletedDateTime]) VALUES (5, 5, 2, 2, 4, NULL)
INSERT [dbo].[UserRoles] ([Id], [UserId], [PharmacyId], [PharmacyBranchId], [RoleId], [DeletedDateTime]) VALUES (6, 6, 2, 2, 2, NULL)
INSERT [dbo].[UserRoles] ([Id], [UserId], [PharmacyId], [PharmacyBranchId], [RoleId], [DeletedDateTime]) VALUES (7, 9, 2, 4, 2, NULL)
INSERT [dbo].[UserRoles] ([Id], [UserId], [PharmacyId], [PharmacyBranchId], [RoleId], [DeletedDateTime]) VALUES (13, 15, 2, 10, 2, NULL)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
INSERT [dbo].[Users] ([Id], [Username], [Email], [Phone], [PasswordHash], [PasswordSalt], [CreatedDate], [DeletedDateTime], [AccessToken], [TokenExpirationDateTime], [RefreshToken], [RefreshTokenExpirationDateTime], [CreatedTokenDateTime], [UpdateDateTime]) VALUES (1, N'test', N'test@"Email".ba', N'0', N'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', N'KnCwD8a7QulejWLY0gnqZQ==', CAST(N'2020-08-12T17:41:06.0000000' AS DateTime2), NULL, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJQZXJzb24iOiIxIiwibmJmIjoxNTk3MjQ4NjUyLCJleHAiOjE1OTcyNDk4NTIsImlhdCI6MTU5NzI0ODY1MiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzNzAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0NDM3MCJ9.dbkEXlwqPL3d9Os95epRIJl6WfJ0YujQdelAiBilESA', CAST(N'2020-08-12T18:30:52.6567170' AS DateTime2), N'wXxz+rgdV8yO3AG9I7o1DMtX8w5B3TqqFb8LBsgNzpE=', CAST(N'2020-08-13T18:10:52.6572690' AS DateTime2), CAST(N'2020-08-12T18:10:52.6573690' AS DateTime2), NULL)
INSERT [dbo].[Users] ([Id], [Username], [Email], [Phone], [PasswordHash], [PasswordSalt], [CreatedDate], [DeletedDateTime], [AccessToken], [TokenExpirationDateTime], [RefreshToken], [RefreshTokenExpirationDateTime], [CreatedTokenDateTime], [UpdateDateTime]) VALUES (3, N'admin', N'su.desktop@"Email"', N'60222333', N'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', N'KnCwD8a7QulejWLY0gnqZQ==', CAST(N'2020-08-14T16:30:20.6509270' AS DateTime2), NULL, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIzIiwiUGhhcm1hY3lJZCI6IjIiLCJQaGFybWFjeUJyYW5jaElkIjoiMiIsIkludmVudG9yeUlkIjoiMSIsIkxpc3QiOiJbe1wiSWRcIjozLFwiVXNlcklkXCI6MyxcIlBoYXJtYWN5SWRcIjoyLFwiUGhhcm1hY3lCcmFuY2hJZFwiOjIsXCJSb2xlSWRcIjoxLFwiRGVsZXRlZERhdGVUaW1lXCI6bnVsbCxcIlVzZXJcIjpudWxsLFwiUGhhcm1hY3lcIjpudWxsLFwiUGhhcm1hY3lCcmFuY2hcIjpudWxsLFwiUm9sZVwiOntcIklkXCI6MSxcIkNvZGVcIjoxLFwiTmFtZVwiOlwiU3VwZXIgYWRtaW5pc3RyYXRvclwiLFwiUm9sZUxldmVsXCI6MSxcIkRlbGV0ZWREYXRlVGltZVwiOm51bGx9fV0iLCJuYmYiOjE2MTM1OTczODAsImV4cCI6MTYxMzU5ODU4MCwiaWF0IjoxNjEzNTk3MzgwLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDM3MCIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzcwIn0.dn-DJuzUGj4hPobtAUtfRbXM2ezTvaclNlAD8azfW3U', CAST(N'2021-02-17T22:49:40.2541111' AS DateTime2), N'lus7EEFclByV9Q04cVHM+iV0TrGLL4apXny9b0/f4Mc=', CAST(N'2021-02-18T22:29:40.2546413' AS DateTime2), CAST(N'2021-02-17T22:29:40.2547252' AS DateTime2), CAST(N'2020-09-14T14:37:32.2140730' AS DateTime2))
INSERT [dbo].[Users] ([Id], [Username], [Email], [Phone], [PasswordHash], [PasswordSalt], [CreatedDate], [DeletedDateTime], [AccessToken], [TokenExpirationDateTime], [RefreshToken], [RefreshTokenExpirationDateTime], [CreatedTokenDateTime], [UpdateDateTime]) VALUES (4, N'desktopSeller', N'desktopSeller@hotmail.com', N'66268485', N'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', N'KnCwD8a7QulejWLY0gnqZQ==', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-09-14T14:36:45.4617320' AS DateTime2))
INSERT [dbo].[Users] ([Id], [Username], [Email], [Phone], [PasswordHash], [PasswordSalt], [CreatedDate], [DeletedDateTime], [AccessToken], [TokenExpirationDateTime], [RefreshToken], [RefreshTokenExpirationDateTime], [CreatedTokenDateTime], [UpdateDateTime]) VALUES (5, N'mobileStockman', N'mobileStockman@gmail.com', N'62548556', N'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', N'KnCwD8a7QulejWLY0gnqZQ==', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiI1IiwiUGhhcm1hY3lJZCI6IjIiLCJQaGFybWFjeUJyYW5jaElkIjoiMiIsIkludmVudG9yeUlkIjoiMSIsIkxpc3QiOiJbe1wiSWRcIjo1LFwiVXNlcklkXCI6NSxcIlBoYXJtYWN5SWRcIjoyLFwiUGhhcm1hY3lCcmFuY2hJZFwiOjIsXCJSb2xlSWRcIjo0LFwiRGVsZXRlZERhdGVUaW1lXCI6bnVsbCxcIlVzZXJcIjpudWxsLFwiUGhhcm1hY3lcIjpudWxsLFwiUGhhcm1hY3lCcmFuY2hcIjpudWxsLFwiUm9sZVwiOntcIklkXCI6NCxcIkNvZGVcIjo0LFwiTmFtZVwiOlwiU3RvY2ttYW5cIixcIlJvbGVMZXZlbFwiOjEsXCJEZWxldGVkRGF0ZVRpbWVcIjpudWxsfX1dIiwibmJmIjoxNjEzNTk1NjQyLCJleHAiOjE2MTM1OTY4NDIsImlhdCI6MTYxMzU5NTY0MiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzNzAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0NDM3MCJ9.B7IHZbYSllvColfbHkpV8pF9rPKGa0iwpsDp4pF_NJA', CAST(N'2021-02-17T22:20:42.4461984' AS DateTime2), N'OCB/chwXMCPmXd449tvWGzXVGgv1ApIqRcqLizalFyY=', CAST(N'2021-02-18T22:00:42.4462035' AS DateTime2), CAST(N'2021-02-17T22:00:42.4462044' AS DateTime2), CAST(N'2021-01-16T17:03:32.6440083' AS DateTime2))
INSERT [dbo].[Users] ([Id], [Username], [Email], [Phone], [PasswordHash], [PasswordSalt], [CreatedDate], [DeletedDateTime], [AccessToken], [TokenExpirationDateTime], [RefreshToken], [RefreshTokenExpirationDateTime], [CreatedTokenDateTime], [UpdateDateTime]) VALUES (6, N'desktop', N'destktop@gmail.com', N'61112335', N'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', N'KnCwD8a7QulejWLY0gnqZQ==', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Username], [Email], [Phone], [PasswordHash], [PasswordSalt], [CreatedDate], [DeletedDateTime], [AccessToken], [TokenExpirationDateTime], [RefreshToken], [RefreshTokenExpirationDateTime], [CreatedTokenDateTime], [UpdateDateTime]) VALUES (9, N'admin2', N'admin2@ggmail.com', NULL, N'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', N'KnCwD8a7QulejWLY0gnqZQ==', CAST(N'2020-09-14T21:07:57.7497530' AS DateTime2), NULL, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiI5IiwiUGhhcm1hY3lJZCI6IjIiLCJQaGFybWFjeUJyYW5jaElkIjoiNCIsIkludmVudG9yeUlkIjoiMiIsIkxpc3QiOiJbe1wiSWRcIjo3LFwiVXNlcklkXCI6OSxcIlBoYXJtYWN5SWRcIjoyLFwiUGhhcm1hY3lCcmFuY2hJZFwiOjQsXCJSb2xlSWRcIjoyLFwiRGVsZXRlZERhdGVUaW1lXCI6bnVsbCxcIlVzZXJcIjpudWxsLFwiUGhhcm1hY3lcIjpudWxsLFwiUGhhcm1hY3lCcmFuY2hcIjpudWxsLFwiUm9sZVwiOntcIklkXCI6MixcIkNvZGVcIjoyLFwiTmFtZVwiOlwiQWRtaW5pc3RyYXRvclwiLFwiUm9sZUxldmVsXCI6MSxcIkRlbGV0ZWREYXRlVGltZVwiOm51bGx9fV0iLCJuYmYiOjE2MTA5MTAyODUsImV4cCI6MTYxMDkxMTQ4NSwiaWF0IjoxNjEwOTEwMjg1LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDM3MCIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzcwIn0.qLRktmhK1bekUbtiEXv8pdU3gKLZpqWr5HvrgWzmbJo', CAST(N'2021-01-17T20:24:45.8277852' AS DateTime2), N'y167rv3os+W2cZDeU6n2A3J/amyvmNwfFGHio1Dd244=', CAST(N'2021-01-18T20:04:45.8278178' AS DateTime2), CAST(N'2021-01-17T20:04:45.8278187' AS DateTime2), NULL)
INSERT [dbo].[Users] ([Id], [Username], [Email], [Phone], [PasswordHash], [PasswordSalt], [CreatedDate], [DeletedDateTime], [AccessToken], [TokenExpirationDateTime], [RefreshToken], [RefreshTokenExpirationDateTime], [CreatedTokenDateTime], [UpdateDateTime]) VALUES (15, N'admin3', N'test@email.ba', NULL, N'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', N'KnCwD8a7QulejWLY0gnqZQ==', CAST(N'2021-01-17T21:19:16.9299485' AS DateTime2), NULL, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIxNSIsIlBoYXJtYWN5SWQiOiIyIiwiUGhhcm1hY3lCcmFuY2hJZCI6IjEwIiwiSW52ZW50b3J5SWQiOiI4IiwiTGlzdCI6Ilt7XCJJZFwiOjEzLFwiVXNlcklkXCI6MTUsXCJQaGFybWFjeUlkXCI6MixcIlBoYXJtYWN5QnJhbmNoSWRcIjoxMCxcIlJvbGVJZFwiOjIsXCJEZWxldGVkRGF0ZVRpbWVcIjpudWxsLFwiVXNlclwiOm51bGwsXCJQaGFybWFjeVwiOm51bGwsXCJQaGFybWFjeUJyYW5jaFwiOm51bGwsXCJSb2xlXCI6e1wiSWRcIjoyLFwiQ29kZVwiOjIsXCJOYW1lXCI6XCJBZG1pbmlzdHJhdG9yXCIsXCJSb2xlTGV2ZWxcIjoxLFwiRGVsZXRlZERhdGVUaW1lXCI6bnVsbH19XSIsIm5iZiI6MTYxMDkxNDc3NSwiZXhwIjoxNjEwOTE1OTc1LCJpYXQiOjE2MTA5MTQ3NzUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzcwIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzNzAifQ.CK0NkTMCAHR7Ur0SVykkokHZHx9gwmZ6JW_osziwBmY', CAST(N'2021-01-17T21:39:36.0894416' AS DateTime2), N'BAIaY7PX72JDCV4XVxzSp2r/7MtnzWy4rE/loy3V3aI=', CAST(N'2021-01-18T21:19:36.0898435' AS DateTime2), CAST(N'2021-01-17T21:19:36.0900525' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[WriteOffInventoryDocuments] ON 

INSERT [dbo].[WriteOffInventoryDocuments] ([Id], [InventoryProductId], [UserId], [WriteOffDateTime], [Quantity], [Reason], [DeletedDateTime]) VALUES (1, 2, 3, CAST(N'2020-09-13T20:53:31.5381760' AS DateTime2), 2, N'Isteko rok', NULL)
INSERT [dbo].[WriteOffInventoryDocuments] ([Id], [InventoryProductId], [UserId], [WriteOffDateTime], [Quantity], [Reason], [DeletedDateTime]) VALUES (2, 2, 3, CAST(N'2020-09-13T20:56:22.6136510' AS DateTime2), 4, N'Rok opet', NULL)
INSERT [dbo].[WriteOffInventoryDocuments] ([Id], [InventoryProductId], [UserId], [WriteOffDateTime], [Quantity], [Reason], [DeletedDateTime]) VALUES (3, 11, 5, CAST(N'2021-02-17T21:00:05.4318785' AS DateTime2), 1, N'otpis', NULL)
INSERT [dbo].[WriteOffInventoryDocuments] ([Id], [InventoryProductId], [UserId], [WriteOffDateTime], [Quantity], [Reason], [DeletedDateTime]) VALUES (4, 11, 5, CAST(N'2021-02-17T21:01:05.8157623' AS DateTime2), 1, N'otpis', NULL)
INSERT [dbo].[WriteOffInventoryDocuments] ([Id], [InventoryProductId], [UserId], [WriteOffDateTime], [Quantity], [Reason], [DeletedDateTime]) VALUES (5, 11, 5, CAST(N'2021-02-17T21:02:23.1024066' AS DateTime2), 1, N'otpis', NULL)
INSERT [dbo].[WriteOffInventoryDocuments] ([Id], [InventoryProductId], [UserId], [WriteOffDateTime], [Quantity], [Reason], [DeletedDateTime]) VALUES (6, 11, 5, CAST(N'2021-02-17T21:10:14.8416864' AS DateTime2), 1, N'otpis', NULL)
INSERT [dbo].[WriteOffInventoryDocuments] ([Id], [InventoryProductId], [UserId], [WriteOffDateTime], [Quantity], [Reason], [DeletedDateTime]) VALUES (7, 11, 5, CAST(N'2021-02-17T21:48:48.7579067' AS DateTime2), 1, N'Isteko rok', NULL)
INSERT [dbo].[WriteOffInventoryDocuments] ([Id], [InventoryProductId], [UserId], [WriteOffDateTime], [Quantity], [Reason], [DeletedDateTime]) VALUES (8, 11, 5, CAST(N'2021-02-17T21:59:08.5714933' AS DateTime2), 1, N'Pokvario se', NULL)
INSERT [dbo].[WriteOffInventoryDocuments] ([Id], [InventoryProductId], [UserId], [WriteOffDateTime], [Quantity], [Reason], [DeletedDateTime]) VALUES (9, 11, 5, CAST(N'2021-02-17T21:59:38.4214796' AS DateTime2), 1, N'Otpis', NULL)
SET IDENTITY_INSERT [dbo].[WriteOffInventoryDocuments] OFF
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200920205528_initial', N'3.1.8')
/****** Object:  Index [IX_AttributeOptions_AttributeId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_AttributeOptions_AttributeId] ON [dbo].[AttributeOptions]
(
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Attributes_PharmacyBranchId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Attributes_PharmacyBranchId] ON [dbo].[Attributes]
(
	[PharmacyBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BillItems_BillId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_BillItems_BillId] ON [dbo].[BillItems]
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BillItems_ProductId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_BillItems_ProductId] ON [dbo].[BillItems]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bills_AddUserId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Bills_AddUserId] ON [dbo].[Bills]
(
	[AddUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bills_PharmacyBranchId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Bills_PharmacyBranchId] ON [dbo].[Bills]
(
	[PharmacyBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categories_PharmacyBranchId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Categories_PharmacyBranchId] ON [dbo].[Categories]
(
	[PharmacyBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cities_CountryId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Cities_CountryId] ON [dbo].[Cities]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Inventories_PharmacyBranchId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Inventories_PharmacyBranchId] ON [dbo].[Inventories]
(
	[PharmacyBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryEntries_InventoryId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryEntries_InventoryId] ON [dbo].[InventoryEntries]
(
	[InventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryEntries_UserId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryEntries_UserId] ON [dbo].[InventoryEntries]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryEntryProducts_InventoryEntryId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryEntryProducts_InventoryEntryId] ON [dbo].[InventoryEntryProducts]
(
	[InventoryEntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryEntryProducts_ProductId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryEntryProducts_ProductId] ON [dbo].[InventoryEntryProducts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryIntermediateProducts_InventoryIntermediateId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryIntermediateProducts_InventoryIntermediateId] ON [dbo].[InventoryIntermediateProducts]
(
	[InventoryIntermediateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryIntermediateProducts_ProductId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryIntermediateProducts_ProductId] ON [dbo].[InventoryIntermediateProducts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryIntermediates_FromInventoryId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryIntermediates_FromInventoryId] ON [dbo].[InventoryIntermediates]
(
	[FromInventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryIntermediates_ToInventoryId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryIntermediates_ToInventoryId] ON [dbo].[InventoryIntermediates]
(
	[ToInventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryIntermediates_UserId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryIntermediates_UserId] ON [dbo].[InventoryIntermediates]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryProducts_InventoryId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryProducts_InventoryId] ON [dbo].[InventoryProducts]
(
	[InventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryProducts_ProductId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryProducts_ProductId] ON [dbo].[InventoryProducts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Persons_CityId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Persons_CityId] ON [dbo].[Persons]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Persons_CountryId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Persons_CountryId] ON [dbo].[Persons]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pharmacies_OwnerUserId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Pharmacies_OwnerUserId] ON [dbo].[Pharmacies]
(
	[OwnerUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PharmacyBranchUsers_PharmacyBranchId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_PharmacyBranchUsers_PharmacyBranchId] ON [dbo].[PharmacyBranchUsers]
(
	[PharmacyBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PharmacyBranchUsers_UserId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_PharmacyBranchUsers_UserId] ON [dbo].[PharmacyBranchUsers]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PharmacyBranches_CityId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_PharmacyBranches_CityId] ON [dbo].[PharmacyBranches]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PharmacyBranches_CountryId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_PharmacyBranches_CountryId] ON [dbo].[PharmacyBranches]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PharmacyBranches_PharmacyId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_PharmacyBranches_PharmacyId] ON [dbo].[PharmacyBranches]
(
	[PharmacyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductAttributes_AttributeId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_ProductAttributes_AttributeId] ON [dbo].[ProductAttributes]
(
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductAttributes_AttributeOptionId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_ProductAttributes_AttributeOptionId] ON [dbo].[ProductAttributes]
(
	[AttributeOptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductAttributes_ProductId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_ProductAttributes_ProductId] ON [dbo].[ProductAttributes]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductCategories_CategoryId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_ProductCategories_CategoryId] ON [dbo].[ProductCategories]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductCategories_ProductId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_ProductCategories_ProductId] ON [dbo].[ProductCategories]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSubstances_ProductId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_ProductSubstances_ProductId] ON [dbo].[ProductSubstances]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSubstances_SubstanceId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_ProductSubstances_SubstanceId] ON [dbo].[ProductSubstances]
(
	[SubstanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_MeasurementUnitId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Products_MeasurementUnitId] ON [dbo].[Products]
(
	[MeasurementUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_PharmacyBranchId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Products_PharmacyBranchId] ON [dbo].[Products]
(
	[PharmacyBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProhibitedSubstances_ProhibitedSubstanceId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_ProhibitedSubstances_ProhibitedSubstanceId] ON [dbo].[ProhibitedSubstances]
(
	[ProhibitedSubstanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProhibitedSubstances_SubstanceId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_ProhibitedSubstances_SubstanceId] ON [dbo].[ProhibitedSubstances]
(
	[SubstanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Substances_PharmacyBranchId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_Substances_PharmacyBranchId] ON [dbo].[Substances]
(
	[PharmacyBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_PharmacyBranchId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_PharmacyBranchId] ON [dbo].[UserRoles]
(
	[PharmacyBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_PharmacyId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_PharmacyId] ON [dbo].[UserRoles]
(
	[PharmacyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_UserId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_UserId] ON [dbo].[UserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WriteOffInventoryDocuments_InventoryProductId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_WriteOffInventoryDocuments_InventoryProductId] ON [dbo].[WriteOffInventoryDocuments]
(
	[InventoryProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WriteOffInventoryDocuments_UserId]    Script Date: 18.2.2021. 23.24.16 ******/
CREATE NONCLUSTERED INDEX [IX_WriteOffInventoryDocuments_UserId] ON [dbo].[WriteOffInventoryDocuments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AttributeOptions]  WITH CHECK ADD  CONSTRAINT [FK_AttributeOptions_Attributes_AttributeId] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[Attributes] ([Id])
GO
ALTER TABLE [dbo].[AttributeOptions] CHECK CONSTRAINT [FK_AttributeOptions_Attributes_AttributeId]
GO
ALTER TABLE [dbo].[Attributes]  WITH CHECK ADD  CONSTRAINT [FK_Attributes_PharmacyBranches_PharmacyBranchId] FOREIGN KEY([PharmacyBranchId])
REFERENCES [dbo].[PharmacyBranches] ([Id])
GO
ALTER TABLE [dbo].[Attributes] CHECK CONSTRAINT [FK_Attributes_PharmacyBranches_PharmacyBranchId]
GO
ALTER TABLE [dbo].[BillItems]  WITH CHECK ADD  CONSTRAINT [FK_BillItems_Bills_BillId] FOREIGN KEY([BillId])
REFERENCES [dbo].[Bills] ([Id])
GO
ALTER TABLE [dbo].[BillItems] CHECK CONSTRAINT [FK_BillItems_Bills_BillId]
GO
ALTER TABLE [dbo].[BillItems]  WITH CHECK ADD  CONSTRAINT [FK_BillItems_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[BillItems] CHECK CONSTRAINT [FK_BillItems_Products_ProductId]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_PharmacyBranches_PharmacyBranchId] FOREIGN KEY([PharmacyBranchId])
REFERENCES [dbo].[PharmacyBranches] ([Id])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_PharmacyBranches_PharmacyBranchId]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_Users_AddUserId] FOREIGN KEY([AddUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_Users_AddUserId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_PharmacyBranches_PharmacyBranchId] FOREIGN KEY([PharmacyBranchId])
REFERENCES [dbo].[PharmacyBranches] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_PharmacyBranches_PharmacyBranchId]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Countries_CountryId]
GO
ALTER TABLE [dbo].[Inventories]  WITH CHECK ADD  CONSTRAINT [FK_Inventories_PharmacyBranches_PharmacyBranchId] FOREIGN KEY([PharmacyBranchId])
REFERENCES [dbo].[PharmacyBranches] ([Id])
GO
ALTER TABLE [dbo].[Inventories] CHECK CONSTRAINT [FK_Inventories_PharmacyBranches_PharmacyBranchId]
GO
ALTER TABLE [dbo].[InventoryEntries]  WITH CHECK ADD  CONSTRAINT [FK_InventoryEntries_Inventories_InventoryId] FOREIGN KEY([InventoryId])
REFERENCES [dbo].[Inventories] ([Id])
GO
ALTER TABLE [dbo].[InventoryEntries] CHECK CONSTRAINT [FK_InventoryEntries_Inventories_InventoryId]
GO
ALTER TABLE [dbo].[InventoryEntries]  WITH CHECK ADD  CONSTRAINT [FK_InventoryEntries_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[InventoryEntries] CHECK CONSTRAINT [FK_InventoryEntries_Users_UserId]
GO
ALTER TABLE [dbo].[InventoryEntryProducts]  WITH CHECK ADD  CONSTRAINT [FK_InventoryEntryProducts_InventoryEntries_InventoryEntryId] FOREIGN KEY([InventoryEntryId])
REFERENCES [dbo].[InventoryEntries] ([Id])
GO
ALTER TABLE [dbo].[InventoryEntryProducts] CHECK CONSTRAINT [FK_InventoryEntryProducts_InventoryEntries_InventoryEntryId]
GO
ALTER TABLE [dbo].[InventoryEntryProducts]  WITH CHECK ADD  CONSTRAINT [FK_InventoryEntryProducts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[InventoryEntryProducts] CHECK CONSTRAINT [FK_InventoryEntryProducts_Products_ProductId]
GO
ALTER TABLE [dbo].[InventoryIntermediateProducts]  WITH CHECK ADD  CONSTRAINT [FK_InventoryIntermediateProducts_InventoryIntermediates_InventoryIntermediateId] FOREIGN KEY([InventoryIntermediateId])
REFERENCES [dbo].[InventoryIntermediates] ([Id])
GO
ALTER TABLE [dbo].[InventoryIntermediateProducts] CHECK CONSTRAINT [FK_InventoryIntermediateProducts_InventoryIntermediates_InventoryIntermediateId]
GO
ALTER TABLE [dbo].[InventoryIntermediateProducts]  WITH CHECK ADD  CONSTRAINT [FK_InventoryIntermediateProducts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[InventoryIntermediateProducts] CHECK CONSTRAINT [FK_InventoryIntermediateProducts_Products_ProductId]
GO
ALTER TABLE [dbo].[InventoryIntermediates]  WITH CHECK ADD  CONSTRAINT [FK_InventoryIntermediates_Inventories_FromInventoryId] FOREIGN KEY([FromInventoryId])
REFERENCES [dbo].[Inventories] ([Id])
GO
ALTER TABLE [dbo].[InventoryIntermediates] CHECK CONSTRAINT [FK_InventoryIntermediates_Inventories_FromInventoryId]
GO
ALTER TABLE [dbo].[InventoryIntermediates]  WITH CHECK ADD  CONSTRAINT [FK_InventoryIntermediates_Inventories_ToInventoryId] FOREIGN KEY([ToInventoryId])
REFERENCES [dbo].[Inventories] ([Id])
GO
ALTER TABLE [dbo].[InventoryIntermediates] CHECK CONSTRAINT [FK_InventoryIntermediates_Inventories_ToInventoryId]
GO
ALTER TABLE [dbo].[InventoryIntermediates]  WITH CHECK ADD  CONSTRAINT [FK_InventoryIntermediates_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[InventoryIntermediates] CHECK CONSTRAINT [FK_InventoryIntermediates_Users_UserId]
GO
ALTER TABLE [dbo].[InventoryProducts]  WITH CHECK ADD  CONSTRAINT [FK_InventoryProducts_Inventories_InventoryId] FOREIGN KEY([InventoryId])
REFERENCES [dbo].[Inventories] ([Id])
GO
ALTER TABLE [dbo].[InventoryProducts] CHECK CONSTRAINT [FK_InventoryProducts_Inventories_InventoryId]
GO
ALTER TABLE [dbo].[InventoryProducts]  WITH CHECK ADD  CONSTRAINT [FK_InventoryProducts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[InventoryProducts] CHECK CONSTRAINT [FK_InventoryProducts_Products_ProductId]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Cities_CityId]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Countries_CountryId]
GO
ALTER TABLE [dbo].[Pharmacies]  WITH CHECK ADD  CONSTRAINT [FK_Pharmacies_Users_OwnerUserId] FOREIGN KEY([OwnerUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Pharmacies] CHECK CONSTRAINT [FK_Pharmacies_Users_OwnerUserId]
GO
ALTER TABLE [dbo].[PharmacyBranchUsers]  WITH CHECK ADD  CONSTRAINT [FK_PharmacyBranchUsers_PharmacyBranches_PharmacyBranchId] FOREIGN KEY([PharmacyBranchId])
REFERENCES [dbo].[PharmacyBranches] ([Id])
GO
ALTER TABLE [dbo].[PharmacyBranchUsers] CHECK CONSTRAINT [FK_PharmacyBranchUsers_PharmacyBranches_PharmacyBranchId]
GO
ALTER TABLE [dbo].[PharmacyBranchUsers]  WITH CHECK ADD  CONSTRAINT [FK_PharmacyBranchUsers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PharmacyBranchUsers] CHECK CONSTRAINT [FK_PharmacyBranchUsers_Users_UserId]
GO
ALTER TABLE [dbo].[PharmacyBranches]  WITH CHECK ADD  CONSTRAINT [FK_PharmacyBranches_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[PharmacyBranches] CHECK CONSTRAINT [FK_PharmacyBranches_Cities_CityId]
GO
ALTER TABLE [dbo].[PharmacyBranches]  WITH CHECK ADD  CONSTRAINT [FK_PharmacyBranches_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[PharmacyBranches] CHECK CONSTRAINT [FK_PharmacyBranches_Countries_CountryId]
GO
ALTER TABLE [dbo].[PharmacyBranches]  WITH CHECK ADD  CONSTRAINT [FK_PharmacyBranches_Pharmacies_PharmacyId] FOREIGN KEY([PharmacyId])
REFERENCES [dbo].[Pharmacies] ([Id])
GO
ALTER TABLE [dbo].[PharmacyBranches] CHECK CONSTRAINT [FK_PharmacyBranches_Pharmacies_PharmacyId]
GO
ALTER TABLE [dbo].[ProductAttributes]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributes_AttributeOptions_AttributeOptionId] FOREIGN KEY([AttributeOptionId])
REFERENCES [dbo].[AttributeOptions] ([Id])
GO
ALTER TABLE [dbo].[ProductAttributes] CHECK CONSTRAINT [FK_ProductAttributes_AttributeOptions_AttributeOptionId]
GO
ALTER TABLE [dbo].[ProductAttributes]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributes_Attributes_AttributeId] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[Attributes] ([Id])
GO
ALTER TABLE [dbo].[ProductAttributes] CHECK CONSTRAINT [FK_ProductAttributes_Attributes_AttributeId]
GO
ALTER TABLE [dbo].[ProductAttributes]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributes_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductAttributes] CHECK CONSTRAINT [FK_ProductAttributes_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategories_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[ProductCategories] CHECK CONSTRAINT [FK_ProductCategories_Categories_CategoryId]
GO
ALTER TABLE [dbo].[ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategories_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductCategories] CHECK CONSTRAINT [FK_ProductCategories_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductSubstances]  WITH CHECK ADD  CONSTRAINT [FK_ProductSubstances_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductSubstances] CHECK CONSTRAINT [FK_ProductSubstances_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductSubstances]  WITH CHECK ADD  CONSTRAINT [FK_ProductSubstances_Substances_SubstanceId] FOREIGN KEY([SubstanceId])
REFERENCES [dbo].[Substances] ([Id])
GO
ALTER TABLE [dbo].[ProductSubstances] CHECK CONSTRAINT [FK_ProductSubstances_Substances_SubstanceId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_MeasurementUnits_MeasurementUnitId] FOREIGN KEY([MeasurementUnitId])
REFERENCES [dbo].[MeasurementUnits] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_MeasurementUnits_MeasurementUnitId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_PharmacyBranches_PharmacyBranchId] FOREIGN KEY([PharmacyBranchId])
REFERENCES [dbo].[PharmacyBranches] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_PharmacyBranches_PharmacyBranchId]
GO
ALTER TABLE [dbo].[ProhibitedSubstances]  WITH CHECK ADD  CONSTRAINT [FK_ProhibitedSubstances_Substances_ProhibitedSubstanceId] FOREIGN KEY([ProhibitedSubstanceId])
REFERENCES [dbo].[Substances] ([Id])
GO
ALTER TABLE [dbo].[ProhibitedSubstances] CHECK CONSTRAINT [FK_ProhibitedSubstances_Substances_ProhibitedSubstanceId]
GO
ALTER TABLE [dbo].[ProhibitedSubstances]  WITH CHECK ADD  CONSTRAINT [FK_ProhibitedSubstances_Substances_SubstanceId] FOREIGN KEY([SubstanceId])
REFERENCES [dbo].[Substances] ([Id])
GO
ALTER TABLE [dbo].[ProhibitedSubstances] CHECK CONSTRAINT [FK_ProhibitedSubstances_Substances_SubstanceId]
GO
ALTER TABLE [dbo].[Substances]  WITH CHECK ADD  CONSTRAINT [FK_Substances_PharmacyBranches_PharmacyBranchId] FOREIGN KEY([PharmacyBranchId])
REFERENCES [dbo].[PharmacyBranches] ([Id])
GO
ALTER TABLE [dbo].[Substances] CHECK CONSTRAINT [FK_Substances_PharmacyBranches_PharmacyBranchId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Pharmacies_PharmacyId] FOREIGN KEY([PharmacyId])
REFERENCES [dbo].[Pharmacies] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Pharmacies_PharmacyId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_PharmacyBranches_PharmacyBranchId] FOREIGN KEY([PharmacyBranchId])
REFERENCES [dbo].[PharmacyBranches] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_PharmacyBranches_PharmacyBranchId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Persons_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Persons] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Persons_Id]
GO
ALTER TABLE [dbo].[WriteOffInventoryDocuments]  WITH CHECK ADD  CONSTRAINT [FK_WriteOffInventoryDocuments_InventoryProducts_InventoryProductId] FOREIGN KEY([InventoryProductId])
REFERENCES [dbo].[InventoryProducts] ([Id])
GO
ALTER TABLE [dbo].[WriteOffInventoryDocuments] CHECK CONSTRAINT [FK_WriteOffInventoryDocuments_InventoryProducts_InventoryProductId]
GO
ALTER TABLE [dbo].[WriteOffInventoryDocuments]  WITH CHECK ADD  CONSTRAINT [FK_WriteOffInventoryDocuments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[WriteOffInventoryDocuments] CHECK CONSTRAINT [FK_WriteOffInventoryDocuments_Users_UserId]
GO
/****** Object:  StoredProcedure [dbo].[fn_billitems_getbyrelatedproductid]    Script Date: 18.2.2021. 23.24.16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fn_billitems_getbyrelatedproductid] @pRelatedProductId int AS 
SELECT "BI".*
FROM "BillItems" AS "BI"
WHERE 
"BI"."BillId" IN (
SELECT "IBI"."BillId"
FROM "BillItems" AS "IBI" WHERE "IBI"."ProductId" = @pRelatedProductId
INTERSECT
SELECT "IBI"."BillId"
FROM "BillItems" AS "IBI" WHERE "IBI"."ProductId" != @pRelatedProductId
)
GO
/****** Object:  StoredProcedure [dbo].[fn_inventoryentries_getdtosbyparameters]    Script Date: 18.2.2021. 23.24.16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fn_inventoryentries_getdtosbyparameters] @pPharmacyBranchId int, @pSearchTerm nvarchar(max) AS SELECT "IE"."Id", "IE"."EntryNumber", "IE"."EntryDateTime", cast(concat("P"."FirstName", ' ', "P"."LastName") as nvarchar(max)) AS "FullName" FROM "InventoryEntries" AS "IE" JOIN "Inventories" AS "I" ON "IE"."InventoryId" = "I"."Id" JOIN "Users" AS "U" ON "IE"."UserId" = "U"."Id" JOIN "Persons" AS "P" ON "U"."Id" = "P"."Id" WHERE "IE"."DeletedDateTime" IS NULL AND "I"."PharmacyBranchId" = @pPharmacyBranchId AND (@pSearchTerm IS NULL OR "IE"."EntryNumber" LIKE '%'+lower(@pSearchTerm)+'%');
GO
/****** Object:  StoredProcedure [dbo].[fn_persons_getdtosbyparameters]    Script Date: 18.2.2021. 23.24.16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fn_persons_getdtosbyparameters] @pFullName nvarchar(max), @pEqualFullName nvarchar(max), @pPharmacyId int AS
SELECT "P"."Id", cast(concat("P"."FirstName", ' ', "P"."LastName") as nvarchar(max)) AS "FullName", 
"P"."DateOfBirth", "U"."Email", "U"."Phone", "CT"."Name" AS "Country", "C"."Name" AS "City", "P"."Address" ,"PB".BranchIdentifier
FROM "Persons" AS "P" JOIN "Users" AS "U" ON "P"."Id" = "U"."Id" 
JOIN "PharmacyBranchUsers" AS "PBU" ON "U"."Id" = "PBU"."UserId"
JOIN "PharmacyBranches" AS "PB" ON "PB".Id = "PBU".PharmacyBranchId
LEFT JOIN "Countries" AS "CT" ON "P"."CountryId" = "CT"."Id" 
LEFT JOIN "Cities" AS "C" ON "P"."CityId" = "C"."Id" 
WHERE "P"."DeletedDateTime" IS NULL AND 
(@pFullName IS NULL OR LOWER(CONCAT("P"."FirstName", ' ', "P"."LastName")) LIKE '%'+LOWER(@pFullName)+'%') AND
(@pEqualFullName IS NULL OR LOWER(CONCAT("P"."FirstName", ' ', "P"."LastName")) = LOWER(@pEqualFullName)) AND
"PBU"."EndDateTime" IS NULL AND "PBU"."DeletedDateTime" IS NULL AND "PB"."PharmacyId" = @pPharmacyId;
GO
/****** Object:  StoredProcedure [dbo].[fn_products_getdtosbyparameters]    Script Date: 18.2.2021. 23.24.16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fn_products_getdtosbyparameters] @pPharmacyBranchId int, @pSearchTerm nvarchar(max), @pEqualFullName nvarchar(max),
@pCategoryId int AS 
SELECT "P"."Id", "P"."Name", "P"."Code", "P"."Description", "MU"."Name" AS "MeasurementUnit", "FormatedCategories"."Categories", 
"ProductSubstance"."SubstancesNumber", "ProductAttribute"."AttributeNumber", "Inventory"."Quantity", "P"."Price" 
FROM "Products" AS "P" LEFT JOIN "MeasurementUnits" AS "MU" ON "P"."MeasurementUnitId" = "MU"."Id" 
OUTER APPLY ( SELECT TOP 1 string_agg("C"."Name", ', ') AS "Categories" 
FROM "ProductCategories" AS "PC" JOIN "Categories" "C" on "PC"."CategoryId" = "C"."Id" 
WHERE "PC"."DeletedDateTime" IS NULL AND "PC"."ProductId" = "P"."Id" AND 
("PC"."CategoryId" = @pCategoryId OR @pCategoryId IS NULL) ) AS "FormatedCategories" 
OUTER APPLY ( SELECT TOP 1 CAST(COUNT(*) AS INT) AS "SubstancesNumber" FROM "ProductSubstances" AS "PS" WHERE "PS"."DeletedDateTime" IS NULL 
AND "PS"."ProductId" = "P"."Id" ) AS "ProductSubstance" OUTER APPLY ( SELECT TOP 1 CAST(COUNT(*) as int) AS "AttributeNumber" 
FROM "ProductAttributes" AS "PA" WHERE "PA"."DeletedDateTime" IS NULL AND "PA"."ProductId" = "P"."Id" ) AS "ProductAttribute" 
OUTER APPLY ( SELECT TOP 1 "IP"."Quantity" FROM "InventoryProducts" AS "IP" WHERE "IP"."DeletedDateTime" IS NULL 
AND "IP"."ProductId" = "P"."Id" ) AS "Inventory" OUTER APPLY( SELECT TOP 1 CAST(COUNT(*) as int) AS "Total" FROM "BillItems" AS "BI" 
WHERE "BI"."ProductId" = "P"."Id" AND "BI"."DeletedDateTime" IS NULL ) AS "SoldProducts" WHERE "P"."DeletedDateTime" IS NULL AND
"P"."PharmacyBranchId" = @pPharmacyBranchId AND (@pSearchTerm IS NULL OR LOWER("P"."Name") LIKE '%'+LOWER(@pSearchTerm)+'%')
AND (@pEqualFullName IS NULL OR LOWER("P"."Name") LIKE LOWER(@pEqualFullName))AND
(@pCategoryId IS NULL OR (@pCategoryId IS NOT NULL AND "FormatedCategories"."Categories" IS NOT NULL)) ORDER BY "SoldProducts"."Total" DESC ;
GO
/****** Object:  StoredProcedure [dbo].[fn_productsubstances_anyprohibitedsubstance]    Script Date: 18.2.2021. 23.24.16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fn_productsubstances_anyprohibitedsubstance] @pProductId int, @pProductIds nvarchar(max) AS SELECT CASE WHEN EXISTS ( SELECT "PHS"."Id" FROM "ProductSubstances" AS "PS" JOIN "Substances" AS "S" ON "PS"."SubstanceId" = "S"."Id" JOIN "ProhibitedSubstances" AS "PHS" ON "S"."Id" = "PHS"."ProhibitedSubstanceId" OR "S"."Id" = "PHS"."SubstanceId" OUTER APPLY ( SELECT TOP 1 "PHS2"."Id" FROM "ProhibitedSubstances" AS "PHS2" JOIN "Substances" "S2" on "PHS2"."ProhibitedSubstanceId" = "S2"."Id" OR "PHS2"."SubstanceId" = "S2"."Id" JOIN "ProductSubstances" AS "PS2" ON "PS2"."SubstanceId" = "S2"."Id" WHERE "PS2"."ProductId" IN (SELECT CAST("VALUES".value AS INT) FROM string_split(@pProductIds, ',') AS "VALUES") AND ("PHS"."SubstanceId" = "S2"."Id" OR "PHS"."ProhibitedSubstanceId" = "S2"."Id") ) AS "Prohibited" WHERE "PS"."ProductId" = @pProductId AND "PS"."DeletedDateTime" IS NULL AND "Prohibited"."Id" IS NOT NULL ) THEN CONVERT(bit,'TRUE') ELSE CONVERT(bit,'FALSE') END;
GO
/****** Object:  StoredProcedure [dbo].[fn_users_getloginbyuserid]    Script Date: 18.2.2021. 23.24.16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fn_users_getloginbyuserid] @pUserId int AS SELECT "U"."Id", "PharmacyBranch"."PharmacyId", "PharmacyBranch"."PharmacyBranchId", "PharmacyBranch"."InventoryId", "U"."AccessToken", "U"."Id" AS "UserId", CONVERT(BIT,CASE WHEN "U"."DeletedDateTime" IS NULL THEN 1 ELSE 0 END) AS "Active", CAST(concat("P"."FirstName", ' ', "P"."LastName") as nvarchar(max)) AS "UserFullName" FROM "Users" AS "U" JOIN "Persons" AS "P" ON "P"."Id" = "U"."Id" OUTER APPLY ( SELECT TOP 1 "PBU"."PharmacyBranchId", "PB"."PharmacyId", "I"."Id" AS "InventoryId" FROM "PharmacyBranchUsers" AS "PBU" JOIN "PharmacyBranches" AS "PB" ON "PBU"."PharmacyBranchId" = "PB"."Id" JOIN "Inventories" AS "I" ON "PB"."Id" = "I"."PharmacyBranchId" WHERE "PBU"."UserId" = "U"."Id" AND "PBU"."EndDateTime" IS NULL AND "PBU"."DeletedDateTime" IS NULL AND "PB"."DeletedDateTime" IS NULL AND "I"."DeletedDateTime" IS NULL ) AS "PharmacyBranch" WHERE "U"."Id" = @pUserId;
GO
/****** Object:  StoredProcedure [dbo].[fn_users_getloginbyusertokens]    Script Date: 18.2.2021. 23.24.16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fn_users_getloginbyusertokens] @pAccessToken nvarchar(max),@pRefreshToken nvarchar(max) AS SELECT "U"."Id", "U"."AccessToken", "U"."Id" AS "UserId" FROM "Users" AS "U" WHERE "U"."DeletedDateTime" IS NULL AND CURRENT_TIMESTAMP < "U"."RefreshTokenExpirationDateTime" AND CAST("U"."AccessToken" as nvarchar(max)) = @pAccessToken AND CAST("U"."RefreshToken" as nvarchar(max))= @pRefreshToken;
GO
USE [master]
GO
ALTER DATABASE [160048] SET  READ_WRITE 
GO
