USE master
GO

DROP DATABASE IF EXISTS CDE
CREATE DATABASE CDE
GO

USE CDE
GO

SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [PositionTitleId], [DistributorId], [AreaId]) VALUES (1, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user@example.com', NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'[3, 4, 5]', 1, NULL, NULL)

SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Areas] ON 

INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (1, N'VTT', N'VTT')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (2, N'ALTASOFTWARE', N'ALT')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (3, N'PRODUCT_QA', N'ALTA_QA')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (4, N'TEXT', N'TEST')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (5, N'ALTA', N'ALTA_QA')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (6, N'HCM', N'Hồ Chí Minh')
INSERT [dbo].[Areas] ([Id], [AreaCode], [AreaName]) VALUES (7, N'Test', N'string')
SET IDENTITY_INSERT [dbo].[Areas] OFF
GO
SET IDENTITY_INSERT [dbo].[PermissionModules] ON 

INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (1, N'Visit plans', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (2, N'Notification', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (3, N'Survey', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (4, N'CMS', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (5, N'Users', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (6, N'Areas', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (7, N'Distributors', NULL)
INSERT [dbo].[PermissionModules] ([Id], [Name], [PermissionIds]) VALUES (8, N'System configuration', NULL)
SET IDENTITY_INSERT [dbo].[PermissionModules] OFF
GO
SET IDENTITY_INSERT [dbo].[Permissions] ON 

INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (1, N'View all visit plans', 1, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (2, N'Create new visit plan', 1, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (3, N'View all existing tasks', 1, 1)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (4, N'Create Notification', 2, 2)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (5, N'Create new survey', 3, 3)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (6, N'Send survey request', 3, 3)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (7, N'Create new article', 4, 4)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (8, N'Update article detail', 4, 4)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (9, N'Publish existing article
', 4, 4)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (10, N'Remove unpublish articles', 4, 4)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (11, N'Add new users', 5, 5)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (12, N'Update user detail', 5, 5)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (13, N'Reset password', 5, 5)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (14, N'Permission setting', 5, 5)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (15, N'Create new area', 6, 6)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (16, N'Update area detail', 6, 6)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (17, N'Delete areas', 6, 6)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (18, N'Create new distributor', 7, 7)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (19, N'Update detail distributor', 7, 7)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (20, N'Delete distributor', 7, 7)
INSERT [dbo].[Permissions] ([Id], [Name], [PermissionMuduleId], [PermissionModulesId]) VALUES (21, N'Edit system configuration', 8, 8)
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
SET IDENTITY_INSERT [dbo].[PositionGroups] ON 

INSERT [dbo].[PositionGroups] ([Id], [Name]) VALUES (1, N'System')
INSERT [dbo].[PositionGroups] ([Id], [Name]) VALUES (2, N'Sales')
INSERT [dbo].[PositionGroups] ([Id], [Name]) VALUES (3, N'Distributor')
INSERT [dbo].[PositionGroups] ([Id], [Name]) VALUES (4, N'Guest')
SET IDENTITY_INSERT [dbo].[PositionGroups] OFF
GO
SET IDENTITY_INSERT [dbo].[PositionTitles] ON 

INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (1, N'Administrator', CAST(N'2024-03-26T17:14:18.5961758' AS DateTime2), NULL, 1)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (2, N'Owner', CAST(N'2024-03-26T17:14:36.3672619' AS DateTime2), NULL, 1)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (3, N'VPCD', CAST(N'2024-03-26T17:14:51.4235618' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (4, N'BM', CAST(N'2024-03-26T17:14:56.7506494' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (5, N'Chanel Activation Head', CAST(N'2024-03-26T17:15:11.1869608' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (6, N'ASM', CAST(N'2024-03-26T17:15:19.3316762' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (7, N'BAM', CAST(N'2024-03-26T17:15:23.8334411' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (8, N'CE – Capability Executive', CAST(N'2024-03-26T17:15:36.2295437' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (9, N'Sale SUP – Sale Supervisor', CAST(N'2024-03-26T17:15:46.3446364' AS DateTime2), NULL, 2)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (10, N'Distributor - OM/TL', CAST(N'2024-03-26T17:15:58.9088163' AS DateTime2), NULL, 3)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (11, N'Other Department', CAST(N'2024-03-26T17:16:18.2700234' AS DateTime2), NULL, 4)
INSERT [dbo].[PositionTitles] ([Id], [Name], [created], [PermissionIds], [PositionGroupId]) VALUES (12, N'Guest', CAST(N'2024-03-26T17:16:25.8445029' AS DateTime2), NULL, 4)
SET IDENTITY_INSERT [dbo].[PositionTitles] OFF
GO