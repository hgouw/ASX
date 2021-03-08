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

4. Added the new script files to update the Companies, WatchLists and EndOfDays tables with the new ASX company in the folder ASX\Scripts

5. Delete all records from the WatchLists and EndOfDays tables

6. Load the EndOfDays data of the new ASX company using ASX DataLoader

7. Generate the script file for the EndOfDays data of the new ASX company using ASX DataLoader

# How to copy the ASX database on SQL Server 2016 or 2017 from on-premise to Azure and vice versa:

1. On the source (on-premise or Azure):  
   a. Right hand click on "ASX"  
   b. Select "Task"  
   c. Click "Export Data-tier application"  
   d. Select "Save to local disk" or "Save to Microsoft Azure"

2. On the destination (on-premise or Azure):  
   a. Right hand click on "Databases"  
   b. Click "Import Data-tier application"  
   c. Select "Import from local disk" or "Import from Windows Azure"  
   d. Specify settings for the new Microsoft Azure SQL Database  
   &nbsp; &nbsp; New database name: ASX  
   &nbsp; &nbsp; Edition of Microsoft Azure SQL Database: Basic  
   &nbsp; &nbsp; Maximum database size (GB): 1  
   &nbsp; &nbsp; Service Objective: Basic










