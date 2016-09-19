namespace _01.CompareSimpleMaths
{
    using System;

    public class Startup
    {
        private const long ExecutionTimes = 1000000;

        public static void Main()
        {
            AdditionTests();
            SubstractionTests();
            IncrementationTests();
            MultiplicationTests();
            DivisionTests();
        }

        private static void AdditionTests()
        {
            ResultsLogger.Log("Addition");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                int a = 300 + 291;
            });

            TimeLogger.LogExecutionTime("Long", () =>
            {
                long a = 34534500 + 29534534531;
            });

            TimeLogger.LogExecutionTime("Float", () =>
            {
                float a = 2.342342340f + 29.132423f;
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                double a = 30.00010d + 20000.91d;
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                decimal a = 30.000030m + 291.9m;
            });
        }

        private static void SubstractionTests()
        {
            ResultsLogger.Log("Square root");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                int a = 300 - 291;
            });

            TimeLogger.LogExecutionTime("Long", () =>
            {
                long a = 34534500 - 29534534531;
            });

            TimeLogger.LogExecutionTime("Float", () =>
            {
                float a = 2.342342340f - 29.132423f;
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                double a = 30.00010d - 20000.91d;
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                decimal a = 30.000030m - 291.9m;
            });
        }

        private static void IncrementationTests()
        {
            ResultsLogger.Log("Incrementation");

            int iNum = 0;
            TimeLogger.LogExecutionTime("Int", () =>
            {
                iNum += 1;
            });

            long lNum = 0;
            TimeLogger.LogExecutionTime("Long", () =>
            {
                lNum += 1;
            });

            float fNum = 0;
            TimeLogger.LogExecutionTime("Float", () =>
            {
                fNum += 1;
            });

            double dNum = 0;
            TimeLogger.LogExecutionTime("Double", () =>
            {
                dNum += 1;
            });

            decimal decNum = 0;
            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                decNum += 1;
            });
        }

        private static void MultiplicationTests()
        {
            ResultsLogger.Log("Multiplication");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                int a = 300 * 291;
            });

            TimeLogger.LogExecutionTime("Long", () =>
            {
                long a = 34534500 * 29534534531;
            });

            TimeLogger.LogExecutionTime("Float", () =>
            {
                float a = 2.342342340f * 29.132423f;
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                double a = 30.00010d * 20000.91d;
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                decimal a = 30.000030m * 291.9m;
            });
        }

        private static void DivisionTests()
        {
            ResultsLogger.Log("Division");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                int a = 300 / 291;
            });

            TimeLogger.LogExecutionTime("Long", () =>
            {
                long a = 34534500 / 29534534531;
            });

            TimeLogger.LogExecutionTime("Float", () =>
            {
                float a = 2.342342340f / 29.132423f;
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                double a = 30.00010d / 20000.91d;
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                decimal a = 30.000030m / 291.9m;
            });
        }
    }
}