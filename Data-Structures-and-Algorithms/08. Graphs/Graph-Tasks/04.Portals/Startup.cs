using System;
using System.Linq;

namespace _04.Portals
{
    public class Startup
    {
        public static void Main()
        {
            var startCoords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rowCol = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var matrixArray = new string[rowCol[0]][];

            for (int i = 0; i < matrixArray.Length; i++)
            {
                matrixArray[i] = Console.ReadLine().Split(' ');
            }

            var matrix = new Matrix(matrixArray);

            matrix.Dfs(startCoords[0], startCoords[1], 0);

            Console.WriteLine(matrix.MaxResult);
        }
    }

    public class Matrix
    {
        private static int[] deltaX = new int[] { 0, -1, 0, 1 };
        private static int[] deltaY = new int[] { -1, 0, 1, 0 };

        private string[][] matrix;
        private static int maxResult = 0;

        public int MaxResult
        {
            get
            {
                return maxResult;
            }
        }
        public Matrix(string[][] matrix)
        {
            this.matrix = matrix;
        }

        public void Dfs(int x, int y, int currentResult)
        {
            if (currentResult > maxResult)
            {
                maxResult = currentResult;
            }

            if (matrix[x][y] != "#" && int.Parse(matrix[x][y]) > 0)
            {
                var nodeValue = int.Parse(matrix[x][y]);

                for (int i = 0; i < deltaX.Length; i++)
                {
                    var possibleX = x + nodeValue * deltaX[i];
                    var possibleY = y + nodeValue * deltaY[i];

                    if (IsInRange(matrix, possibleX, possibleY) &&
                        matrix[possibleX][possibleY] != "#")
                    {
                        this.matrix[x][y] = "0";
                        this.Dfs(possibleX, possibleY, currentResult + nodeValue);
                        this.matrix[x][y] = nodeValue.ToString();
                    }
                }
            }
        }

        private static bool IsInRange(string[][] matrix, int x, int y)
        {
            return x >= 0 && x < matrix.Length &&
                y >= 0 && y < matrix[x].Length;
        }
    }
}
