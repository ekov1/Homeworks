namespace Matrix
{
    using System;
    using System.Linq;
    using System.Reflection;
    class Startup
    {
        static void Main()
        {
            var type = typeof(SampleForAttributes);
            var attributes = type.GetCustomAttributes(false);

            foreach (VersionAttribute item in attributes)
            {
                Console.WriteLine("Version: {0}\n", item.Version);
            }

            MatrixGeneric<int> matrix = new MatrixGeneric<int>(3, 3);
            MatrixGeneric<int> secondMatrix = new MatrixGeneric<int>(3, 3);  //Change size if you want to cause Exception

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    matrix[i, j] = i + j + 1; //Remove the " + 1" if you want to print the matrix, containing zeros.
                    secondMatrix[i, j] = 2 * (i + j + 1); 
                }
            }
            var newMatrix = secondMatrix * matrix;
            //var newMatrix = secondMatrix - matrix;
            //var newMatrix = secondMatrix + matrix;
            if (newMatrix)
            {
                Console.WriteLine("Matrix doesn't contain zeros.");
            }
            else
            {
                for (int i = 0; i < newMatrix.Rows; i++)
                {
                    for (int j = 0; j < newMatrix.Cols; j++)
                    {
                        Console.Write(newMatrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
