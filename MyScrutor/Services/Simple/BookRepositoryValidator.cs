using MyScrutor.Models;

namespace MyScrutor.Services.Simple
{
    public class BookRepositoryValidator : IBookRepository
    {
        private readonly IBookRepository _bookRepository;
        public BookRepositoryValidator(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void SaveBook(Book book)
        {
            if (book.Name == string.Empty)
            {
                throw new ArgumentException("Name can not be empty");
            }
            _bookRepository.SaveBook(book);
        }
    }
}
