CREATE TABLE [dbo].[History]
(
    [Code] VARCHAR(10) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Open] DECIMAL(6, 3) NOT NULL, 
    [High] DECIMAL(6, 3) NOT NULL, 
    [Low] DECIMAL(6, 3) NOT NULL, 
    [Last] DECIMAL(6, 3) NOT NULL, 
    PRIMARY KEY ([Code], [Date]),
    CONSTRAINT [FK_History_Company] FOREIGN KEY ([Code]) REFERENCES [dbo].[Company]([Code])
)