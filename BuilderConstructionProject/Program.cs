
using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using BuilderConstructionProject.TokenUtility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter
            (new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                //ContractResolver=new CamelCasePropertyNamesContractResolver()
                PropertyNameCaseInsensitive = false,
                PropertyNamingPolicy = null,
                WriteIndented = true,
                TypeInfoResolver = JsonSerializerOptions.Default.TypeInfoResolver,
            }));
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<InvContext>(options =>
{
    // Provide the connection string for the SQL Server
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
    sqlOptions => sqlOptions.MigrationsAssembly("BuilderConstructionProject")); // Specify the migrations assembly here
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});



builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITokenServrice, TokenManager>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(op =>
{
    op.Password.RequiredLength = 7;
    op.Password.RequireUppercase = false;
    op.User.RequireUniqueEmail = true;
    op.Password.RequireDigit = false;
}).AddEntityFrameworkStores<InvContext>()
                .AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
{

    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(op =>
{
    op.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        //ValidateAudience = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7244",
        ValidAudience = "https://localhost:44386",
        // ValidAudience = "https://localhost:50869",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKeysuperSecretKey@345"))
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
