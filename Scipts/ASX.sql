select count(Code) from EndOfDays
where (Date >= '1997-01-01 00:00:00:000')
and (Date <= '2004-12-31 23:59:59:999')
and (Code = 'MPL')

select count(Code) from EndOfDays
where (Date >= '1997-01-01 00:00:00:000')
and (Date <= '2004-12-31 23:59:59:999')
and (Code = 'PPL')

delete from EndOfDays
where (Date >= '1997-01-01 00:00:00:000')
and (Date <= '2004-12-31 23:59:59:999')
and (Code = 'MPL')

delete from EndOfDays
where (Date >= '1997-01-01 00:00:00:000')
and (Date <= '2004-12-31 23:59:59:999')
and (Code = 'PPL')