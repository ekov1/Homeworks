namespace _01.StudentClass.Units.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Verification
    {
        public static void NullVerification(string data)
        {
            if (data == null)
            {
                throw new ArgumentException("This information space cannot be left empty!");
            }
        }

        public static void ZeroOrNegative(int data)
        {
            if (data <= 0)
            {
                throw new ArgumentException("This information space cannot be zero or negative");
            }
        }
    }
}
