USE [master]
GO
/****** Object:  Database [universityDb]    Script Date: 07-Jan-17 1:31:06 PM ******/
CREATE DATABASE [universityDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'universityDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\universityDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'universityDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\universityDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [universityDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [universityDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [universityDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [universityDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [universityDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [universityDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [universityDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [universityDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [universityDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [universityDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [universityDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [universityDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [universityDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [universityDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [universityDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [universityDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [universityDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [universityDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [universityDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [universityDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [universityDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [universityDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [universityDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [universityDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [universityDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [universityDb] SET  MULTI_USER 
GO
ALTER DATABASE [universityDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [universityDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [universityDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [universityDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [universityDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [universityDb]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 07-Jan-17 1:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[proffessor_id] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 07-Jan-17 1:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[faculty_id] [int] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 07-Jan-17 1:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[university_id] [int] NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Proffessors]    Script Date: 07-Jan-17 1:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proffessors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[department_id] [int] NOT NULL,
 CONSTRAINT [PK_Proffessors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 07-Jan-17 1:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[faculty_id] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students_Courses]    Script Date: 07-Jan-17 1:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students_Courses](
	[student_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
 CONSTRAINT [PK_Students_Courses] PRIMARY KEY CLUSTERED 
(
	[student_id] ASC,
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 07-Jan-17 1:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[proffessor_id] [int] NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Universities]    Script Date: 07-Jan-17 1:31:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Universities] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Proffessors] FOREIGN KEY([proffessor_id])
REFERENCES [dbo].[Proffessors] ([id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Proffessors]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Faculties] FOREIGN KEY([faculty_id])
REFERENCES [dbo].[Faculties] ([id])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Faculties]
GO
ALTER TABLE [dbo].[Faculties]  WITH CHECK ADD  CONSTRAINT [FK_Faculties_Universities] FOREIGN KEY([university_id])
REFERENCES [dbo].[Universities] ([id])
GO
ALTER TABLE [dbo].[Faculties] CHECK CONSTRAINT [FK_Faculties_Universities]
GO
ALTER TABLE [dbo].[Proffessors]  WITH CHECK ADD  CONSTRAINT [FK_Proffessors_Departments] FOREIGN KEY([department_id])
REFERENCES [dbo].[Departments] ([id])
GO
ALTER TABLE [dbo].[Proffessors] CHECK CONSTRAINT [FK_Proffessors_Departments]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([faculty_id])
REFERENCES [dbo].[Faculties] ([id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO
ALTER TABLE [dbo].[Students_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Students_Courses_Courses] FOREIGN KEY([course_id])
REFERENCES [dbo].[Courses] ([id])
GO
ALTER TABLE [dbo].[Students_Courses] CHECK CONSTRAINT [FK_Students_Courses_Courses]
GO
ALTER TABLE [dbo].[Students_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Students_Courses_Students] FOREIGN KEY([student_id])
REFERENCES [dbo].[Students] ([id])
GO
ALTER TABLE [dbo].[Students_Courses] CHECK CONSTRAINT [FK_Students_Courses_Students]
GO
ALTER TABLE [dbo].[Titles]  WITH CHECK ADD  CONSTRAINT [FK_Titles_Proffessors] FOREIGN KEY([proffessor_id])
REFERENCES [dbo].[Proffessors] ([id])
GO
ALTER TABLE [dbo].[Titles] CHECK CONSTRAINT [FK_Titles_Proffessors]
GO
USE [master]
GO
ALTER DATABASE [universityDb] SET  READ_WRITE 
GO
