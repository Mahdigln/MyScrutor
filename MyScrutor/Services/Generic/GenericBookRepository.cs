using MyScrutor.Models;

namespace MyScrutor.Services.Generic
{
    public class GenericBookRepository : IRepository<Book>
    {
        public void Save(Book entity)
        {
            Console.WriteLine("Executed code of save book");
        }
    }
}
