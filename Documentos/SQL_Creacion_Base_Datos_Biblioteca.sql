/*
Ruta donde se guardara el archivo, debera existir
para esta prueba se creara la base de datos en la sigiente ruta
c:\PruebaLIbreryaTRAVEL\MSSQL\DATA
PUEDEN UTILIZAR LA RUTA QUE DESEEN, SOLO DEBE EXISTIR
*/
USE [master]
GO

/****** Object:  Database [Biblioteca]    Script Date: 11/15/2022 16:50:01 ******/
CREATE DATABASE [Biblioteca] ON  PRIMARY 
( NAME = N'Biblioteca', FILENAME = N'c:\PruebaLIbreryaTRAVEL\MSSQL\DATA\Biblioteca.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Biblioteca_log', FILENAME = N'c:\PruebaLIbreryaTRAVEL\MSSQL\DATA\Biblioteca_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Biblioteca] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Biblioteca].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Biblioteca] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Biblioteca] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Biblioteca] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Biblioteca] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Biblioteca] SET ARITHABORT OFF 
GO

ALTER DATABASE [Biblioteca] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Biblioteca] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Biblioteca] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Biblioteca] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Biblioteca] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Biblioteca] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Biblioteca] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Biblioteca] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Biblioteca] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Biblioteca] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Biblioteca] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Biblioteca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Biblioteca] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Biblioteca] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Biblioteca] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Biblioteca] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Biblioteca] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [Biblioteca] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Biblioteca] SET  READ_WRITE 
GO

ALTER DATABASE [Biblioteca] SET RECOVERY FULL 
GO

ALTER DATABASE [Biblioteca] SET  MULTI_USER 
GO

ALTER DATABASE [Biblioteca] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Biblioteca] SET DB_CHAINING OFF 

USE [Biblioteca]
GO
/****** Object:  Table [dbo].[autores]    Script Date: 11/15/2022 18:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NULL,
	[apellido] [nvarchar](max) NULL,
 CONSTRAINT [PK_autores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[editoriales]    Script Date: 11/15/2022 18:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[editoriales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[sede] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_editoriales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[libros]    Script Date: 11/15/2022 18:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libros](
	[isbn] [int] IDENTITY(1,1) NOT NULL,
	[editorialesId] [int] NOT NULL,
	[titulo] [nvarchar](80) NOT NULL,
	[sinopsis] [nvarchar](150) NULL,
	[nPagina] [int] NOT NULL,
 CONSTRAINT [PK_libros] PRIMARY KEY CLUSTERED 
(
	[isbn] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[autores_has_libros]    Script Date: 11/15/2022 18:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autores_has_libros](
	[autoresId] [int] NOT NULL,
	[librosIsbn] [int] NOT NULL,
 CONSTRAINT [PK_autores_has_libros] PRIMARY KEY CLUSTERED 
(
	[autoresId] ASC,
	[librosIsbn] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_autores_has_libros_autores_autoresId]    Script Date: 11/15/2022 18:53:48 ******/
ALTER TABLE [dbo].[autores_has_libros]  WITH CHECK ADD  CONSTRAINT [FK_autores_has_libros_autores_autoresId] FOREIGN KEY([autoresId])
REFERENCES [dbo].[autores] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[autores_has_libros] CHECK CONSTRAINT [FK_autores_has_libros_autores_autoresId]
GO
/****** Object:  ForeignKey [FK_autores_has_libros_libros_librosIsbn]    Script Date: 11/15/2022 18:53:48 ******/
ALTER TABLE [dbo].[autores_has_libros]  WITH CHECK ADD  CONSTRAINT [FK_autores_has_libros_libros_librosIsbn] FOREIGN KEY([librosIsbn])
REFERENCES [dbo].[libros] ([isbn])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[autores_has_libros] CHECK CONSTRAINT [FK_autores_has_libros_libros_librosIsbn]
GO
/****** Object:  ForeignKey [FK_libros_editoriales_editorialesId]    Script Date: 11/15/2022 18:53:48 ******/
ALTER TABLE [dbo].[libros]  WITH CHECK ADD  CONSTRAINT [FK_libros_editoriales_editorialesId] FOREIGN KEY([editorialesId])
REFERENCES [dbo].[editoriales] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[libros] CHECK CONSTRAINT [FK_libros_editoriales_editorialesId]
GO
