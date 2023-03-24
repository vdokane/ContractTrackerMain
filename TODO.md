

Was this supposed to be in this project?
ContractTracker.Export.Test
Git/Get MSBuil working on the SSDT so you can check in your GitHubAction build yaml

# TODO  Last Updated 2023/3/24
REMOVE filter component models.. the IDictionary maps it for you. Thank you Blazor!
DateTime drop down is sending wrong wrong.
Each filter control needs a heading text/param
Get the call backs, er, delegates working! 

---TODO db stuff
Make sure Service types have a seed script and are now maintained in this DB like the legacy db.
What about load proc methods
New vendor table needs actual aduit fields
So the very next thing to do is finish the migration script between SandBoxLite to ContractTracker
That way the vendor table will be populated and you will have records to use for searching. 
 USE SandBoxLite
 GO
 select count(1) from Vendors
 --199500
THAT WAY... you can build a new griding/search system. 


## Where you left off
Why is my LIKE broke in VendorSearch? Noob!  System.InvalidCastException: 'Unable to cast object of type 'System.Int64' to type 'System.Int32'.'
Build a good repo for consuming it <-- in progress with the unit test. Do I need EXECUTE?


Since local DB has been created, test saving! IApplicationErrorService ..and getting. This will be a good table to use to test grid/filtering
And can SelectFiler.razor be accessed?
Test UOW mock transaction

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
