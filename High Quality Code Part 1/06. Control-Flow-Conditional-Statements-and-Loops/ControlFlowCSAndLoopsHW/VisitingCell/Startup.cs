namespace VisitingCell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            var list = new List<int> { 30, 50, 11, 44, 342, 55, 4040, -40 };
            var listViewer = new ListViewer(list);

            var random = new Random();
            var cellIndex = random.Next(0, list.Count);

            listViewer.VisitCell(list[cellIndex]);
        }
    }
}
