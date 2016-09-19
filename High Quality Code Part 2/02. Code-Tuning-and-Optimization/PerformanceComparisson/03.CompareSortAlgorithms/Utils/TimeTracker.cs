namespace _03.CompareSortAlgorithms.Utils
{
    using System;
    using System.Diagnostics;

    public class TimeTracker
    {
        private const long ExecutionTimes = 100000;

        public static void MeasureTime(string sortingType, Action sortingMethod)
        {
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < ExecutionTimes; i++)
            {
                sortingMethod();
            }

            Logger.Log($"{sortingType} execution time -> {sw.Elapsed.ToString()}");
        }
    }
}
