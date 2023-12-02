using AluraBot.Data.Context;
using AluraBot.Domain.Interfaces.Repository;
using AluraBot.Domain.Interfaces.Services;

namespace AluraBot.Application
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICourseRepository _courseRepository;
        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger, AppDbContext dbContext, ICourseRepository courseRepository)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _courseRepository = courseRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var coursesList = await _courseRepository.GetAll();

                using (var scope = _serviceProvider.CreateScope())
                {
                    var handler = scope.ServiceProvider.GetRequiredService<IAluraService>();

                    handler.AccessAlura();
                    handler.SearchCourse("rpa");
                    var courses = handler.GetListCourses();

                    foreach (var course in courses)
                    {
                        handler.GetDetailsOfCourses(course);
                        _courseRepository.Insert(course);
                    }
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
