using CourierServices.Core.Models.Abstractions;
using CourierServices.DataAccess;
using CourierServices.DataAccess.Repositories;
using CourierServices.Application.Services;
using CourierServices.Infrasrtucture;
using Microsoft.EntityFrameworkCore;

namespace CourierServices
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


            builder.Services.AddDbContext<CourierServicesDbContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration["ConnectionStrings:CourierServicesConnectionString"]);
            });

            builder.Services.AddScoped<ICourierServices, CourierServicesRepository>();
            builder.Services.AddScoped<ICoreFunctionalityService, CoreFunctionalityService>();
            builder.Services.AddScoped<IValidator, Validator>();

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
