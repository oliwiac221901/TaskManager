using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Application;
using TaskManagerAPI.Application.Common.Interfaces;
using TaskManagerAPI.Persistence;
using TaskManagerAPI.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TaskManagerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TaskManagerDbConnection")));

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddScoped<ITaskManagerDbContext, TaskManagerDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

