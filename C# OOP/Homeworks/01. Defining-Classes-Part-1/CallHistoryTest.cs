namespace MobileDevice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CallHistoryTest
    {
        public static GSM gsm = new GSM();

        public static Call callOne = new Call("13.12.2014", "10:12", "0665436765", 120);
        public static Call callTwo = new Call("13.12.2014", "12:45", "0961234565", 12);
        public static Call callThree = new Call("13.12.2014", "13:19", "0455438965", 67);

        public static List<Call> callHistory = new List<Call>() { callOne, callTwo, callThree };

        public static void PrintTestCallPrice(List<Call> callHistory, double price)
        {
            var testPrice = GSM.CallsPrice(callHistory, price);
            Console.WriteLine("\nTotal price of test calls: {0:F2}", testPrice);
        }

        public static void RemoveLongestCall(List<Call> callHistory, double price)
        {
            var orderedCalls = callHistory.OrderBy(x => x.Duration).ToList();
            orderedCalls.RemoveAt(orderedCalls.Count - 1);

            var testPrice = GSM.CallsPrice(orderedCalls, price);
            Console.WriteLine("After removing the longest call: {0:F2}", testPrice);

        }
    }
}
