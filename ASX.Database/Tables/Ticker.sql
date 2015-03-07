CREATE TABLE [dbo].[Ticker]
(
    [Code] NVARCHAR(10) NOT NULL, 
    [CompanyName] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Ticker] PRIMARY KEY ([Code]) 
)