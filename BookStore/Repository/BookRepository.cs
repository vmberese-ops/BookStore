using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            Book newBook = new Book()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            List<BookModel> books = new List<BookModel>();
            List<Book> allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach (Book book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Id = book.Id,
                        Author = book.Author,
                        Title = book.Title,
                        Description = book.Description,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                BookModel bookDetails = new BookModel()
                {
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }

            return null;
            //return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title == title || x.Author == author).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id = 1, Title="MVC", Author="Joeferson", Description="This is the description for MVC Book", Category="Programming", Language="Chinese", TotalPages=105},
                new BookModel(){Id = 2, Title="Dot Net Core", Author="Joeferson", Description="This is the description for Dot Net Core Book", Category="Framework", Language="Chinese", TotalPages=294},
                new BookModel(){Id = 3, Title="C#", Author="James", Description="This is the description for C# Book", Category="Programming", Language="Indian", TotalPages=142},
                new BookModel(){Id = 4, Title="Java", Author="Kobe", Description="This is the description for Java Book", Category="Programming", Language="English", TotalPages=266},
                new BookModel(){Id = 5, Title="Php", Author="Omar", Description="This is the description for Php Book", Category="Web Development", Language="Arabic", TotalPages=110},
            };
        }
    }
}
