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
            var data=_bookRepository.GetAllBooks();
            return View(data);
        }

        public ViewResult GetByID(int id)
        {
           var data= _bookRepository.GetBookByID(id);
            return View(data);
        }
        public List<Book> Search(string title,string author)
        {
            return _bookRepository.SearchBook(title, author);
        }


    }
}
