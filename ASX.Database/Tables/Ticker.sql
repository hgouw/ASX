CREATE TABLE [dbo].[Ticker]
(
    [Ticker] NVARCHAR(10) NOT NULL, 
    [CompanyName] NCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Ticker] PRIMARY KEY ([Ticker]) 
)
