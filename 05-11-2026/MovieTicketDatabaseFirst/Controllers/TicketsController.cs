using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieTicketDatabaseFirst.Data;
using MovieTicketDatabaseFirst.Models;

namespace MovieTicketDatabaseFirst.Controllers
{
    public class TicketsController : Controller
    {
        private readonly MovieTicketDbContext _context;

        public TicketsController(MovieTicketDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Movie)
                .OrderByDescending(t => t.Id)
                .ToListAsync();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadMovies();
            return View(new Ticket { ShowDate = DateTime.Today.AddDays(1).AddHours(19), SeatQuantity = 1 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            if (!await _context.Movies.AnyAsync(m => m.Id == ticket.MovieId))
            {
                ModelState.AddModelError(nameof(Ticket.MovieId), "Phim không tồn tại.");
            }

            if (!ModelState.IsValid)
            {
                LoadMovies(ticket.MovieId);
                return View(ticket);
            }

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            LoadMovies(ticket.MovieId);
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            if (!await _context.Movies.AnyAsync(m => m.Id == ticket.MovieId))
            {
                ModelState.AddModelError(nameof(Ticket.MovieId), "Phim không tồn tại.");
            }

            if (!ModelState.IsValid)
            {
                LoadMovies(ticket.MovieId);
                return View(ticket);
            }

            if (!await _context.Tickets.AnyAsync(t => t.Id == id))
            {
                return NotFound();
            }

            _context.Update(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _context.Tickets
                .Include(t => t.Movie)
                .FirstOrDefaultAsync(t => t.Id == id);
            return ticket == null ? NotFound() : View(ticket);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private void LoadMovies(int? selectedId = null)
        {
            ViewBag.Movies = new SelectList(_context.Movies.OrderBy(m => m.Title), "Id", "Title", selectedId);
        }
    }
}
