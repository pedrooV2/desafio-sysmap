using AluraBot.Domain.Models;

namespace AluraBot.Domain.Interfaces.Services
{
    public interface IAluraService
    {
        void AccessAlura();
        void SearchCourse(string courseName);
        IEnumerable<Course> GetListCourses();
        void GetDetailsOfCourses(Course item);
    }
}
