﻿-- Reference Data for WatchLists
MERGE INTO [dbo].[WatchLists] AS Target USING
(VALUES
  (N'AMP'),
  (N'ANZ'),
  (N'ASX'),
  (N'BFG'),
  (N'BHP'),
  (N'BSL'),
  (N'BTT'),
  (N'CBA'),
  (N'CGF'),
  (N'COH'),
  (N'CPU'),
  (N'CSL'),
  (N'CSR'),
  (N'FMG'),
  (N'FXJ'),
  (N'HVN'),
  (N'IAG'),
  (N'JBH'),
  (N'KMD'),
  (N'LYC'),
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
  (N'WPL')
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