using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Helpers;
using ProductManagement.Core.DataServices;
using ProductManagement.Core.Processors;
using ProductManagement.Persistence;
using ProductManagement.Persistence.Repositories;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = "Filename=:memory:";
var conn = new SqliteConnection(connString);
conn.Open();

builder.Services.AddDbContext<ProductManagementDbContext>(opt => opt.UseSqlite(conn));

DatabaseHelper.EnsureDatabaseCreated(conn);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductProcessor, ProductProcessor>();

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .WriteTo.File(path: "c:\\prodmgmtlogs\\logs\\log-.txt",
                outputTemplate: "{Timestamp: yyyy-MM-dd HH:mm:ss.fff zzz} [{Level: u3}] {Message:lj}{NewLine}{Exception}",
                rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: LogEventLevel.Information
  ).CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
