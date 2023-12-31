USE [master]
GO
/****** Object:  Database [Estetica]    Script Date: 3/7/2023 17:34:13 ******/
CREATE DATABASE [Estetica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Estetica', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\Estetica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Estetica_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\Estetica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Estetica] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Estetica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Estetica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Estetica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Estetica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Estetica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Estetica] SET ARITHABORT OFF 
GO
ALTER DATABASE [Estetica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Estetica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Estetica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Estetica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Estetica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Estetica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Estetica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Estetica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Estetica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Estetica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Estetica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Estetica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Estetica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Estetica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Estetica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Estetica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Estetica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Estetica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Estetica] SET  MULTI_USER 
GO
ALTER DATABASE [Estetica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Estetica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Estetica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Estetica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Estetica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Estetica] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Estetica] SET QUERY_STORE = ON
GO
ALTER DATABASE [Estetica] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Estetica]
GO
/****** Object:  Table [dbo].[Administrativos]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrativos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [varchar](10) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contraseña] [varchar](200) NOT NULL,
	[FechaNac] [datetime] NULL,
	[Edad] [int] NOT NULL,
	[Tarea] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Administrativo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [varchar](10) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[FechaNac] [date] NULL,
	[Edad] [int] NOT NULL,
	[NroCliente] [int] NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesionales]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesionales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [varchar](10) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[FechaNac] [datetime] NOT NULL,
	[Edad] [int] NOT NULL,
 CONSTRAINT [PK_Profesional] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tratamientos]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tratamientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
	[Costo] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Tratamientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cliente_Id] [int] NOT NULL,
	[Profesional_Id] [int] NOT NULL,
	[Fecha] [date] NULL,
	[Hora] [varchar](50) NOT NULL,
	[Consultorio] [varchar](10) NULL,
	[Total] [decimal](18, 0) NOT NULL,
	[Tratamiento_Id] [int] NOT NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_Administrativo_Alta]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Administrativo_Alta]
	@DNI varchar(10),
	@Nom varchar(50),
	@Ape varchar(50),
	@Tel varchar(50),
	@Email Varchar(50),
	@Con varchar(50),
	@FN DateTime,
	@Edad int,
	@tarea varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Administrativos
	(DNI, Nombre, Apellido, Telefono, Email, Contraseña, FechaNac,Edad,Tarea)
	values
	(@DNI,@Nom,@Ape,@Tel,@Email,@Con,@FN,@Edad,@Tarea)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Administrativo_Baja]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Administrativo_Baja]
@Id	int
AS
BEGIN

	SET NOCOUNT ON;

    DELETE from Administrativos
	Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Administrativo_Modificar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Administrativo_Modificar]
	@DNI varchar(10),
	@Nom varchar(50),
	@Ape varchar(50),
	@Tel varchar(50),
	@Email Varchar(50),
	@Con varchar(50),
	@FN DateTime,
	@Edad int,
	@tarea varchar(100),
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	update  Administrativos
	SET
	DNI=@DNI,
	Nombre=@Nom,
	Apellido=@Ape,
	Telefono=@Tel,
	Email=@Email,
	Contraseña=@Con,
	FechaNac=@FN,
	Edad=@Edad,
	Tarea=@tarea
	where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Administrativos_Listar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Administrativos_Listar]
	
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, DNI, Nombre, Apellido, Telefono, Email, Contraseña, FechaNac,Edad,Tarea
	from Administrativos
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Baja]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Baja]
@NC	int
AS
BEGIN

	SET NOCOUNT ON;

    DELETE from Clientes
	Where NroCliente=@NC
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Modificar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Modificar]
	@DNI varchar(10),
	@Nom varchar(50),
	@Ape varchar(50),
	@Tel varchar(50),
	@Email Varchar(50),
	@FN Date,
	@Edad int,
	@Id int,
	@NC int,
	@dir varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	update  Clientes
	SET
	DNI=@DNI,
	Nombre=@Nom,
	Apellido=@Ape,
	Telefono=@Tel,
	Email=@Email,
	FechaNac=@FN,
	Edad=@Edad,
	NroCliente=@NC,
	Direccion=@Dir
	where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Clientes_Alta]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Clientes_Alta]
	@DNI varchar(10),
	@Nom varchar(50),
	@Ape varchar(50),
	@Tel varchar(50),
	@Email Varchar(50),
	@FN DateTime,
	@Edad int,
	@NC int,
	@dir varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Clientes
	(DNI, Nombre, Apellido, Telefono, Email, FechaNac,Edad,NroCliente,Direccion)
	values
	(@DNI,@Nom,@Ape,@Tel,@Email,@FN,@Edad,@NC,@dir)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Clientes_Listar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Clientes_Listar]
	
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, DNI, Nombre, Apellido, Telefono, Email, FechaNac,Edad,NroCliente,Direccion
	from Clientes
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Turno_Cli]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Listar_Turno_Cli]
		@cli int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT c.Apellido as Cliente, p.Apellido as Profesional, Fecha, Hora, Consultorio, Total,t.Nombre as Tratamiento
	from Clientes as c, Profesionales as p, Tratamientos as t, Turnos as tu
	where c.id = @cli and c.id = tu.Cliente_Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarAdminXMail]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ListarAdminXMail]
@cont 	varchar(200),
@email varchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;

   
	select count(Contraseña) from Administrativos where Contraseña =  @cont and Email = @email
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Profesional_Alta]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Profesional_Alta]
	@DNI varchar(10),
	@Nom varchar(50),
	@Ape varchar(50),
	@Tel varchar(50),
	@Email Varchar(50),
	@Tit varchar(50),
	@FN DateTime,
	@Edad int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Profesionales
	(DNI, Nombre, Apellido, Telefono, Email, Titulo, FechaNac,Edad)
	values
	(@DNI,@Nom,@Ape,@Tel,@Email,@Tit,@FN,@Edad)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Profesional_Baja]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Profesional_Baja]
@Id	int
AS
BEGIN

	SET NOCOUNT ON;

    DELETE from Profesionales
	Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Profesional_Listar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Profesional_Listar]
	
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, DNI, Nombre, Apellido, Telefono, Email, Titulo, FechaNac,Edad
	from Profesionales
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Profesional_Modificar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Profesional_Modificar] 
	@DNI varchar(10),
	@Nom varchar(50),
	@Ape varchar(50),
	@Tel varchar(50),
	@Email Varchar(50),
	@Tit varchar(50),
	@FN DateTime,
	@Edad int,
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	update  Profesionales
	SET
	DNI=@DNI,
	Nombre=@Nom,
	Apellido=@Ape,
	Telefono=@Tel,
	Email=@Email,
	Titulo=@Tit,
	FechaNac=@FN,
	Edad=@Edad
	where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Tratamiento_Alta]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Tratamiento_Alta] 
	@Nom varchar(50),
	@Tipo varchar(20),
	@Costo decimal(18,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Tratamientos
	(Nombre,Tipo,Costo)
	values
	(@Nom,@Tipo,@Costo)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Tratamiento_Borrar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Tratamiento_Borrar]
@Id	int
AS
BEGIN

	SET NOCOUNT ON;

    DELETE from Tratamientos
	Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Tratamiento_Modificacion]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Tratamiento_Modificacion] 
	@Nom varchar(50),
	@Tipo varchar(20),
	@Costo decimal(18,0),
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update  Tratamientos
	SET
	Nombre=@Nom,
	Tipo=@Tipo,
	Costo=@Costo
	where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Tratamiento_X_Id]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Tratamiento_X_Id]
@Id int	
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Nombre, Tipo, Costo
	from Tratamientos
	where Id =@Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Tratamiento_X_Nombre]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Tratamiento_X_Nombre]
@Nombre varchar(50)	
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Nombre, Tipo, Costo
	from Tratamientos
	where Id =@Nombre
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Tratamientos_Corporales_Listar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Tratamientos_Corporales_Listar]
	
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Nombre, Tipo, Costo
	from Tratamientos
	where Tipo = 'Corporal'
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Tratamientos_Faciales_Listar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Tratamientos_Faciales_Listar]
	
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Nombre, Tipo, Costo
	from Tratamientos
	where Tipo = 'Facial'
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Tratamientos_Listar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Tratamientos_Listar]
	
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Nombre, Tipo, Costo
	from Tratamientos
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Turno_Alta]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Turno_Alta]
	@Cliente int,
	@Profesional int,
	@Fecha date,
	@Hora varchar(50),
	@Consultorio varchar(50),
	@Total decimal(18,0),
	@Tratamiento int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Turnos
	(Cliente_Id, Profesional_Id, Fecha, Hora, Consultorio, Total,Tratamiento_Id)
	values
	(@Cliente,@Profesional,@Fecha,@Hora,@Consultorio,@Total,@Tratamiento)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Turno_Baja]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Turno_Baja]
@Id	int
AS
BEGIN

	SET NOCOUNT ON;

    DELETE from Turnos
	Where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Turno_Modificar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Turno_Modificar]
	@cli int,
	@pro int,
	@fecha date,
	@hora varchar(50),
	@consul varchar(10),
	@total decimal(18,0),
	@trat int,
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	update  Turnos
	SET
	Cliente_Id = @cli, Profesional_Id=@pro, Fecha=@fecha, Hora=@hora, Consultorio=@consul, Total=@total,Tratamiento_Id=@trat
	where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Turno_X_Id_Turno]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Turno_X_Id_Turno]
@Id int	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select count(Tratamiento_Id) from Turnos where Tratamiento_Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Turnos_Listar]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Turnos_Listar]
	
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT tu.Id,c.Apellido as Cliente, p.Apellido as Profesional, Fecha, Hora, Consultorio, Total,t.Nombre as Tratamiento, t.Tipo as Tipo
	from Clientes as c, Profesionales as p, Tratamientos as t, Turnos as tu
	where c.id = tu.Cliente_Id and p.Id=tu.Profesional_Id and t.Id=tu.Tratamiento_Id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Turnos_Listar_Id_Cliente]    Script Date: 3/7/2023 17:34:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Turnos_Listar_Id_Cliente]
	@cli int,
	@trat int
	
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT tu.Id, c.Apellido as Cliente, p.Apellido as Profesional, Fecha, Hora, Consultorio, Total,t.Nombre as Tratamiento
	from Clientes as c, Profesionales as p, Tratamientos as t, Turnos as tu
	where c.id = @cli and c.id = tu.Cliente_Id and t.Id=@trat
END
GO
USE [master]
GO
ALTER DATABASE [Estetica] SET  READ_WRITE 
GO
