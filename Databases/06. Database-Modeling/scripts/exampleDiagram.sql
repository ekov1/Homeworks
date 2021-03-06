USE [master]
GO
/****** Object:  Database [modellingDatabase]    Script Date: 07-Jan-17 1:30:04 PM ******/
CREATE DATABASE [modellingDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'modellingDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\modellingDatabase.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'modellingDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\modellingDatabase_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [modellingDatabase] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [modellingDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [modellingDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [modellingDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [modellingDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [modellingDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [modellingDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [modellingDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [modellingDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [modellingDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [modellingDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [modellingDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [modellingDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [modellingDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [modellingDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [modellingDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [modellingDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [modellingDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [modellingDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [modellingDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [modellingDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [modellingDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [modellingDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [modellingDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [modellingDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [modellingDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [modellingDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [modellingDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [modellingDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [modellingDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [modellingDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
USE [modellingDatabase]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 07-Jan-17 1:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adress_text] [nvarchar](100) NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 07-Jan-17 1:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contry]    Script Date: 07-Jan-17 1:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contry](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_Contry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 07-Jan-17 1:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 07-Jan-17 1:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([id], [adress_text], [town_id]) VALUES (1, N'bul.Bulgaria 100', 1)
INSERT [dbo].[Address] ([id], [adress_text], [town_id]) VALUES (2, N'Money Boulevard 100', 2)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([id], [name]) VALUES (1, N'Europe')
INSERT [dbo].[Continent] ([id], [name]) VALUES (2, N'Asia')
INSERT [dbo].[Continent] ([id], [name]) VALUES (3, N'Australia')
INSERT [dbo].[Continent] ([id], [name]) VALUES (4, N'Africa')
INSERT [dbo].[Continent] ([id], [name]) VALUES (5, N'America')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Contry] ON 

INSERT [dbo].[Contry] ([id], [name], [continent_id]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Contry] ([id], [name], [continent_id]) VALUES (2, N'USA', 5)
SET IDENTITY_INSERT [dbo].[Contry] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Kiro', N'Kirev', 1)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (3, N'George', N'Michael', 2)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (2, N'Las Vegas', 2)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([town_id])
REFERENCES [dbo].[Town] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Contry]  WITH CHECK ADD  CONSTRAINT [FK_Contry_Continent] FOREIGN KEY([continent_id])
REFERENCES [dbo].[Continent] ([id])
GO
ALTER TABLE [dbo].[Contry] CHECK CONSTRAINT [FK_Contry_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address_id])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Contry] FOREIGN KEY([country_id])
REFERENCES [dbo].[Contry] ([id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Contry]
GO
USE [master]
GO
ALTER DATABASE [modellingDatabase] SET  READ_WRITE 
GO
