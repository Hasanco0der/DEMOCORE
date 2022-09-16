using DEMOCORE.Data;
using DEMOCORE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOCORE.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }



        public async Task<int> AddNewBook(Book model)
        {
            var newBook = new books()
            {
                Author = model.Author,
                Des = model.Des,
                Title = model.Title,
                Category=model.Category,
                Language = model.Language,
                Totalpages = model.Totalpages,
                CoverImageUrl = model.CoverImageUrl
               
            };

            await _context.books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.ID;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.books
                 .Select(book => new Book()
                 {
                     Author = book.Author,
                     Category = book.Category,
                     Des = book.Des,
                     ID = book.ID,
                     Language = book.Language,
                     Title = book.Title,
                     Totalpages = book.Totalpages,
                     CoverImageUrl = book.CoverImageUrl
                 }).ToListAsync();
        }

      

        public async Task<Book> GetBookById(int id)
        {
            return await _context.books.Where(x => x.ID == id)
                 .Select(book => new Book()
                 {
                     Author = book.Author,
                     Category = book.Category,
                     Des = book.Des,
                     ID = book.ID,
                     Language = book.Language,
                     Title = book.Title,
                     Totalpages = book.Totalpages,
                     CoverImageUrl = book.CoverImageUrl,
                 }).FirstOrDefaultAsync();
        }
       
    }
}
