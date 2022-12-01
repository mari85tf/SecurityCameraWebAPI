using SecurityCameraWebAPI.Interfaces;
using SecurityCameraWebAPI.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ICameraManager, CameraManager>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
