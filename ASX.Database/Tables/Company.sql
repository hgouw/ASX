CREATE TABLE [dbo].[Companies]
(
    [Code] VARCHAR(10) NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [Group] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Company] PRIMARY KEY ([Code]), 
    CONSTRAINT [FK_Company_IndustryGroup] FOREIGN KEY ([Group]) REFERENCES [dbo].[IndustryGroups] ([Group])
)