-- Reference Data for WatchLists
MERGE INTO [dbo].[WatchLists] AS Target USING
(VALUES
  (N'A2M'),
  (N'AMP'),
  (N'ANZ'),
  (N'ASX'),
  (N'AYS'),
  (N'BAL'),
  (N'BFG'),
  (N'BHP'),
  (N'BKL'),
  (N'BSL'),
  (N'BTT'),
  (N'BWX'),
  (N'CBA'),
  (N'CGF'),
  (N'COH'),
  (N'CPU'),
  (N'CSL'),
  (N'CSR'),
  (N'DMP'),
  (N'FMG'),
  (N'FXJ'),
  (N'HVN'),
  (N'IAG'),
  (N'JBH'),
  (N'KMD'),
  (N'LNK'),
  (N'LYC'),
  (N'MEA'),
  (N'MPL'),
  (N'MQG'),
  (N'MYO'),
  (N'MYR'),
  (N'NAB'),
  (N'NEC'),
  (N'NHF'),
  (N'OZL'),
  (N'PPL'),
  (N'PPT'),
  (N'PTM'),
  (N'QAN'),
  (N'QBE'),
  (N'RIO'),
  (N'RMD'),
  (N'SVW'),
  (N'TEN'),
  (N'TLS'),
  (N'TRS'),
  (N'WBC'),
  (N'WES'),
  (N'WIG'),
  (N'WOW'),
  (N'WPL'),
  (N'XRO')
)
AS SOURCE ([Code])
ON Target.[Code] = Source.[Code]

-- Update matched rows
WHEN MATCHED THEN
UPDATE SET [Code] = Source.[Code]

-- Insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Code])
VALUES (Source.[Code]);