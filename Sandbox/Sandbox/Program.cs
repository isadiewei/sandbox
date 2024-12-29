using Sandbox.Database;
using Sandbox.Repository;
using Service;
using Sandbox.Scaffolding;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.RegisterServices("Service");
builder.Services.RegisterServices("Repository");
builder.Services.AddSingleton<DatabaseConnection>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
