
using Microsoft.EntityFrameworkCore;
using TentaHub.Models;

var builder = WebApplication.CreateBuilder(args);

string dbConnectionString = builder.Configuration.GetConnectionString("mysql");

/// <summary>
/// Services
/// </summary>
/// <returns></returns>



builder.Services.AddControllers();
builder.Services.AddDbContext<UniversityContext>(opt => opt.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.Logger.LogDebug("MySQL connection string: "+dbConnectionString);


app.UseHttpsRedirection();
app.MapControllers();

app.Run();
