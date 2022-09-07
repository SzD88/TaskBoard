using Application;
using Application.AutoMappings;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace WebAPI
{

    public class Program
    {
        //public IConfiguration Configuration { get; }

        //public Program(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
         
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();

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

        }
    }
}
