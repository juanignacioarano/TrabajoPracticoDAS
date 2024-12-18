USE [master]
GO
/****** Object:  Database [TrabajoPractico]    Script Date: 9/30/2024 12:03:52 AM ******/
CREATE DATABASE [TrabajoPractico]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrabajoPractico', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TrabajoPractico.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TrabajoPractico_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TrabajoPractico_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TrabajoPractico] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrabajoPractico].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrabajoPractico] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrabajoPractico] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrabajoPractico] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrabajoPractico] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrabajoPractico] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrabajoPractico] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TrabajoPractico] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrabajoPractico] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrabajoPractico] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrabajoPractico] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrabajoPractico] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrabajoPractico] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrabajoPractico] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrabajoPractico] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrabajoPractico] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TrabajoPractico] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrabajoPractico] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrabajoPractico] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrabajoPractico] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrabajoPractico] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrabajoPractico] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrabajoPractico] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrabajoPractico] SET RECOVERY FULL 
GO
ALTER DATABASE [TrabajoPractico] SET  MULTI_USER 
GO
ALTER DATABASE [TrabajoPractico] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrabajoPractico] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrabajoPractico] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrabajoPractico] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TrabajoPractico] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TrabajoPractico] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TrabajoPractico', N'ON'
GO
ALTER DATABASE [TrabajoPractico] SET QUERY_STORE = ON
GO
ALTER DATABASE [TrabajoPractico] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TrabajoPractico]
GO
/****** Object:  Table [dbo].[HistorialMedico]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialMedico](
	[IdHistorial] [int] NOT NULL,
	[IdPaciente] [int] NULL,
	[IdMedico] [int] NULL,
	[Diagnostico] [nvarchar](255) NOT NULL,
	[Tratamiento] [nvarchar](255) NOT NULL,
	[FechaConsulta] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdHistorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicoEspecialidad]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicoEspecialidad](
	[IdMedico] [int] NOT NULL,
	[IdEspecialidad] [int] NOT NULL,
 CONSTRAINT [PK__MedicoEs__25B51C588FA1FE08] PRIMARY KEY CLUSTERED 
(
	[IdMedico] ASC,
	[IdEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[IdMedico] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[Matricula] [nvarchar](50) NOT NULL,
	[DNI] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mst_Especialidades]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mst_Especialidades](
	[IdEspecialidad] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
 CONSTRAINT [PK_Mst_Especialidades] PRIMARY KEY CLUSTERED 
(
	[IdEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[IdPaciente] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[DNI] [nvarchar](10) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Direccion] [nvarchar](255) NOT NULL,
	[Telefono] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Genero] [nvarchar](20) NOT NULL,
	[NumeroDeAfiliado] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__Paciente__C93DB49B28BFFB9D] PRIMARY KEY CLUSTERED 
(
	[IdPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[IdTurno] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[IdMedico] [int] NOT NULL,
	[FechaTurno] [datetime] NOT NULL,
	[MotivoConsulta] [nvarchar](255) NOT NULL,
	[FechaLlegada] [datetime] NULL,
 CONSTRAINT [PK__Turnos__C1ECF79A2C2DED90] PRIMARY KEY CLUSTERED 
(
	[IdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] NOT NULL,
	[NombreUsuario] [nvarchar](100) NOT NULL,
	[Contraseña] [nvarchar](100) NOT NULL,
	[Rol] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (2, 1)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (2, 2)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (2, 3)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (3, 1)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (4, 1)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (4, 2)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (4, 3)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (5, 1)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (5, 2)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (6, 1)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (6, 8)
GO
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI]) VALUES (1, N'Juan', N'Arano', N'asdnokasd', N'TEMP_1')
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI]) VALUES (2, N'Juan', N'Arano', N'aasdasd', N'TEMP_2')
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI]) VALUES (3, N'afsdf', N'sadfdasf', N'dsfsdf', N'234')
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI]) VALUES (4, N'Juan', N'Arano', N'asfdsdfsadf', N'45008773')
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI]) VALUES (5, N'Juan', N'Arano', N'MP4938432', N'45008771')
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI]) VALUES (6, N'Juan', N'Arano', N'dfsd', N'45008asd')
GO
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (1, N'Cardiología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (2, N'Dermatología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (3, N'Ginecología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (4, N'Pediatría')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (5, N'Oftalmología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (6, N'Neurología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (7, N'Urología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (8, N'Ortopedia')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (9, N'Psicología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (10, N'Oncología')
GO
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado]) VALUES (1, N'juana', N'akdsm', N'123', CAST(N'2024-09-29' AS Date), N'marcas', N'11232323', N'zdsad', N'Masculino', N'asdsad')
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado]) VALUES (2, N'jorege', N'adsasd', N'45008773', CAST(N'2024-09-29' AS Date), N'avsdfa', N'112389021', N'asdlasd', N'Masculino', N'numero')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Medicos_DNI]    Script Date: 9/30/2024 12:03:52 AM ******/
ALTER TABLE [dbo].[Medicos] ADD  CONSTRAINT [UC_Medicos_DNI] UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Medicos__0FB9FB4FB668B097]    Script Date: 9/30/2024 12:03:52 AM ******/
ALTER TABLE [dbo].[Medicos] ADD UNIQUE NONCLUSTERED 
(
	[Matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Paciente__C035B8DD0109F0C3]    Script Date: 9/30/2024 12:03:52 AM ******/
ALTER TABLE [dbo].[Pacientes] ADD  CONSTRAINT [UQ__Paciente__C035B8DD0109F0C3] UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuarios__6B0F5AE077FD4C3A]    Script Date: 9/30/2024 12:03:52 AM ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[NombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HistorialMedico]  WITH CHECK ADD FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medicos] ([IdMedico])
GO
ALTER TABLE [dbo].[HistorialMedico]  WITH CHECK ADD  CONSTRAINT [FK__Historial__IdPac__47DBAE45] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Pacientes] ([IdPaciente])
GO
ALTER TABLE [dbo].[HistorialMedico] CHECK CONSTRAINT [FK__Historial__IdPac__47DBAE45]
GO
ALTER TABLE [dbo].[MedicoEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK__MedicoEsp__IdEsp__778AC167] FOREIGN KEY([IdEspecialidad])
REFERENCES [dbo].[Mst_Especialidades] ([IdEspecialidad])
GO
ALTER TABLE [dbo].[MedicoEspecialidad] CHECK CONSTRAINT [FK__MedicoEsp__IdEsp__778AC167]
GO
ALTER TABLE [dbo].[MedicoEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK__MedicoEsp__IdMed__76969D2E] FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medicos] ([IdMedico])
GO
ALTER TABLE [dbo].[MedicoEspecialidad] CHECK CONSTRAINT [FK__MedicoEsp__IdMed__76969D2E]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK__Turnos__IdMedico__4AB81AF0] FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medicos] ([IdMedico])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK__Turnos__IdMedico__4AB81AF0]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK__Turnos__IdPacien__4BAC3F29] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Pacientes] ([IdPaciente])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK__Turnos__IdPacien__4BAC3F29]
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_ESPECIALIDAD]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_ESPECIALIDAD]
    @IdEspecialidad int,
	@Descripcion nvarchar(100)
AS
BEGIN
UPDATE Mst_Especialidades
SET Descripcion = @Descripcion
WHERE IdEspecialidad = @IdEspecialidad;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_PACIENTE]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_PACIENTE]
    @IdPaciente INT,
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @DNI NVARCHAR(10),
    @FechaNacimiento DATE,
    @Direccion NVARCHAR(255),
    @Telefono NVARCHAR(15),
    @Email NVARCHAR(100),
    @Genero NVARCHAR(20)
AS
BEGIN
    UPDATE Pacientes
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        DNI = @DNI,
        FechaNacimiento = @FechaNacimiento,
        Direccion = @Direccion,
        Telefono = @Telefono,
        Email = @Email,
        Genero = @Genero
    WHERE IdPaciente = @IdPaciente;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_TURNO]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_TURNO]
    @IdTurno INT,
    @IdPaciente INT,
    @IdMedico INT,
    @FechaTurno DATETIME,
    @MotivoConsulta NVARCHAR(255)
AS
BEGIN
    UPDATE Turnos
    SET IdPaciente = @IdPaciente,
        IdMedico = @IdMedico,
        FechaTurno = @FechaTurno,
        MotivoConsulta = @MotivoConsulta
    WHERE IdTurno = @IdTurno;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_ESPECIALIDAD]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_ESPECIALIDAD]
    @IdEspecialidad int
AS
BEGIN
    Delete from Mst_Especialidades where IdEspecialidad = @IdEspecialidad
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ESPECIALIDAD]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_ESPECIALIDAD]
    @Descripcion Nvarchar(100)
AS
BEGIN
    DECLARE @Id INT;
    SELECT @Id = COALESCE(MAX(IdTurno), 0) + 1 FROM Turnos;

    INSERT INTO MstMst_Especialidades(IdEspecialidad, Descripcion)
    VALUES (@Id, @Descripcion);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_HISTORIAL_MEDICO]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_HISTORIAL_MEDICO]
    @IdPaciente INT,
    @IdMedico INT,
    @Diagnostico NVARCHAR(255),
    @Tratamiento NVARCHAR(255),
    @FechaConsulta DATETIME
AS
BEGIN
    DECLARE @IdHistorial INT;
    SELECT @IdHistorial = COALESCE(MAX(IdHistorial), 0) + 1 FROM HistorialMedico;

    INSERT INTO HistorialMedico (IdHistorial, IdPaciente, IdMedico, Diagnostico, Tratamiento, FechaConsulta)
    VALUES (@IdHistorial, @IdPaciente, @IdMedico, @Diagnostico, @Tratamiento, @FechaConsulta);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MEDICO]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_MEDICO]
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Matricula NVARCHAR(50),
	@Dni NVARCHAR(15),
    @IdMedico INT OUTPUT -- Parámetro de salida
AS
BEGIN
    -- Generar el nuevo IdMedico manualmente
    SELECT @IdMedico = COALESCE(MAX(IdMedico), 0) + 1 FROM Medicos;

    -- Insertar el médico en la tabla con el IdMedico generado
    INSERT INTO Medicos (IdMedico, Nombre, Apellido, Dni, Matricula)
    VALUES (@IdMedico, @Nombre, @Apellido, @Dni, @Matricula);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MEDICO_ESPECIALIDAD]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_MEDICO_ESPECIALIDAD]
    @IdMedico INT,
    @IdEspecialidad INT
AS
BEGIN
    -- Verificar si ya existe la relación antes de insertar
    IF NOT EXISTS (SELECT 1 FROM MedicoEspecialidad WHERE IdMedico = @IdMedico AND IdEspecialidad = @IdEspecialidad)
    BEGIN
        INSERT INTO MedicoEspecialidad (IdMedico, IdEspecialidad)
        VALUES (@IdMedico, @IdEspecialidad);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_PACIENTE]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_PACIENTE]
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @DNI NVARCHAR(10),
    @FechaNacimiento DATE,
    @Direccion NVARCHAR(255),
	@NumeroDeAfiliado NVARCHAR(255),
    @Telefono NVARCHAR(15),
    @Email NVARCHAR(100),
    @Genero NVARCHAR(20)
AS
BEGIN
    DECLARE @IdPaciente INT;
    SELECT @IdPaciente = COALESCE(MAX(IdPaciente), 0) + 1 FROM Pacientes;

    INSERT INTO Pacientes (IdPaciente, Nombre, Apellido, DNI, NumeroDeAfiliado, FechaNacimiento, Direccion, Telefono, Email, Genero)
    VALUES (@IdPaciente, @Nombre, @Apellido, @DNI, @NumeroDeAfiliado, @FechaNacimiento, @Direccion, @Telefono, @Email, @Genero);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_TURNO]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_TURNO]
    @IdPaciente INT,
    @IdMedico INT,
    @FechaTurno DATETIME,
    @MotivoConsulta NVARCHAR(255)
AS
BEGIN
    DECLARE @IdTurno INT;
    SELECT @IdTurno = COALESCE(MAX(IdTurno), 0) + 1 FROM Turnos;

    INSERT INTO Turnos (IdTurno, IdPaciente, IdMedico, FechaTurno, MotivoConsulta)
    VALUES (@IdTurno, @IdPaciente, @IdMedico, @FechaTurno, @MotivoConsulta);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_USUARIO]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_USUARIO]
    @NombreUsuario NVARCHAR(100),
    @Contraseña NVARCHAR(100),
    @Rol NVARCHAR(50)
AS
BEGIN
    DECLARE @IdUsuario INT;
    SELECT @IdUsuario = COALESCE(MAX(IdUsuario), 0) + 1 FROM Usuarios;

    INSERT INTO Usuarios (IdUsuario, NombreUsuario, Contraseña, Rol)
    VALUES (@IdUsuario, @NombreUsuario, @Contraseña, @Rol);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_ESPECIALIDADES]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LISTAR_ESPECIALIDADES]
AS
BEGIN
    SELECT * FROM Mst_Especialidades;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_ESPECIALIDADES_POR_MEDICO]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LISTAR_ESPECIALIDADES_POR_MEDICO]
@IdMedico int
AS
BEGIN
	SET NOCOUNT ON;

	Select m.IdEspecialidad, m.Descripcion From MedicoEspecialidad e 
	inner join Mst_Especialidades m on m.IdEspecialidad = e.IdEspecialidad
	where IdMedico = @IdMedico
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_MEDICOS]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LISTAR_MEDICOS]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select * From Medicos
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_PACIENTES]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_LISTAR_PACIENTES]
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Pacientes
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_TURNOS]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LISTAR_TURNOS]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM Turnos
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LLEGADA_TURNO]    Script Date: 9/30/2024 12:03:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LLEGADA_TURNO]
	@IdTurno int,
	@FechaLlegada datetime
AS
BEGIN
	SET NOCOUNT ON;
	Update Turnos set FechaLlegada = @FechaLlegada where IdTurno = @IdTurno
END
GO
USE [master]
GO
ALTER DATABASE [TrabajoPractico] SET  READ_WRITE 
GO
