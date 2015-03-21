-- Reference Data for Company
MERGE INTO [dbo].[Company] AS Target USING
(VALUES
  (N'CPU', N'COMPUTERSHARE LTD FPO', N'Software & Services'),
  (N'CSR', N'CSR LIMITED FPO', N'Materials'),
  (N'FXJ', N'FAIRFAX MEDIA LTD FPO', N'Media'),
  (N'MPL', N'MEDIBANK PRIVATE LTD FPO', N'Insurance')
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