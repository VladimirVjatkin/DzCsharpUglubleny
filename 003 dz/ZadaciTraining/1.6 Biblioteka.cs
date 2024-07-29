using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public bool RemoveBook(string title)
        {
            return books.RemoveAll(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)) > 0;
        }

        public void ListAllBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }
    }
}
