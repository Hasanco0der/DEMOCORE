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
       public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book GetByID(int id)
        {
           return _bookRepository.GetBookByID(id);
        }
        public List<Book> Search(string title,string author)
        {
            return _bookRepository.SearchBook(title, author);
        }


    }
}
