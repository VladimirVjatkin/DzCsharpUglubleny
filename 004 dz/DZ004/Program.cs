using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ004
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Создаем объект Bits с использованием значения byte
            Bits bitsFromByte = new Bits((byte)170); // 170 в двоичном виде: 10101010
            Console.WriteLine($"Initial value (byte): {bitsFromByte.Value}"); // Выводим значение

            // Проверяем и выводим значение бита на позиции 3 (считаем от 0)
            Console.WriteLine($"Bit at index 3: {bitsFromByte.GetBitByIndex(3)}"); // Должно быть 1

            // Устанавливаем бит на позиции 2 в 1
            bitsFromByte.SetBitByIndex(2, true);
            Console.WriteLine($"Value after setting bit 2: {bitsFromByte.Value}"); // Должно быть 174

            // Преобразуем Bits в int
            int intValue = (int)bitsFromByte;
            Console.WriteLine($"Value as int: {intValue}");

            // Преобразуем int в Bits
            Bits bitsFromInt = (Bits)intValue;
            Console.WriteLine($"New Bits from int: {bitsFromInt.Value}");

            // Устанавливаем бит на позиции 7 в 0 через индексатор
            bitsFromInt[7] = false;
            Console.WriteLine($"Value after clearing bit 7 (using indexer): {bitsFromInt.Value}");

            // Преобразуем Bits в long
            long longValue = bitsFromInt;
            Console.WriteLine($"Value as long: {longValue}");

            // Преобразуем long в Bits
            Bits bitsFromLong = (Bits)longValue;
            Console.WriteLine($"New Bits from long: {bitsFromLong.Value}");
        



        }
    }
}
