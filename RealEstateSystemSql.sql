USE [RealEstateSystem]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 2023-07-25 12:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[agents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_type] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[phone] [varchar](20) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[address] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 2023-07-25 12:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[phone] [varchar](20) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[address] [varchar](200) NOT NULL,
	[requirement] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[property]    Script Date: 2023-07-25 12:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[property](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NULL,
	[square_feet] [int] NULL,
	[price] [decimal](10, 2) NULL,
	[address] [varchar](200) NULL,
	[bedrooms] [int] NULL,
	[bathrooms] [int] NULL,
	[year_of_build] [int] NULL,
	[offer_type] [varchar](50) NULL,
	[inspection_status] [varchar](50) NULL,
	[inspection_date] [date] NULL,
	[repair_status] [varchar](50) NULL,
	[repair_date] [date] NULL,
	[photo] [varbinary](max) NULL,
	[balcony] [bit] NULL,
	[pool] [bit] NULL,
	[backyard] [bit] NULL,
	[garage] [bit] NULL,
	[description] [varchar](max) NULL,
	[client_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[property_agents]    Script Date: 2023-07-25 12:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[property_agents](
	[property_id] [int] NOT NULL,
	[agent_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[property_id] ASC,
	[agent_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 2023-07-25 12:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[agent_id] [int] NOT NULL,
	[client_id] [int] NOT NULL,
	[schedule_type] [varchar](50) NOT NULL,
	[schedule_time] [datetime] NOT NULL,
	[property_id] [int] NULL,
	[description] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[agents] ON 

INSERT [dbo].[agents] ([id], [user_type], [username], [password], [name], [phone], [email], [address]) VALUES (1, N'broker', N'001', N'1234', N'John Smith (Broker)', N'1111111111', N'john.smith@example.com', N'123 Broker St')
INSERT [dbo].[agents] ([id], [user_type], [username], [password], [name], [phone], [email], [address]) VALUES (2, N'agent', N'002', N'1234', N'Michael Johnson', N'2222222222', N'michael.johnson@example.com', N'456 Agent Rd')
INSERT [dbo].[agents] ([id], [user_type], [username], [password], [name], [phone], [email], [address]) VALUES (3, N'agent', N'003', N'1234', N'Emily Williams', N'3333333333', N'emily.williams@example.com', N'789 Agent Ave')
INSERT [dbo].[agents] ([id], [user_type], [username], [password], [name], [phone], [email], [address]) VALUES (4, N'agent', N'004', N'1234', N'David Brown', N'4444444444', N'david.brown@example.com', N'101 Agent Rd')
INSERT [dbo].[agents] ([id], [user_type], [username], [password], [name], [phone], [email], [address]) VALUES (5, N'agent', N'005', N'1234', N'Sarah Lee', N'5555555555', N'sarah.lee@example.com', N'111 Agent St')
INSERT [dbo].[agents] ([id], [user_type], [username], [password], [name], [phone], [email], [address]) VALUES (6, N'agent', N'006', N'1234', N'Robert Kim', N'6666666666', N'robert.kim@example.com', N'222 Agent Rd')
SET IDENTITY_INSERT [dbo].[agents] OFF
GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [phone], [email], [address], [requirement]) VALUES (1, N'John Doe', N'1234567890', N'johndoe@example.com', N'123 Main St', N'Buyer')
INSERT [dbo].[clients] ([id], [name], [phone], [email], [address], [requirement]) VALUES (2, N'Jane Smith', N'2345678901', N'janesmith@example.com', N'456 Oak Ave', N'Seller')
INSERT [dbo].[clients] ([id], [name], [phone], [email], [address], [requirement]) VALUES (3, N'Michael Johnson', N'3456789012', N'michaeljohnson@example.com', N'789 Elm Rd', N'Buyer')
INSERT [dbo].[clients] ([id], [name], [phone], [email], [address], [requirement]) VALUES (4, N'Emily Williams', N'4567890123', N'emilywilliams@example.com', N'101 Maple St', N'Seller')
INSERT [dbo].[clients] ([id], [name], [phone], [email], [address], [requirement]) VALUES (5, N'David Brown', N'5678901234', N'davidbrown@example.com', N'555 Pine Ave', N'Buyer')
INSERT [dbo].[clients] ([id], [name], [phone], [email], [address], [requirement]) VALUES (6, N'Sarah Lee', N'6789012345', N'sarahlee@example.com', N'777 Oak St', N'Seller')
INSERT [dbo].[clients] ([id], [name], [phone], [email], [address], [requirement]) VALUES (7, N'Robert Kim', N'7890123456', N'robertkim@example.com', N'888 Cedar Rd', N'Buyer')
INSERT [dbo].[clients] ([id], [name], [phone], [email], [address], [requirement]) VALUES (8, N'Jennifer Lee', N'8901234567', N'jenniferlee@example.com', N'222 Birch Ave', N'Seller')
INSERT [dbo].[clients] ([id], [name], [phone], [email], [address], [requirement]) VALUES (9, N'William Chen', N'9012345678', N'williamchen@example.com', N'333 Elm St', N'Buyer')
INSERT [dbo].[clients] ([id], [name], [phone], [email], [address], [requirement]) VALUES (10, N'Michelle Wang', N'0123456789', N'michellewang@example.com', N'444 Oak Rd', N'Seller')
SET IDENTITY_INSERT [dbo].[clients] OFF
GO
SET IDENTITY_INSERT [dbo].[property] ON 

INSERT [dbo].[property] ([id], [type], [square_feet], [price], [address], [bedrooms], [bathrooms], [year_of_build], [offer_type], [inspection_status], [inspection_date], [repair_status], [repair_date], [photo], [balcony], [pool], [backyard], [garage], [description], [client_id]) VALUES (1, N'house', 2000, CAST(250000.00 AS Decimal(10, 2)), N'123 Main St', 3, 2, 2000, N'For Buy', N'Done', CAST(N'2023-07-20' AS Date), N'Pending', CAST(N'2023-08-05' AS Date), NULL, 1, 0, 1, 1, N'This is a beautiful house for sale.', 1)
INSERT [dbo].[property] ([id], [type], [square_feet], [price], [address], [bedrooms], [bathrooms], [year_of_build], [offer_type], [inspection_status], [inspection_date], [repair_status], [repair_date], [photo], [balcony], [pool], [backyard], [garage], [description], [client_id]) VALUES (2, N'apartment', 1200, CAST(150000.00 AS Decimal(10, 2)), N'456 Elm St', 2, 2, 2010, N'For Buy', N'Pending', CAST(N'2023-08-05' AS Date), NULL, NULL, NULL, 0, 1, 0, 0, N'A cozy apartment in a great location.', 2)
INSERT [dbo].[property] ([id], [type], [square_feet], [price], [address], [bedrooms], [bathrooms], [year_of_build], [offer_type], [inspection_status], [inspection_date], [repair_status], [repair_date], [photo], [balcony], [pool], [backyard], [garage], [description], [client_id]) VALUES (3, N'house', 1800, CAST(300000.00 AS Decimal(10, 2)), N'101 Maple Rd', 4, 3, 1995, N'For Buy', N'Done', CAST(N'2023-07-20' AS Date), N'None', NULL, NULL, 1, 0, 1, 1, N'Spacious house with a large backyard.', 3)
INSERT [dbo].[property] ([id], [type], [square_feet], [price], [address], [bedrooms], [bathrooms], [year_of_build], [offer_type], [inspection_status], [inspection_date], [repair_status], [repair_date], [photo], [balcony], [pool], [backyard], [garage], [description], [client_id]) VALUES (4, N'apartment', 900, CAST(120000.00 AS Decimal(10, 2)), N'222 Birch Ave', 1, 1, 2018, N'For Buy', N'Pending', CAST(N'2023-07-31' AS Date), NULL, NULL, NULL, 0, 0, 0, 0, N'Cozy apartment with modern amenities.', 4)
INSERT [dbo].[property] ([id], [type], [square_feet], [price], [address], [bedrooms], [bathrooms], [year_of_build], [offer_type], [inspection_status], [inspection_date], [repair_status], [repair_date], [photo], [balcony], [pool], [backyard], [garage], [description], [client_id]) VALUES (5, N'house', 2500, CAST(350000.00 AS Decimal(10, 2)), N'333 Cedar Rd', 5, 3, 2005, N'For Buy', N'Done', CAST(N'2023-07-20' AS Date), N'None', NULL, NULL, 1, 1, 1, 1, N'Beautiful house with a swimming pool.', 5)
INSERT [dbo].[property] ([id], [type], [square_feet], [price], [address], [bedrooms], [bathrooms], [year_of_build], [offer_type], [inspection_status], [inspection_date], [repair_status], [repair_date], [photo], [balcony], [pool], [backyard], [garage], [description], [client_id]) VALUES (6, N'apartment', 1000, CAST(140000.00 AS Decimal(10, 2)), N'555 Oak St', 2, 1, 2008, N'For Sale', N'Pending', CAST(N'2023-08-05' AS Date), NULL, NULL, NULL, 0, 0, 0, 0, N'Affordable apartment with great amenities.', 6)
INSERT [dbo].[property] ([id], [type], [square_feet], [price], [address], [bedrooms], [bathrooms], [year_of_build], [offer_type], [inspection_status], [inspection_date], [repair_status], [repair_date], [photo], [balcony], [pool], [backyard], [garage], [description], [client_id]) VALUES (7, N'house', 2200, CAST(280000.00 AS Decimal(10, 2)), N'666 Elm Rd', 3, 2, 2010, N'For Sale', N'Done', CAST(N'2023-07-20' AS Date), N'None', NULL, NULL, 1, 0, 1, 1, N'Spacious house with a backyard and garage.', 7)
INSERT [dbo].[property] ([id], [type], [square_feet], [price], [address], [bedrooms], [bathrooms], [year_of_build], [offer_type], [inspection_status], [inspection_date], [repair_status], [repair_date], [photo], [balcony], [pool], [backyard], [garage], [description], [client_id]) VALUES (8, N'apartment', 1500, CAST(180000.00 AS Decimal(10, 2)), N'777 Maple St', 2, 2, 2016, N'For Sale', N'Done', CAST(N'2023-07-20' AS Date), NULL, NULL, NULL, 1, 1, 0, 0, N'Modern condo in a prime location.', 8)
INSERT [dbo].[property] ([id], [type], [square_feet], [price], [address], [bedrooms], [bathrooms], [year_of_build], [offer_type], [inspection_status], [inspection_date], [repair_status], [repair_date], [photo], [balcony], [pool], [backyard], [garage], [description], [client_id]) VALUES (9, N'house', 2800, CAST(400000.00 AS Decimal(10, 2)), N'888 Pine Ave', 4, 3, 2012, N'For Sale', N'Done', CAST(N'2023-07-15' AS Date), N'Pending', CAST(N'2023-07-31' AS Date), NULL, 1, 0, 1, 1, N'Luxurious house with a large backyard.', 9)
INSERT [dbo].[property] ([id], [type], [square_feet], [price], [address], [bedrooms], [bathrooms], [year_of_build], [offer_type], [inspection_status], [inspection_date], [repair_status], [repair_date], [photo], [balcony], [pool], [backyard], [garage], [description], [client_id]) VALUES (10, N'apartment', 1100, CAST(160000.00 AS Decimal(10, 2)), N'999 Oak Rd', 2, 1, 2015, N'For Sale', N'Pending', CAST(N'2023-08-05' AS Date), NULL, NULL, NULL, 0, 0, 0, 0, N'Modern apartment with great views.', 10)
SET IDENTITY_INSERT [dbo].[property] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedules] ON 

INSERT [dbo].[Schedules] ([id], [agent_id], [client_id], [schedule_type], [schedule_time], [property_id], [description]) VALUES (1, 1, 1, N'appointment', CAST(N'2023-08-05T10:00:00.000' AS DateTime), NULL, N'Appointment with client A on 2023-08-05')
INSERT [dbo].[Schedules] ([id], [agent_id], [client_id], [schedule_type], [schedule_time], [property_id], [description]) VALUES (2, 1, 2, N'appointment', CAST(N'2023-08-06T14:30:00.000' AS DateTime), NULL, N'Appointment with client B on 2023-08-06')
INSERT [dbo].[Schedules] ([id], [agent_id], [client_id], [schedule_type], [schedule_time], [property_id], [description]) VALUES (3, 1, 3, N'appointment', CAST(N'2023-08-07T11:15:00.000' AS DateTime), NULL, N'Appointment with client C on 2023-08-07')
INSERT [dbo].[Schedules] ([id], [agent_id], [client_id], [schedule_type], [schedule_time], [property_id], [description]) VALUES (4, 1, 4, N'appointment', CAST(N'2023-08-08T09:45:00.000' AS DateTime), NULL, N'Appointment with client D on 2023-08-08')
INSERT [dbo].[Schedules] ([id], [agent_id], [client_id], [schedule_type], [schedule_time], [property_id], [description]) VALUES (5, 1, 5, N'appointment', CAST(N'2023-08-09T13:00:00.000' AS DateTime), NULL, N'Appointment with client E on 2023-08-09')
INSERT [dbo].[Schedules] ([id], [agent_id], [client_id], [schedule_type], [schedule_time], [property_id], [description]) VALUES (6, 1, 6, N'meeting', CAST(N'2023-08-10T15:00:00.000' AS DateTime), NULL, N'Meeting with agent F on 2023-08-10')
INSERT [dbo].[Schedules] ([id], [agent_id], [client_id], [schedule_type], [schedule_time], [property_id], [description]) VALUES (7, 1, 7, N'meeting', CAST(N'2023-08-11T12:30:00.000' AS DateTime), NULL, N'Meeting with agent G on 2023-08-11')
INSERT [dbo].[Schedules] ([id], [agent_id], [client_id], [schedule_type], [schedule_time], [property_id], [description]) VALUES (8, 1, 8, N'meeting', CAST(N'2023-08-12T10:45:00.000' AS DateTime), NULL, N'Meeting with agent H on 2023-08-12')
INSERT [dbo].[Schedules] ([id], [agent_id], [client_id], [schedule_type], [schedule_time], [property_id], [description]) VALUES (9, 1, 9, N'meeting', CAST(N'2023-08-13T16:30:00.000' AS DateTime), NULL, N'Meeting with agent I on 2023-08-13')
INSERT [dbo].[Schedules] ([id], [agent_id], [client_id], [schedule_type], [schedule_time], [property_id], [description]) VALUES (10, 1, 10, N'meeting', CAST(N'2023-08-14T14:15:00.000' AS DateTime), NULL, N'Meeting with agent J on 2023-08-14')
SET IDENTITY_INSERT [dbo].[Schedules] OFF
GO
ALTER TABLE [dbo].[property]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[clients] ([id])
GO
ALTER TABLE [dbo].[property_agents]  WITH CHECK ADD FOREIGN KEY([agent_id])
REFERENCES [dbo].[agents] ([id])
GO
ALTER TABLE [dbo].[property_agents]  WITH CHECK ADD FOREIGN KEY([property_id])
REFERENCES [dbo].[property] ([id])
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD FOREIGN KEY([agent_id])
REFERENCES [dbo].[agents] ([id])
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[clients] ([id])
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD FOREIGN KEY([property_id])
REFERENCES [dbo].[property] ([id])
GO
