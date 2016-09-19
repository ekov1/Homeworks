namespace _02.CompareAdvancedMaths
{
    using System;
    using _01.CompareAdvancedMaths;

    class Startup
    {
        private const long ExecutionTimes = 1000000;

        static void Main()
        {
            SquareRootTests();
            NaturalLogarithmTests();
            SinusTests();
        }

        private static void SquareRootTests()
        {
            ResultsLogger.Log("Square root");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                float a = (float)Math.Sqrt(3.04003);
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                double a = Math.Sqrt(3.04003);
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                decimal a = (decimal)Math.Sqrt(3.04003);
            });
        }

        private static void NaturalLogarithmTests()
        {
            ResultsLogger.Log("Natural logarithm");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                
                float a = (float)Math.Log(3.04003);
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                double a = Math.Log(3.04003);
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                decimal a = (decimal)Math.Log(3.04003);
            });
        }

        private static void SinusTests()
        {
            ResultsLogger.Log("Sinus");

            TimeLogger.LogExecutionTime("Int", () =>
            {
                float a = (float)Math.Sin(2.03);
            });

            TimeLogger.LogExecutionTime("Double", () =>
            {
                double a = Math.Sin(2.03);
            });

            TimeLogger.LogExecutionTime("Decimal", () =>
            {
                decimal a = (decimal)Math.Sin(2.03);
            });
        }
    }
}
