MERGE INTO Ticker AS Target USING
(VALUES
  (N'CPU', N'COMPUTERSHARE LTD FPO'),
  (N'CSR', N'CSR LIMITED FPO'),
  (N'FXJ', N'FAIRFAX MEDIA LTD FPO'),
  (N'MPL', N'MEDIBANK PRIVATE LTD FPO')
)
AS SOURCE ([Code], CompanyName)
ON Target.Code = Source.Code

WHEN MATCHED THEN
UPDATE SET [Code] = Source.[Code],
           CompanyName = Source.CompanyName

WHEN NOT MATCHED BY TARGET THEN
INSERT ([Code], CompanyName)
VALUES (Source.[Code], Source.CompanyName);