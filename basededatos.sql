USE [master]
GO
/****** Object:  Database [TrabajoPractico]    Script Date: 11/26/2024 10:44:51 PM ******/
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
/****** Object:  Table [dbo].[MedicoEspecialidad]    Script Date: 11/26/2024 10:44:51 PM ******/
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
/****** Object:  Table [dbo].[Medicos]    Script Date: 11/26/2024 10:44:51 PM ******/
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
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mst_Especialidades]    Script Date: 11/26/2024 10:44:51 PM ******/
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
/****** Object:  Table [dbo].[Pacientes]    Script Date: 11/26/2024 10:44:51 PM ******/
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
	[NumeroDeAfiliado] [nvarchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Paciente__C93DB49B4835A546] PRIMARY KEY CLUSTERED 
(
	[IdPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[IdTurno] [int] NOT NULL,
	[IdMedico] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[HoraLlegada] [datetime] NULL,
	[Motivo] [nvarchar](255) NULL,
	[Estado] [nvarchar](50) NOT NULL,
	[FechaCancelacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] NOT NULL,
	[NombreUsuario] [nvarchar](100) NOT NULL,
	[PasswordHash] [nvarchar](256) NULL,
	[Salt] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (1, 1)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (1, 2)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (2, 3)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (2, 4)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (3, 5)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (3, 6)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (4, 7)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (5, 8)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (6, 9)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (7, 10)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (8, 11)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (9, 12)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (10, 13)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (11, 1)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (11, 2)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (11, 3)
INSERT [dbo].[MedicoEspecialidad] ([IdMedico], [IdEspecialidad]) VALUES (11, 4)
GO
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI], [Activo]) VALUES (1, N'Alejandro', N'Sánchez', N'M12345', N'30012345', 1)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI], [Activo]) VALUES (2, N'Carolina', N'García', N'M54321', N'35067890', 1)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI], [Activo]) VALUES (3, N'Federico', N'Martínez', N'M67890', N'40023456', 1)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI], [Activo]) VALUES (4, N'Natalia', N'Hernández', N'M34567', N'45056789', 1)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI], [Activo]) VALUES (5, N'Gabriel', N'López', N'M78901', N'31012345', 1)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI], [Activo]) VALUES (6, N'Paula', N'Ríos', N'M23456', N'32023456', 1)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI], [Activo]) VALUES (7, N'Ricardo', N'Pérez', N'M89012', N'33034567', 1)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI], [Activo]) VALUES (8, N'Mariana', N'Silva', N'M45678', N'34045678', 1)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI], [Activo]) VALUES (9, N'Diego', N'Ramírez', N'M56789', N'36056789', 1)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI], [Activo]) VALUES (10, N'Claudia', N'Torres', N'M90123', N'37067890', 0)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Apellido], [Matricula], [DNI], [Activo]) VALUES (11, N'Lucila', N'Perez', N'aaaaa', N'444234234', 1)
GO
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (1, N'Cardiología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (2, N'Pediatría')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (3, N'Traumatología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (4, N'Neurología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (5, N'Dermatología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (6, N'Gastroenterología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (7, N'Oftalmología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (8, N'Oncología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (9, N'Psiquiatría')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (10, N'Otorrinolaringología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (11, N'Endocrinología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (12, N'Reumatología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (13, N'Urología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (14, N'Neumología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (15, N'Hematología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (16, N'Geriatría')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (17, N'Infectología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (18, N'Anestesiología')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (19, N'Cirugía General')
INSERT [dbo].[Mst_Especialidades] ([IdEspecialidad], [Descripcion]) VALUES (20, N'Medicina Interna')
GO
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado], [Activo]) VALUES (1, N'Juan', N'Pérez', N'45087773', CAST(N'1985-05-15' AS Date), N'Calle Falsa 123', N'1123456789', N'juan.perez@gmail.com', N'Masculino', N'A001', 1)
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado], [Activo]) VALUES (2, N'María', N'Gómez', N'38005678', CAST(N'1990-09-10' AS Date), N'Calle Verdadera 456', N'1145678910', N'maria.gomez@gmail.com', N'Femenino', N'A002', 1)
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado], [Activo]) VALUES (3, N'Carlos', N'López', N'42009876', CAST(N'1980-03-22' AS Date), N'Calle Real 789', N'1167890123', N'carlos.lopez@gmail.com', N'Masculino', N'A003', 1)
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado], [Activo]) VALUES (4, N'Ana', N'Martínez', N'41006789', CAST(N'1992-07-19' AS Date), N'Calle Azul 101', N'1122334455', N'ana.martinez@gmail.com', N'Femenino', N'A004', 1)
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado], [Activo]) VALUES (5, N'Jorge', N'González', N'47008945', CAST(N'1978-11-11' AS Date), N'Calle Amarilla 202', N'1178901234', N'jorge.gonzalez@gmail.com', N'Masculino', N'A005', 1)
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado], [Activo]) VALUES (6, N'Laura', N'Fernández', N'39004567', CAST(N'1986-03-05' AS Date), N'Calle Verde 303', N'1143210987', N'laura.fernandez@gmail.com', N'Femenino', N'A006', 1)
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado], [Activo]) VALUES (7, N'Luis', N'Rodríguez', N'43006789', CAST(N'1995-01-20' AS Date), N'Calle Naranja 404', N'1125678901', N'luis.rodriguez@gmail.com', N'Masculino', N'A007', 1)
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado], [Activo]) VALUES (8, N'Sofía', N'Blanco', N'40005678', CAST(N'1993-06-12' AS Date), N'Calle Blanca 505', N'1187654321', N'sofia.blanco@gmail.com', N'Femenino', N'A008', 1)
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado], [Activo]) VALUES (9, N'Pedro', N'Suárez', N'45008912', CAST(N'1988-12-30' AS Date), N'Calle Negra 606', N'1134567890', N'pedro.suarez@gmail.com', N'Masculino', N'A009', 1)
INSERT [dbo].[Pacientes] ([IdPaciente], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Email], [Genero], [NumeroDeAfiliado], [Activo]) VALUES (10, N'Marta', N'Díaz', N'46006745', CAST(N'1983-10-01' AS Date), N'Calle Roja 707', N'1145673210', N'marta.diaz@gmail.com', N'Femenino', N'A010', 0)
GO
INSERT [dbo].[Turnos] ([IdTurno], [IdMedico], [IdPaciente], [FechaHora], [HoraLlegada], [Motivo], [Estado], [FechaCancelacion]) VALUES (1, 11, 7, CAST(N'2024-11-25T12:30:56.000' AS DateTime), NULL, N'Motivo', N'Cancelado', CAST(N'2024-11-25T14:12:09.830' AS DateTime))
INSERT [dbo].[Turnos] ([IdTurno], [IdMedico], [IdPaciente], [FechaHora], [HoraLlegada], [Motivo], [Estado], [FechaCancelacion]) VALUES (2, 8, 5, CAST(N'2024-11-25T00:35:12.000' AS DateTime), NULL, N'Motivo', N'No Asistió', NULL)
GO
INSERT [dbo].[Usuarios] ([IdUsuario], [NombreUsuario], [PasswordHash], [Salt]) VALUES (1, N'admin', N'0xA6C13A3AD910508BD0D7FBF2EB020D53DE22A8B68E085FF5D7CA56406A4BAA4C', N'0241413B-4A52-41F0-AF25-092B49DB8E2F')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Medicos_DNI]    Script Date: 11/26/2024 10:44:51 PM ******/
ALTER TABLE [dbo].[Medicos] ADD  CONSTRAINT [UC_Medicos_DNI] UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Medicos__0FB9FB4F1AF5ABB7]    Script Date: 11/26/2024 10:44:51 PM ******/
ALTER TABLE [dbo].[Medicos] ADD UNIQUE NONCLUSTERED 
(
	[Matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Paciente__C035B8DDD1D09F1E]    Script Date: 11/26/2024 10:44:51 PM ******/
ALTER TABLE [dbo].[Pacientes] ADD  CONSTRAINT [UQ__Paciente__C035B8DDD1D09F1E] UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuarios__6B0F5AE066CA96D9]    Script Date: 11/26/2024 10:44:51 PM ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[NombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Medicos] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Pacientes] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Turnos] ADD  DEFAULT ('Pendiente') FOR [Estado]
GO
ALTER TABLE [dbo].[MedicoEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK__MedicoEsp__IdEsp__778AC167] FOREIGN KEY([IdEspecialidad])
REFERENCES [dbo].[Mst_Especialidades] ([IdEspecialidad])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicoEspecialidad] CHECK CONSTRAINT [FK__MedicoEsp__IdEsp__778AC167]
GO
ALTER TABLE [dbo].[MedicoEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK__MedicoEsp__IdMed__76969D2E] FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medicos] ([IdMedico])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicoEspecialidad] CHECK CONSTRAINT [FK__MedicoEsp__IdMed__76969D2E]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Medico] FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medicos] ([IdMedico])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_Medico]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Pacientes] ([IdPaciente])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_Paciente]
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_ESPECIALIDAD]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[SP_ACTUALIZAR_ESPECIALIDAD]
    @IdEspecialidad INT,
    @Descripcion NVARCHAR(100)
AS
BEGIN
    -- Verificamos si la especialidad existe antes de intentar actualizar
    IF EXISTS (SELECT 1 FROM Mst_Especialidades WHERE IdEspecialidad = @IdEspecialidad)
    BEGIN
        -- Realizamos la actualización
        UPDATE Mst_Especialidades
        SET Descripcion = @Descripcion
        WHERE IdEspecialidad = @IdEspecialidad;
    END
    ELSE
    BEGIN
        -- Opcional: Devuelve un mensaje si el IdEspecialidad no existe
        RAISERROR ('No se encontró una especialidad con el Id proporcionado.', 16, 1);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_ESTADO_MEDICO]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_ESTADO_MEDICO]
    @IdMedico INT,
    @Activo BIT
AS
BEGIN
    BEGIN TRANSACTION;

    -- Actualizar el estado de los turnos vencidos (más de 1 hora y 30 minutos después de la hora programada)
    UPDATE Turnos
    SET Estado = 'No Asistió'
    WHERE HoraLlegada IS NULL
      AND Estado = 'Pendiente'
      AND GETDATE() > DATEADD(MINUTE, 91, FechaHora);

    COMMIT TRANSACTION;

    SET NOCOUNT ON;

    -- Verificar si el médico existe
    IF NOT EXISTS (SELECT 1 FROM Medicos WHERE IdMedico = @IdMedico)
    BEGIN
        RAISERROR ('El médico no existe.', 16, 1);
        RETURN;
    END

    -- Verificar si el médico tiene turnos pendientes
    IF @Activo = 0 AND EXISTS (
        SELECT 1
        FROM Turnos
        WHERE IdMedico = @IdMedico AND Estado = 'Pendiente'
    )
    BEGIN
        RAISERROR ('El médico tiene turnos pendientes y no puede ser desactivado.', 16, 1);
        RETURN;
    END

    -- Actualizar el estado del médico
    UPDATE Medicos
    SET Activo = @Activo
    WHERE IdMedico = @IdMedico;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_ESTADO_PACIENTE]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_ESTADO_PACIENTE]
    @IdPaciente INT,
    @Activo BIT
AS
BEGIN
    SET NOCOUNT ON;

	    BEGIN TRANSACTION;

    -- Actualizar el estado de los turnos vencidos (más de 1 hora y 30 minutos después de la hora programada)
    UPDATE Turnos
    SET Estado = 'No Asistió'
    WHERE HoraLlegada IS NULL
      AND Estado = 'Pendiente'
      AND GETDATE() > DATEADD(MINUTE, 91, FechaHora);

    COMMIT TRANSACTION;


    -- Verificar si el paciente existe
    IF NOT EXISTS (SELECT 1 FROM Pacientes WHERE IdPaciente = @IdPaciente)
    BEGIN
        RAISERROR ('El paciente no existe.', 16, 1);
        RETURN;
    END

    -- Verificar si el paciente tiene turnos pendientes
    IF @Activo = 0 AND EXISTS (
        SELECT 1
        FROM Turnos
        WHERE IdPaciente = @IdPaciente AND Estado = 'Pendiente'
    )
    BEGIN
        RAISERROR ('El paciente tiene turnos pendientes y no puede ser desactivado.', 16, 1);
        RETURN;
    END

    -- Actualizar el estado del paciente
    UPDATE Pacientes
    SET Activo = @Activo
    WHERE IdPaciente = @IdPaciente;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_MEDICO]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_MEDICO]
    @IdMedico INT,
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Matricula NVARCHAR(50),
    @Dni NVARCHAR(10)
AS
BEGIN
    -- Verificar que el DNI no esté duplicado en otro registro
    IF EXISTS (
        SELECT 1 
        FROM Medicos 
        WHERE Dni = @Dni AND IdMedico <> @IdMedico
    )
    BEGIN
        RAISERROR ('El DNI ya está registrado en otro médico.', 16, 1);
        RETURN;
    END

    -- Verificar que la Matrícula no esté duplicada en otro registro
    IF EXISTS (
        SELECT 1 
        FROM Medicos 
        WHERE Matricula = @Matricula AND IdMedico <> @IdMedico
    )
    BEGIN
        RAISERROR ('La matrícula ya está registrada en otro médico.', 16, 1);
        RETURN;
    END

    -- Actualizar los datos del médico
    UPDATE Medicos
    SET
        Nombre = @Nombre,
        Apellido = @Apellido,
        Matricula = @Matricula,
        Dni = @Dni
    WHERE IdMedico = @IdMedico;

    PRINT 'Médico actualizado correctamente.';
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_PACIENTE]    Script Date: 11/26/2024 10:44:51 PM ******/
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
    @Genero NVARCHAR(20),
    @NumeroDeAfiliado NVARCHAR(100)
AS
BEGIN
    -- Depuración para verificar los valores que llegan
    PRINT 'IdPaciente: ' + CAST(@IdPaciente AS NVARCHAR)
    PRINT 'DNI: ' + @DNI
    PRINT 'NumeroDeAfiliado: ' + @NumeroDeAfiliado

    -- Verificar que el DNI no esté duplicado en otro registro
    IF EXISTS (
        SELECT 1 
        FROM Pacientes 
        WHERE DNI = @DNI AND IdPaciente <> @IdPaciente
    )
    BEGIN
        RAISERROR ('El DNI ya está registrado en otro paciente.', 16, 1);
        RETURN;
    END

    -- Verificar que el Número de Afiliado no esté duplicado en otro registro
    IF EXISTS (
        SELECT 1 
        FROM Pacientes 
        WHERE NumeroDeAfiliado = @NumeroDeAfiliado AND IdPaciente <> @IdPaciente
    )
    BEGIN
        RAISERROR ('El Número de Afiliado ya está registrado en otro paciente.', 16, 1);
        RETURN;
    END

    -- Actualizar los datos del paciente
    UPDATE Pacientes
    SET
        Nombre = @Nombre,
        Apellido = @Apellido,
        DNI = @DNI,
        FechaNacimiento = @FechaNacimiento,
        Direccion = @Direccion,
        Telefono = @Telefono,
        Email = @Email,
        Genero = @Genero,
        NumeroDeAfiliado = @NumeroDeAfiliado
    WHERE IdPaciente = @IdPaciente;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_USUARIO]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_USUARIO]
    @Id INT,
    @Username NVARCHAR(50),
    @Password NVARCHAR(50) = NULL -- Contraseña opcional
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar que el Username no esté duplicado en otro registro
    IF EXISTS (SELECT 1 FROM Usuarios WHERE NombreUsuario = @Username AND IdUsuario <> @Id)
    BEGIN
        RAISERROR ('El nombre de usuario ya está registrado.', 16, 1);
        RETURN;
    END

    -- Verificar si se proporcionó una contraseña
    IF @Password IS NOT NULL
    BEGIN
        -- Generar un nuevo salt y hash para la contraseña
        DECLARE @Salt NVARCHAR(128) = CONVERT(NVARCHAR(128), NEWID());
        DECLARE @PasswordHash NVARCHAR(256);

        -- Combinar la contraseña con el salt y hashear el resultado
        SET @PasswordHash = CONVERT(NVARCHAR(256), HASHBYTES('SHA2_256', @Password + @Salt), 1);

        -- Actualizar el nombre de usuario y la contraseña
        UPDATE Usuarios
        SET
            NombreUsuario = @Username,
            PasswordHash = @PasswordHash,
            Salt = @Salt
        WHERE IdUsuario = @Id;
    END
    ELSE
    BEGIN
        -- Solo actualizar el nombre de usuario
        UPDATE Usuarios
        SET NombreUsuario = @Username
        WHERE IdUsuario = @Id;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_CANCELAR_TURNO]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CANCELAR_TURNO]
    @IdTurno INT
AS
BEGIN
    -- Verificar que el turno exista
    IF NOT EXISTS (
        SELECT 1 FROM Turnos WHERE IdTurno = @IdTurno
    )
    BEGIN
        RAISERROR ('El turno no existe.', 16, 1);
        RETURN;
    END

    -- Verificar que el turno no haya sido presentado
    IF EXISTS (
        SELECT 1 FROM Turnos WHERE IdTurno = @IdTurno AND Estado = 'Asistió'
    )
    BEGIN
        RAISERROR ('No se puede cancelar un turno que ya fue presentado.', 16, 1);
        RETURN;
    END

    -- Verificar que el turno no haya sido cancelado ya
    IF EXISTS (
        SELECT 1 FROM Turnos WHERE IdTurno = @IdTurno AND Estado = 'Cancelado'
    )
    BEGIN
        RAISERROR ('El turno ya está cancelado.', 16, 1);
        RETURN;
    END

    -- Verificar que no haya pasado más de 1 hora y 30 minutos de la fecha de presentación
    IF EXISTS (
        SELECT 1 FROM Turnos
        WHERE IdTurno = @IdTurno
          AND GETDATE() > DATEADD(MINUTE, 90, FechaHora)
    )
    BEGIN
        RAISERROR ('No se puede cancelar un turno después de 1 hora y 30 minutos de la fecha de presentación.', 16, 1);
        RETURN;
    END

    -- Cancelar el turno (cambiar su estado a 'Cancelado' y registrar la fecha de cancelación)
    UPDATE Turnos
    SET Estado = 'Cancelado',
        FechaCancelacion = GETDATE()
    WHERE IdTurno = @IdTurno;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_ESPECIALIDADES_POR_MEDICO]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_ELIMINAR_ESPECIALIDADES_POR_MEDICO]
    @IdMedico INT
AS
BEGIN
    DELETE FROM MedicoEspecialidad
    WHERE IdMedico = @IdMedico;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_TURNO]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ELIMINAR_TURNO]
    @IdTurno INT
AS
BEGIN
    -- Verificar que el turno exista
    IF NOT EXISTS (
        SELECT 1 FROM Turnos WHERE IdTurno = @IdTurno
    )
    BEGIN
        RAISERROR ('El turno no existe.', 16, 1);
        RETURN;
    END

    -- Verificar que el turno no haya sido presentado
    IF EXISTS (
        SELECT 1 FROM Turnos WHERE IdTurno = @IdTurno AND Estado = 'Asistió'
    )
    BEGIN
        RAISERROR ('No se puede eliminar un turno que ya fue presentado.', 16, 1);
        RETURN;
    END

    -- Verificar que el turno no haya sido cancelado ya
    IF EXISTS (
        SELECT 1 FROM Turnos WHERE IdTurno = @IdTurno AND Estado = 'Cancelado'
    )
    BEGIN
        RAISERROR ('No se puede eliminar un turno que ya fue cancelado.', 16, 1);
        RETURN;
    END

    -- Verificar que no haya pasado más de 1 hora y 30 minutos de la fecha de presentación
    IF EXISTS (
        SELECT 1 FROM Turnos
        WHERE IdTurno = @IdTurno
          AND GETDATE() > DATEADD(MINUTE, 90, FechaHora)
    )
    BEGIN
        RAISERROR ('No se puede eliminar un turno después de 1 hora y 30 minutos de la fecha de presentación.', 16, 1);
        RETURN;
    END

    -- Eliminar el turno
    DELETE FROM Turnos
    WHERE IdTurno = @IdTurno;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_USUARIO]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ELIMINAR_USUARIO]
@IdUsuario int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Usuarios where IdUsuario = @IdUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ESPECIALIDAD]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_ESPECIALIDAD]
    @Descripcion NVARCHAR(100)
AS
BEGIN
    -- Verificar si ya existe una especialidad con la misma descripción
    IF EXISTS (SELECT 1 FROM Mst_Especialidades WHERE Descripcion = @Descripcion)
    BEGIN
        -- Si existe, lanzar un error personalizado
        RAISERROR ('Ya existe una especialidad con la misma descripción.', 16, 1);
        RETURN;
    END;

    -- Declarar el nuevo ID de la especialidad
    DECLARE @IdEspecialidad INT;

    -- Calcular el nuevo ID como el siguiente número consecutivo
    SELECT @IdEspecialidad = COALESCE(MAX(IdEspecialidad), 0) + 1 FROM Mst_Especialidades;

    -- Insertar la nueva especialidad
    INSERT INTO Mst_Especialidades (IdEspecialidad, Descripcion)
    VALUES (@IdEspecialidad, @Descripcion);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MEDICO]    Script Date: 11/26/2024 10:44:51 PM ******/
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
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verificar que el DNI no esté duplicado
        IF EXISTS (
            SELECT 1 
            FROM Medicos 
            WHERE Dni = @Dni
        )
        BEGIN
            RAISERROR ('El DNI ya está registrado en otro médico.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Verificar que la matrícula no esté duplicada
        IF EXISTS (
            SELECT 1 
            FROM Medicos 
            WHERE Matricula = @Matricula
        )
        BEGIN
            RAISERROR ('La matrícula ya está registrada en otro médico.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Generar el nuevo IdMedico
        SELECT @IdMedico = COALESCE(MAX(IdMedico), 0) + 1 FROM Medicos;

        -- Insertar el médico en la tabla
        INSERT INTO Medicos (IdMedico, Nombre, Apellido, Dni, Matricula)
        VALUES (@IdMedico, @Nombre, @Apellido, @Dni, @Matricula);

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
        -- Manejo de errores
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Relevantar el error
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MEDICO_ESPECIALIDAD]    Script Date: 11/26/2024 10:44:51 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_PACIENTE]    Script Date: 11/26/2024 10:44:51 PM ******/
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
    @Telefono NVARCHAR(15),
    @Email NVARCHAR(100),
    @Genero NVARCHAR(20),
    @NumeroDeAfiliado NVARCHAR(100)
AS
BEGIN
    -- Verificar si ya existe un paciente con el mismo DNI
    IF EXISTS (SELECT 1 FROM Pacientes WHERE DNI = @DNI)
    BEGIN
        RAISERROR ('El DNI ya está registrado.', 16, 1);
        RETURN;
    END

    -- Verificar si ya existe un paciente con el mismo NumeroDeAfiliado
    IF EXISTS (SELECT 1 FROM Pacientes WHERE NumeroDeAfiliado = @NumeroDeAfiliado)
    BEGIN
        RAISERROR ('El Número de Afiliado ya está registrado.', 16, 1);
        RETURN;
    END

    -- Calcular el nuevo IdPaciente
    DECLARE @IdPaciente INT;
    SELECT @IdPaciente = COALESCE(MAX(IdPaciente), 0) + 1 FROM Pacientes;

    -- Insertar el nuevo paciente
    INSERT INTO Pacientes (IdPaciente, Nombre, Apellido, DNI, FechaNacimiento, Direccion, Telefono, Email, Genero, NumeroDeAfiliado)
    VALUES (@IdPaciente, @Nombre, @Apellido, @DNI, @FechaNacimiento, @Direccion, @Telefono, @Email, @Genero, @NumeroDeAfiliado);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_TURNO]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_INSERTAR_TURNO]
    @IdMedico INT,
    @IdPaciente INT,
    @FechaHora DATETIME,
    @Motivo NVARCHAR(255),
    @IdTurno INT OUTPUT -- Parámetro de salida para el ID
AS
BEGIN
    -- Verificar que el paciente esté activo
    IF NOT EXISTS (
        SELECT 1 
        FROM Pacientes
        WHERE IdPaciente = @IdPaciente AND Activo = 1
    )
    BEGIN
        RAISERROR ('El paciente no está activo.', 16, 1);
        RETURN;
    END

    -- Generar el nuevo IdTurno
    SELECT @IdTurno = COALESCE(MAX(IdTurno), 0) + 1 FROM Turnos;

    -- Verificar disponibilidad del médico
    IF EXISTS (
        SELECT 1 
        FROM Turnos
        WHERE IdMedico = @IdMedico AND FechaHora = @FechaHora AND Estado IN ('Pendiente', 'Asistió')
    )
    BEGIN
        RAISERROR ('El médico ya tiene un turno asignado en esta fecha y hora.', 16, 1);
        RETURN;
    END

    -- Verificar que el paciente no tenga otro turno al mismo tiempo
    IF EXISTS (
        SELECT 1 
        FROM Turnos
        WHERE IdPaciente = @IdPaciente AND FechaHora = @FechaHora AND Estado IN ('Pendiente', 'Asistió')
    )
    BEGIN
        RAISERROR ('El paciente ya tiene un turno asignado en esta fecha y hora.', 16, 1);
        RETURN;
    END

    -- Insertar el turno con estado inicial "Pendiente"
    INSERT INTO Turnos (IdTurno, IdMedico, IdPaciente, FechaHora, Motivo, Estado)
    VALUES (@IdTurno, @IdMedico, @IdPaciente, @FechaHora, @Motivo, 'Pendiente');
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_USUARIO]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_INSERTAR_USUARIO]
    @Username NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    -- Genera un salt único usando NEWID()
    DECLARE @Salt NVARCHAR(128) = CONVERT(NVARCHAR(128), NEWID()) 
    DECLARE @PasswordHash NVARCHAR(256)

    -- Calcular el nuevo IdUsuario basado en el máximo existente
    DECLARE @Id INT
    SELECT @Id = COALESCE(MAX(IdUsuario), 0) + 1 FROM Usuarios;

    -- Combina la contraseña con el salt y hashea el resultado
    SET @PasswordHash = CONVERT(NVARCHAR(256), HASHBYTES('SHA2_256', @Password + @Salt), 1)

    -- Insertar el usuario en la base de datos con su salt y hash de contraseña
    INSERT INTO Usuarios (IdUsuario, NombreUsuario, PasswordHash, Salt)
    VALUES (@Id, @Username, @PasswordHash, @Salt)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_ESPECIALIDADES]    Script Date: 11/26/2024 10:44:51 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_ESPECIALIDADES_POR_MEDICO]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LISTAR_ESPECIALIDADES_POR_MEDICO]
@IdMedico int
AS
BEGIN
	SET NOCOUNT ON;

	Select * From MedicoEspecialidad where IdMedico = @IdMedico
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_MEDICOS]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_LISTAR_MEDICOS]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        m.IdMedico,
        m.Nombre,
        m.Apellido,
        m.Dni,
		m.Activo,
        m.Matricula,
        ISNULL(STRING_AGG(e.Descripcion, ', '), 'Sin Especialidades') AS Especialidades
    FROM Medicos m
    LEFT JOIN MedicoEspecialidad me ON m.IdMedico = me.IdMedico
    LEFT JOIN Mst_Especialidades e ON me.IdEspecialidad = e.IdEspecialidad
    GROUP BY 
        m.IdMedico,
        m.Nombre,
        m.Apellido,
        m.Dni,
		m.Activo,
        m.Matricula
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_MEDICOS_ACTIVOS]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[SP_LISTAR_MEDICOS_ACTIVOS]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        m.IdMedico,
        m.Nombre,
        m.Apellido,
        m.Dni,
        m.Activo,
        m.Matricula,
        ISNULL(STRING_AGG(e.Descripcion, ', '), 'Sin Especialidades') AS Especialidades
    FROM Medicos m
    LEFT JOIN MedicoEspecialidad me ON m.IdMedico = me.IdMedico
    LEFT JOIN Mst_Especialidades e ON me.IdEspecialidad = e.IdEspecialidad
    WHERE m.Activo = 1
    GROUP BY 
        m.IdMedico,
        m.Nombre,
        m.Apellido,
        m.Dni,
        m.Activo,
        m.Matricula;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_PACIENTES]    Script Date: 11/26/2024 10:44:51 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_PACIENTES_ACTIVOS]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[SP_LISTAR_PACIENTES_ACTIVOS]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.IdPaciente,
        p.Nombre,
        p.Apellido,
        p.DNI,
        p.FechaNacimiento,
        p.Direccion,
        p.Telefono,
        p.Email,
        p.Genero,
        p.NumeroDeAfiliado,
        p.Activo
    FROM Pacientes p
    WHERE p.Activo = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_TURNOS]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_LISTAR_TURNOS]
    @FechaInicio DATETIME = NULL,
    @FechaFin DATETIME = NULL,
    @IdMedico INT = NULL,
    @IdPaciente INT = NULL
AS
BEGIN
    BEGIN TRANSACTION;

    -- Actualizar el estado de los turnos vencidos (más de 1 hora y 30 minutos después de la hora programada)
    UPDATE Turnos
    SET Estado = 'No Asistió'
    WHERE HoraLlegada IS NULL
      AND Estado = 'Pendiente'
      AND GETDATE() > DATEADD(MINUTE, 91, FechaHora);

    COMMIT TRANSACTION;

    -- Listar los turnos con el estado actualizado
    SELECT 
        t.IdTurno, 
        t.FechaHora, 
        t.Motivo,
        t.Estado,
        t.HoraLlegada,
        m.Nombre AS NombreMedico, 
        m.Apellido AS ApellidoMedico,
        m.Dni AS DniMedico,
        p.Nombre AS NombrePaciente, 
        p.Apellido AS ApellidoPaciente,
        p.Dni AS DniPaciente,
        t.IdMedico,
        t.IdPaciente
    FROM Turnos t
    INNER JOIN Medicos m ON t.IdMedico = m.IdMedico
    INNER JOIN Pacientes p ON t.IdPaciente = p.IdPaciente
    WHERE (@FechaInicio IS NULL OR t.FechaHora >= @FechaInicio)
      AND (@FechaFin IS NULL OR t.FechaHora <= @FechaFin)
      AND (@IdMedico IS NULL OR t.IdMedico = @IdMedico)
      AND (@IdPaciente IS NULL OR t.IdPaciente = @IdPaciente)
    ORDER BY t.FechaHora;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_USUARIOS]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_LISTAR_USUARIOS]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from Usuarios
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LOGIN_USUARIO]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LOGIN_USUARIO]
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @IsAuthenticated BIT OUTPUT
AS
BEGIN
    DECLARE @StoredHash NVARCHAR(256)
    DECLARE @StoredSalt NVARCHAR(128)
    DECLARE @LoginHash NVARCHAR(256)

    -- Obtener el hash y el salt almacenados para el usuario
    SELECT @StoredHash = PasswordHash, @StoredSalt = Salt
    FROM Usuarios
    WHERE NombreUsuario = @Username

    -- Si el usuario no existe, retornar fallo de autenticación
    IF @StoredHash IS NULL
    BEGIN
        SET @IsAuthenticated = 0
        RETURN
    END

    -- Hashear la contraseña proporcionada con el salt del usuario
    SET @LoginHash = CONVERT(NVARCHAR(256), HASHBYTES('SHA2_256', @Password + @StoredSalt), 1)

    -- Comparar el hash de la contraseña proporcionada con el hash almacenado
    IF @LoginHash = @StoredHash
        SET @IsAuthenticated = 1
    ELSE
        SET @IsAuthenticated = 0
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_LLEGADA]    Script Date: 11/26/2024 10:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_REGISTRAR_LLEGADA]
    @IdTurno INT,
    @HoraLlegada DATETIME
AS
BEGIN
    -- Verificar que el turno exista
    IF NOT EXISTS (
        SELECT 1 FROM Turnos WHERE IdTurno = @IdTurno
    )
    BEGIN
        RAISERROR ('El turno no existe.', 16, 1);
        RETURN;
    END

    -- Verificar si el turno ya está registrado como "Asistió"
    IF EXISTS (
        SELECT 1 
        FROM Turnos 
        WHERE IdTurno = @IdTurno AND Estado = 'Asistió'
    )
    BEGIN
        RAISERROR ('El turno ya fue presentado.', 16, 1);
        RETURN;
    END

    -- Obtener la fecha y hora del turno
    DECLARE @FechaHoraTurno DATETIME;
    SELECT @FechaHoraTurno = FechaHora FROM Turnos WHERE IdTurno = @IdTurno;

    -- Verificar que la llegada esté dentro del rango permitido (1 hora y media antes o después del turno)
    IF @HoraLlegada < DATEADD(MINUTE, -90, @FechaHoraTurno) OR @HoraLlegada > DATEADD(MINUTE, 90, @FechaHoraTurno)
    BEGIN
        RAISERROR ('La hora de llegada está fuera del rango permitido (1 hora y media antes o después del turno).', 16, 1);
        RETURN;
    END

    -- Registrar la llegada y cambiar el estado a "Asistió"
    UPDATE Turnos
    SET HoraLlegada = @HoraLlegada, Estado = 'Asistió'
    WHERE IdTurno = @IdTurno;
END;
GO
USE [master]
GO
ALTER DATABASE [TrabajoPractico] SET  READ_WRITE 
GO
