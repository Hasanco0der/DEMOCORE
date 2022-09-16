using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DEMOCORE.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using DEMOCORE.Repository;
using DEMOCORE.Models;
using Microsoft.AspNetCore.Http;

namespace DEMOCORE.Controllers
{
    public class booksController : Controller
    {
        private readonly BookStoreContext _context;
        private readonly IBookRepository _bookRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public booksController(BookStoreContext context, IWebHostEnvironment webHostEnvironment, IBookRepository bookRepository)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _bookRepository = bookRepository; 
        }

        // GET: books
        public async Task<ViewResult> Index()
        {
            return View(await _bookRepository.GetAllBooks());
        }

        // GET: books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.books
                .FirstOrDefaultAsync(m => m.ID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: books/Create
        public IActionResult Create(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        // POST: books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Book books)
        {
            if (ModelState.IsValid)
            {
                if (books.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    books.CoverImageUrl = await UploadImage(folder, books.CoverPhoto);
                }
                int id = await _bookRepository.AddNewBook(books);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Create), new { isSuccess = true, bookId = id });
                }
            }
            return View(books);
        }

        // GET: books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        // POST: books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Author,Des,Category,Totalpages,Language")] books books)
        {
            if (id != books.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!booksExists(books.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }

        // GET: books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.books
                .FirstOrDefaultAsync(m => m.ID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _context.books.FindAsync(id);
            _context.books.Remove(books);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool booksExists(int id)
        {
            return _context.books.Any(e => e.ID == id);
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
