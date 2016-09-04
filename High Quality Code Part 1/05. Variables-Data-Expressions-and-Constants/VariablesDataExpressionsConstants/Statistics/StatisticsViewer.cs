namespace Statistics
{
    using System;
    using System.Linq;
    using System.Text;

    public class StatisticsViewer
    {
        private const char ConsoleSeparatorCharacter = '=';
        private const int ConsoleSeparatorRepearCount = 47;

        public void PrintStatistics(double[] statisctics)
        {
            string maxValue = statisctics.Max().ToString("0.00");
            string minValue = statisctics.Min().ToString("0.00");
            string averageValue = statisctics.Average().ToString("0.00");
            var builder = new StringBuilder();

            builder.AppendLine("The given statistics show the following results");
            builder.AppendLine(new string(ConsoleSeparatorCharacter, ConsoleSeparatorRepearCount));

            builder.AppendLine($"Maximum value is around {maxValue} ");
            builder.AppendLine($"Minimum value is around {minValue} ");
            builder.AppendLine($"The average value is around {averageValue} ");

            Console.WriteLine(builder.ToString());
        }
    }
}
