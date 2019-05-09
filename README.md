# How to add a new ASX company:

1. Download the latest ASXListedCompanies.csv from https://www.asx.com.au/asx/research/listedCompanies.do for the details of the company

2. Added the new ASX company in the following script files:
   ASX\ASX.Database\Reference Data\Company.insert.data.sql
   ASX\ASX.Database\Reference Data\Company.merge.data.sql
   ASX\ASX.Database\Reference Data\WatchList.insert.data.sql
   ASX\ASX.Database\Reference Data\WatchList.merge.data.sql

3. Added the new ASX company in the following text and csv files:
   ASX\Docs\Companies.txt
   ASX\Docs\InsertCompanies.txt
   ASX\Docs\MergeCompanies.txt
   ASX\Docs\WatchList.csv

4. Added the new script files to update the Companies, WatchLists and EndOfDays tables with the new ASX company in the folder ASX\Scipts

5. Delete all records from the WatchLists and EndOfDays tables

6. Load the EndOfDays data of the new ASX company using ASX DataLoader

7. Generate the script file for the EndOfDays data of the new ASX company using ASX DataLoader












