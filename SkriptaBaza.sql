USE [master]
GO
/****** Object:  Database [AptRentSoft]    Script Date: 8/30/2024 1:07:22 AM ******/
CREATE DATABASE [AptRentSoft]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AptRentSoft', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AptRentSoft.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AptRentSoft_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AptRentSoft_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AptRentSoft] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AptRentSoft].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AptRentSoft] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AptRentSoft] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AptRentSoft] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AptRentSoft] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AptRentSoft] SET ARITHABORT OFF 
GO
ALTER DATABASE [AptRentSoft] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AptRentSoft] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AptRentSoft] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AptRentSoft] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AptRentSoft] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AptRentSoft] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AptRentSoft] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AptRentSoft] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AptRentSoft] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AptRentSoft] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AptRentSoft] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AptRentSoft] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AptRentSoft] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AptRentSoft] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AptRentSoft] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AptRentSoft] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AptRentSoft] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AptRentSoft] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AptRentSoft] SET  MULTI_USER 
GO
ALTER DATABASE [AptRentSoft] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AptRentSoft] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AptRentSoft] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AptRentSoft] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AptRentSoft] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AptRentSoft] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AptRentSoft] SET QUERY_STORE = ON
GO
ALTER DATABASE [AptRentSoft] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AptRentSoft]
GO
/****** Object:  Table [dbo].[Apartman]    Script Date: 8/30/2024 1:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartman](
	[DomacinstvoID] [int] NOT NULL,
	[ApartmanID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [varchar](50) NOT NULL,
	[ProsecnaOcena] [float] NULL,
 CONSTRAINT [PK_Apartman] PRIMARY KEY CLUSTERED 
(
	[DomacinstvoID] ASC,
	[ApartmanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domacinstvo]    Script Date: 8/30/2024 1:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domacinstvo](
	[DomacinstvoID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [varchar](50) NOT NULL,
	[BrojApartmana] [int] NULL,
 CONSTRAINT [PK_Domacinstvo] PRIMARY KEY CLUSTERED 
(
	[DomacinstvoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OcenaApartmana]    Script Date: 8/30/2024 1:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OcenaApartmana](
	[DomacinstvoID] [int] NOT NULL,
	[ApartmanID] [int] NOT NULL,
	[GostID] [int] NOT NULL,
	[OcenaApartmana] [int] NULL,
 CONSTRAINT [PK_OcenaApartmana] PRIMARY KEY CLUSTERED 
(
	[DomacinstvoID] ASC,
	[ApartmanID] ASC,
	[GostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rezervacija]    Script Date: 8/30/2024 1:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rezervacija](
	[RezervacijaID] [varchar](50) NOT NULL,
	[ApartmanID] [int] NOT NULL,
	[GostID] [int] NOT NULL,
	[DatumOd] [datetime] NULL,
	[DatumDo] [datetime] NULL,
	[DomacinstvoID] [int] NOT NULL,
 CONSTRAINT [PK_Rezervacija] PRIMARY KEY CLUSTERED 
(
	[RezervacijaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/30/2024 1:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](10) NOT NULL,
	[Ime] [varchar](50) NOT NULL,
	[Prezime] [varchar](50) NOT NULL,
	[Uloga] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Apartman] ON 
GO
INSERT [dbo].[Apartman] ([DomacinstvoID], [ApartmanID], [Naziv], [ProsecnaOcena]) VALUES (41, 70, N'Jelena', 0)
GO
INSERT [dbo].[Apartman] ([DomacinstvoID], [ApartmanID], [Naziv], [ProsecnaOcena]) VALUES (41, 71, N'Milena', 0)
GO
INSERT [dbo].[Apartman] ([DomacinstvoID], [ApartmanID], [Naziv], [ProsecnaOcena]) VALUES (41, 72, N'Regina', 0)
GO
INSERT [dbo].[Apartman] ([DomacinstvoID], [ApartmanID], [Naziv], [ProsecnaOcena]) VALUES (41, 75, N'Rak', 0)
GO
INSERT [dbo].[Apartman] ([DomacinstvoID], [ApartmanID], [Naziv], [ProsecnaOcena]) VALUES (41, 76, N'Sesti sprat', 4)
GO
INSERT [dbo].[Apartman] ([DomacinstvoID], [ApartmanID], [Naziv], [ProsecnaOcena]) VALUES (42, 73, N'Topola', 0)
GO
INSERT [dbo].[Apartman] ([DomacinstvoID], [ApartmanID], [Naziv], [ProsecnaOcena]) VALUES (42, 74, N'Borko', 0)
GO
INSERT [dbo].[Apartman] ([DomacinstvoID], [ApartmanID], [Naziv], [ProsecnaOcena]) VALUES (45, 78, N'Dusan', 0)
GO
SET IDENTITY_INSERT [dbo].[Apartman] OFF
GO
SET IDENTITY_INSERT [dbo].[Domacinstvo] ON 
GO
INSERT [dbo].[Domacinstvo] ([DomacinstvoID], [Naziv], [BrojApartmana]) VALUES (41, N'Bugi apartmani Kotor', 5)
GO
INSERT [dbo].[Domacinstvo] ([DomacinstvoID], [Naziv], [BrojApartmana]) VALUES (42, N'Domacinstvo Peric Zlatibor', 2)
GO
INSERT [dbo].[Domacinstvo] ([DomacinstvoID], [Naziv], [BrojApartmana]) VALUES (45, N'Dom u srcu mom', 1)
GO
SET IDENTITY_INSERT [dbo].[Domacinstvo] OFF
GO
INSERT [dbo].[OcenaApartmana] ([DomacinstvoID], [ApartmanID], [GostID], [OcenaApartmana]) VALUES (41, 76, 3, 4)
GO
INSERT [dbo].[Rezervacija] ([RezervacijaID], [ApartmanID], [GostID], [DatumOd], [DatumDo], [DomacinstvoID]) VALUES (N'KatarinaJovanovic4176192024292024', 76, 3, CAST(N'2024-09-01T00:00:00.000' AS DateTime), CAST(N'2024-09-02T00:00:00.000' AS DateTime), 41)
GO
INSERT [dbo].[Rezervacija] ([RezervacijaID], [ApartmanID], [GostID], [DatumOd], [DatumDo], [DomacinstvoID]) VALUES (N'MarkoMarkovic4170592024892024', 70, 4, CAST(N'2024-09-05T00:00:00.000' AS DateTime), CAST(N'2024-09-08T00:00:00.000' AS DateTime), 41)
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Username], [Password], [Ime], [Prezime], [Uloga]) VALUES (1, N'mikimiki123', N'123123', N'Milos', N'Prorocic', 0)
GO
INSERT [dbo].[User] ([Id], [Username], [Password], [Ime], [Prezime], [Uloga]) VALUES (3, N'kikikiki', N'321321', N'Katarina', N'Jovanovic', 1)
GO
INSERT [dbo].[User] ([Id], [Username], [Password], [Ime], [Prezime], [Uloga]) VALUES (4, N'lele', N'lele', N'Marko', N'Markovic', 1)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Apartman]  WITH CHECK ADD  CONSTRAINT [FK_Apartman_Domacinstvo1] FOREIGN KEY([DomacinstvoID])
REFERENCES [dbo].[Domacinstvo] ([DomacinstvoID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Apartman] CHECK CONSTRAINT [FK_Apartman_Domacinstvo1]
GO
ALTER TABLE [dbo].[OcenaApartmana]  WITH CHECK ADD  CONSTRAINT [FK_OcenaApartmana_Apartman] FOREIGN KEY([DomacinstvoID], [ApartmanID])
REFERENCES [dbo].[Apartman] ([DomacinstvoID], [ApartmanID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[OcenaApartmana] CHECK CONSTRAINT [FK_OcenaApartmana_Apartman]
GO
ALTER TABLE [dbo].[OcenaApartmana]  WITH CHECK ADD  CONSTRAINT [FK_OcenaApartmana_User] FOREIGN KEY([GostID])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[OcenaApartmana] CHECK CONSTRAINT [FK_OcenaApartmana_User]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [FK_Rezervacija_Apartman] FOREIGN KEY([DomacinstvoID], [ApartmanID])
REFERENCES [dbo].[Apartman] ([DomacinstvoID], [ApartmanID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [FK_Rezervacija_Apartman]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [FK_Rezervacija_User] FOREIGN KEY([GostID])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [FK_Rezervacija_User]
GO
ALTER TABLE [dbo].[Apartman]  WITH CHECK ADD  CONSTRAINT [CK_Apartman] CHECK  (([DomacinstvoID]>(0)))
GO
ALTER TABLE [dbo].[Apartman] CHECK CONSTRAINT [CK_Apartman]
GO
ALTER TABLE [dbo].[Apartman]  WITH CHECK ADD  CONSTRAINT [CK_Apartman_1] CHECK  (([ApartmanID]>(0)))
GO
ALTER TABLE [dbo].[Apartman] CHECK CONSTRAINT [CK_Apartman_1]
GO
ALTER TABLE [dbo].[Apartman]  WITH CHECK ADD  CONSTRAINT [CK_Apartman_2] CHECK  (([ProsecnaOcena]>=(0)))
GO
ALTER TABLE [dbo].[Apartman] CHECK CONSTRAINT [CK_Apartman_2]
GO
ALTER TABLE [dbo].[Domacinstvo]  WITH CHECK ADD  CONSTRAINT [CK_Domacinstvo] CHECK  (([DomacinstvoID]>(0)))
GO
ALTER TABLE [dbo].[Domacinstvo] CHECK CONSTRAINT [CK_Domacinstvo]
GO
ALTER TABLE [dbo].[Domacinstvo]  WITH CHECK ADD  CONSTRAINT [CK_Domacinstvo_1] CHECK  (([BrojApartmana]>=(0)))
GO
ALTER TABLE [dbo].[Domacinstvo] CHECK CONSTRAINT [CK_Domacinstvo_1]
GO
ALTER TABLE [dbo].[OcenaApartmana]  WITH CHECK ADD  CONSTRAINT [CK_OcenaApartmana] CHECK  (([DomacinstvoID]>(0)))
GO
ALTER TABLE [dbo].[OcenaApartmana] CHECK CONSTRAINT [CK_OcenaApartmana]
GO
ALTER TABLE [dbo].[OcenaApartmana]  WITH CHECK ADD  CONSTRAINT [CK_OcenaApartmana_1] CHECK  (([ApartmanID]>(0)))
GO
ALTER TABLE [dbo].[OcenaApartmana] CHECK CONSTRAINT [CK_OcenaApartmana_1]
GO
ALTER TABLE [dbo].[OcenaApartmana]  WITH CHECK ADD  CONSTRAINT [CK_OcenaApartmana_2] CHECK  (([OcenaApartmana]>=(1) AND [OcenaApartmana]<=(5)))
GO
ALTER TABLE [dbo].[OcenaApartmana] CHECK CONSTRAINT [CK_OcenaApartmana_2]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [CK_Rezervacija_1] CHECK  (([DatumOd]>getdate()))
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [CK_Rezervacija_1]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [CK_Rezervacija_2] CHECK  (([DatumDo]>getdate()))
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [CK_Rezervacija_2]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [CK_Rezervacija_3] CHECK  (([DomacinstvoID]>(0)))
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [CK_Rezervacija_3]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [CK_Rezervacija_4] CHECK  (([ApartmanID]>(0)))
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [CK_Rezervacija_4]
GO
USE [master]
GO
ALTER DATABASE [AptRentSoft] SET  READ_WRITE 
GO
