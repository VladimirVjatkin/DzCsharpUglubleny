using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study001
{
    internal class Rectangle
    {
        /* 1.2. Разработайте класс "Прямоугольник" с полями "длина" и "ширина". 
         * Создайте метод для вычисления площади. Создайте объект и вычислите его площадь. */

        public double Width { get; set; }
        public double Height { get; set; }
        public double Area => Width * Height;
        public double Perimeter => 2 * (Width + Height);
        

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

    }
}
