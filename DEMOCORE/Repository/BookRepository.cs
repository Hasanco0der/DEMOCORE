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
                new Book(){ID=1,Title="Mvc",Author="Hasan",Des="Tis Description For Mvc Book"},
                new Book(){ID=2,Title="Python",Author="Ali",Des="Tis Description For Python Book"},
                new Book(){ID=3,Title="PHP",Author="Omar",Des="Tis Description For Php Book"},
                new Book(){ID=4,Title="Java",Author="jwad",Des="Tis Description For Java Book"},
                new Book(){ID=5,Title="ASP",Author="hussain",Des="Tis Description For ASP Book"},
                new Book(){ID=66,Title="الحياة بلا مكان",Author="حسن الموسوي",Des="كتـــاب بــــلا معنــــى"},
            };
        }
    }
}
