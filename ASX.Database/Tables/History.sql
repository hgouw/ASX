CREATE TABLE [dbo].[History]
(
    [Code] NVARCHAR(10) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Open] DECIMAL(6, 3) NOT NULL, 
    [High] DECIMAL(6, 3) NOT NULL, 
    [Low] DECIMAL(6, 3) NOT NULL, 
    [Last] DECIMAL(6, 3) NOT NULL, 
    CONSTRAINT [FK_History_Ticker] FOREIGN KEY ([Code]) REFERENCES [Ticker]([Code]), 
    PRIMARY KEY ([Code], [Date])
)