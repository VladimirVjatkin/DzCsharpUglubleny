using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Cart
    {
        private List<Product> items = new List<Product>();

        public void AddItem(Product product)
        {
            items.Add(product);
        }

        public decimal TotalCost
        {
            get { return items.Sum(item => item.Price); }
        }
    }
}
