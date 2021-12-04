using Microsoft.EntityFrameworkCore;
using ToDoList.DataBase.Entities;

namespace ToDoList.DataBase
{
    public class ToDoListDbContext : DbContext
    {
        public DbSet<WorkTask> WorkTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=MAJTAJ\SQLEXPRESS;Database=ToDoList;Trusted_Connection=True;");
        }

    }
}
