namespace BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BitArray64 : IEnumerable<int>
    {
        private const int length = 64;
        private int[] bitArray;

        public BitArray64(ulong value)
        {
            string bits = DecToBinary(value);

            this.bitArray = BitsToArray(bits);
        }

        public static bool operator ==(BitArray64 firstArr, BitArray64 secondArr)
        {
            return firstArr.Equals(secondArr);
        }

        public static bool operator !=(BitArray64 firstArr, BitArray64 secondArr)
        {
            return !firstArr.Equals(secondArr);
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > length - 1)
                {
                    throw new ArgumentException("Index is out of boundaries of Bitarray64!");
                }

                return this.bitArray[bitArray.Length - 1 - index];
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in bitArray)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            var otherArr = obj as BitArray64;

            for (int i = 0; i < length; i++)
            {
                if (this.bitArray[i] != (otherArr.bitArray[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return bitArray.GetHashCode();
        }

        public static string DecToBinary(ulong number)
        {
            string result = String.Empty;
            do
            {
                ulong digit = number % 2;
                result = digit + result;
                number /= 2;

            } while (number != 0);

            return result.ToString().PadLeft(64, '0');
        }

        public static int[] BitsToArray(string bits)
        {
            var bitArray = new int[64];
            for (int i = 0; i < bitArray.Length; i++)
            {
                bitArray[i] = int.Parse(bits[i].ToString());
            }
            return bitArray;
        }

        public override string ToString()
        {
            return String.Join(string.Empty, this.bitArray);
        }
    }
}
