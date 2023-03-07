using Application;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()   //!!! #avoid #bug #mistake
                                          .AllowAnyMethod()
                                         .AllowAnyHeader();
                                     // .AllowCredentials();
                      });
});  
                                

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddDbContext<TaskBoardContext>(options =>
  options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TaskBoard2"));

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
// app.UseDefaultFiles(); // needed to use JS/HTML/
app.UseStaticFiles();  // needed to use JS/HTML/
app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

// app.UseAuthorization();

app.MapControllers();

app.Run();

