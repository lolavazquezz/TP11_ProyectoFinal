USE [master]
GO
/****** Object:  Database [DB_Conciertos]    Script Date: 21/11/2023 08:17:27 ******/
CREATE DATABASE [DB_Conciertos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Conciertos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DB_Conciertos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Conciertos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DB_Conciertos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DB_Conciertos] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Conciertos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Conciertos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Conciertos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Conciertos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Conciertos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Conciertos] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Conciertos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Conciertos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Conciertos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Conciertos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Conciertos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Conciertos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Conciertos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Conciertos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Conciertos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Conciertos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_Conciertos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Conciertos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Conciertos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Conciertos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Conciertos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Conciertos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Conciertos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Conciertos] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_Conciertos] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Conciertos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Conciertos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Conciertos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Conciertos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Conciertos] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_Conciertos', N'ON'
GO
ALTER DATABASE [DB_Conciertos] SET QUERY_STORE = OFF
GO
USE [DB_Conciertos]
GO
/****** Object:  User [alumno]    Script Date: 21/11/2023 08:17:27 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Artista]    Script Date: 21/11/2023 08:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artista](
	[IdArtista] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Artista] PRIMARY KEY CLUSTERED 
(
	[IdArtista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 21/11/2023 08:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[IdConcierto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioConcierto] PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Concierto]    Script Date: 21/11/2023 08:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concierto](
	[IdConcierto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Hora] [datetime] NOT NULL,
	[IdArtista] [int] NOT NULL,
	[Ubicacion] [text] NOT NULL,
	[Pais] [varchar](50) NOT NULL,
	[Imagen] [text] NOT NULL,
	[Genero] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[Mes] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Concierto] PRIMARY KEY CLUSTERED 
(
	[IdConcierto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Artista] ON 

INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (1, N'Taylor Swift')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (2, N'Bad Bunny')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (3, N'Rauw Alejandro')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (4, N'Miranda')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (5, N'Tan Bionica')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (6, N'Andres Calamaro')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (7, N'No Te va a Gustar')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (8, N'Ciro y los Persas')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (9, N'Karol G')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (10, N'Peso Pluma')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (11, N'Ed Sheeran')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (12, N'Lana Del Rey')
INSERT [dbo].[Artista] ([IdArtista], [Nombre]) VALUES (13, N'Coldplay')
SET IDENTITY_INSERT [dbo].[Artista] OFF
GO
SET IDENTITY_INSERT [dbo].[Concierto] ON 

INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (6, N'Taylor Swift Live', CAST(N'2023-01-15T00:00:00.000' AS DateTime), CAST(N'1900-01-01T19:00:00.000' AS DateTime), 1, N'Estadio Nacional', N'Argentina', N'yggj', N'Pop', 5000, N'Enero')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (7, N'Bad Bunny World Tour', CAST(N'2023-02-20T00:00:00.000' AS DateTime), CAST(N'1900-01-01T20:30:00.000' AS DateTime), 2, N'Estadio Monumental', N'Chile', N'hwqwj', N'Trap', 6000, N'Febrero')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (8, N'Rauw Alejandro Live', CAST(N'2023-03-10T00:00:00.000' AS DateTime), CAST(N'1900-01-01T18:45:00.000' AS DateTime), 3, N'Arena Bogotá', N'Colombia', N'jbj', N'Rap', 4000, N'Marzo')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (10, N'Miranda en Concierto', CAST(N'2023-04-05T00:00:00.000' AS DateTime), CAST(N'1900-01-01T21:15:00.000' AS DateTime), 4, N'Teatro Metropolitano', N'Uruguay', N'jgv', N'Pop', 3500, N'Abril')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (11, N'Tan Bionica Show', CAST(N'2023-05-12T00:00:00.000' AS DateTime), CAST(N'1900-01-01T20:00:00.000' AS DateTime), 5, N'Estadio Nacional', N'Argentina', N'lhbj', N'Rock', 5500, N'Mayo')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (12, N'Andres Calamaro Live', CAST(N'2023-06-18T00:00:00.000' AS DateTime), CAST(N'1900-01-01T19:30:00.000' AS DateTime), 6, N'Movistar Arena', N'Chile', N'hjy', N'Rock', 4800, N'Junio')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (13, N'No Te va a Gustar Live', CAST(N'2023-07-02T00:00:00.000' AS DateTime), CAST(N'1900-01-01T20:15:00.000' AS DateTime), 7, N'Estadio Centenario', N'Uruguay', N'URL', N'Rock', 6000, N'Julio')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (14, N'Ciro y los Persas en Vivo', CAST(N'2023-08-11T00:00:00.000' AS DateTime), CAST(N'1900-01-01T21:00:00.000' AS DateTime), 8, N'Estadio Monumental', N'Argentina', N'UR', N'Rock', 5500, N'Agosto')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (15, N'Karol G World Tour', CAST(N'2023-09-25T00:00:00.000' AS DateTime), CAST(N'1900-01-01T20:30:00.000' AS DateTime), 9, N'Movistar Arena', N'Chile', N'URL   ', N'Trap', 4500, N'Septiembre')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (17, N'Peso Pluma Concert', CAST(N'2023-10-05T00:00:00.000' AS DateTime), CAST(N'1900-01-01T19:15:00.000' AS DateTime), 10, N'Teatro Colón', N'Colombia', N'KHBK', N'Pop', 4000, N'Octubre')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (19, N'Ed Sheeran Live', CAST(N'2023-11-20T00:00:00.000' AS DateTime), CAST(N'1900-01-01T20:00:00.000' AS DateTime), 11, N'Estadio Nacional', N'Argentina', N'vhmn', N'Pop', 6000, N'Noviembre')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (21, N'Lana Del Rey en Vivo', CAST(N'2023-12-15T00:00:00.000' AS DateTime), CAST(N'1900-01-01T19:45:00.000' AS DateTime), 12, N'Arena Montevideo', N'Uruguay', N'hhj', N'Pop', 4000, N'Diciembre')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (24, N'Coldplay World Tour', CAST(N'2024-01-10T00:00:00.000' AS DateTime), CAST(N'1900-01-01T21:00:00.000' AS DateTime), 13, N'Estadio Monumental', N'Chile', N'vnh', N'Pop', 5000, N'Enero')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (25, N'Taylor Swift Live', CAST(N'2024-02-25T00:00:00.000' AS DateTime), CAST(N'1900-01-01T20:30:00.000' AS DateTime), 1, N'Estadio Nacional', N'Argentina', N'URL', N'Pop', 5000, N'Febrero')
INSERT [dbo].[Concierto] ([IdConcierto], [Nombre], [Fecha], [Hora], [IdArtista], [Ubicacion], [Pais], [Imagen], [Genero], [Stock], [Mes]) VALUES (26, N'Bad Bunny World Tour', CAST(N'2024-03-15T00:00:00.000' AS DateTime), CAST(N'1900-01-01T19:45:00.000' AS DateTime), 2, N'Estadio Nacional', N'Chile', N'hhh', N'Trap', 6000, N'Marzo')
SET IDENTITY_INSERT [dbo].[Concierto] OFF
GO
USE [master]
GO
ALTER DATABASE [DB_Conciertos] SET  READ_WRITE 
GO
