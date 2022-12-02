# TODO  Last Updated 2022/11/14

## Default placement of DB
https://stackoverflow.com/questions/10170305/setting-defaultdatapath-and-defaultlogpath-programmatically-using-sql-statement
:setvar DefaultDataPath "C:\Users\OKANE.DAVID\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\OKANE.DAVID\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

## Where you left off
Finish IApplicationErrorLogCommandRepository, service, etc. Go ahead and set up an in memory unit test?
And can SelectFiler.razor be accessed?

## Error
- Error boundries on client, in a catch, call ErrorServiceApi, figure out error request model. 
- Create a client error log table
- Create a server error log table <-- Inject in BusinessRuleExceptionMiddleware
- Inject Logger into all pages


## Document Management
- VERY NEXT TO DO  The incoming data stream of length 723832 exceeds the maximum allowed length 512000. (Parameter 'maxAllowedSize')
- System.ArgumentOutOfRangeException: The incoming data stream of length 723832 exceeds the maximum allowed length 512000. (Parameter 'maxAllowedSize')
https://stackoverflow.com/questions/38698350/increase-upload-file-size-in-asp-net-core

- Build IFileUpload Service

## Security
- Redirect on lougout/force expire
- Update DB to match production changes in legacy system ..Person/User
- very next thing is: Token builder should have issuer, _sec and audience passed in to the constructor
- For above statment - Make sure that the local storage is getting saved and retrieved as a MODEL not just the token
- TokenBuilder is in common so how do I want to store that for the web app? isDev(), isStaging()? 

## Griding
- Filters for griding system ..ugh.. 

## Data Migration
- Seed script for [dbo].[ProcurementMethods] needs to be updated
- Data migration -> Get rid of the concept of document, Budget Updates ContractUsers, not person, get rid of persons

## Pipelines
- Get the GitHub Action CI pipeline running: https://github.com/readme/guides/sothebys-github-actions

- Finish up adding all services/factory <-- or do I want to leverage native DI more?

## UI
- General design

## Sole Source
- Do sole source tables, routing.. 
- Better way to call SPs than in FDVCIS
- 3rd party stuff Calendars, grids
- CsvHelper <-- get the format files
- ..and of course.. all new ui design!
