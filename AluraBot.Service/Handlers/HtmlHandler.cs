using AluraBot.Domain.Models;
using HtmlAgilityPack;

namespace AluraBot.Service.Handlers
{
    public class HtmlHandler
    {
        private HtmlDocument _htmlDocument;
        public HtmlHandler()
        {
            _htmlDocument = new HtmlDocument();
        }

        public IEnumerable<Course> GetListCourses(string pageContent)
        {
            _htmlDocument.LoadHtml(pageContent);

            var coursesList = new List<Course>();

            var courseItems = _htmlDocument.DocumentNode
                .SelectNodes("/html/body/div[2]/div[2]/section/ul/li");

            foreach (var item in courseItems)
            {
                var mainInfo = item.ChildNodes.First(c => c.Name == "a");

                var url = mainInfo
                    .Attributes
                    .First(c => c.Name == "href")
                    .Value;

                var courseInfo = mainInfo
                    .ChildNodes
                    .First(c => c.Name == "div")
                    .ChildNodes;

                var title = courseInfo.First(c => c.Name == "h4").InnerText;
                var description = courseInfo.First(c => c.Name == "p").InnerText;

                var course = new Course(title, description, url);

                coursesList.Add(course);
            }

            return coursesList;
        }
    }
}
