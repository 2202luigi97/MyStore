USE [master]
GO
/****** Object:  Database [MyStore]    Script Date: 20 abr. 2023 05:39:22 ******/
CREATE DATABASE [MyStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Clientes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Clientes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Clientes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Clientes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MyStore] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MyStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyStore] SET  MULTI_USER 
GO
ALTER DATABASE [MyStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyStore] SET QUERY_STORE = ON
GO
ALTER DATABASE [MyStore] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MyStore]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Celular] [varchar](10) NOT NULL,
	[Correo] [varchar](200) NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdUsuarioRegistra] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[IdUsuarioActualiza] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formularios]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formularios](
	[IdFormulario] [int] IDENTITY(1,1) NOT NULL,
	[Formulario] [varchar](50) NOT NULL,
	[Activo] [bit] NULL,
	[IdUsuarioRegistra] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[IdUsuarioActualiza] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFormulario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Permiso] [varchar](50) NOT NULL,
	[Activo] [bit] NULL,
	[IdUsuarioRegistra] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[IdUsuarioActualiza] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[CodigoBarra] [varchar](100) NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](50) NOT NULL,
	[Activo] [bit] NULL,
	[IdUsuarioRegistra] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[IdUsuarioActualiza] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolFormularios]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolFormularios](
	[IdRolFormulario] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL,
	[IdFormulario] [int] NULL,
	[Activo] [bit] NULL,
	[IdUsuarioRegistra] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[IdUsuarioActualiza] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRolFormulario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolPermisos]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolPermisos](
	[IdRolPermiso] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL,
	[IdPermiso] [int] NULL,
	[Activo] [bit] NULL,
	[IdUsuarioRegistra] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[IdUsuarioActualiza] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRolPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [varchar](200) NOT NULL,
	[Correo] [varchar](200) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varbinary](max) NULL,
	[Bloqueado] [bit] NOT NULL,
	[IntentosFallidos] [smallint] NOT NULL,
	[IdRol] [int] NULL,
	[Activo] [bit] NULL,
	[IdUsuarioRegistra] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[IdUsuarioActualiza] [int] NULL,
	[FechaActualizacion] [datetime] NULL,
 CONSTRAINT [PK__Usuarios__5B65BF97476E6953] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Formularios] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Permisos] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[RolFormularios] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[RolPermisos] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [DF__Usuarios__Intent__5FB337D6]  DEFAULT ((0)) FOR [IntentosFallidos]
GO
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [DF__Usuarios__Activo__619B8048]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Categorias]
GO
ALTER TABLE [dbo].[RolFormularios]  WITH CHECK ADD FOREIGN KEY([IdFormulario])
REFERENCES [dbo].[Formularios] ([IdFormulario])
GO
ALTER TABLE [dbo].[RolFormularios]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[RolPermisos]  WITH CHECK ADD FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permisos] ([IdPermiso])
GO
ALTER TABLE [dbo].[RolPermisos]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK__Usuarios__IdRol__60A75C0F] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK__Usuarios__IdRol__60A75C0F]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCliente]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteCliente]
@IdCliente INT,
@IdUsuarioActualiza INT
AS
BEGIN
UPDATE Cliente
SET
Activo=0,IdUsuarioActualiza=@IdUsuarioActualiza,FechaActualizacion=GETDATE()
WHERE IdCliente=@IdCliente;
SELECT SCOPE_IDENTITY() AS IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCliente]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertCliente]
@Nombre VARCHAR(200),
@Celular VARCHAR(10),
@Correo VARCHAR(200),
@Activo BIT,
@IdUsuarioRegistra INT
AS
BEGIN
INSERT INTO Cliente (Nombre, Celular, Correo, Activo,IdUsuarioRegistra,FechaRegistro)
VALUES (@Nombre,@Celular,@Correo,1,@IdUsuarioRegistra,GETDATE());
SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[SelectCliente]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SelectCliente]
@IdCliente INT = 0
AS
BEGIN
	IF @IdCliente > 0
		BEGIN 
			SELECT
				c.IdCliente
				,c.Nombre
				,c.Celular
				,c.Correo
				 FROM Cliente c 
				 WHERE c.IdCliente = @IdCliente
		END
	ELSE 
		BEGIN
        	SELECT
				c.IdCliente
				,c.Nombre
				,c.Celular
				,c.Correo
				 FROM Cliente c 
				 WHERE c.Activo = 1 
        END
END 
GO
/****** Object:  StoredProcedure [dbo].[UpdateCliente]    Script Date: 20 abr. 2023 05:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateCliente]
@IdCliente INT,
@Nombre VARCHAR(200),
@Celular VARCHAR(10),
@Correo VARCHAR(200),
@IdUsuarioActualiza INT
AS
BEGIN
UPDATE Cliente
SET Nombre=@Nombre,Celular=@Celular,Correo=@Correo,IdUsuarioActualiza=@IdUsuarioActualiza,FechaActualizacion=GETDATE()
WHERE IdCliente=@IdCliente;
SELECT SCOPE_IDENTITY() AS IdCliente
END
GO
USE [master]
GO
ALTER DATABASE [MyStore] SET  READ_WRITE 
GO
