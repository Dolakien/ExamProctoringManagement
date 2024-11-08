USE [master]
GO
/****** Object:  Database [ExamProctoringManagementDB]    Script Date: 04/10/2024 11:12:24 CH ******/
CREATE DATABASE [ExamProctoringManagementDB]


/***GO
ALTER DATABASE [ExamProctoringManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExamProctoringManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ExamProctoringManagementDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ExamProctoringManagementDB] SET QUERY_STORE = OFF
GO***/
USE [ExamProctoringManagementDB]
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam](
	[ExamID] [nvarchar](20) NOT NULL,
	[ExamName] [nvarchar](50) NULL,
	[Type] [varchar](20) NULL,
	[FromDate] [datetime2](6) NULL,
	[ToDate] [datetime2](6) NULL,
	[SemesterID] [nvarchar](20) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ExamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormSlot]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormSlot](
	[FormSlotID] [nvarchar](20) NOT NULL,
	[FormID] [nvarchar](20) NULL,
	[SlotID] [nvarchar](20) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[FormSlotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormSwap]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormSwap](
	[FormID] [nvarchar](20) NOT NULL,
	[UserID] [nvarchar](20) NULL,
	[Type] [bit] NULL,
	[IsAllowed] [bit] NULL,
	[FromSlot] [nvarchar](20) NULL,
	[ToSlot] [nvarchar](20) NULL,
	[Status] [bit] NULL,
	[CreateDate] [datetime2](6) NULL,
PRIMARY KEY CLUSTERED 
(
	[FormID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[GroupID] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupRoom]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupRoom](
	[GroupRoomID] [nvarchar](20) NOT NULL,
	[GroupID] [nvarchar](20) NULL,
	[RoomID] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupRoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProctoringSchedule]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProctoringSchedule](
	[ScheduleID] [nvarchar](20) NOT NULL,
	[UserID] [nvarchar](20) NULL,
	[ProctorType] [nvarchar](20) NULL,
	[SlotReferenceID] [nvarchar](20) NULL,
	[Status] [bit] NULL,
	[IsFinished] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistrationForm]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrationForm](
	[FormID] [nvarchar](20) NOT NULL,
	[UserID] [nvarchar](20) NULL,
	[Status] [bit] NULL,
	[CreateDate] [datetime2](6) NULL,
PRIMARY KEY CLUSTERED 
(
	[FormID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportID] [nvarchar](20) NOT NULL,
	[UserID] [nvarchar](20) NULL,
	[FromDate] [datetime2](6) NULL,
	[ToDate] [datetime2](6) NULL,
	[TotalHours] [real] NULL,
	[UnitPerHour] [numeric](38, 2) NULL,
	[TotalAmount] [numeric](38, 2) NULL,
	[IsPaid] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[RoleDescription] [nvarchar](255) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomID] [nvarchar](20) NOT NULL,
	[RoomName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[SemesterID] [nvarchar](20) NOT NULL,
	[SemesterName] [nvarchar](50) NULL,
	[FromDate] [datetime2](6) NULL,
	[ToDate] [datetime2](6) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SemesterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slot]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slot](
	[SlotID] [nvarchar](20) NOT NULL,
	[Date] [datetime2](6) NULL,
	[Start] [time](7) NULL,
	[End] [time](7) NULL,
	[Status] [bit] NULL,
	[ExamID] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[SlotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SlotReference]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlotReference](
	[SlotReferenceID] [nvarchar](20) NOT NULL,
	[SlotID] [nvarchar](20) NULL,
	[RoomID] [nvarchar](20) NULL,
	[GroupID] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[SlotReferenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SlotRoomSubject]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlotRoomSubject](
	[SlotRoomSubjectID] [nvarchar](20) NOT NULL,
	[SlotReferenceID] [nvarchar](20) NULL,
	[SubjectID] [nvarchar](20) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SlotRoomSubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectID] [nvarchar](20) NOT NULL,
	[SubjectName] [nvarchar](50) NULL,
	[ExamID] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 04/10/2024 11:12:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](50) NULL,
    [PasswordSalt] VARBINARY(128)NOT NULL,
    [PasswordHash] VARBINARY(128) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[MainMajor] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[Gender] [bit] NULL,
	[DoB] [DATETIME] NULL,
	[PhoneNumber] [varchar](12) NULL,
	[RoleID] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK__User__1788CCACE5F13170] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE RefreshToken(
    RefreshTokenID INT IDENTITY(1,1) PRIMARY KEY,
    UserID NVARCHAR(20) NOT NULL,
    Token NVARCHAR(255) NOT NULL,
    ExpiryDate DATETIME NOT NULL,
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);
GO

INSERT [dbo].[Exam] ([ExamID], [ExamName], [Type], [FromDate], [ToDate], [SemesterID], [Status]) VALUES (N'1', N'Final Exam', N'Block10_FE', CAST(N'2024-11-15T00:00:00.0000000' AS DateTime2), CAST(N'2024-11-22T00:00:00.0000000' AS DateTime2), N'FALL24', 1)
INSERT [dbo].[Exam] ([ExamID], [ExamName], [Type], [FromDate], [ToDate], [SemesterID], [Status]) VALUES (N'2', N'Retake Exam', N'Block10_RE', CAST(N'2024-11-23T00:00:00.0000000' AS DateTime2), CAST(N'2024-11-30T00:00:00.0000000' AS DateTime2), N'FALL24', 0)
INSERT [dbo].[Exam] ([ExamID], [ExamName], [Type], [FromDate], [ToDate], [SemesterID], [Status]) VALUES (N'3', N'Final Exam', N'Block3_FE', CAST(N'2024-12-15T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-22T00:00:00.0000000' AS DateTime2), N'FALL24', 0)
GO
INSERT [dbo].[FormSlot] ([FormSlotID], [FormID], [SlotID], [Status]) VALUES (N'1', N'1', N'1', 1)
INSERT [dbo].[FormSlot] ([FormSlotID], [FormID], [SlotID], [Status]) VALUES (N'2', N'1', N'3', 1)
INSERT [dbo].[FormSlot] ([FormSlotID], [FormID], [SlotID], [Status]) VALUES (N'3', N'2', N'3', 1)
GO
INSERT [dbo].[FormSwap] ([FormID], [UserID], [Type], [IsAllowed], [FromSlot], [ToSlot], [Status]) VALUES (N'1', N'4', NULL, 0, N'3', N'2', 1)
GO
INSERT [dbo].[Group] ([GroupID]) VALUES (N'1')
INSERT [dbo].[Group] ([GroupID]) VALUES (N'2')
INSERT [dbo].[Group] ([GroupID]) VALUES (N'3')
GO
INSERT [dbo].[GroupRoom] ([GroupRoomID], [GroupID], [RoomID]) VALUES (N'1', N'1', N'001')
INSERT [dbo].[GroupRoom] ([GroupRoomID], [GroupID], [RoomID]) VALUES (N'2', N'1', N'002')
INSERT [dbo].[GroupRoom] ([GroupRoomID], [GroupID], [RoomID]) VALUES (N'3', N'1', N'003')
INSERT [dbo].[GroupRoom] ([GroupRoomID], [GroupID], [RoomID]) VALUES (N'4', N'2', N'100')
INSERT [dbo].[GroupRoom] ([GroupRoomID], [GroupID], [RoomID]) VALUES (N'5', N'2', N'101')
INSERT [dbo].[GroupRoom] ([GroupRoomID], [GroupID], [RoomID]) VALUES (N'6', N'2', N'102')
INSERT [dbo].[GroupRoom] ([GroupRoomID], [GroupID], [RoomID]) VALUES (N'7', N'3', N'103')
INSERT [dbo].[GroupRoom] ([GroupRoomID], [GroupID], [RoomID]) VALUES (N'8', N'3', N'104')
INSERT [dbo].[GroupRoom] ([GroupRoomID], [GroupID], [RoomID]) VALUES (N'9', N'3', N'105')
GO
INSERT [dbo].[ProctoringSchedule] ([ScheduleID], [UserID], [ProctorType], [SlotReferenceID], [Status], [IsFinished]) VALUES (N'1', N'3', N'Giám Thị Phòng', N'1', 1, 0)
INSERT [dbo].[ProctoringSchedule] ([ScheduleID], [UserID], [ProctorType], [SlotReferenceID], [Status], [IsFinished]) VALUES (N'2', N'3', N'Giám Thị Phòng', N'2', 1, 0)
INSERT [dbo].[ProctoringSchedule] ([ScheduleID], [UserID], [ProctorType], [SlotReferenceID], [Status], [IsFinished]) VALUES (N'3', N'4', N'Giám Thị Hành Lang', N'3', 1, 0)
GO
INSERT [dbo].[RegistrationForm] ([FormID], [UserID], [Status]) VALUES (N'1', N'3', 1)
INSERT [dbo].[RegistrationForm] ([FormID], [UserID], [Status]) VALUES (N'2', N'4', 1)
GO
INSERT [dbo].[Report] ([ReportID], [UserID], [FromDate], [ToDate], [TotalHours], [UnitPerHour], [TotalAmount], [IsPaid]) VALUES (N'1', N'3', CAST(N'2024-08-15T00:00:00.0000000' AS DateTime2), CAST(N'2024-09-14T00:00:00.0000000' AS DateTime2), 2, CAST(10000.00 AS Numeric(38, 2)), CAST(20000.00 AS Numeric(38, 2)), 0)
INSERT [dbo].[Report] ([ReportID], [UserID], [FromDate], [ToDate], [TotalHours], [UnitPerHour], [TotalAmount], [IsPaid]) VALUES (N'2', N'4', CAST(N'2024-08-15T00:00:00.0000000' AS DateTime2), CAST(N'2024-09-14T00:00:00.0000000' AS DateTime2), 1.5, CAST(10000.00 AS Numeric(38, 2)), CAST(15000.00 AS Numeric(38, 2)), 1)
GO
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleDescription], [Status]) VALUES (1, N'Trưởng Phòng Khảo Thí ', NULL, 1)
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleDescription], [Status]) VALUES (2, N'Nhân Viên Phòng Khảo Thí ', NULL, 1)
INSERT [dbo].[Role] ([RoleID], [RoleName], [RoleDescription], [Status]) VALUES (3, N'Giảng Viên', NULL, 1)
GO
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'001', N'001')
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'002', N'002')
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'003', N'003')
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'004', N'004')
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'005', N'005')
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'100', N'100')
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'101', N'101')
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'102', N'102')
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'103', N'103')
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'104', N'104')
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'105', N'105')
INSERT [dbo].[Room] ([RoomID], [RoomName]) VALUES (N'A01', N'Hội Trường A')
GO
INSERT [dbo].[Semester] ([SemesterID], [SemesterName], [FromDate], [ToDate], [Status]) VALUES (N'FALL24', N'FALL 2024', CAST(N'2024-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-31T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Semester] ([SemesterID], [SemesterName], [FromDate], [ToDate], [Status]) VALUES (N'SPRING25', N'SPRING 2025', CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2025-04-30T00:00:00.0000000' AS DateTime2), 0)
GO
INSERT [dbo].[Slot] ([SlotID], [Date], [Start], [End], [Status], [ExamID]) VALUES (N'1', CAST(N'2024-11-15T00:00:00.0000000' AS DateTime2), CAST(N'07:30:00' AS Time), CAST(N'09:00:00' AS Time), 1, N'1')
INSERT [dbo].[Slot] ([SlotID], [Date], [Start], [End], [Status], [ExamID]) VALUES (N'2', CAST(N'2024-11-15T00:00:00.0000000' AS DateTime2), CAST(N'09:30:00' AS Time), CAST(N'11:00:00' AS Time), 1, N'1')
INSERT [dbo].[Slot] ([SlotID], [Date], [Start], [End], [Status], [ExamID]) VALUES (N'3', CAST(N'2024-11-15T00:00:00.0000000' AS DateTime2), CAST(N'12:50:00' AS Time), CAST(N'14:50:00' AS Time), 1, N'1')
GO
INSERT [dbo].[SlotReference] ([SlotReferenceID], [SlotID], [RoomID], [GroupID]) VALUES (N'1', N'1', N'101', NULL)
INSERT [dbo].[SlotReference] ([SlotReferenceID], [SlotID], [RoomID], [GroupID]) VALUES (N'2', N'3', N'105', NULL)
INSERT [dbo].[SlotReference] ([SlotReferenceID], [SlotID], [RoomID], [GroupID]) VALUES (N'3', N'3', NULL, N'3')
GO
INSERT [dbo].[SlotRoomSubject] ([SlotRoomSubjectID], [SlotReferenceID], [SubjectID], [Status]) VALUES (N'1', N'1', N'FALL24_PRN231_PE_1', 1)
INSERT [dbo].[SlotRoomSubject] ([SlotRoomSubjectID], [SlotReferenceID], [SubjectID], [Status]) VALUES (N'2', N'2', N'FALL24_PRN231_FE_1', 1)
INSERT [dbo].[SlotRoomSubject] ([SlotRoomSubjectID], [SlotReferenceID], [SubjectID], [Status]) VALUES (N'3', N'2', N'FALL24_PRM392_FE_1', 1)
GO
INSERT [dbo].[Subject] ([SubjectID], [SubjectName], [ExamID]) VALUES (N'FALL24_PRM392_FE_1', N'PRM392', N'1')
INSERT [dbo].[Subject] ([SubjectID], [SubjectName], [ExamID]) VALUES (N'FALL24_PRN231_FE_1', N'PRN231', N'1')
INSERT [dbo].[Subject] ([SubjectID], [SubjectName], [ExamID]) VALUES (N'FALL24_PRN231_PE_1', N'PRN231', N'1')
GO
INSERT [dbo].[User] 
([UserID], [UserName], [PasswordSalt], [PasswordHash], [FullName], [Email], [MainMajor], [Address], [Gender], [DoB], [PhoneNumber], [RoleID], [Status]) 
VALUES 
(N'1', N'ThanhNQ', 
CONVERT(varbinary(128), 'fxKo5tlLr28qWMsIG1DUUHFc1CpvaBfLXFAJghBrIlBAedjRsl3CKgPNLCirJt339lF7caHL4D2SjqMa04RktQ=='), 
CONVERT(varbinary(128), 'SqvjxO+7fgtEOG5PtnXWOLAlrI1Y47CQHDORoos6gscpI0yx7iISk5h4L6zQ94dvU/AjmsJNPpq4CdUOO64ejpiRjaCgJMHrkojiDkQOx12lsfX7GfcyxhXqgb0FbG4FX4GAvFms554/2GJH0zI3EsEW3Ki3nUZV2DC6oFt8vEU='), 
N'Nguyễn Quang Thanh', N'thanh@fpt.vn', NULL, N'123/1A', 0, CAST(N'2024-10-04' AS Date), N'0909123123', 1, 1);

INSERT [dbo].[User] 
([UserID], [UserName], [PasswordSalt], [PasswordHash], [FullName], [Email], [MainMajor], [Address], [Gender], [DoB], [PhoneNumber], [RoleID], [Status]) 
VALUES 
(N'2', N'TienNHT', 
CONVERT(varbinary(128), 'fxKo5tlLr28qWMsIG1DUUHFc1CpvaBfLXFAJghBrIlBAedjRsl3CKgPNLCirJt339lF7caHL4D2SjqMa04RktQ=='), 
CONVERT(varbinary(128), 'SqvjxO+7fgtEOG5PtnXWOLAlrI1Y47CQHDORoos6gscpI0yx7iISk5h4L6zQ94dvU/AjmsJNPpq4CdUOO64ejpiRjaCgJMHrkojiDkQOx12lsfX7GfcyxhXqgb0FbG4FX4GAvFms554/2GJH0zI3EsEW3Ki3nUZV2DC6oFt8vEU='), 
N'Nguyễn Hồ Tân Tiến', N'tien@fpt.vn', NULL, N'123/1A', 0, CAST(N'2024-10-04' AS Date), N'0909123124', 2, 1);

INSERT [dbo].[User] 
([UserID], [UserName], [PasswordSalt], [PasswordHash], [FullName], [Email], [MainMajor], [Address], [Gender], [DoB], [PhoneNumber], [RoleID], [Status]) 
VALUES 
(N'3', N'DungNG', 
CONVERT(varbinary(128), 'fxKo5tlLr28qWMsIG1DUUHFc1CpvaBfLXFAJghBrIlBAedjRsl3CKgPNLCirJt339lF7caHL4D2SjqMa04RktQ=='), 
CONVERT(varbinary(128), 'SqvjxO+7fgtEOG5PtnXWOLAlrI1Y47CQHDORoos6gscpI0yx7iISk5h4L6zQ94dvU/AjmsJNPpq4CdUOO64ejpiRjaCgJMHrkojiDkQOx12lsfX7GfcyxhXqgb0FbG4FX4GAvFms554/2GJH0zI3EsEW3Ki3nUZV2DC6oFt8vEU='), 
N'Ngô Quang Dũng', N'dung@fpt.vn', N'Kĩ Thuật Phần Mềm', N'123/1A', 0, CAST(N'2024-10-04' AS Date), N'0909123125', 3, 1);

INSERT [dbo].[User] 
([UserID], [UserName], [PasswordSalt], [PasswordHash], [FullName], [Email], [MainMajor], [Address], [Gender], [DoB], [PhoneNumber], [RoleID], [Status]) 
VALUES 
(N'4', N'NamPNH', 
CONVERT(varbinary(128), 'fxKo5tlLr28qWMsIG1DUUHFc1CpvaBfLXFAJghBrIlBAedjRsl3CKgPNLCirJt339lF7caHL4D2SjqMa04RktQ=='), 
CONVERT(varbinary(128), 'SqvjxO+7fgtEOG5PtnXWOLAlrI1Y47CQHDORoos6gscpI0yx7iISk5h4L6zQ94dvU/AjmsJNPpq4CdUOO64ejpiRjaCgJMHrkojiDkQOx12lsfX7GfcyxhXqgb0FbG4FX4GAvFms554/2GJH0zI3EsEW3Ki3nUZV2DC6oFt8vEU='), 
N'Phan Nguyễn Hoài Nam', N'nam@fpt.vn', N'Ngôn Ngữ Anh', N'123/1A', 1, CAST(N'2024-10-04' AS Date), N'0909123126', 3, 1);

GO
ALTER TABLE [dbo].[Exam]  WITH CHECK ADD FOREIGN KEY([SemesterID])
REFERENCES [dbo].[Semester] ([SemesterID])
GO
ALTER TABLE [dbo].[FormSlot]  WITH CHECK ADD FOREIGN KEY([FormID])
REFERENCES [dbo].[RegistrationForm] ([FormID])
GO
ALTER TABLE [dbo].[FormSlot]  WITH CHECK ADD FOREIGN KEY([SlotID])
REFERENCES [dbo].[Slot] ([SlotID])
GO
ALTER TABLE [dbo].[FormSwap]  WITH CHECK ADD FOREIGN KEY([FromSlot])
REFERENCES [dbo].[Slot] ([SlotID])
GO
ALTER TABLE [dbo].[FormSwap]  WITH CHECK ADD FOREIGN KEY([ToSlot])
REFERENCES [dbo].[Slot] ([SlotID])
GO
ALTER TABLE [dbo].[FormSwap]  WITH CHECK ADD  CONSTRAINT [FK__FormSwap__UserID__66603565] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[FormSwap] CHECK CONSTRAINT [FK__FormSwap__UserID__66603565]
GO
ALTER TABLE [dbo].[GroupRoom]  WITH CHECK ADD  CONSTRAINT [FK_GroupRoom_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[GroupRoom] CHECK CONSTRAINT [FK_GroupRoom_Group]
GO
ALTER TABLE [dbo].[GroupRoom]  WITH CHECK ADD  CONSTRAINT [FK_GroupRoom_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[GroupRoom] CHECK CONSTRAINT [FK_GroupRoom_Room]
GO
ALTER TABLE [dbo].[ProctoringSchedule]  WITH CHECK ADD FOREIGN KEY([SlotReferenceID])
REFERENCES [dbo].[SlotReference] ([SlotReferenceID])
GO
ALTER TABLE [dbo].[ProctoringSchedule]  WITH CHECK ADD  CONSTRAINT [FK__Proctorin__UserI__6E01572D] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[ProctoringSchedule] CHECK CONSTRAINT [FK__Proctorin__UserI__6E01572D]
GO
ALTER TABLE [dbo].[RegistrationForm]  WITH CHECK ADD  CONSTRAINT [FK__Registrat__UserI__656C112C] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[RegistrationForm] CHECK CONSTRAINT [FK__Registrat__UserI__656C112C]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK__Report__UserID__6EF57B66] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK__Report__UserID__6EF57B66]
GO
ALTER TABLE [dbo].[Slot]  WITH CHECK ADD FOREIGN KEY([ExamID])
REFERENCES [dbo].[Exam] ([ExamID])
GO
ALTER TABLE [dbo].[SlotReference]  WITH CHECK ADD FOREIGN KEY([SlotID])
REFERENCES [dbo].[Slot] ([SlotID])
GO
ALTER TABLE [dbo].[SlotReference]  WITH CHECK ADD  CONSTRAINT [FK_SlotReference_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[SlotReference] CHECK CONSTRAINT [FK_SlotReference_Group]
GO
ALTER TABLE [dbo].[SlotReference]  WITH CHECK ADD  CONSTRAINT [FK_SlotReference_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[SlotReference] CHECK CONSTRAINT [FK_SlotReference_Room]
GO
ALTER TABLE [dbo].[SlotRoomSubject]  WITH CHECK ADD FOREIGN KEY([SlotReferenceID])
REFERENCES [dbo].[SlotReference] ([SlotReferenceID])
GO
ALTER TABLE [dbo].[SlotRoomSubject]  WITH CHECK ADD FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD FOREIGN KEY([ExamID])
REFERENCES [dbo].[Exam] ([ExamID])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__RoleID__6477ECF3] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__RoleID__6477ECF3]
GO
USE [master]
GO
ALTER DATABASE [ExamProctoringManagementDB] SET  READ_WRITE 
GO
