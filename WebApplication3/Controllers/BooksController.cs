using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using WebApplication3.Entites;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class BooksController : ODataController
    {
        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Books);
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get(int key)
        {
            var book = _context.Books.FirstOrDefault(p => p.Id == key);
            if (book == null)
                return NotFound();

            return Ok(book);
        }
    }
}