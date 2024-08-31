using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study001
{
    public class Books
    {

        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }

        public Books(string Author, string Title, string Description, int Year)
        {

            this.Author = Author;
            this.Title = Title;
            this.Description = Description;
            this.Year = Year;

        }
    }
}
