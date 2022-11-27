using BookApi.Data.Entities;
using BookApi.Infrastructure;
using BookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private IRentService _rentService;

        public RentsController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpGet("{id}")]
        public RentDto Get(int id)
        {
            var rent = _rentService.GetRentById(id);
            var dto = new RentDto
            {
                BookId = rent.BookId,
                Fullname = rent.Fullname,
                Quantity = rent.Quantity,
            };
            return dto;
        }

       

        [HttpGet("")]
        public List<RentDto> GetAll()
        {
            var dtos = _rentService.GetAll().Select(d =>
            {
                return new RentDto
                {
                    BookId = d.BookId,
                    Fullname = d.Fullname,
                    Quantity = d.Quantity,
                };
            });
            return dtos.ToList();
        }
        [HttpPost("")]
        public RentDto Add([FromBody]RentDto rent)
        {
            _rentService.Add(new Rent
            {
                BookId = rent.BookId,
                Fullname = rent.Fullname,
                Quantity = rent.Quantity,
            });
            return rent;
        }
    }
}
