using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Service;
using WebAPI.Service.impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddScoped<ITodoService, TodoItemService>();
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Default"), 
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Default"))));
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