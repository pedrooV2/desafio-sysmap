using AluraBot.Data.Context;
using AluraBot.Data.Repository;
using AluraBot.Domain.Interfaces.Repository;
using AluraBot.Domain.Interfaces.Services;
using AluraBot.Service;
using Microsoft.EntityFrameworkCore;

namespace AluraBot.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("sqliteDb"));
            }, ServiceLifetime.Singleton);

            // repository DI
            builder.Services.AddSingleton<ICourseRepository, CourseRepository>();

            // service DI
            builder.Services.AddScoped<IAluraService, SeleniumService>();

            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }
    }
}