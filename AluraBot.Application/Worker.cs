using AluraBot.Data.Context;
using AluraBot.Domain.Interfaces;
using AluraBot.Service.Handler;

namespace AluraBot.Application
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICourseRepository _courseRepository;

        public Worker(ILogger<Worker> logger, AppDbContext dbContext, ICourseRepository courseRepository)
        {
            _logger = logger;
            _courseRepository = courseRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var coursesList = await _courseRepository.GetAll();

                using (var handler = new SeleniumHandler())
                {
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
