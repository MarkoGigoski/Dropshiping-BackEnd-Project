using Dropshiping.BackEnd.Helpers;

namespace Dropshiping.BackEnd.Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Ineject Configuration String - SQL server
            DipendencyInjectionHelpers.InjectDbContext(builder.Services, builder.Configuration);

            //Inject Repository
            DipendencyInjectionHelpers.InjectRepositories(builder.Services);

            //Inject Service
            DipendencyInjectionHelpers.InjectService(builder.Services);

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
        }
    }
}