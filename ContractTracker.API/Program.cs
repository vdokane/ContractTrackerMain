using ContractTracker.API.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer; //Use NuGet Microsoft.AspNetCore.Authentication.JwtBearer

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddHttpContextAccessor(); //For passing the HttContext into services

//Stored in secrets.json, whish needs to be managed per project by Manager User Secrets. 
var issuerSigningKey = builder.Configuration["IssuerSigningKey"];

//Allow the app to use JWT authentication, all requests will need to have this to pass
//This should allow cookie and JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                authenticationScheme: JwtBearerDefaults.AuthenticationScheme,
                configureOptions: options =>
                {
                    //Configuration.Bind("JwtSettings", options)
                    options.IncludeErrorDetails = true;
                    options.TokenValidationParameters =
                        new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                        {
                            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(issuerSigningKey)), 
                            ValidAudience = @"http://localhost:44340", //This is who can consume it, the client 
                            ValidIssuer = @"http://localhost:25940",  //This is the API app the created the token
                            RequireExpirationTime = false,
                            ValidateIssuer = false,
                            ValidateLifetime = false,
                            ValidateAudience = false
                        };
                });


//TODO so it can use normal cookies also .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => Configuration.Bind("CookieSettings", options));




//Register NONE business services for injection. Ex: Authorization, Authentication services, HttpContext services, etc.
builder.Services.AddTransient<ISignedInUserService, SignedInUserService>();
 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
 }

app.UseCors(); //?? Will this work?
app.UseAuthorization();

app.MapControllers();

app.Run();
