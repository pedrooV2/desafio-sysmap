using AluraBot.Data.Context;
using AluraBot.Data.Repository;
using AluraBot.Domain.Interfaces;
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

            builder.Services.AddSingleton<ICourseRepository, CourseRepository>();
            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }
    }
}