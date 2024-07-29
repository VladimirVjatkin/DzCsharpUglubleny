using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class Car
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        private int mileage;

        public Car(string brand, string model, int year, int initialMileage)
        {
            Brand = brand;
            Model = model;
            Year = year;
            mileage = initialMileage;
        }

        public bool UpdateMileage(int newMileage)
        {
            if (newMileage >= mileage)
            {
                mileage = newMileage;
                return true;
            }
            return false;
        }

        public string GetInfo()
        {
            return $"Car: {Brand} {Model}, Year: {Year}, Mileage: {mileage}km";
        }
    }
}
