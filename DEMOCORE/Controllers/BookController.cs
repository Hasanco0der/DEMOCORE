using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEMOCORE.Models;
using DEMOCORE.Repository;
using Microsoft.AspNetCore.Mvc;
using DEMOCORE.Data;

namespace DEMOCORE.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-details{id}",Name ="bookdetailsroute")]
        public ViewResult GetByID(int id)
        {
           var data= _bookRepository.GetBookByID(id);
            return View(data);
        }
        public ViewResult Search(string title,string author)
        {
           var data= _bookRepository.SearchBook(title, author);
            return View(data);
        }

        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewBook(books book)
        {
            int id = _bookRepository.Addnewbook(book);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
            }
            return View();
        }

    }
}
