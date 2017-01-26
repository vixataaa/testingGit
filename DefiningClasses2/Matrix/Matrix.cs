using System;
using System.Text;

namespace Matrix
{
    public class Matrix<T>
    {
        private T[,] matrix;

        public int Rows
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }
        public int Cols
        {
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
        }   //constructor

        public T this[int row, int col]
        {
            set
            {
                this.matrix[row, col] = value;
            }
            get
            {
                return this.matrix[row, col];
            }
        }   //indexer

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new System.InvalidOperationException("Addition can`t be performed on matrices with different sizes");
            }   //check if both matrices have same # of rows/cols

            var result = new Matrix<T>(first.Rows, first.Cols);

            dynamic sum = 0;

            for (int rows = 0; rows < first.Rows; rows++)
            {
                for (int cols = 0; cols < first.Cols; cols++)
                {
                    sum = (dynamic)first[rows, cols] + second[rows, cols];
                    result[rows, cols] = sum;

                    sum = 0;
                }
            }

            return result;
        }   //addition of matrices with same size

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new System.InvalidOperationException("Subtraction can`t be performed on matrices with different sizes");
            }   //check if both matrices have same # of rows/cols

            var result = new Matrix<T>(first.Rows, first.Cols);

            dynamic subtr = 0;

            for (int rows = 0; rows < first.Rows; rows++)
            {
                for (int cols = 0; cols < first.Cols; cols++)
                {
                    subtr = (dynamic)first[rows, cols] - second[rows, cols];
                    result[rows, cols] = subtr;

                    subtr = 0;
                }
            }

            return result;
        }   //subtraction of matrices with same size

        //row, col content
        private T[] RowContent(int row)
        {
            T[] result = new T[this.Cols];

            for (int i = 0; i < this.Cols; i++)
            {
                result[i] = this.matrix[row, i];
            }

            return result;
        }   //returns array containing the elements in a chosen row
        private T[] ColContent(int col)
        {
            T[] result = new T[this.Rows];

            for (int i = 0; i < this.Rows; i++)
            {
                result[i] = this.matrix[i, col];
            }

            return result;
        }   //returns array containing the elements in a chosen column

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.Cols != second.Rows)
            {
                throw new System.InvalidOperationException("Multiplication can`t be performed on such matrices");
            }

            var result = new Matrix<T>(first.Rows, second.Cols);

            dynamic sum = 0;

            for (int rowFirst = 0; rowFirst < first.Rows; rowFirst++)
            {
                for (int colSecond = 0; colSecond < second.Cols; colSecond++)
                {
                    for (int i = 0; i < first.Cols; i++)
                    {
                        sum += (dynamic)first.RowContent(rowFirst)[i] * second.ColContent(colSecond)[i];
                    }

                    result[rowFirst, colSecond] = sum;
                    sum = 0;
                }
            }

            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int rows = 0; rows < matrix.matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.matrix.GetLength(1); cols++)
                {
                    if ((dynamic)matrix[rows, cols] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            if(matrix)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int rows = 0; rows < this.Rows; rows++)
            {
                for (int cols = 0; cols < this.Cols; cols++)
                {
                    result.Append(matrix[rows, cols]);
                    result.Append(" ");
                }
                result.AppendLine();
            }

            return result.ToString();
        }   //tostring override


    }
}
