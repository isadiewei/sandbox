using Sandbox.Database;
using Sandbox.Scaffolding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers();
builder.Services.RegisterServices("Service");
builder.Services.RegisterServices("Repository");

builder.Services.AddSingleton<DatabaseConnection>();
builder.Logging.ConfigureLogging();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
