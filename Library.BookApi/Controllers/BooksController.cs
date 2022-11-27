using BookApi.Data.Entities;
using BookApi.Infrastructure;
using BookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public BookDto Get(int id)
        {
            var book = _bookService.GetBookById(id);
            var dto = new BookDto
            {
                Author = book.Author,
                Id = id,
                Price = book.Price,
                Quantity = book.Quantity,
                Title = book.Title,
            };
            return dto;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }

        [HttpGet("")]
        public List<BookDto> GetAll()
        {
            var dtos = _bookService.GetAll().Select(d =>
            {
                return new BookDto
                {
                    Id = d.Id,
                    Title = d.Title,
                    Quantity = d.Quantity,
                    Price = d.Price,
                    Author = d.Author,
                };
            });
            return dtos.ToList();
        }
        [HttpPost("")]
        public BookDto Add(BookDto book)
        {
            _bookService.Add(new Book
            {
                 Id = book.Id,
                  Author = book.Author,
                   Price = book.Price,
                    Quantity=   book.Quantity,
                     Title= book.Title,
            });
            return book;
        }
    }
}
