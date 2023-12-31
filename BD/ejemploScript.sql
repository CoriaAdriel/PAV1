USE [master]
GO
/****** Object:  Database [ProyectoBasePAV1]    Script Date: 20/7/2023 11:00:03 ******/
CREATE DATABASE [ProyectoBasePAV1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectoBasePAV1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SERVIDOR\MSSQL\DATA\ProyectoBasePAV1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProyectoBasePAV1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SERVIDOR\MSSQL\DATA\ProyectoBasePAV1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProyectoBasePAV1] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoBasePAV1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoBasePAV1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoBasePAV1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectoBasePAV1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProyectoBasePAV1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectoBasePAV1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProyectoBasePAV1] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectoBasePAV1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectoBasePAV1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectoBasePAV1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectoBasePAV1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProyectoBasePAV1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProyectoBasePAV1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProyectoBasePAV1] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProyectoBasePAV1] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProyectoBasePAV1]
GO
/****** Object:  Table [dbo].[Carreras]    Script Date: 20/7/2023 11:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carreras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_Carreras] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 20/7/2023 11:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[FechaNacimiento] [datetime] NULL,
	[IdSexo] [int] NOT NULL,
	[IdTipoDocumento] [int] NOT NULL,
	[NroDocumento] [varchar](50) NOT NULL,
	[Calle] [varchar](100) NULL,
	[NroCasa] [varchar](100) NULL,
	[Soltero] [bit] NULL,
	[Casado] [bit] NULL,
	[Hijos] [bit] NULL,
	[CantidadHijos] [int] NULL,
	[IdCarrera] [int] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexos]    Script Date: 20/7/2023 11:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_Sexos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDocumentos]    Script Date: 20/7/2023 11:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDocumentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_TiposDocumentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 20/7/2023 11:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Carreras] ON 

INSERT [dbo].[Carreras] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Ingenieria en Sistemas de Informacion', NULL)
INSERT [dbo].[Carreras] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Ingenieria Industrial', NULL)
INSERT [dbo].[Carreras] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Ingenieria Mecánica', NULL)
INSERT [dbo].[Carreras] ([Id], [Nombre], [Descripcion]) VALUES (4, N'Ingenieria Quimica', NULL)
SET IDENTITY_INSERT [dbo].[Carreras] OFF
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 

INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdSexo], [IdTipoDocumento], [NroDocumento], [Calle], [NroCasa], [Soltero], [Casado], [Hijos], [CantidadHijos], [IdCarrera]) VALUES (1, N'Adriel', N'Coria', CAST(N'2000-08-21T00:00:00.000' AS DateTime), 1, 3, N'42729872', N'Gral Paz', N'500', 0, 1, 1, 3, 1)
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdSexo], [IdTipoDocumento], [NroDocumento], [Calle], [NroCasa], [Soltero], [Casado], [Hijos], [CantidadHijos], [IdCarrera]) VALUES (2, N'Denise', N'Coria', CAST(N'1998-06-04T00:00:00.000' AS DateTime), 2, 1, N'41322611', N'Gral Paz', N'540', 1, 0, 0, 0, 4)
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdSexo], [IdTipoDocumento], [NroDocumento], [Calle], [NroCasa], [Soltero], [Casado], [Hijos], [CantidadHijos], [IdCarrera]) VALUES (3, N'Juan', N'Berasetegui', CAST(N'2023-07-20T00:00:00.000' AS DateTime), 1, 1, N'42121561', N'Chocolate', N'2314', 0, 1, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
SET IDENTITY_INSERT [dbo].[Sexos] ON 

INSERT [dbo].[Sexos] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Masculino', NULL)
INSERT [dbo].[Sexos] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Femenino', NULL)
INSERT [dbo].[Sexos] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Otro', NULL)
SET IDENTITY_INSERT [dbo].[Sexos] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDocumentos] ON 

INSERT [dbo].[TiposDocumentos] ([Id], [Nombre], [Descripcion]) VALUES (1, N'DNI', NULL)
INSERT [dbo].[TiposDocumentos] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Pasaporte', NULL)
INSERT [dbo].[TiposDocumentos] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Libreta Universitaria', NULL)
SET IDENTITY_INSERT [dbo].[TiposDocumentos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contraseña]) VALUES (0, N'Adriel', N'123')
INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contraseña]) VALUES (1, N'Elias', N'456')
INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contraseña]) VALUES (2, N'Javier', N'123')
INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contraseña]) VALUES (3, N'John', N'Pollo')
INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contraseña]) VALUES (4, N'Jeremie', N'321')
INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contraseña]) VALUES (5, N'Elias', N'654')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Carreras] FOREIGN KEY([IdCarrera])
REFERENCES [dbo].[Carreras] ([Id])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Carreras]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Sexos] FOREIGN KEY([IdSexo])
REFERENCES [dbo].[Sexos] ([Id])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Sexos]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_TiposDocumentos] FOREIGN KEY([IdTipoDocumento])
REFERENCES [dbo].[TiposDocumentos] ([Id])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_TiposDocumentos]
GO
/****** Object:  StoredProcedure [dbo].[GetCarreras]    Script Date: 20/7/2023 11:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCarreras]	
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Carreras
END
GO
/****** Object:  StoredProcedure [dbo].[GetTiposDocumentos]    Script Date: 20/7/2023 11:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTiposDocumentos]	
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TiposDocumentos
END
GO
/****** Object:  StoredProcedure [dbo].[InsertNuevoUsuario]    Script Date: 20/7/2023 11:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertNuevoUsuario]	
@nombreUsuario varchar(50),
@contraseña varchar(50)
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Usuarios VALUES (@nombreUsuario, @contraseña)
END
GO
USE [master]
GO
ALTER DATABASE [ProyectoBasePAV1] SET  READ_WRITE 
GO
