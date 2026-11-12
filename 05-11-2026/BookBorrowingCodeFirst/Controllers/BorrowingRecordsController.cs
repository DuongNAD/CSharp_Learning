using BookBorrowingCodeFirst.Data;
using BookBorrowingCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookBorrowingCodeFirst.Controllers
{
    public class BorrowingRecordsController : Controller
    {
        private readonly LibraryDbContext _context;

        public BorrowingRecordsController(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _context.BorrowingRecords
                .Include(r => r.Book)
                .OrderByDescending(r => r.Id)
                .ToListAsync();
            return View(records);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadBooks();
            return View(new BorrowingRecord { BorrowDate = DateTime.Today });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowingRecord record)
        {
            if (!await _context.Books.AnyAsync(b => b.Id == record.BookId))
            {
                ModelState.AddModelError(nameof(BorrowingRecord.BookId), "Sách không tồn tại.");
            }

            if (!ModelState.IsValid)
            {
                LoadBooks(record.BookId);
                return View(record);
            }

            _context.BorrowingRecords.Add(record);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var record = await _context.BorrowingRecords.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            LoadBooks(record.BookId);
            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BorrowingRecord record)
        {
            if (id != record.Id)
            {
                return BadRequest();
            }

            var existing = await _context.BorrowingRecords.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            if (!await _context.Books.AnyAsync(b => b.Id == record.BookId))
            {
                ModelState.AddModelError(nameof(BorrowingRecord.BookId), "Sách không tồn tại.");
            }

            if (record.ReturnDate.HasValue && record.ReturnDate.Value.Date < existing.BorrowDate.Date)
            {
                ModelState.AddModelError(nameof(BorrowingRecord.ReturnDate), "Ngày trả không được nhỏ hơn ngày mượn.");
            }

            if (!ModelState.IsValid)
            {
                record.BorrowDate = existing.BorrowDate;
                record.BorrowerEmail = existing.BorrowerEmail;
                LoadBooks(record.BookId);
                return View(record);
            }

            existing.ReturnDate = record.ReturnDate;
            existing.BorrowerName = record.BorrowerName;
            existing.BookId = record.BookId;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.BorrowingRecords
                .Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.Id == id);
            return record == null ? NotFound() : View(record);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var record = await _context.BorrowingRecords.FindAsync(id);
            if (record != null)
            {
                _context.BorrowingRecords.Remove(record);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private void LoadBooks(int? selectedId = null)
        {
            ViewBag.Books = new SelectList(_context.Books.OrderBy(b => b.Title), "Id", "Title", selectedId);
        }
    }
}
