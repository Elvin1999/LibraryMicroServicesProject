using BookApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Infrastructure
{
    public interface IRentService
    {
        Rent GetRentById(int id);
        List<Rent> GetAll();
        void Add(Rent book);
        void Delete(int id);
    }
}
