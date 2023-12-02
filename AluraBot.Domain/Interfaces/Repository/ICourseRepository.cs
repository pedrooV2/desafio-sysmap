using AluraBot.Domain.Models;

namespace AluraBot.Domain.Interfaces.Repository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        void Insert(Course course);
    }
}
