namespace _01.SchoolClasses.SchoolUnits.UniqueData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class UniqueClassNumber
    {
        private static int counter;

        static UniqueClassNumber()
        {
            counter = 1;
        }

        public static int GenerateClassNumber()
        {
            return counter++;
        }
    }
}
