using Sandbox.Database;
using Sandbox.Scaffolding;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.RegisterServices("Service");
builder.Services.RegisterServices("Repository");

builder.Services.AddSingleton<DatabaseConnection>();
builder.Logging.ConfigureLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
