using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public enum LengthUnit { Meters, Feet, Inches }
    public enum WeightUnit { Kilograms, Pounds, Ounces }
    public enum TemperatureUnit { Celsius, Fahrenheit, Kelvin }

    public class Converter
    {
        public double Convert(double value, LengthUnit from, LengthUnit to, int precision = 2)
        {
            double meters = ConvertToMeters(value, from);
            return Math.Round(ConvertFromMeters(meters, to), precision);
        }

        public double Convert(double value, WeightUnit from, WeightUnit to, int precision = 2)
        {
            double kilograms = ConvertToKilograms(value, from);
            return Math.Round(ConvertFromKilograms(kilograms, to), precision);
        }

        public double Convert(double value, TemperatureUnit from, TemperatureUnit to, int precision = 2)
        {
            double celsius = ConvertToCelsius(value, from);
            return Math.Round(ConvertFromCelsius(celsius, to), precision);
        }

        private double ConvertToMeters(double value, LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.Meters: return value;
                case LengthUnit.Feet: return value * 0.3048;
                case LengthUnit.Inches: return value * 0.0254;
                default: throw new ArgumentException("Invalid unit");
            }
        }

        private double ConvertFromMeters(double meters, LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.Meters: return meters;
                case LengthUnit.Feet: return meters / 0.3048;
                case LengthUnit.Inches: return meters / 0.0254;
                default: throw new ArgumentException("Invalid unit");
            }
        }

        // Аналогичные методы для веса и температуры...
    }
}
