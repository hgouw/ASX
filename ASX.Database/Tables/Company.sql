CREATE TABLE [dbo].[Company]
(
    [Code] NVARCHAR(10) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Company] PRIMARY KEY ([Code]) 
)