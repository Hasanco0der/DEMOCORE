using DEMOCORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOCORE.Repository
{
    public class BookRepository
    {
        public List<Book> GetAllBooks()
        {
            return DataSource();
        }

        public Book GetBookByID(int id)
        {
            return DataSource().Where(x => x.ID == id).FirstOrDefault();
        }

        public List<Book> SearchBook(string Tittle,string Author)
        {
            return DataSource().Where(x => x.Title.Contains(Tittle) || x.Author.Contains(Author)).ToList();
        }

        private List<Book> DataSource()
        {
            return new List<Book>()
            {
                new Book(){ID=1,Title="Mvc",Author="Hasan"},
                new Book(){ID=2,Title="python",Author="Ali"},
                new Book(){ID=3,Title="pip",Author="Omar"},
                new Book(){ID=4,Title="java",Author="jwad"},
                new Book(){ID=5,Title="Asp",Author="hussain"},
            };
        }
    }
}
