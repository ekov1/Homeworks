namespace MobileDevice
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            Console.WriteLine(GSM.iphone4s + "\n"); //Iphone 

            //Test phone
            GSM mobile = new GSM("Galaxy-s-3-neo", "Samsung", 200, "Mitko", "HP-100", 150, 120, BatteryType.NiCd, 230, 5605);
            Console.WriteLine(mobile);

            var testGMSs = GSMTest.gsmTests;
            GSMTest.PrintTestGSM(testGMSs);
            
            var callHistory = CallHistoryTest.callHistory;
            GSM.DisplayCallHistory(callHistory); //Printing calls

            CallHistoryTest.PrintTestCallPrice(callHistory, 0.37); //Printing price

            CallHistoryTest.RemoveLongestCall(callHistory, 0.37); //After removing longest call

            Console.WriteLine("\nClearing all call history...");
            callHistory.Clear();
            GSM.DisplayCallHistory(callHistory);
            Console.WriteLine("\nAll history cleared");
        }

    }
}
