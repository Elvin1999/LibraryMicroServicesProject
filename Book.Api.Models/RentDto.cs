using BookApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class RentDto
    {
        public string Fullname { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
