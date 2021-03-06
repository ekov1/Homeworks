USE [master]
GO
/****** Object:  Database [DictionaryDb]    Script Date: 08-Jan-17 1:02:35 AM ******/
CREATE DATABASE [DictionaryDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DictionaryDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DictionaryDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DictionaryDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DictionaryDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DictionaryDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DictionaryDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DictionaryDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DictionaryDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DictionaryDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DictionaryDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DictionaryDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [DictionaryDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DictionaryDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DictionaryDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DictionaryDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DictionaryDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DictionaryDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DictionaryDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DictionaryDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DictionaryDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DictionaryDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DictionaryDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DictionaryDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DictionaryDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DictionaryDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DictionaryDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DictionaryDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DictionaryDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DictionaryDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DictionaryDb] SET  MULTI_USER 
GO
ALTER DATABASE [DictionaryDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DictionaryDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DictionaryDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DictionaryDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DictionaryDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DictionaryDb]
GO
/****** Object:  Table [dbo].[Dictionaries]    Script Date: 08-Jan-17 1:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dictionaries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dictionaries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 08-Jan-17 1:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[dictionary_id] [int] NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonyms]    Script Date: 08-Jan-17 1:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonyms](
	[first_synonym_id] [int] NOT NULL,
	[second_synonym_id] [int] NOT NULL,
 CONSTRAINT [PK_Synonyms] PRIMARY KEY CLUSTERED 
(
	[first_synonym_id] ASC,
	[second_synonym_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 08-Jan-17 1:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[word_id] [int] NOT NULL,
	[translation_word_id] [int] NOT NULL,
	[language_id] [int] NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[word_id] ASC,
	[translation_word_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 08-Jan-17 1:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[explanation] [text] NOT NULL,
	[language_id] [int] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Languages]  WITH CHECK ADD  CONSTRAINT [FK_Languages_Dictionaries] FOREIGN KEY([dictionary_id])
REFERENCES [dbo].[Dictionaries] ([id])
GO
ALTER TABLE [dbo].[Languages] CHECK CONSTRAINT [FK_Languages_Dictionaries]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words] FOREIGN KEY([first_synonym_id])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words1] FOREIGN KEY([second_synonym_id])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words1]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Languages] FOREIGN KEY([language_id])
REFERENCES [dbo].[Languages] ([id])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Languages]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words] FOREIGN KEY([translation_word_id])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words1] FOREIGN KEY([translation_word_id])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words1]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([language_id])
REFERENCES [dbo].[Languages] ([id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
USE [master]
GO
ALTER DATABASE [DictionaryDb] SET  READ_WRITE 
GO
