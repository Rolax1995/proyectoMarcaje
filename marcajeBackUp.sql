USE [master]
GO
/****** Object:  Database [marcajeUMG]    Script Date: 27/10/2023 23:32:30 ******/
CREATE DATABASE [marcajeUMG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'marcajeUMG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\marcajeUMG.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'marcajeUMG_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\marcajeUMG_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [marcajeUMG] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [marcajeUMG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [marcajeUMG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [marcajeUMG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [marcajeUMG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [marcajeUMG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [marcajeUMG] SET ARITHABORT OFF 
GO
ALTER DATABASE [marcajeUMG] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [marcajeUMG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [marcajeUMG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [marcajeUMG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [marcajeUMG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [marcajeUMG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [marcajeUMG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [marcajeUMG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [marcajeUMG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [marcajeUMG] SET  DISABLE_BROKER 
GO
ALTER DATABASE [marcajeUMG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [marcajeUMG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [marcajeUMG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [marcajeUMG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [marcajeUMG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [marcajeUMG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [marcajeUMG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [marcajeUMG] SET RECOVERY FULL 
GO
ALTER DATABASE [marcajeUMG] SET  MULTI_USER 
GO
ALTER DATABASE [marcajeUMG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [marcajeUMG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [marcajeUMG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [marcajeUMG] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [marcajeUMG] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [marcajeUMG] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'marcajeUMG', N'ON'
GO
ALTER DATABASE [marcajeUMG] SET QUERY_STORE = ON
GO
ALTER DATABASE [marcajeUMG] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [marcajeUMG]
GO
/****** Object:  Table [dbo].[Asignacion]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignacion](
	[idAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[idCurso] [int] NOT NULL,
	[idEstudiante] [int] NOT NULL,
 CONSTRAINT [PK_Asignacion] PRIMARY KEY CLUSTERED 
(
	[idAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asistencia]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencia](
	[idAsistencia] [int] IDENTITY(1,1) NOT NULL,
	[idCurso] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Asistencia] PRIMARY KEY CLUSTERED 
(
	[idAsistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[idCarrera] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[idCarrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Catedratico]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catedratico](
	[idCatedratico] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Catedratico] PRIMARY KEY CLUSTERED 
(
	[idCatedratico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Centro]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Centro](
	[idCentro] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Centro] PRIMARY KEY CLUSTERED 
(
	[idCentro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Centro_Carrera]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Centro_Carrera](
	[idCentro_Carrera] [int] IDENTITY(1,1) NOT NULL,
	[idCentro] [int] NOT NULL,
	[idCarrera] [int] NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_Centro_Carrera] PRIMARY KEY CLUSTERED 
(
	[idCentro_Carrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciclo]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciclo](
	[idCiclo] [int] IDENTITY(1,1) NOT NULL,
	[idCentro_Carrera] [int] NOT NULL,
	[idJornada] [int] NOT NULL,
	[grado] [varchar](10) NULL,
	[seccion] [char](1) NULL,
 CONSTRAINT [PK_Ciclo] PRIMARY KEY CLUSTERED 
(
	[idCiclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[idCurso] [int] IDENTITY(1,1) NOT NULL,
	[idCiclo] [int] NOT NULL,
	[idCatedratico] [int] NOT NULL,
	[idDia] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[horaInicio] [int] NOT NULL,
	[horaFin] [int] NOT NULL,
	[maxEstudiante] [int] NOT NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[idCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dias]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dias](
	[idDia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Dias] PRIMARY KEY CLUSTERED 
(
	[idDia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[idEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[carne] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[idEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jornada]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jornada](
	[idJornada] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[horaInicio] [int] NOT NULL,
	[horaFin] [int] NOT NULL,
 CONSTRAINT [PK_Jornada] PRIMARY KEY CLUSTERED 
(
	[idJornada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Usuario]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Usuario](
	[idTipo_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tip_Usuario] PRIMARY KEY CLUSTERED 
(
	[idTipo_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/10/2023 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idPropietario] [int] NOT NULL,
	[idTipo_Usuario] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[contraseña] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Ususario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Carrera] ON 

INSERT [dbo].[Carrera] ([idCarrera], [nombre]) VALUES (1, N'Ingenieria En Sistemas')
SET IDENTITY_INSERT [dbo].[Carrera] OFF
GO
SET IDENTITY_INSERT [dbo].[Catedratico] ON 

INSERT [dbo].[Catedratico] ([idCatedratico], [nombre], [telefono]) VALUES (1, N'Cristian Ramos', N'5555-4444')
INSERT [dbo].[Catedratico] ([idCatedratico], [nombre], [telefono]) VALUES (2, N'Miguel Barrientos', N'5555-8888')
SET IDENTITY_INSERT [dbo].[Catedratico] OFF
GO
SET IDENTITY_INSERT [dbo].[Centro] ON 

INSERT [dbo].[Centro] ([idCentro], [nombre], [direccion], [telefono]) VALUES (1, N'Antigua', N'Antigua Guatemala', N'78884444')
SET IDENTITY_INSERT [dbo].[Centro] OFF
GO
SET IDENTITY_INSERT [dbo].[Centro_Carrera] ON 

INSERT [dbo].[Centro_Carrera] ([idCentro_Carrera], [idCentro], [idCarrera], [fecha]) VALUES (1, 1, 1, CAST(N'2023-10-21' AS Date))
SET IDENTITY_INSERT [dbo].[Centro_Carrera] OFF
GO
SET IDENTITY_INSERT [dbo].[Dias] ON 

INSERT [dbo].[Dias] ([idDia], [nombre]) VALUES (1, N'Lunes')
INSERT [dbo].[Dias] ([idDia], [nombre]) VALUES (2, N'Martes')
INSERT [dbo].[Dias] ([idDia], [nombre]) VALUES (3, N'Miercoles')
INSERT [dbo].[Dias] ([idDia], [nombre]) VALUES (4, N'Jueves')
INSERT [dbo].[Dias] ([idDia], [nombre]) VALUES (5, N'Viernes')
INSERT [dbo].[Dias] ([idDia], [nombre]) VALUES (6, N'Sabado')
INSERT [dbo].[Dias] ([idDia], [nombre]) VALUES (7, N'Domingo')
SET IDENTITY_INSERT [dbo].[Dias] OFF
GO
SET IDENTITY_INSERT [dbo].[Estudiante] ON 

INSERT [dbo].[Estudiante] ([idEstudiante], [nombre], [telefono], [carne]) VALUES (1, N'Rolando Lopez', N'5014-2869', N'2294-16-12846')
INSERT [dbo].[Estudiante] ([idEstudiante], [nombre], [telefono], [carne]) VALUES (2, N'Gerardo Ulin', N'4044-5347', N'2294-18-3682')
SET IDENTITY_INSERT [dbo].[Estudiante] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipo_Usuario] ON 

INSERT [dbo].[Tipo_Usuario] ([idTipo_Usuario], [descripcion]) VALUES (1, N'admin')
INSERT [dbo].[Tipo_Usuario] ([idTipo_Usuario], [descripcion]) VALUES (2, N'maestro')
INSERT [dbo].[Tipo_Usuario] ([idTipo_Usuario], [descripcion]) VALUES (3, N'estudiante')
SET IDENTITY_INSERT [dbo].[Tipo_Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idUsuario], [idPropietario], [idTipo_Usuario], [nombre], [correo], [contraseña]) VALUES (1, 1, 2, N'Cris Ramos', N'cramos@miumg.edu.gt', N'Temporal123')
INSERT [dbo].[Usuario] ([idUsuario], [idPropietario], [idTipo_Usuario], [nombre], [correo], [contraseña]) VALUES (3, 2, 3, N'Fidel Gerardo', N'fulin@miumg.edu.gt', N'Temporal123')
INSERT [dbo].[Usuario] ([idUsuario], [idPropietario], [idTipo_Usuario], [nombre], [correo], [contraseña]) VALUES (4, 2, 1, N'Doc. Miguel Barr.', N'bbarrientos@miumg.edu.gt', N'Temporal123')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Asignacion]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Asignacion] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Curso] ([idCurso])
GO
ALTER TABLE [dbo].[Asignacion] CHECK CONSTRAINT [FK_Curso_Asignacion]
GO
ALTER TABLE [dbo].[Asignacion]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_Asignacion] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[Estudiante] ([idEstudiante])
GO
ALTER TABLE [dbo].[Asignacion] CHECK CONSTRAINT [FK_Estudiante_Asignacion]
GO
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Asistencia] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Curso] ([idCurso])
GO
ALTER TABLE [dbo].[Asistencia] CHECK CONSTRAINT [FK_Curso_Asistencia]
GO
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_Usuraio_Asistencia] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Asistencia] CHECK CONSTRAINT [FK_Usuraio_Asistencia]
GO
ALTER TABLE [dbo].[Centro_Carrera]  WITH CHECK ADD  CONSTRAINT [FK_Carrera_Centro_Carrera] FOREIGN KEY([idCarrera])
REFERENCES [dbo].[Carrera] ([idCarrera])
GO
ALTER TABLE [dbo].[Centro_Carrera] CHECK CONSTRAINT [FK_Carrera_Centro_Carrera]
GO
ALTER TABLE [dbo].[Centro_Carrera]  WITH CHECK ADD  CONSTRAINT [FK_Centro_Centro_Carrera] FOREIGN KEY([idCentro])
REFERENCES [dbo].[Centro] ([idCentro])
GO
ALTER TABLE [dbo].[Centro_Carrera] CHECK CONSTRAINT [FK_Centro_Centro_Carrera]
GO
ALTER TABLE [dbo].[Ciclo]  WITH CHECK ADD  CONSTRAINT [FK_Centro_Carrera_Ciclo] FOREIGN KEY([idCentro_Carrera])
REFERENCES [dbo].[Centro_Carrera] ([idCentro_Carrera])
GO
ALTER TABLE [dbo].[Ciclo] CHECK CONSTRAINT [FK_Centro_Carrera_Ciclo]
GO
ALTER TABLE [dbo].[Ciclo]  WITH CHECK ADD  CONSTRAINT [FK_Jornada_Ciclo] FOREIGN KEY([idJornada])
REFERENCES [dbo].[Jornada] ([idJornada])
GO
ALTER TABLE [dbo].[Ciclo] CHECK CONSTRAINT [FK_Jornada_Ciclo]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Catedratico_Curso] FOREIGN KEY([idCatedratico])
REFERENCES [dbo].[Catedratico] ([idCatedratico])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Catedratico_Curso]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Ciclo_Curso] FOREIGN KEY([idCiclo])
REFERENCES [dbo].[Ciclo] ([idCiclo])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Ciclo_Curso]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Dia_Curso] FOREIGN KEY([idDia])
REFERENCES [dbo].[Dias] ([idDia])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Dia_Curso]
GO
ALTER TABLE [dbo].[Usuario]  WITH NOCHECK ADD  CONSTRAINT [FK_Catedratico_Ususario] FOREIGN KEY([idPropietario])
REFERENCES [dbo].[Catedratico] ([idCatedratico])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Usuario] NOCHECK CONSTRAINT [FK_Catedratico_Ususario]
GO
ALTER TABLE [dbo].[Usuario]  WITH NOCHECK ADD  CONSTRAINT [FK_Estudiante_Ususario] FOREIGN KEY([idPropietario])
REFERENCES [dbo].[Estudiante] ([idEstudiante])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Usuario] NOCHECK CONSTRAINT [FK_Estudiante_Ususario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Ususario_Usuario] FOREIGN KEY([idTipo_Usuario])
REFERENCES [dbo].[Tipo_Usuario] ([idTipo_Usuario])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Tipo_Ususario_Usuario]
GO
USE [master]
GO
ALTER DATABASE [marcajeUMG] SET  READ_WRITE 
GO
