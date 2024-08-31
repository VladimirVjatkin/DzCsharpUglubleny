using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ004
{

    /* Реализуйте операторы явного и неявного приведения из long, int, byt в Bits.*/


    public class Bits
    {
        public long Value { get; private set; }

        public Bits(byte value)
        {
            Value = value;
        }

        public Bits(int value)
        {
            Value = value;
        }

        public Bits(long value)
        {
            Value = value;
        }

        public bool GetBitByIndex(byte index)
        {
            return (Value & (1L << index)) != 0;
        }

        public void SetBitByIndex(byte index, bool value)
        {
            if (value)
            {
                Value |= (1L << index);
            }
            else
            {
                Value &= ~(1L << index);
            }
        }

        public bool this[byte index]
        {
            get => GetBitByIndex(index);
            set => SetBitByIndex(index, value);
        }

       
        public static implicit operator long(Bits bits) => bits.Value;
        public static explicit operator Bits(long value) => new Bits(value);

        public static implicit operator int(Bits bits) => (int)bits.Value;
        public static explicit operator Bits(int value) => new Bits(value);

        public static implicit operator byte(Bits bits) => (byte)bits.Value;
        public static explicit operator Bits(byte value) => new Bits(value);
    }

}
