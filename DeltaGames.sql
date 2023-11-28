USE [master]
GO
/****** Object:  Database [DeltaGames]    Script Date: 28/11/2023 12:07:43 ******/
CREATE DATABASE [DeltaGames]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DeltaGames', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DeltaGames.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DeltaGames_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DeltaGames_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DeltaGames] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DeltaGames].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DeltaGames] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DeltaGames] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DeltaGames] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DeltaGames] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DeltaGames] SET ARITHABORT OFF 
GO
ALTER DATABASE [DeltaGames] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DeltaGames] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DeltaGames] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DeltaGames] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DeltaGames] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DeltaGames] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DeltaGames] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DeltaGames] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DeltaGames] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DeltaGames] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DeltaGames] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DeltaGames] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DeltaGames] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DeltaGames] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DeltaGames] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DeltaGames] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DeltaGames] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DeltaGames] SET RECOVERY FULL 
GO
ALTER DATABASE [DeltaGames] SET  MULTI_USER 
GO
ALTER DATABASE [DeltaGames] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DeltaGames] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DeltaGames] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DeltaGames] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DeltaGames] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DeltaGames', N'ON'
GO
ALTER DATABASE [DeltaGames] SET QUERY_STORE = OFF
GO
USE [DeltaGames]
GO
/****** Object:  User [alumno]    Script Date: 28/11/2023 12:07:43 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 28/11/2023 12:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[TipoCategoria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[conciertos]    Script Date: 28/11/2023 12:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conciertos](
	[Idconcierto] [varchar](50) NOT NULL,
	[Nombre] [varchar](70) NOT NULL,
	[CantLikes] [int] NOT NULL,
	[fkUsuario] [int] NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[FechaConcierto] [date] NOT NULL,
	[Imagen] [text] NOT NULL,
	[Precio] [int] NOT NULL,
	[fkCategoria] [int] NOT NULL,
 CONSTRAINT [PK_conciertos] PRIMARY KEY CLUSTERED 
(
	[Idconcierto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 28/11/2023 12:07:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (1, N'Pop')
INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (2, N'Rock')
INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (3, N'Reggaeton')
INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (4, N'Trap')
INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (5, N'Rap')
INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (6, N'Tango')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
INSERT [dbo].[conciertos] ([Idconcierto], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaConcierto], [Imagen], [Precio], [fkCategoria]) VALUES (N'10', N'Taylor Swift', 2, NULL, N'The Eras Tour', CAST(N'2023-12-03' AS Date), N'https://media.admagazine.com/photos/6421c251b63d56abbb4a6336/16:9/w_5999,h_3374,c_limit/GettyImages-1474485122.jpg', 15, 1)
INSERT [dbo].[conciertos] ([Idconcierto], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaConcierto], [Imagen], [Precio], [fkCategoria]) VALUES (N'11', N'Rauw Alejandro', 2, NULL, N'Por el Mundo', CAST(N'2024-01-04' AS Date), N'https://okdiario.com/img/2022/11/08/rauw-alejandro..jpg', 2, 6)
INSERT [dbo].[conciertos] ([Idconcierto], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaConcierto], [Imagen], [Precio], [fkCategoria]) VALUES (N'12', N'Los Autenticos Decadentes', 1, NULL, N'Fiesta de la Cerveza', CAST(N'2024-05-06' AS Date), N'https://i.scdn.co/image/ab6761610000e5eb39bb27c9cc186cb2479a48d6', 3, 3)
INSERT [dbo].[conciertos] ([Idconcierto], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaConcierto], [Imagen], [Precio], [fkCategoria]) VALUES (N'15', N'One Direction', 0, NULL, N'One day One Life', CAST(N'2023-11-30' AS Date), N'https://media.glamour.mx/photos/64370d469140a8879ed24682/1:1/w_1999,h_1999,c_limit/One_Direction.jpg', 15, 5)
INSERT [dbo].[conciertos] ([Idconcierto], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaConcierto], [Imagen], [Precio], [fkCategoria]) VALUES (N'17', N'Bad Bunny', 0, NULL, N'La Vuelta Al Mundo', CAST(N'2023-12-25' AS Date), N'data:image/jpeg;base64,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', 20, 1)
INSERT [dbo].[conciertos] ([Idconcierto], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaConcierto], [Imagen], [Precio], [fkCategoria]) VALUES (N'18', N'Cardi B', 0, NULL, N'Please Me', CAST(N'2024-03-01' AS Date), N'https://people.com/thmb/qRfrCA5X8z7gH8viaD4Yaw3Gk2I=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(599x0:601x2)/cardi-b-tout-66e2490a8ed5459394d3ab05516d5219.jpg', 200, 1)
INSERT [dbo].[conciertos] ([Idconcierto], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaConcierto], [Imagen], [Precio], [fkCategoria]) VALUES (N'19', N'Morat', 0, NULL, N'Balas Perdidas', CAST(N'2024-03-01' AS Date), N'https://lumiere-a.akamaihd.net/v1/images/fl1o8duxeaeak_z_946fb5b8.jpeg', 24, 1)
INSERT [dbo].[conciertos] ([Idconcierto], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaConcierto], [Imagen], [Precio], [fkCategoria]) VALUES (N'6', N'Chano', 1, NULL, N'Ama De Mi Corazon', CAST(N'2024-03-01' AS Date), N'https://i.scdn.co/image/ab6761610000e5ebe89b4a659445115974d4e09f', 20, 5)
INSERT [dbo].[conciertos] ([Idconcierto], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaConcierto], [Imagen], [Precio], [fkCategoria]) VALUES (N'8', N'Tan Bionica', 12, NULL, N'Ciudad Magica ', CAST(N'2024-03-01' AS Date), N'https://i.scdn.co/image/ab6761610000e5ebb4063d372f85c22f4468ca24', 50, 1)
INSERT [dbo].[conciertos] ([Idconcierto], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaConcierto], [Imagen], [Precio], [fkCategoria]) VALUES (N'9', N'WOS', 5, NULL, N'Arrancarmelo', CAST(N'2024-03-01' AS Date), N'https://static.wikia.nocookie.net/rap/images/2/20/Valent%C3%ADnOlivaWos.jpg/revision/latest?cb=20210313190652&path-prefix=es', 20, 5)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Contraseña], [Nombre]) VALUES (5, N'1234', N'LeoK')
INSERT [dbo].[Usuarios] ([IdUsuario], [Contraseña], [Nombre]) VALUES (6, N'123', N'Alexis')
INSERT [dbo].[Usuarios] ([IdUsuario], [Contraseña], [Nombre]) VALUES (7, N'pepe', N'Alote')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[conciertos]  WITH CHECK ADD  CONSTRAINT [FK_conciertos_Categorias] FOREIGN KEY([fkCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[conciertos] CHECK CONSTRAINT [FK_conciertos_Categorias]
GO
ALTER TABLE [dbo].[conciertos]  WITH CHECK ADD  CONSTRAINT [FK_conciertos_Usuarios] FOREIGN KEY([fkUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[conciertos] CHECK CONSTRAINT [FK_conciertos_Usuarios]
GO
USE [master]
GO
ALTER DATABASE [DeltaGames] SET  READ_WRITE 
GO
