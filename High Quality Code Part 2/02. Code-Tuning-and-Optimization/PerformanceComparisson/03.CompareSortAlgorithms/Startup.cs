namespace _03.CompareSortAlgorithms
{
    using Models;
    using Utils;

    public class Startup
    {
        public static void Main()
        {
            StringSorting();
            IntSorting();
            DoubleSorting();
        }

        private static void StringSorting()
        {
            string[] arrayToSort = new string[] { "hehe", "wow", "isurual", "whatIf", "isRael", "isnt", "rael", "huh", "whaddaboutdat", "tahtsIT", "noMoreStrings" };
            Logger.Log("String array sorting");

            TimeTracker.MeasureTime("Insertion sort", () =>
            {
                SortingAlgorithms.InsertionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Selection sort", () =>
            {
                SortingAlgorithms.SelectionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Quick sort", () =>
            {
                SortingAlgorithms.QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
            });
        }

        private static void IntSorting()
        {
            var arrayToSort = RandomArrayGenerator.GenerateIntArray(-30, 23242342);
            Logger.Log("Int array sorting");

            TimeTracker.MeasureTime("Insertion sort", () =>
            {
                SortingAlgorithms.InsertionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Selection sort", () =>
            {
                SortingAlgorithms.SelectionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Quick sort", () =>
            {
                SortingAlgorithms.QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
            });
        }

        private static void DoubleSorting()
        {
            var arrayToSort = RandomArrayGenerator.GenerateDoubleArray(-30, 23242342);

            Logger.Log("Double array sorting");

            TimeTracker.MeasureTime("Insertion sort", () =>
            {
                SortingAlgorithms.InsertionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Selection sort", () =>
            {
                SortingAlgorithms.SelectionSort(arrayToSort);
            });

            TimeTracker.MeasureTime("Quick sort", () =>
            {
                SortingAlgorithms.QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
            });
        }
    }
}