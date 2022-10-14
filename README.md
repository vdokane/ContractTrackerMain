# TODO  2022/10/07
--VERY NEXT TO DO  The incoming data stream of length 723832 exceeds the maximum allowed length 512000. (Parameter 'maxAllowedSize')
System.ArgumentOutOfRangeException: The incoming data stream of length 723832 exceeds the maximum allowed length 512000. (Parameter 'maxAllowedSize')
--Build IFileUpload Service


- Upload and download a document in Sanbox ..ugh https://stackoverflow.com/questions/62665194/blazor-webassembly-pwa-iformfile-fromform-is-always-null

# TODO  2022/09/06
- Redirect on lougout/force expire
- Commit finally
- Update DB to match production changes in legacy system
- Filters for griding system ..ugh.. 
--Seed script for [dbo].[ProcurementMethods] needs to be updated

# TODO  2022/08/05

- https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-6.0



# TODO  update 2022/06/29 (I think this is mostly done)

--very next thing is: Token builder should have issuer, _sec and audience passed in to the constructor
TokenBuilder is in common so how do I want to store that for the web app? isDev(), isStaging()? 


- Start work items in ADO to keep track of all of this instead of the read me
-  
- Finish up adding all services/factory <-- or do I want to leverage native DI more?
- General design
- Data migration
- Do sole source tables, routing.. 
- Better way to call SPs than in FDVCIS
- 3rd party stuff Calendars, grids
- CsvHelper <-- get the format files
- Document managment :( 
- ..and of course.. ui!


# Notes About NuGets
https://github.com/Tewr/BlazorFileReader/blob/main/src/Blazor.FileReader/Tewr.Blazor.FileReader.md

Do not update any of the web assembly packages without update the .net core SDK or it will break everything
C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App
