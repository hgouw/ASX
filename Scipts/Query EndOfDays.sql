USE [ASX]
GO

SELECT COUNT(Code) FROM EndOfDays
WHERE (Date >= '1997-01-01 00:00:00:000')
AND (Date <= '2004-12-31 23:59:59:999')
AND (Code = 'MPL')

SELECT COUNT(Code) FROM EndOfDays
WHERE (Date >= '1997-01-01 00:00:00:000')
AND (Date <= '2004-12-31 23:59:59:999')
AND (Code = 'PPL')

DELETE FROM EndOfDays
WHERE (Date >= '1997-01-01 00:00:00:000')
AND (Date <= '2004-12-31 23:59:59:999')
AND (Code = 'MPL')

DELETE FROM EndOfDays
WHERE (Date >= '1997-01-01 00:00:00:000')
AND (Date <= '2004-12-31 23:59:59:999')
AND (Code = 'PPL')