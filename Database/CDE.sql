USE master
GO

DROP DATABASE IF EXISTS CDE
CREATE DATABASE CDE
GO

USE CDE
GO

SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [Password], [Fullname], [Email], [Phone], [Address], [Photo], [Description], [Status], [Created], [SuperiorId], [Inferior], [PermissionId], [PositionTitleId], [DistributorId], [AreaId]) VALUES (1, N'$2a$11$LCeQmD3q06CZFLyvO96dVedCrON32rLReeo3OdkU7UbSs1YjVrQEC', N'string', N'user@example.com', NULL, NULL, NULL, NULL, 1, CAST(N'2024-03-27T16:11:09.6594063' AS DateTime2), NULL, NULL, N'[3, 4, 5]', 1, NULL, NULL)

SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO

