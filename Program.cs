
using Microsoft.EntityFrameworkCore;
using TentaHub.Models;

var builder = WebApplication.CreateBuilder(args);

string dbConnectionString = builder.Configuration.GetConnectionString("mysql");



builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.Logger.LogDebug("MySQL connection string: "+dbConnectionString);

app.MapControllers();

app.Run();
