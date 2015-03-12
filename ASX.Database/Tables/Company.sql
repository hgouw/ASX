CREATE TABLE [dbo].[Company]
(
    [Code] VARCHAR(10) NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Company] PRIMARY KEY ([Code]) 
)