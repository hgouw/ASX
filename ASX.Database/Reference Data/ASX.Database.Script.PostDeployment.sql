/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r ".\IndustryGroup.insert.data.sql"
--:r ".\IndustryGroup.merge.data.sql"
:r ".\Company.insert.data.sql"
--:r ".\Company.merge.data.sql"
:r ".\WatchList.insert.data.sql"
--:r ".\WatchList.merge.data.sql"
:r ".\EndOfDay.insert.data.1997.sql"
:r ".\EndOfDay.insert.data.1998.sql"
:r ".\EndOfDay.insert.data.1999.sql"
:r ".\EndOfDay.insert.data.2000.sql"
:r ".\EndOfDay.insert.data.2001.sql"
:r ".\EndOfDay.insert.data.2002.sql"
:r ".\EndOfDay.insert.data.2003.sql"
:r ".\EndOfDay.insert.data.2004.sql"
:r ".\EndOfDay.insert.data.2005.sql"
:r ".\EndOfDay.insert.data.2006.sql"
:r ".\EndOfDay.insert.data.2007.sql"
:r ".\EndOfDay.insert.data.2008.sql"
:r ".\EndOfDay.insert.data.2009.sql"
:r ".\EndOfDay.insert.data.2010.sql"
:r ".\EndOfDay.insert.data.2011.sql"
:r ".\EndOfDay.insert.data.2012.sql"
:r ".\EndOfDay.insert.data.2013.sql"
:r ".\EndOfDay.insert.data.2014.sql"
:r ".\EndOfDay.insert.data.2015.sql"
:r ".\EndOfDay.insert.data.2016.sql"
:r ".\EndOfDay.insert.data.2017.sql"
GO