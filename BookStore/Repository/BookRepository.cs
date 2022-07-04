using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
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
