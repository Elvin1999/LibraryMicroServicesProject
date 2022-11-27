using BookApi.Data.Context;
using BookApi.Data.Entities;
using BookApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public class RentService : IRentService
    {
        private LibraryContext _context;

        public RentService(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Rent rent)
        {
            _context.Rents.Add(rent);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public List<Rent> GetAll()
        {
            return _context.Rents.ToList();
        }

        public Rent GetRentById(int id)
        {
            var rent = _context.Rents.FirstOrDefault(b => b.Id == id);
            return rent;
        }
    }
}
