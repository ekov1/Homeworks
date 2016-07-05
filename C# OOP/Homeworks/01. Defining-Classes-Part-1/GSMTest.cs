namespace MobileDevice
{
    using System;
    using System.Collections.Generic;
    class GSMTest
    {
        private static GSM gsmOne = new GSM("GT-i3000", "Samsung");
        private static GSM gsmTwo = new GSM("GT-i50000", "Samsungen");
        private static GSM gsmThree = new GSM("pi-232323", "SomeChineeseBrand");

        public static List<GSM> gsmTests = new List<GSM>() { gsmOne, gsmTwo, gsmThree };

        public static void PrintTestGSM(List<GSM> gsmTests)
        {
            Console.WriteLine("Test GSM specs\n{0}", new string('=', 60));
            for (int i = 0; i < gsmTests.Count; i++)
            {
                Console.WriteLine("Model: --> {0} \nManufacturer: --> {1} \n", gsmTests[i].Model, gsmTests[i].Manufacturer);
            }
        }

    }
}
