using Microsoft.EntityFrameworkCore;
using SecurityCameraWebAPI;
using SecurityCameraWebAPI.DBContext;
using SecurityCameraWebAPI.Interfaces;
using SecurityCameraWebAPI.Managers;

var builder = WebApplication.CreateBuilder(args);


string allowAllPolicy = "AllowAll";
// Add services to the container.

builder.Services.AddTransient<ICameraManager, CameraManager>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllPolicy,
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                              });
});
builder.Services.AddDbContext<CameraContext>(opt => opt.UseSqlServer(Secrets.ConnectionString));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseCors(allowAllPolicy);

app.MapControllers();

app.Run();
