using System;
using System.Text;

namespace Brackets
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var solutions = new long[input.Length + 1, input.Length + 1];
            long upperLeftCell = 0;
            long upperRightCell = 0;

            solutions[0, 0] = 1;

            for (int i = 1; i < solutions.GetLength(0); i++)
            {
                for (int j = 0; j < solutions.GetLength(1); j++)
                {
                    if (input[i - 1] == '(')
                    {
                        upperLeftCell = j == 0 ? 0 : solutions[i - 1, j - 1];
                        upperRightCell = 0;
                    }
                    else if (input[i - 1] == ')')
                    {
                        upperRightCell = j == solutions.GetLength(1) - 1 ? 0 : solutions[i - 1, j + 1];
                        upperLeftCell = 0;
                    }
                    else
                    {
                        upperLeftCell = j == 0 ? 0 : solutions[i - 1, j - 1];
                        upperRightCell = j == solutions.GetLength(1) - 1 ? 0 : solutions[i - 1, j + 1];
                    }

                    solutions[i, j] = upperLeftCell + upperRightCell;
                }
            }

            //PrintMatrix(solutions);
            Console.WriteLine(solutions[input.Length, 0]);
        }

        private static void PrintMatrix(long[,] matrix)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                //builder.Append($"{i} => ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    builder.Append(matrix[i, j] + " ");
                }

                builder.AppendLine();
            }

            Console.WriteLine(builder.ToString());
        }
    }
}
