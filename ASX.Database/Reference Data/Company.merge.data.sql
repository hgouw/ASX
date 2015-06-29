-- Reference Data for Company
MERGE INTO [dbo].[Companies] AS Target USING
(VALUES

)
AS SOURCE ([Code], [Name], [Group])
ON Target.[Code] = Source.[Code]

-- Update matched rows
WHEN MATCHED THEN
UPDATE SET [Code] = Source.[Code],
           [Name] = Source.[Name],
           [Group] = Source.[Group]

-- Insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Code], [Name], [Group])
VALUES (Source.[Code], Source.[Name], Source.[Group]);