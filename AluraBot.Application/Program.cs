// See https://aka.ms/new-console-template for more information
using AluraBot.Service.Handler;

using (var handler = new SeleniumHandler())
{   
    handler.AccessAlura();
    handler.SearchCourse("rpa");
    var courses = handler.GetListCourses();

    foreach (var course in courses)
    {
        handler.GetDetailsOfCourses(course);
    }
}
