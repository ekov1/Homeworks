namespace Matrix
{
    using System;
   
    public class MatrixGeneric<T> where T : IComparable<T>
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public MatrixGeneric(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[Rows, Cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rows cannot be a negative number!");
                }
                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cols cannot be a negative number!");
                }
                this.cols = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                {
                    throw new ArgumentException("No such index in matrix!");
                }
                return this.matrix[row, col];
            }
            set
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                {
                    throw new ArgumentException("Out of boundaries of array!");
                }
                this.matrix[row, col] = value;
            }
        }

        public static MatrixGeneric<T> operator +(MatrixGeneric<T> firstMatrix, MatrixGeneric<T> secondMatrix)
        {
            MatrixGeneric<T> newMatrix = new MatrixGeneric<T>(firstMatrix.Rows, firstMatrix.Cols);

            if (firstMatrix.Rows == secondMatrix.Rows && firstMatrix.Cols == secondMatrix.Cols)
            {
                for (int i = 0; i < newMatrix.Rows; i++)
                {
                    for (int j = 0; j < newMatrix.Cols; j++)
                    {
                        newMatrix[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                    }
                }
                return newMatrix;
            }
            else
            {
                throw new ArgumentException("Cannot perform operation: Different size of matrixes!");
            }
        }

        public static MatrixGeneric<T> operator -(MatrixGeneric<T> firstMatrix, MatrixGeneric<T> secondMatrix)
        {
            MatrixGeneric<T> newMatrix = new MatrixGeneric<T>(firstMatrix.Rows, firstMatrix.Cols);

            if (firstMatrix.Rows == secondMatrix.Rows && firstMatrix.Cols == secondMatrix.Cols)
            {
                for (int i = 0; i < newMatrix.Rows; i++)
                {
                    for (int j = 0; j < newMatrix.Cols; j++)
                    {
                        newMatrix[i, j] = (dynamic)firstMatrix[i, j] - (dynamic)secondMatrix[i, j];
                    }
                }
                return newMatrix;
            }
            else
            {
                throw new ArgumentException("Cannot perform operation: Different size of matrixes!");
            }
        }

        public static MatrixGeneric<T> operator *(MatrixGeneric<T> firstMatrix, MatrixGeneric<T> secondMatrix)
        {
            MatrixGeneric<T> newMatrix = new MatrixGeneric<T>(firstMatrix.Rows, firstMatrix.Cols);

            if (firstMatrix.Cols == secondMatrix.Rows)
            {
                for (int i = 0; i < newMatrix.Rows; i++)
                {
                    for (int j = 0; j < newMatrix.Cols; j++)
                    {
                        newMatrix[i, j] = (dynamic)firstMatrix[i, j] * (dynamic)secondMatrix[i, j];
                    }
                }
                return newMatrix;
            }
            else
            {
                throw new ArgumentException("Cannot perform operation: Different size of matrixes!");
            }
        }

        public static bool operator true(MatrixGeneric<T> matrix)
        {
            bool noZeros = true;

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    if ((dynamic)matrix[i, j] == 0)
                    {
                        noZeros = false;
                    }
                }
            }

            return noZeros;
        }

        public static bool operator false(MatrixGeneric<T> matrix)
        {
            bool noZeros = false;

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    if ((dynamic)matrix[i, j] != 0)
                    {
                        noZeros = true;
                    }
                }
            }

            return noZeros;
        }
    }
}
