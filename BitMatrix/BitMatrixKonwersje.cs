using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMatrixImplementation
{
    public partial class BitMatrix
    {
        public static implicit operator BitMatrix(int[,] array)
        {
            if(array == null)
                throw new NullReferenceException();
            if(array.Length == 0)
                throw new ArgumentOutOfRangeException();

            return new BitMatrix(array);
        } 
        
        public static explicit operator BitMatrix(bool[,] array)
        {
            if(array == null)
                throw new NullReferenceException();
            if(array.Length == 0)
                throw new ArgumentOutOfRangeException();

            return new BitMatrix(array);
        }
    
        public static implicit operator int[,](BitMatrix matrix)
        {
            int[,] array = new int[matrix.NumberOfRows, matrix.NumberOfColumns];
            for(int i = 0;i<matrix.NumberOfRows;i++)
            {
                for(int j = 0;j<matrix.NumberOfColumns;j++)
                {
                    array[i,j] = matrix[i,j];
                }
            }
            return array;
        }

        public static implicit operator bool[,](BitMatrix matrix)
        {
            bool[,] array = new bool[matrix.NumberOfRows, matrix.NumberOfColumns];
            for(int i = 0;i<matrix.NumberOfRows;i++)
            {
                for(int j = 0;j<matrix.NumberOfColumns;j++)
                {
                    array[i,j] = BitToBool(matrix[i,j]);
                }
            }
            return array;
        }

        public static explicit operator BitArray(BitMatrix matrix)
        {
            return new BitArray(matrix.data);
        }
    }
}
