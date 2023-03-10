USE [master]
GO
/****** Object:  Database [BETestDB]    Script Date: 11/21/2022 3:11:31 PM ******/
CREATE DATABASE [BETestDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BETestDB', FILENAME = N'C:\Users\AD\BETestDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BETestDB_log', FILENAME = N'C:\Users\AD\BETestDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BETestDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BETestDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BETestDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BETestDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BETestDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BETestDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BETestDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BETestDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BETestDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BETestDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BETestDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BETestDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BETestDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BETestDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BETestDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BETestDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BETestDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BETestDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BETestDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BETestDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BETestDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BETestDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BETestDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BETestDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BETestDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BETestDB] SET  MULTI_USER 
GO
ALTER DATABASE [BETestDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BETestDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BETestDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BETestDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BETestDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BETestDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BETestDB] SET QUERY_STORE = OFF
GO
USE [BETestDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/21/2022 3:11:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[UserId] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](30) NULL,
	[Email] [nvarchar](20) NULL,
	[FirstName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NULL,
	[CreatedOn] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/21/2022 3:11:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[OrderStatus] [int] NULL,
	[OrderType] [int] NULL,
	[OrderBy] [uniqueidentifier] NOT NULL,
	[OrderedOn] [datetime] NULL,
	[ShippedOn] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/21/2022 3:11:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [uniqueidentifier] NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[UnitPrice] [decimal](18, 0) NULL,
	[SupplierId] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 11/21/2022 3:11:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplerId] [uniqueidentifier] NOT NULL,
	[SupplierName] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([OrderBy])
REFERENCES [dbo].[Customer] ([UserId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplerId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Supplier]
GO
/****** Object:  StoredProcedure [dbo].[GetActiveOrders]    Script Date: 11/21/2022 3:11:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveOrders] 
AS
BEGIN
SELECT 
[dbo].[Order].OrderId,[dbo].[Order].OrderStatus,[dbo].[Order].OrderType,[dbo].[Order].OrderedOn,[dbo].[Order].ShippedOn, [dbo].[Order].IsActive AS OrderIsActive
,[dbo].[Customer].UserId,[dbo].[Product].ProductId,[dbo].[Product].ProductName,[dbo].[Product].UnitPrice,[dbo].[Product].CreatedOn AS ProductCreatedOn, [dbo].[Product].IsActive AS ProductAvailability
,[dbo].[Supplier].SupplerId,[dbo].[Supplier].SupplierName,[dbo].[Supplier].CreatedOn AS SupplierCreatedOn,[dbo].[Supplier].IsActive AS SupplierIsActive
FROM [dbo].[Order]
INNER JOIN [dbo].[Customer] ON [dbo].[Order].OrderBy = [dbo].[Customer].UserId 
INNER JOIN [dbo].[Product] ON [dbo].[Order].ProductId  = [dbo].[Product].ProductId
INNER JOIN [dbo].[Supplier] ON [dbo].[Product].SupplierId = [dbo].[Supplier].SupplerId
WHERE [dbo].[Customer].IsActive=1 AND [dbo].[Order].IsActive=1;
END
GO
USE [master]
GO
ALTER DATABASE [BETestDB] SET  READ_WRITE 
GO
