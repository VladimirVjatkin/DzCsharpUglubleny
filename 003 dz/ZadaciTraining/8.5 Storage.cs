using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public interface IStorage<T>
    {
        void Add(T item);
        bool Remove(T item);
        T Find(Func<T, bool> predicate);
    }

    public class ProductList : IStorage<Product>
    {
        private List<Product> products = new List<Product>();

        public void Add(Product item)
        {
            products.Add(item);
        }

        public bool Remove(Product item)
        {
            return products.Remove(item);
        }

        public Product Find(Func<Product, bool> predicate)
        {
            return products.FirstOrDefault(predicate);
        }
    }

    public class BookCatalog : IStorage<Book>
    {
        private Dictionary<string, Book> books = new Dictionary<string, Book>();

        public void Add(Book item)
        {
            books[item.ISBN] = item;
        }

        public bool Remove(Book item)
        {
            return books.Remove(item.ISBN);
        }

        public Book Find(Func<Book, bool> predicate)
        {
            return books.Values.FirstOrDefault(predicate);
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
