using AluraBot.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraBot.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }
    }
}
