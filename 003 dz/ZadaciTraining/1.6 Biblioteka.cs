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


using System; // Подключение пространства имен System, которое включает базовые классы .NET.
using System.Collections.Generic; // Подключение пространства имен для работы с обобщенными коллекциями, такими как List<T>.
using System.Linq; // Подключение пространства имен для LINQ (Language Integrated Query) — используется для работы с данными в коллекциях.
using System.Text; // Подключение пространства имен для работы с текстовыми строками и их кодировками.
using System.Threading.Tasks; // Подключение пространства имен для работы с асинхронным программированием.

namespace ZadaciTraining // Определение пространства имен для группировки классов и других типов в логическую единицу.
{
    public class Book // Объявление публичного класса Book.
    {
        public string Title { get; set; } // Автоматическое свойство для хранения названия книги.
        public string Author { get; set; } // Автоматическое свойство для хранения автора книги.

        public Book(string title, string author) // Конструктор класса Book, принимающий название и автора книги.
        {
            Title = title; // Инициализация свойства Title значением аргумента title.
            Author = author; // Инициализация свойства Author значением аргумента author.
        }
    }

    public class Library // Объявление публичного класса Library.
    {
        private List<Book> books = new List<Book>(); // Приватное поле для хранения списка книг. Инициализация пустого списка.

        public void AddBook(Book book) // Публичный метод для добавления книги в библиотеку.
        {
            books.Add(book); // Добавление книги в список books.
        }

        public bool RemoveBook(string title) // Публичный метод для удаления книги по названию. Возвращает true, если книга была удалена.
        {
            // Удаление всех книг с заданным названием (независимо от регистра). Возвращает true, если хотя бы одна книга была удалена.
            return books.RemoveAll(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)) > 0;
        }

        public void ListAllBooks() // Публичный метод для вывода всех книг в библиотеке.
        {
            foreach (var book in books) // Перебор всех книг в списке books.
            {
                // Вывод информации о каждой книге в формате "Title by Author".
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }
    }
}
