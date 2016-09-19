namespace _01.CompareSimpleMaths
{
    using System;
    using System.Diagnostics;

    public class TimeLogger
    {
        private const long ExecutionTimes = 10000000;

        public static void LogExecutionTime(string numberType, Action testMethod)
        {
            var stopWatch = Stopwatch.StartNew();

            for (int i = 0; i < ExecutionTimes; i++)
            {
                testMethod();
            }

            ResultsLogger.LogResultTime(stopWatch.Elapsed.ToString(), numberType);
        }
    }
}
