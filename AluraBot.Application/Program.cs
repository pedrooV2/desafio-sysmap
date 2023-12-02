// See https://aka.ms/new-console-template for more information
using AluraBot.Data.Context;
using AluraBot.Service.Handler;

using (var dbContext = new AppDbContext())
{
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
    var coursesList = dbContext.Courses.ToList();
}


