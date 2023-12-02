using AluraBot.Domain.Interfaces.Services;
using AluraBot.Domain.Models;
using AluraBot.Service.Handlers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace AluraBot.Service
{
    public class SeleniumService : IAluraService, IDisposable
    {
        private IWebDriver _webDriver;
        private HtmlHandler _htmlHandler;

        public SeleniumService()
        {
            _webDriver = new ChromeDriver();
            _htmlHandler = new HtmlHandler();
        }

        public void AccessAlura()
        {
            try
            {
                _webDriver.Navigate().GoToUrl("https://www.alura.com.br/");
            }
            catch
            {
                throw new Exception("Falha ao acessar o site");
            }
        }

        public void SearchCourse(string courseName)
        {
            try
            {
                _webDriver.FindElement(By.Id("header-barraBusca-form-campoBusca"))
                .SendKeys(courseName + Keys.Enter);
            }
            catch
            {
                throw new Exception($"Falha ao consultar o conteúdo: {courseName}");
            }
        }

        public IEnumerable<Course> GetListCourses()
        {
            var coursesList = new List<Course>();

            try
            {
                do
                {
                    var nextPageElement = _webDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/nav/a[2]"));

                    var courses = _htmlHandler.GetListCourses(_webDriver.PageSource);

                    coursesList.AddRange(courses);

                    var pagination = nextPageElement.GetAttribute("class");

                    if (pagination.Contains("disabled"))
                        break;

                    nextPageElement.Click();

                } while (true);
            }
            catch
            {
                throw new Exception("Falha ao resgatar as informações dos cursos pesquisados");
            }

            return coursesList;
        }

        public void GetDetailsOfCourses(Course item)
        {
            try
            {
                _webDriver.Navigate().GoToUrl(item.Url);

                var totalHour = _webDriver.FindElement(By.XPath("/html/body/section[1]/div/div[2]/div[1]/div/div[1]/div/p[1]")).Text;
                var instructor = _webDriver.FindElement(By.XPath("/html/body/section[2]/div[1]/section/div/div/div/h3")).Text;

                item.SetTotalHour(totalHour);
                item.SetInstructor(instructor);
                item.SetStatusMessage(true, "Informações resgatadas com sucesso");
            }
            catch
            {
                item.SetStatusMessage(false, "Falha ao resgatar Carga Horário / Instrutor");
            }

            _webDriver.Navigate().Back();
        }

        public void Dispose()
        {
            _webDriver.Quit();
        }
    }
}
