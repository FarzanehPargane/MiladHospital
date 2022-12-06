
--Create database

USE [master]
GO
IF NOT EXISTS (SELECT [name] FROM sys.databases WHERE name = N'Hospital')
BEGIN
CREATE DATABASE [Hospital] COLLATE Arabic_CI_AS
END
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'Hospital', @new_cmptlevel=150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
BEGIN
	EXEC [Hospital].[dbo].[sp_fulltext_database] @action = 'enable'
END
GO
ALTER DATABASE [Hospital] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Hospital] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Hospital] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Hospital] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Hospital] SET ARITHABORT OFF
GO
ALTER DATABASE [Hospital] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Hospital] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Hospital] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Hospital] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Hospital] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Hospital] SET CURSOR_DEFAULT GLOBAL
GO
ALTER DATABASE [Hospital] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Hospital] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Hospital] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Hospital] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Hospital] SET DISABLE_BROKER
GO
ALTER DATABASE [Hospital] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Hospital] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Hospital] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Hospital] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Hospital] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Hospital] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Hospital] SET READ_WRITE
GO
ALTER DATABASE [Hospital] SET RECOVERY FULL
GO
ALTER DATABASE [Hospital] SET MULTI_USER
GO
ALTER DATABASE [Hospital] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Hospital] SET DB_CHAINING OFF
GO

USE [Hospital]
GO

--Create Roles
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'public' AND type = 'R')
	CREATE ROLE [public] AUTHORIZATION [dbo]
GO

--Database Schemas

USE [Hospital]
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'dbo')
EXEC sys.sp_executesql N'CREATE SCHEMA [dbo] AUTHORIZATION [dbo]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'guest')
EXEC sys.sp_executesql N'CREATE SCHEMA [guest] AUTHORIZATION [guest]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'INFORMATION_SCHEMA')
EXEC sys.sp_executesql N'CREATE SCHEMA [INFORMATION_SCHEMA] AUTHORIZATION [INFORMATION_SCHEMA]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'sys')
EXEC sys.sp_executesql N'CREATE SCHEMA [sys] AUTHORIZATION [sys]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'db_owner')
EXEC sys.sp_executesql N'CREATE SCHEMA [db_owner] AUTHORIZATION [db_owner]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'db_accessadmin')
EXEC sys.sp_executesql N'CREATE SCHEMA [db_accessadmin] AUTHORIZATION [db_accessadmin]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'db_securityadmin')
EXEC sys.sp_executesql N'CREATE SCHEMA [db_securityadmin] AUTHORIZATION [db_securityadmin]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'db_ddladmin')
EXEC sys.sp_executesql N'CREATE SCHEMA [db_ddladmin] AUTHORIZATION [db_ddladmin]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'db_backupoperator')
EXEC sys.sp_executesql N'CREATE SCHEMA [db_backupoperator] AUTHORIZATION [db_backupoperator]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'db_datareader')
EXEC sys.sp_executesql N'CREATE SCHEMA [db_datareader] AUTHORIZATION [db_datareader]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'db_datawriter')
EXEC sys.sp_executesql N'CREATE SCHEMA [db_datawriter] AUTHORIZATION [db_datawriter]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'db_denydatareader')
EXEC sys.sp_executesql N'CREATE SCHEMA [db_denydatareader] AUTHORIZATION [db_denydatareader]'
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'db_denydatawriter')
EXEC sys.sp_executesql N'CREATE SCHEMA [db_denydatawriter] AUTHORIZATION [db_denydatawriter]'
GO

--Table dbo.AppointmentReservation

USE [Hospital]
GO

--Create table and its columns
CREATE TABLE [dbo].[AppointmentReservation] (
	[Id] [int] NOT NULL IDENTITY (1, 1),
	[AppointmentId] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
	[Mellicode] [varchar](10) NULL,
	[Mobile] [varchar](11) NULL,
	[ReservedNumber] [int] NOT NULL,
	[TrackingCode] [varchar](10) NOT NULL,
	[RegisterDate] [datetime] NOT NULL);
GO

SET IDENTITY_INSERT [dbo].[AppointmentReservation] ON
GO
INSERT INTO [dbo].[AppointmentReservation] ([Id], [AppointmentId], [Name], [Surname], [Mellicode], [Mobile], [ReservedNumber], [TrackingCode], [RegisterDate])
	VALUES (7, 3, N'فرزانه', N'پرگنه', N'0083844571', N'40956565652', 7, N'71614', CAST(0x0000af63001c99b1 AS datetime))

GO
INSERT INTO [dbo].[AppointmentReservation] ([Id], [AppointmentId], [Name], [Surname], [Mellicode], [Mobile], [ReservedNumber], [TrackingCode], [RegisterDate])
	VALUES (8, 3, N'فرزانه', N'پرگنه', N'0055312880', N'40956565652', 8, N'84912', CAST(0x0000af63002cc012 AS datetime))

GO
INSERT INTO [dbo].[AppointmentReservation] ([Id], [AppointmentId], [Name], [Surname], [Mellicode], [Mobile], [ReservedNumber], [TrackingCode], [RegisterDate])
	VALUES (9, 3, N'فرزانه', N'پرگنه', N'0083844570', N'40956565652', 9, N'94236', CAST(0x0000af6300ca96af AS datetime))

GO
SET IDENTITY_INSERT [dbo].[AppointmentReservation] OFF
GO

--Table dbo.Appointments

USE [Hospital]
GO

--Create table and its columns
CREATE TABLE [dbo].[Appointments] (
	[Id] [int] NOT NULL IDENTITY (1, 1),
	[DoctorId] [int] NOT NULL,
	[ReserveDate] [datetime] NOT NULL,
	[StartTime] [time] NOT NULL,
	[EndTime] [time] NOT NULL,
	[Capacity] [int] NOT NULL,
	[UsedCapacity] [int] NOT NULL CONSTRAINT [DF_Appointments_UsedCapacity] DEFAULT ((0)),
	[Active] [bit] NOT NULL CONSTRAINT [DF_Appointments_Active] DEFAULT ((1)));
GO

SET IDENTITY_INSERT [dbo].[Appointments] ON
GO
INSERT INTO [dbo].[Appointments] ([Id], [DoctorId], [ReserveDate], [StartTime], [EndTime], [Capacity], [UsedCapacity], [Active])
	VALUES (3, 1, CAST(0x0000afaf00000000 AS datetime), CAST(0x070040230e43 AS time), CAST(0x0700e0349564 AS time), 50, 9, CAST ('True' AS bit))

GO
INSERT INTO [dbo].[Appointments] ([Id], [DoctorId], [ReserveDate], [StartTime], [EndTime], [Capacity], [UsedCapacity], [Active])
	VALUES (6, 2, CAST(0x0000afb000000000 AS datetime), CAST(0x070010acd153 AS time), CAST(0x070048f9f66c AS time), 60, 0, CAST ('True' AS bit))

GO
INSERT INTO [dbo].[Appointments] ([Id], [DoctorId], [ReserveDate], [StartTime], [EndTime], [Capacity], [UsedCapacity], [Active])
	VALUES (7, 3, CAST(0x0000afaf00000000 AS datetime), CAST(0x0700b0bd5875 AS time), CAST(0x0700e80a7e8e AS time), 70, 0, CAST ('True' AS bit))

GO
INSERT INTO [dbo].[Appointments] ([Id], [DoctorId], [ReserveDate], [StartTime], [EndTime], [Capacity], [UsedCapacity], [Active])
	VALUES (8, 4, CAST(0x0000afb100000000 AS datetime), CAST(0x0700a8e76f4b AS time), CAST(0x0700e0349564 AS time), 50, 0, CAST ('True' AS bit))

GO
INSERT INTO [dbo].[Appointments] ([Id], [DoctorId], [ReserveDate], [StartTime], [EndTime], [Capacity], [UsedCapacity], [Active])
	VALUES (9, 5, CAST(0x0000afb200000000 AS datetime), CAST(0x0700e80a7e8e AS time), CAST(0x07002058a3a7 AS time), 50, 0, CAST ('True' AS bit))

GO
INSERT INTO [dbo].[Appointments] ([Id], [DoctorId], [ReserveDate], [StartTime], [EndTime], [Capacity], [UsedCapacity], [Active])
	VALUES (10, 6, CAST(0x0000afb200000000 AS datetime), CAST(0x0700e0349564 AS time), CAST(0x07001882ba7d AS time), 30, 0, CAST ('True' AS bit))

GO
INSERT INTO [dbo].[Appointments] ([Id], [DoctorId], [ReserveDate], [StartTime], [EndTime], [Capacity], [UsedCapacity], [Active])
	VALUES (11, 7, CAST(0x0000afb300000000 AS datetime), CAST(0x070010acd153 AS time), CAST(0x07001882ba7d AS time), 40, 0, CAST ('True' AS bit))

GO
INSERT INTO [dbo].[Appointments] ([Id], [DoctorId], [ReserveDate], [StartTime], [EndTime], [Capacity], [UsedCapacity], [Active])
	VALUES (13, 8, CAST(0x0000afb400000000 AS datetime), CAST(0x070040230e43 AS time), CAST(0x07007870335c AS time), 30, 0, CAST ('True' AS bit))

GO
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO

--Table dbo.Doctors

USE [Hospital]
GO

--Create table and its columns
CREATE TABLE [dbo].[Doctors] (
	[Id] [int] NOT NULL IDENTITY (1, 1),
	[SpecialtyId] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
	[Mellicode] [varchar](10) NULL,
	[Mobile] [varchar](11) NULL);
GO

SET IDENTITY_INSERT [dbo].[Doctors] ON
GO
INSERT INTO [dbo].[Doctors] ([Id], [SpecialtyId], [Name], [Surname], [Mellicode], [Mobile])
	VALUES (1, 1, N'نسرین', N'مقتدایی', NULL, NULL)

GO
INSERT INTO [dbo].[Doctors] ([Id], [SpecialtyId], [Name], [Surname], [Mellicode], [Mobile])
	VALUES (2, 1, N'آرزو', N'پناهی', NULL, NULL)

GO
INSERT INTO [dbo].[Doctors] ([Id], [SpecialtyId], [Name], [Surname], [Mellicode], [Mobile])
	VALUES (3, 2, N'جواد', N'فرهمند', NULL, NULL)

GO
INSERT INTO [dbo].[Doctors] ([Id], [SpecialtyId], [Name], [Surname], [Mellicode], [Mobile])
	VALUES (4, 2, N'سینا', N'اکبری', NULL, NULL)

GO
INSERT INTO [dbo].[Doctors] ([Id], [SpecialtyId], [Name], [Surname], [Mellicode], [Mobile])
	VALUES (5, 3, N'نادر', N'سلیمانی', NULL, NULL)

GO
INSERT INTO [dbo].[Doctors] ([Id], [SpecialtyId], [Name], [Surname], [Mellicode], [Mobile])
	VALUES (6, 3, N'علی', N'افشار', NULL, NULL)

GO
INSERT INTO [dbo].[Doctors] ([Id], [SpecialtyId], [Name], [Surname], [Mellicode], [Mobile])
	VALUES (7, 4, N'الهام', N'نوری', NULL, NULL)

GO
INSERT INTO [dbo].[Doctors] ([Id], [SpecialtyId], [Name], [Surname], [Mellicode], [Mobile])
	VALUES (8, 4, N'کیان', N'عسگری', NULL, NULL)

GO
SET IDENTITY_INSERT [dbo].[Doctors] OFF
GO

--Table dbo.Specialties

USE [Hospital]
GO

--Create table and its columns
CREATE TABLE [dbo].[Specialties] (
	[Id] [int] NOT NULL IDENTITY (1, 1),
	[Field] [nvarchar](50) NOT NULL);
GO

SET IDENTITY_INSERT [dbo].[Specialties] ON
GO
INSERT INTO [dbo].[Specialties] ([Id], [Field])
	VALUES (1, N'زنان، زایمان')

GO
INSERT INTO [dbo].[Specialties] ([Id], [Field])
	VALUES (2, N'چشم پزشک')

GO
INSERT INTO [dbo].[Specialties] ([Id], [Field])
	VALUES (3, N'مغز و اعصاب')

GO
INSERT INTO [dbo].[Specialties] ([Id], [Field])
	VALUES (4, N'روانپزشک')

GO
SET IDENTITY_INSERT [dbo].[Specialties] OFF
GO

--Executing Entities
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Appointments_SelectFreetimeDoctors]
	
AS
BEGIN
	select Appointments.*,substring(convert(varchar,Appointments.StartTime),0,9)+'-'+substring(convert(varchar,Appointments.EndTime),0,9) as AppointmentsTime,Doctors.Name+' '+Doctors.Surname as DoctorName,Specialties.Field,Specialties.Id as SpecialtuId,(Capacity-UsedCapacity) as RemainCapacity from Appointments inner join Doctors
	on Appointments.DoctorId=Doctors.Id
	inner join Specialties on Doctors.SpecialtyId=Specialties.Id
	where Appointments.ReserveDate>=GETDATE()  and Active=convert(bit,1)
END

GO

GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AppointmentReservation_Insert]
@AppointmentId int,
@Name nvarchar(30),
@Surname nvarchar(30),
@Mellicode varchar(10),
@Mobile varchar(11),
@Result int out
AS
BEGIN try
begin transaction
declare @UsedCapacity int
declare @Capacity int
declare @TrackingCode varchar(10)
select @UsedCapacity=UsedCapacity,@Capacity=Capacity from Appointments where Id=@AppointmentId
set @TrackingCode=convert(varchar,(@UsedCapacity+1))+SUBSTRING(convert(varchar,RAND()),3,4)
if(@Capacity>@UsedCapacity)
begin
if exists(select * from AppointmentReservation where Mellicode=@Mellicode and AppointmentId=@AppointmentId)
set @Result=-3
else
begin
insert into AppointmentReservation values(@AppointmentId,@Name,@Surname,@Mellicode,@Mobile,@UsedCapacity+1,@TrackingCode,GETDATE())
set @Result=SCOPE_IDENTITY()
update Appointments set UsedCapacity=UsedCapacity+1 where Id=@AppointmentId
end
end
else
set @Result=-2
commit transaction 
return @result
end try
begin catch
rollback transaction
return -1
end catch



GO

GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AppointmentReservation_SelectById]
	@id int
AS
BEGIN
	select TrackingCode,ReservedNumber from AppointmentReservation where Id=@id
END

GO

GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AppointmentReservation_SelectByMellicode]
	@AppointmentId int,
	@Mellicode varchar(10)
AS
BEGIN
	select TrackingCode,ReservedNumber from AppointmentReservation where AppointmentId=@AppointmentId and Mellicode=@Mellicode
END

GO

GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Specialties_SelectAll]
	
AS
BEGIN
	select * from Specialties
END

GO

GO

--Indexes of table dbo.AppointmentReservation
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TABLE [dbo].[AppointmentReservation] ADD CONSTRAINT [PK_AppointmentReservation] PRIMARY KEY CLUSTERED ([Id]) 
GO

--Indexes of table dbo.Appointments
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TABLE [dbo].[Appointments] ADD CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([Id]) 
GO

--Indexes of table dbo.Doctors
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TABLE [dbo].[Doctors] ADD CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED ([Id]) 
GO

--Indexes of table dbo.Specialties
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TABLE [dbo].[Specialties] ADD CONSTRAINT [PK_specialty] PRIMARY KEY CLUSTERED ([Id]) 
GO

--Foreign Keys

USE [Hospital]
GO
ALTER TABLE [dbo].[AppointmentReservation] WITH CHECK ADD CONSTRAINT [FK_AppointmentReservation_Appointments] 
	FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[Appointments] ([Id])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO
ALTER TABLE [dbo].[AppointmentReservation] CHECK CONSTRAINT [FK_AppointmentReservation_Appointments]
GO
ALTER TABLE [dbo].[Appointments] WITH CHECK ADD CONSTRAINT [FK_Appointments_Doctors] 
	FOREIGN KEY ([DoctorId]) REFERENCES [dbo].[Doctors] ([Id])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Doctors]
GO
ALTER TABLE [dbo].[Doctors] WITH CHECK ADD CONSTRAINT [FK_Doctors_Specialties] 
	FOREIGN KEY ([SpecialtyId]) REFERENCES [dbo].[Specialties] ([Id])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_Doctors_Specialties]
GO
