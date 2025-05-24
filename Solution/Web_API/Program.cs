

using _1.DAL.DataContext;
using _1.DAL.Repositories;
using _2.BLL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


///Config - ConnectionString ------------------------------------------------------------------------------
builder.Services.AddDbContext<MakersDbContext>
        (options => options.UseSqlServer(builder.Configuration.GetConnectionString("_connectionString")));
//---------------------------------------------------------------------------------------------------------

// JWT -----------------------------------------------------------------------------------------------------
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
//-----------------------------------------------------------------------------------------------------------



///Congif - Interfaces_Services ---------------------------------------------------------------------------
builder.Services.AddScoped<IRepositoryAuth, RepositoryAuth>();
builder.Services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
builder.Services.AddScoped<IRepositoryPrestamo, RepositoryPrestamo>();



builder.Services.AddScoped<IServices,Services>();
//--------------------------------------------------------------------------------------------------------






// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

//Register Authentication method ----------------------------------------------------------- 
app.UseAuthentication();
//-----------------------------------------------------------------------------------------

app.UseAuthorization();

app.MapControllers();

app.Run();
