﻿using BookStore.Models;
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
                new BookModel(){Id = 1, Title="MVC", Author="Stony"},
                new BookModel(){Id = 2, Title="dot net core", Author=" "},
                new BookModel(){Id = 3, Title="C#", Author="Krom"},
                new BookModel(){Id = 4, Title="Java", Author="Pat"},
                new BookModel(){Id = 5, Title="Php", Author="Tetet"},
            };
        }
    }
}
