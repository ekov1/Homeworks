namespace Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StatisticsViewer
    {
        private const char ConsoleSeparatorCharacter = '=';
        private const int ConsoleSeparatorRepearCount = 47;

        public double GetMaxValue(double[] statistics)
        {
            double currentMax = statistics[0];

            for (int i = 1; i < statistics.Length; i++)
            {
                if (statistics[i] > currentMax)
                {
                    currentMax = statistics[i];
                }
            }

            return currentMax;
        }

        public double GetMinValue(double[] statistics)
        {
            double currentMin = statistics[0];

            for (int i = 1; i < statistics.Length; i++)
            {
                if (statistics[i] < currentMin)
                {
                    currentMin = statistics[i];
                }
            }

            return currentMin;
        }

        public double GetSum(double[] statisctics)
        {
            double sum = 0;

            for (int i = 0; i < statisctics.Length; i++)
            {
                sum += statisctics[i];
            }

            return sum;
        }

        public double GetAverageValue(double[] statisctics)
        {
            double average = GetSum(statisctics) / statisctics.Length;

            return average;
        }

        public void PrintStatistics(double[] statisctics)
        {
            string maxValue = GetMaxValue(statisctics).ToString("0.00");
            string minValue = GetMinValue(statisctics).ToString("0.00");
            string averageValue = GetAverageValue(statisctics).ToString("0.00");
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
