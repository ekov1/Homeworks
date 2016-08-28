namespace VisitingCell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // I thought of some random calculations to please the given example
    public class ListViewer
    {
        private const int MinXValue = -100;
        private const int MaxXValue = 100;
        private const int MinYValue = -100;
        private const int MaxYValue = 100;

        private IList<int> cells;

        public ListViewer(List<int> list)
        {
            this.cells = list;
        }

        public void VisitCell(int cellValue)
        {
            var x = cellValue + this.cells.Count;
            var y = cellValue - this.cells.Count;

            var isXInRange = MinXValue <= x && x <= MaxXValue;
            var isYInRange = MinYValue <= y && y <= MaxYValue;

            if (isXInRange && isYInRange && this.CanVisitCell(cellValue))
            {
                Console.WriteLine("Cell visited!");
                return;
            }
            else
            {
                Console.WriteLine("Cell not visited!");
            }
        }
        public bool CanVisitCell(int cellValue)
        {
            if (cellValue % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
