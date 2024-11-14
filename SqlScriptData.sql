USE [CafeMenu]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 14.11.2024 20:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ParentCategoryId] [int] NULL,
	[CreatorUserId] [int] NOT NULL,
	[CategoryName] [nvarchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaim]    Script Date: 14.11.2024 20:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_OperationClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 14.11.2024 20:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatorUserId] [int] NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductProperty]    Script Date: 14.11.2024 20:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductProperty](
	[ProductPropertyId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
 CONSTRAINT [PK_ProductProperty] PRIMARY KEY CLUSTERED 
(
	[ProductPropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 14.11.2024 20:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[PropertyId] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](100) NULL,
	[Value] [nvarchar](100) NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14.11.2024 20:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 14.11.2024 20:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_User_CreatorUserId] FOREIGN KEY([CreatorUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_User_CreatorUserId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category_CategoryId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_User_CreatorUserId] FOREIGN KEY([CreatorUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_User_CreatorUserId]
GO
ALTER TABLE [dbo].[ProductProperty]  WITH CHECK ADD  CONSTRAINT [FK_ProductProperty_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductProperty] CHECK CONSTRAINT [FK_ProductProperty_Product_ProductId]
GO
ALTER TABLE [dbo].[ProductProperty]  WITH CHECK ADD  CONSTRAINT [FK_ProductProperty_Property_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([PropertyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductProperty] CHECK CONSTRAINT [FK_ProductProperty_Property_PropertyId]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_OperationClaim_OperationClaimId] FOREIGN KEY([OperationClaimId])
REFERENCES [dbo].[OperationClaim] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_OperationClaim_OperationClaimId]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_User_UserId]
GO
