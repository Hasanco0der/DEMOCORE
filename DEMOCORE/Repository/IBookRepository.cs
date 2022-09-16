using DEMOCORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOCORE.Repository
{
   public interface IBookRepository
    {
        Task<int> AddNewBook(Book model);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id); 
    }
}
