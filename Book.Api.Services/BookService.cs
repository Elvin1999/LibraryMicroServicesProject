using BookApi.Data.Context;
using BookApi.Data.Entities;
using BookApi.Infrastructure;
using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public class BookService:IBookService
    {
        private LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id==id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            var book=_context.Books.FirstOrDefault(b => b.Id==id);
            return book;
        }
    }
}
