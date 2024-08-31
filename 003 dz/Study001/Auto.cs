using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study001
{
    internal class Auto
    {
        /*1.5. Создайте класс "Автомобиль" с полями "марка", "модель", "год выпуска" и "пробег". 
         * Добавьте метод для обновления пробега и метод для вывода полной информации об автомобиле.
         * Подсказка:  Убедитесь, что новый пробег не меньше текущего.
        */

        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public int Mileage { get; set; }

        public Auto(string Manufacturer, string Model, string color, int Year, int Milage )
        {
            this.Manufacturer = Manufacturer;
            this.Model = Model;
            this.Color = Color;
            this.Year = Year;
            this.Mileage = Milage;

        }



        public bool ActualMileage(int actualkm)
        {
            if (Mileage <= actualkm)
            {
                Mileage = actualkm;
                Console.WriteLine($"Mileage updated to {Mileage} km");
                return true;
            }
            else
            {
                Console.WriteLine($"Wrong actual km, last stored Mileage is {Mileage} ");
                return false;
            }

        }

        public void PrintAllInfo() 
        { 
            Console.WriteLine($"Model: {Model}, Color: {Color}, Year: {Year}, Manufacturer: {Manufacturer}, Mileage: {Mileage} km");
        }


    }
}
