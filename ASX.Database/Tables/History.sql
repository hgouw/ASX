CREATE TABLE [dbo].[History]
(
    [Date] DATETIME NOT NULL, 
    [Code] NVARCHAR(10) NOT NULL, 
    [Open] DECIMAL(6, 3) NOT NULL, 
    [High] DECIMAL(6, 3) NOT NULL, 
    [Low] DECIMAL(6, 3) NOT NULL, 
    [Last] DECIMAL(6, 3) NOT NULL, 
    CONSTRAINT [FK_History_Company] FOREIGN KEY ([Code]) REFERENCES [Company]([Code]), 
    PRIMARY KEY ([Date], [Code])
)