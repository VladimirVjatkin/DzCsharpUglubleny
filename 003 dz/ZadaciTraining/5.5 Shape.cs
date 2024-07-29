using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateArea()
        {
            return width * height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (width + height);
        }
    }

    public class Triangle : Shape
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double a, double b, double c)
        {
            sideA = a;
            sideB = b;
            sideC = c;
        }

        public override double CalculateArea()
        {
            double s = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
        }

        public override double CalculatePerimeter()
        {
            return sideA + sideB + sideC;
        }
    }
}
