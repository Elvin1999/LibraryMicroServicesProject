using BookApi.Data.Entities;
using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Infrastructure
{
    public interface IBookService
    {
        Book GetBookById(int id);
        List<Book> GetAll();
        void Add(Book book);
        void Delete(int id);
    }
}
