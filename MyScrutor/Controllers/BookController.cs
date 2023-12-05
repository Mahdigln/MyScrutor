using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyScrutor.Models;
using MyScrutor.Services.Generic;
using MyScrutor.Services.Simple;

namespace MyScrutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IRepository<Book> _genericbooksRepository;
        public BookController(IBookRepository bookRepository, IRepository<Book> genericbooksRepository)
        {
            _bookRepository = bookRepository;
            _genericbooksRepository = genericbooksRepository;  
        }

        [HttpPost(nameof(SaveBook))]
        public IActionResult SaveBook(Book book)
        {
            try
            {
                _bookRepository.SaveBook(book);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Ok();
        }
    }
}
