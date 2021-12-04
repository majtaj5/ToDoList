using ToDoList.DataBase;

namespace ToDoList.Core.Helpers
{
    public class DataBaseLocator
    {
        public static ToDoListDbContext Database { get; set; }
    }
}
