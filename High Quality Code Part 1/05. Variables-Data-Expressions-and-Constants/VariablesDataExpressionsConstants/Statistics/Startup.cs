namespace Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var statisctic = new double[] { 3.526, 5.67, 4.404, 50.30, 66.66, 69.609, 0.104, -45.5005043 };
            var statViewer = new StatisticsViewer();

            statViewer.PrintStatistics(statisctic);
        }
    }
}
