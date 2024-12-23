USE [CafeMenu]
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Name], [Surname], [Username], [PasswordSalt], [PasswordHash], [Status]) VALUES (1, N'Aykut', N'Öztürk', N'aykutozturk', 0x9F8D5F72D2360476CE8C6D0A048E92F5094516839FB662965CF5CC9927D6E68D50F4F11BDFFA243BC5879F388B02B3B7A9BF6C191FE9890F4A734E925E2A0A01C5B8A4281B6739F2573C6F647ADA17BB4231DD2E9564960DDA23870430C564AF60497A95B8FE132912168457B4AC76B8C30D818EBA5B75D1B46610D8DC660DD6, 0x8F37818F0700B181098139DFB43033CDD1AE5F2325A557B7BD60F05C8483669F5952FA2C731C06700F5CF19ACA9369F092545102C58BEB0429863476CE0F5F88, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Property] ON 

INSERT [dbo].[Property] ([PropertyId], [Key], [Value]) VALUES (1, N'Stok', N'10')
SET IDENTITY_INSERT [dbo].[Property] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [ParentCategoryId], [CreatorUserId], [CategoryName], [IsDeleted], [CreatedDate]) VALUES (1, 0, 1, N'Bilgisayar', 0, CAST(N'2024-11-13T13:37:15.267' AS DateTime))
INSERT [dbo].[Category] ([CategoryId], [ParentCategoryId], [CreatorUserId], [CategoryName], [IsDeleted], [CreatedDate]) VALUES (2, 1, 1, N'Notebookk', 1, CAST(N'2024-11-13T14:10:53.830' AS DateTime))
INSERT [dbo].[Category] ([CategoryId], [ParentCategoryId], [CreatorUserId], [CategoryName], [IsDeleted], [CreatedDate]) VALUES (3, 1, 1, N'Notebook', 0, CAST(N'2024-11-15T10:43:38.900' AS DateTime))
INSERT [dbo].[Category] ([CategoryId], [ParentCategoryId], [CreatorUserId], [CategoryName], [IsDeleted], [CreatedDate]) VALUES (4, 1, 1, N'Masaüstü Bilgisayarlar', 0, CAST(N'2024-11-15T10:44:49.183' AS DateTime))
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [CategoryId], [CreatorUserId], [ProductName], [Price], [ImagePath], [IsDeleted], [CreatedDate]) VALUES (3, 1, 1, N'Lenovo IdeaPad Gaming 3', CAST(35000.00 AS Decimal(18, 2)), N'/Images/d485cc80-238b-4a53-bd36-4f1b3b7c2497_11_14_2024.PNG', 0, CAST(N'2024-11-14T18:41:42.067' AS DateTime))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductProperty] ON 

INSERT [dbo].[ProductProperty] ([ProductPropertyId], [ProductId], [PropertyId]) VALUES (3, 3, 1)
SET IDENTITY_INSERT [dbo].[ProductProperty] OFF
GO
