DELETE FROM [dbo].[Companies]

-- Insert Reference Data for Company
INSERT INTO [dbo].[Companies] ([Code], [Name], [Group]) VALUES (N'CPU', N'COMPUTERSHARE LTD FPO', N'Software & Services')
INSERT INTO [dbo].[Companies] ([Code], [Name], [Group]) VALUES (N'CSR', N'CSR LIMITED FPO', N'Materials')
INSERT INTO [dbo].[Companies] ([Code], [Name], [Group]) VALUES (N'FXJ', N'FAIRFAX MEDIA LTD FPO', N'Media')
INSERT INTO [dbo].[Companies] ([Code], [Name], [Group]) VALUES (N'MPL', N'MEDIBANK PRIVATE LTD FPO', N'Insurance')