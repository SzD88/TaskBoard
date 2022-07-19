using Application.AutoMappings;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISubTaskRepository, SubTaskRepository>();
builder.Services.AddScoped<ISubTaskService, SubTaskService>();
// builder.Services.AddScoped<IProjectsRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddDbContext<ProjectManagerContext>(options =>
options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProjectManager"));  // klasa kontekstu 


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); // *
}
);
builder.Services.AddSingleton(AutoMapperConfig.Initialize());


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDefaultFiles(); // needed to use JS/HTML/
app.UseStaticFiles();  // needed to use JS/HTML/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
