USE [Movie_Rental]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 12/04/2019 09:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Movies_ID] [numeric](18, 0) IDENTITY(101,1) NOT NULL,
	[Rating] [int] NULL,
	[Title] [nvarchar](255) NULL,
	[Release_Date] [datetime] NULL,
	[Rental_Cost] [money] NULL,
	[Copies] [nvarchar](50) NULL,
	[Genre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Movies_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/04/2019 09:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [numeric](18, 0) IDENTITY(10001,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rented_Movies]    Script Date: 12/04/2019 09:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rented_Movies](
	[RMID] [numeric](18, 0) IDENTITY(1001,1) NOT NULL,
	[Movies_IDFK] [numeric](18, 0) NULL,
	[Movies_Title] [nvarchar](255) NULL,
	[DateReleased] [datetime] NULL,
	[DateReturned] [datetime] NULL,
	[Customer_IDFK] [numeric](18, 0) NULL,
	[Charges] [int] NULL,
	[Returned] [varchar](50) NULL,
	[Copies] [int] NULL,
 CONSTRAINT [PK_Rented_Movies] PRIMARY KEY CLUSTERED 
(
	[RMID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Rented_Movies1]    Script Date: 12/04/2019 09:33:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rented_Movies1]
	
AS
	SELECT * from Rented_Movies
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[Movies1]    Script Date: 12/04/2019 09:33:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Movies1]

AS
	SELECT * from Movies
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[Customer2]    Script Date: 12/04/2019 09:33:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customer2]
	
AS
	SELECT * from Customer
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[Customer1]    Script Date: 12/04/2019 09:33:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customer1]
	
AS
	SELECT * from Customer
RETURN 0
GO


SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT INTO [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Phone]) VALUES (CAST(10001 AS Decimal(18, 0)), N'Lovely', N'LastName', N'Address', CAST(9878676767 AS Decimal(18, 0)))
INSERT INTO [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Phone]) VALUES (CAST(10002 AS Decimal(18, 0)), N'Shiv', N'Kumars', N'India', CAST(9988675611 AS Decimal(18, 0)))
INSERT INTO [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Phone]) VALUES (CAST(10003 AS Decimal(18, 0)), N'Shiv Kumar', N'Sharma', N'Bathinda', CAST(9878675645 AS Decimal(18, 0)))
INSERT INTO [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Phone]) VALUES (CAST(10004 AS Decimal(18, 0)), N'Priya', N'verma', N'Jalandhar', CAST(9878786767 AS Decimal(18, 0)))
INSERT INTO [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Phone]) VALUES (CAST(10005 AS Decimal(18, 0)), N'Tamanna', N'Sharma', N'Jalandhar', CAST(9877675645 AS Decimal(18, 0)))
INSERT INTO [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Phone]) VALUES (CAST(10006 AS Decimal(18, 0)), N'sudhanshu', N'Sharma', N'India', CAST(9878265645 AS Decimal(18, 0)))
INSERT INTO [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Phone]) VALUES (CAST(10007 AS Decimal(18, 0)), N'Shekhar', N'sharma', N'india', CAST(8767564545 AS Decimal(18, 0)))
INSERT INTO [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Phone]) VALUES (CAST(10008 AS Decimal(18, 0)), N'Ramesh', N'Kumar', N'Dubai', CAST(9878676756 AS Decimal(18, 0)))
INSERT INTO [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Phone]) VALUES (CAST(10009 AS Decimal(18, 0)), N'Radha', N'krishnan', N'Australia', CAST(857578575 AS Decimal(18, 0)))
INSERT INTO [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [Phone]) VALUES (CAST(10010 AS Decimal(18, 0)), N'LLO', N'verma', N'India', CAST(98787675 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Customer] OFF


SET IDENTITY_INSERT [dbo].[Movies] ON
INSERT INTO [dbo].[Movies] ([Movies_ID], [Rating], [Title], [Release_Date], [Rental_Cost], [Copies], [Genre]) VALUES (CAST(105 AS Decimal(18, 0)), 4, N'The Princess', N'2016-11-01 03:59:00', CAST(2.0000 AS Money), N'11', N'Fiction')
INSERT INTO [dbo].[Movies] ([Movies_ID], [Rating], [Title], [Release_Date], [Rental_Cost], [Copies], [Genre]) VALUES (CAST(106 AS Decimal(18, 0)), 5, N'Lovely', N'2019-12-03 03:48:42', CAST(5.0000 AS Money), N'4', N'Fictions')
INSERT INTO [dbo].[Movies] ([Movies_ID], [Rating], [Title], [Release_Date], [Rental_Cost], [Copies], [Genre]) VALUES (CAST(107 AS Decimal(18, 0)), 5, N'The hated', N'2019-12-03 03:53:02', CAST(5.0000 AS Money), N'6', N'Love Story')
INSERT INTO [dbo].[Movies] ([Movies_ID], [Rating], [Title], [Release_Date], [Rental_Cost], [Copies], [Genre]) VALUES (CAST(108 AS Decimal(18, 0)), 5, N'Well Being', N'2009-12-03 05:10:38', CAST(2.0000 AS Money), N'4', N'Hatred')
SET IDENTITY_INSERT [dbo].[Movies] OFF

SET IDENTITY_INSERT [dbo].[Rented_Movies] ON
INSERT INTO [dbo].[Rented_Movies] ([RMID], [Movies_IDFK], [Movies_Title], [DateReleased], [DateReturned], [Customer_IDFK], [Charges], [Returned], [Copies]) VALUES (CAST(1005 AS Decimal(18, 0)), CAST(105 AS Decimal(18, 0)), N'The Princess', N'2019-12-03 11:12:57', N'2019-12-10 11:13:02', CAST(10001 AS Decimal(18, 0)), 5, N'Yes', 1)
INSERT INTO [dbo].[Rented_Movies] ([RMID], [Movies_IDFK], [Movies_Title], [DateReleased], [DateReturned], [Customer_IDFK], [Charges], [Returned], [Copies]) VALUES (CAST(1006 AS Decimal(18, 0)), CAST(106 AS Decimal(18, 0)), N'Lovely', N'2019-12-03 03:49:34', N'2019-12-10 03:49:41', CAST(10001 AS Decimal(18, 0)), 5, N'Yes', 1)
INSERT INTO [dbo].[Rented_Movies] ([RMID], [Movies_IDFK], [Movies_Title], [DateReleased], [DateReturned], [Customer_IDFK], [Charges], [Returned], [Copies]) VALUES (CAST(1007 AS Decimal(18, 0)), CAST(107 AS Decimal(18, 0)), N'The hated', N'2019-12-03 03:53:54', N'2019-12-10 03:54:00', CAST(10001 AS Decimal(18, 0)), 5, N'Yes', 1)
INSERT INTO [dbo].[Rented_Movies] ([RMID], [Movies_IDFK], [Movies_Title], [DateReleased], [DateReturned], [Customer_IDFK], [Charges], [Returned], [Copies]) VALUES (CAST(1008 AS Decimal(18, 0)), CAST(105 AS Decimal(18, 0)), N'The Princess', N'2019-12-03 04:22:46', N'2019-12-10 04:22:54', CAST(10001 AS Decimal(18, 0)), 5, N'No', 1)
INSERT INTO [dbo].[Rented_Movies] ([RMID], [Movies_IDFK], [Movies_Title], [DateReleased], [DateReturned], [Customer_IDFK], [Charges], [Returned], [Copies]) VALUES (CAST(1009 AS Decimal(18, 0)), CAST(105 AS Decimal(18, 0)), N'The Princess', N'2019-12-03 04:22:46', N'2019-12-10 04:22:54', CAST(10001 AS Decimal(18, 0)), 5, N'No', 1)
INSERT INTO [dbo].[Rented_Movies] ([RMID], [Movies_IDFK], [Movies_Title], [DateReleased], [DateReturned], [Customer_IDFK], [Charges], [Returned], [Copies]) VALUES (CAST(1010 AS Decimal(18, 0)), CAST(108 AS Decimal(18, 0)), N'Well Being', N'2019-12-03 05:12:03', N'2019-12-10 05:12:08', CAST(10001 AS Decimal(18, 0)), 2, N'No', 2)
INSERT INTO [dbo].[Rented_Movies] ([RMID], [Movies_IDFK], [Movies_Title], [DateReleased], [DateReturned], [Customer_IDFK], [Charges], [Returned], [Copies]) VALUES (CAST(1011 AS Decimal(18, 0)), CAST(108 AS Decimal(18, 0)), N'Well Being', N'2019-12-03 05:12:26', N'2019-12-10 05:12:32', CAST(10003 AS Decimal(18, 0)), 2, N'No', 6)
INSERT INTO [dbo].[Rented_Movies] ([RMID], [Movies_IDFK], [Movies_Title], [DateReleased], [DateReturned], [Customer_IDFK], [Charges], [Returned], [Copies]) VALUES (CAST(1012 AS Decimal(18, 0)), CAST(108 AS Decimal(18, 0)), N'Well Being', N'2019-12-03 05:12:54', N'2019-12-10 05:12:59', CAST(10006 AS Decimal(18, 0)), 2, N'Yes', 5)
INSERT INTO [dbo].[Rented_Movies] ([RMID], [Movies_IDFK], [Movies_Title], [DateReleased], [DateReturned], [Customer_IDFK], [Charges], [Returned], [Copies]) VALUES (CAST(1013 AS Decimal(18, 0)), CAST(108 AS Decimal(18, 0)), N'Well Being', N'2019-12-03 05:15:55', N'2019-12-10 05:16:16', CAST(10003 AS Decimal(18, 0)), 2, N'No', 4)
INSERT INTO [dbo].[Rented_Movies] ([RMID], [Movies_IDFK], [Movies_Title], [DateReleased], [DateReturned], [Customer_IDFK], [Charges], [Returned], [Copies]) VALUES (CAST(1014 AS Decimal(18, 0)), CAST(106 AS Decimal(18, 0)), N'Lovely', N'2019-12-03 11:47:10', N'2019-12-10 11:47:23', CAST(10006 AS Decimal(18, 0)), 5, N'Yes', 1)
SET IDENTITY_INSERT [dbo].[Rented_Movies] OFF
