using AluraBot.Domain.Models;

namespace AluraBot.Domain.Interfaces.Services
{
    public interface IAluraService : IDisposable
    {
        void AccessAlura();
        bool SearchCourse(string courseName);
        IEnumerable<Course> GetListCourses();
        void GetDetailsOfCourses(Course item);        
    }
}
