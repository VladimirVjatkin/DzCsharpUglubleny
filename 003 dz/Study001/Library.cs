using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Study001
{
    

        internal class Library
        {
            /* 1.6. Разработайте класс "Библиотека", который может хранить список объектов класса "Книга". 
             * Добавьте методы для добавления книги, удаления книги и вывода всех книг.
             * Подсказка: Используйте список (List<>) для хранения книг. */
            public List<Books> books { get; set; } = new List<Books>();

        /* добавить книгу */


        public void AddBook(Books book)
        {
            books.Add(book);
        }
        public void RemoveBook(Books book)
        {
            books[books.IndexOf(book)] = null;
            books.RemoveAll(x => x == null);

        }

    }



}

