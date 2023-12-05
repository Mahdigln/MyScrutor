using MyScrutor.Models;

namespace MyScrutor.Services.Simple
{
    public interface IBookRepository
    {
        void SaveBook(Book book);
    }
}
