CREATE TABLE [dbo].[WatchLists]
(
	[Code] VARCHAR(10) NOT NULL, 
	CONSTRAINT [PK_WatchList] PRIMARY KEY ([Code]), 
	CONSTRAINT [FK_WatchList_Company] FOREIGN KEY ([Code]) REFERENCES [dbo].[Companies]([Code])
)