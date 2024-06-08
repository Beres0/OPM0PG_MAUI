using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using WSH_HomeAssignment.Domain;
using WSH_HomeAssignment.Infrastructure;

namespace WSH_HomeAssignment.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
      
            // Add services to the container.
            builder.Services.AddServices(builder);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(options =>
            {
                options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}