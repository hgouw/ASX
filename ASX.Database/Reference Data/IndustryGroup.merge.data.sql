-- Reference Data for IndustryGroup
MERGE INTO [dbo].[IndustryGroup] AS Target USING
(VALUES
  (N'Software & Services'),
  (N'Materials'),
  (N'Media'),
  (N'Insurance')
)
AS SOURCE ([Group])
ON Target.[Group] = Source.[Group]

-- Update matched rows
WHEN MATCHED THEN
UPDATE SET [Group] = Source.[Group]

-- Insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Group])
VALUES (Source.[Group]);