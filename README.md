#If You Are Reading This
This is a project for tracking contracts. ...and for the author to learn webassembly. Free to use and I will always appreciate feedback

# Notes About NuGets
https://github.com/Tewr/BlazorFileReader/blob/main/src/Blazor.FileReader/Tewr.Blazor.FileReader.md

Do not update any of the web assembly packages without update the .net core SDK or it will break everything
C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App


## GOOD TO KNOW
https://stackoverflow.com/questions/63993294/there-was-no-runtime-pack-for-microsoft-aspnetcore-app-available-for-the-specifi
Client - Microsoft.NET.Sdk.BlazorWebAssembly
Server - Microsoft.NET.Sdk.Web
Shared - Microsoft.NET.Sdk

So do NOT put IFormFile in a common model. You will have to add the Framework Reference, Microsoft.AspNetCore.App and then 
change the project type. Which then causes a build error. So keep IFromFile api request and response models in the Blazor and API projects. Sucks