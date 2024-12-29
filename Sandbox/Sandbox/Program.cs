using Sandbox.Database;
using Sandbox.Scaffolding;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.RegisterServices("Service");
builder.Services.RegisterServices("Repository");
builder.Services.AddSingleton<DatabaseConnection>();

builder.Logging.ClearProviders();
builder.Logging.AddNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
