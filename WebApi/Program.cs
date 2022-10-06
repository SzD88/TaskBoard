using Application;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddDbContext<ProjectManagerContext>(options =>
  options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProjectManager"));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); // *
            }
);

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

