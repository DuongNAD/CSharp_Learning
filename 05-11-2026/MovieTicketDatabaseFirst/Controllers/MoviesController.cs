using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketDatabaseFirst.Data;

namespace MovieTicketDatabaseFirst.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieTicketDbContext _context;

        public MoviesController(MovieTicketDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.OrderBy(m => m.Title).ToListAsync());
        }
    }
}
