using AluraBot.Domain.Models;

namespace AluraBot.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        void Insert(Course course);
    }
}
