using AluraBot.Data.Context;
using AluraBot.Domain.Interfaces.Repository;
using AluraBot.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraBot.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;

        public CourseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _dbContext
                .Courses
                .AsNoTracking()
                .ToListAsync();  
        }

        public async void Insert(Course course)
        {
            await _dbContext.AddAsync(course);
            await _dbContext.SaveChangesAsync();
        }
    }
}
