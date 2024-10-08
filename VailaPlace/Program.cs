using Microsoft.EntityFrameworkCore;
using VailaPlace.Data;
using VailaPlace.Mapping;
using VailaPlace.Repository.IRepository;
using VailaPlace.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
#region log
//Log.Logger=new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/vailalig.txt",rollingInterval:RollingInterval.Day).CreateLogger();
//builder.Host.UseSerilog(); 
//builder.Services.AddControllers(option =>
//{
//}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
#endregion

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Dependancy Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Dependancy Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add AutoMaper
builder.Services.AddAutoMapper(typeof(MappingConfig));


var Key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
//AddAuth
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken=true;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key)),
        ValidateIssuer = false,
        ValidateAudience = false ,
    };

});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

