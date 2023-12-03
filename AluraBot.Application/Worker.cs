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
                Console.WriteLine("Qual tema deseja pesquisar na Alura hoje?");
                var courseInput = Console.ReadLine();

                if (string.IsNullOrEmpty(courseInput))
                {
                    Console.WriteLine("Digite um valor válido!");
                    continue;
                }

                using (var scope = _serviceProvider.CreateScope())
                {
                    using (var handler = scope.ServiceProvider.GetRequiredService<IAluraService>())
                    {
                        try
                        {
                            handler.AccessAlura();

                            if(handler.SearchCourse(courseInput))
                            {
                                var courses = handler.GetListCourses();

                                foreach (var course in courses)
                                {
                                    handler.GetDetailsOfCourses(course);
                                    _courseRepository.Insert(course);

                                    Console.WriteLine(course.ToString());
                                    Console.WriteLine("\n --------------------------------------------------------- \n");
                                }

                                Console.WriteLine($"Estes foram os resultados encontrados para o tema {courseInput}!");
                            }
                            else
                                Console.WriteLine("O tema pesquisado não retornou resultados. Tente outro tema.");
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError("Falha ao executar raspagem de dados no site Alura. Tente novamente!");
                            _logger.LogError("ERRO: " + ex.Message);
                        }
                    }
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
