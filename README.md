# TODO  2022/08/05
- Very next this is have a pipeline catch this BusinessRuleException and return a 400 bad request
- https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-6.0
- Then have the client capture 400s and toast them with the messages
- Lastly, get the cookie to expire

# TODO  update 2022/06/29 (I think this is mostly done)

--very next thing is: Token builder should have issuer, _sec and audience passed in to the constructor
TokenBuilder is in common so how do I want to store that for the web app? isDev(), isStaging()? 


- Start work items in ADO to keep track of all of this instead of the read me
-  
- Finish up adding all services/factory <-- or do I want to leverage native DI more?
- Best way to do business rules and return it back to the client, should it just throw 500?
- General design
- Data migration
- Do sole source tables, routing.. 
- Better way to call SPs than in FDVCIS
- 3rd party stuff Calendars, grids
- CsvHelper <-- get the format files
- Document managment :( 
- ..and of course.. ui!