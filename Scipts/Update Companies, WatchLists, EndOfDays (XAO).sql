INSERT INTO [dbo].[Companies] ([Code], [Name], [Group]) VALUES (N'XAO', N'ALL ORDINARIES INDEX', N'Not Applic')
INSERT INTO [dbo].[WatchLists] ([Code]) VALUES (N'XAO')
ALTER TABLE [dbo].[EndOfDays] ALTER COLUMN [Open]   DECIMAL(8, 3)
ALTER TABLE [dbo].[EndOfDays] ALTER COLUMN [High]   DECIMAL(8, 3)
ALTER TABLE [dbo].[EndOfDays] ALTER COLUMN [Low]    DECIMAL(8, 3)
ALTER TABLE [dbo].[EndOfDays] ALTER COLUMN [Close]  DECIMAL(8, 3)
ALTER TABLE [dbo].[EndOfDays] ALTER COLUMN [Volume] bigint NULL