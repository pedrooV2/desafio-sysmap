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

        public bool SearchedCourseExists(string pageContent)
        {
            _htmlDocument.LoadHtml(pageContent);

            var courseExists = _htmlDocument.DocumentNode.SelectSingleNode("//div[@class='search-noResult search-noResult--visible']") == null;

            return courseExists;
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

        public string GetInfoByXPathList(string pageContent, IEnumerable<string> xpathList)
        {
            _htmlDocument.LoadHtml(pageContent);

            foreach (var xpath in xpathList)
            {
                var node = _htmlDocument.DocumentNode.SelectSingleNode(xpath);

                if (node != null)
                    return node.InnerText;
            }

            return "Não foi possível resgatar a informação";
        }

        //public string GetCourseTotalHour(string pageContent)
        //{
        //    _htmlDocument.LoadHtml(pageContent);

        //    var node = _htmlDocument.DocumentNode.SelectSingleNode("//*[@class='formacao__info-conclusao']/div[2]/div");

        //    if (node != null)
        //        return node.InnerText;

        //    node = _htmlDocument.DocumentNode.SelectSingleNode("/html/body/section[1]/div/div[2]/div[1]/div/div[1]/div/p[1]");

        //    if (node != null)
        //        return node.InnerText;

        //    return "Não foi possível resgatar a Carga Horária";
        //}
    }
}
