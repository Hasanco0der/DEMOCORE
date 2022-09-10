using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEMOCORE.Models;
using DEMOCORE.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DEMOCORE.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
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

        public ViewResult aa()
        {
            return View();
        }

    }
}
