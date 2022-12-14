USE [master]
GO
/****** Object:  Database [EsquemaPrueba]    Script Date: 23/10/2022 14:32:08 ******/
CREATE DATABASE [EsquemaPrueba]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EsquemaPrueba', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EsquemaPrueba.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EsquemaPrueba_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EsquemaPrueba_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EsquemaPrueba] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EsquemaPrueba].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EsquemaPrueba] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET ARITHABORT OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EsquemaPrueba] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EsquemaPrueba] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EsquemaPrueba] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EsquemaPrueba] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EsquemaPrueba] SET  MULTI_USER 
GO
ALTER DATABASE [EsquemaPrueba] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EsquemaPrueba] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EsquemaPrueba] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EsquemaPrueba] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EsquemaPrueba] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EsquemaPrueba] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EsquemaPrueba] SET QUERY_STORE = OFF
GO
USE [EsquemaPrueba]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 23/10/2022 14:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](200) NULL,
	[Apellidos] [varchar](200) NULL,
	[Correo] [varchar](200) NULL,
	[Direccion] [varchar](200) NULL,
	[Estado] [varchar](2) NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 23/10/2022 14:32:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NOT NULL,
	[Usuario] [varchar](200) NULL,
	[Clave] [varchar](200) NULL,
	[Estado] [varchar](2) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Persona]
GO
USE [master]
GO
ALTER DATABASE [EsquemaPrueba] SET  READ_WRITE 
GO
