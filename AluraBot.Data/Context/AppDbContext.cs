using AluraBot.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraBot.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
