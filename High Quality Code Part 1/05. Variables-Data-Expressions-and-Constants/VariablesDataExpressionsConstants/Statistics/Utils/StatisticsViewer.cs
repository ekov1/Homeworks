namespace Statistics.Utils
{
    using System;
    using System.Linq;
    using Contracts;

    public class StatisticsViewer
    {
        private const char ConsoleSeparatorCharacter = '=';
        private const int ConsoleSeparatorRepearCount = 47;
        private IWriter consoleWriter;

        public StatisticsViewer()
        {
            consoleWriter = new ConsoleWriter();
        }

        public void PrintStatistics(double[] statisctics)
        {
            string maxValue = statisctics.Max().ToString("0.00");
            string minValue = statisctics.Min().ToString("0.00");
            string averageValue = statisctics.Average().ToString("0.00");

            string separator = new string(ConsoleSeparatorCharacter, ConsoleSeparatorRepearCount);

            consoleWriter.Print("The given statistics show the following results");
            consoleWriter.Print(separator);

            consoleWriter.Print($"Maximum value is around {maxValue} ");
            consoleWriter.Print($"Minimum value is around {minValue} ");
            consoleWriter.Print($"The average value is around {averageValue} ");
        }
    }
}
