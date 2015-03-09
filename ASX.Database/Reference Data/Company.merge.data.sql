-- Reference Data for Company
MERGE INTO Company AS Target USING
(VALUES
  (N'CPU', N'COMPUTERSHARE LTD FPO'),
  (N'CSR', N'CSR LIMITED FPO'),
  (N'FXJ', N'FAIRFAX MEDIA LTD FPO'),
  (N'MPL', N'MEDIBANK PRIVATE LTD FPO')
)
AS SOURCE ([Code], Name)
ON Target.Code = Source.Code

-- Update matched rows
WHEN MATCHED THEN
UPDATE SET [Code] = Source.[Code],
           Name = Source.Name

-- Insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Code], Name)
VALUES (Source.[Code], Source.Name);