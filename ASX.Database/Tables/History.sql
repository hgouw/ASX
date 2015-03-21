CREATE TABLE [dbo].[History]
(
    [Date] DATETIME NOT NULL, 
    [Code] VARCHAR(10) NOT NULL, 
    [Open] DECIMAL(6, 3) NOT NULL, 
    [High] DECIMAL(6, 3) NOT NULL, 
    [Low] DECIMAL(6, 3) NOT NULL, 
    [Last] DECIMAL(6, 3) NOT NULL, 
    PRIMARY KEY ([Date], [Code]),
    CONSTRAINT [FK_History_Company] FOREIGN KEY ([Code]) REFERENCES [dbo].[Company]([Code])
)