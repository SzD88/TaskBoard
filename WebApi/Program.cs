using WebAPI.Installers;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
 
var builder = WebApplication.CreateBuilder(args);
 
var frontendAdress = builder.Configuration.GetConnectionString("FrontEndCS") ;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                         policy
                        .WithOrigins(frontendAdress)
                        .SetIsOriginAllowed((host) => true);
                         policy
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                      });
});
 
builder.Services.InstallServicesInAssembly(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();

