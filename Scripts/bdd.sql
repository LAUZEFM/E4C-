USE [master]
GO
/****** Object:  Database [BateauBTS]    Script Date: 15/03/2019 14:33:37 ******/
CREATE DATABASE [BateauBTS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BateauBTS', FILENAME = N'E:\Databases\Utilisateurs\BateauBTSdata.mdf' , SIZE = 5120KB , MAXSIZE = 307200KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BateauBTS_log', FILENAME = N'E:\Databases\Utilisateurs\BateauBTS_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BateauBTS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BateauBTS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BateauBTS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BateauBTS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BateauBTS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BateauBTS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BateauBTS] SET ARITHABORT OFF 
GO
ALTER DATABASE [BateauBTS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BateauBTS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BateauBTS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BateauBTS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BateauBTS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BateauBTS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BateauBTS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BateauBTS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BateauBTS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BateauBTS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BateauBTS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BateauBTS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BateauBTS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BateauBTS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BateauBTS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BateauBTS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BateauBTS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BateauBTS] SET RECOVERY FULL 
GO
ALTER DATABASE [BateauBTS] SET  MULTI_USER 
GO
ALTER DATABASE [BateauBTS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BateauBTS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BateauBTS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BateauBTS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BateauBTS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BateauBTS', N'ON'
GO
USE [BateauBTS]
GO
/****** Object:  UserDefinedFunction [dbo].[totalTempReel]    Script Date: 15/03/2019 14:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[totalTempReel]()
returns time as begin declare @tot time;
SELECT @tot = CAST(t.time_sum/3600 AS VARCHAR(2)) + ':'
     + CAST(t.time_sum%3600/60 AS VARCHAR(2)) + ':'
     + CAST(((t.time_sum%3600)%60) AS VARCHAR(2))
FROM ( SELECT SUM(DATEDIFF(S, '00:00:00', format(cast(HeureArrivee as datetime) - 
cast(HeureDepart as datetime) + cast([dbo].[totalTemps] () as datetime),'hh:mm:ss'))) AS time_sum
       from vec, voilier, course, 
penalite, se_voire_attribuer, EPREUVE where vec.id_course = course.Id_Course and vec.Id_Epreuve = 
EPREUVE.Id_Epreuve and vec.Id_Voilier = VOILIER.Id_Voilier and se_voire_attribuer.Id_Course 
= VEC.Id_Course and se_voire_attribuer.Id_Epreuve = VEC.Id_Epreuve and se_voire_attribuer.Id_Penalite 
= PENALITE.Id_Penalite and se_voire_attribuer.Id_Voilier = VEC.Id_Voilier) t
return @tot
end
GO
/****** Object:  UserDefinedFunction [dbo].[totalTemps]    Script Date: 15/03/2019 14:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[totalTemps]()
returns time as begin declare @tot time;
SELECT @tot = CAST(t.time_sum/3600 AS VARCHAR(2)) + ':'
     + CAST(t.time_sum%3600/60 AS VARCHAR(2)) + ':'
     + CAST(((t.time_sum%3600)%60) AS VARCHAR(2))
FROM ( SELECT SUM(DATEDIFF(S, '00:00:00', Temps_Penalite)) AS time_sum
       from vec, voilier, course, 
penalite, se_voire_attribuer, EPREUVE where vec.id_course = course.Id_Course and vec.Id_Epreuve = 
EPREUVE.Id_Epreuve and vec.Id_Voilier = VOILIER.Id_Voilier and se_voire_attribuer.Id_Course 
= VEC.Id_Course and se_voire_attribuer.Id_Epreuve = VEC.Id_Epreuve and se_voire_attribuer.Id_Penalite 
= PENALITE.Id_Penalite and se_voire_attribuer.Id_Voilier = VEC.Id_Voilier) t
return @tot
end
GO
/****** Object:  UserDefinedFunction [dbo].[totalTempsReel]    Script Date: 15/03/2019 14:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[totalTempsReel]()
returns time as begin declare @tot time;
SELECT @tot = CAST(t.time_sum/3600 AS VARCHAR(2)) + ':'
     + CAST(t.time_sum%3600/60 AS VARCHAR(2)) + ':'
     + CAST(((t.time_sum%3600)%60) AS VARCHAR(2))
FROM ( SELECT SUM(DATEDIFF(S, '00:00:00', format(cast(HeureArrivee as datetime) - 
cast(HeureDepart as datetime) + cast([dbo].[totalTemps] () as datetime),'hh:mm:ss'))) AS time_sum
       from vec, voilier, course, 
penalite, se_voire_attribuer, EPREUVE where vec.id_course = course.Id_Course and vec.Id_Epreuve = 
EPREUVE.Id_Epreuve and vec.Id_Voilier = VOILIER.Id_Voilier and se_voire_attribuer.Id_Course 
= VEC.Id_Course and se_voire_attribuer.Id_Epreuve = VEC.Id_Epreuve and se_voire_attribuer.Id_Penalite 
= PENALITE.Id_Penalite and se_voire_attribuer.Id_Voilier = VEC.Id_Voilier) t
return @tot
end
GO
/****** Object:  Table [dbo].[COURSE]    Script Date: 15/03/2019 14:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COURSE](
	[Id_Course] [int] IDENTITY(1,1) NOT NULL,
	[Nom_Course] [varchar](25) NULL,
	[Lieu_Course] [varchar](25) NULL,
	[Date_Course] [datetime] NULL,
 CONSTRAINT [prk_constraint_COURSE] PRIMARY KEY NONCLUSTERED 
(
	[Id_Course] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ENTREPRISE]    Script Date: 15/03/2019 14:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ENTREPRISE](
	[Id_Entreprise] [int] IDENTITY(1,1) NOT NULL,
	[Nom_Entreprise] [varchar](50) NULL,
	[Num_Siret] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Entreprise] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EQUIPAGE]    Script Date: 15/03/2019 14:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EQUIPAGE](
	[Id_Equipage] [int] IDENTITY(1,1) NOT NULL,
	[Nom_Equipage] [varchar](100) NULL,
	[Num_Siret] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Equipage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PENALITE]    Script Date: 15/03/2019 14:33:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PENALITE](
	[Id_Penalite] [int] IDENTITY(1,1) NOT NULL,
	[Nom_Penalite] [varchar](25) NULL,
	[Code_Penalite] [varchar](25) NULL,
	[Temps_Penalite] [int] NULL,
 CONSTRAINT [prk_constraint_PENALITE] PRIMARY KEY NONCLUSTERED 
(
	[Id_Penalite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONNE]    Script Date: 15/03/2019 14:33:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONNE](
	[Id_Personne] [int] IDENTITY(1,1) NOT NULL,
	[Nom_Personne] [varchar](50) NULL,
	[Prenom_Personne] [varchar](50) NULL,
	[CP_Personne] [int] NULL,
	[Adresse1_Personne] [varchar](200) NULL,
	[Adresse2_Personne] [varchar](200) NULL,
	[Ville_Personne] [varchar](50) NULL,
	[Pays_Personne] [varchar](50) NULL,
	[Role_Personne] [varchar](50) NULL,
	[Id_Equipage] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Personne] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VOILIER]    Script Date: 15/03/2019 14:33:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VOILIER](
	[Id_Voilier] [int] IDENTITY(1,1) NOT NULL,
	[Longueur_Voilier] [int] NULL,
	[Nom_Voilier] [varchar](50) NULL,
	[Temps_Brut_Voilier] [int] NULL,
	[Temps_Reel_Voilier] [int] NULL,
	[Id_Equipage] [int] NULL,
	[Id_Penalite] [int] NULL,
	[Id_Entreprise] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Voilier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ContactAddOrEdit]    Script Date: 15/03/2019 14:33:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ContactAddOrEdit]
	@mode nvarchar(10),
	@ContactId int,
	@Name nvarchar(50),
	@MobileNumber nvarchar(50),
	@Address nvarchar(50)
AS
	IF @mode = 'Add'
	BEGIN 
	INSERT INTO tbl_Contact(Name, MobileNumber, 
	Adress)
	VALUES (@Name, @MobileNumber, @Address)
END
GO
USE [master]
GO
ALTER DATABASE [BateauBTS] SET  READ_WRITE 
GO
