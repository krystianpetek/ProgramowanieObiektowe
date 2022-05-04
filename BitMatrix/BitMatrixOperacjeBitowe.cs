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
        public BitMatrix And(BitMatrix other)
        {
            if(other == null || this == null)
                throw new ArgumentNullException();

            if (this.NumberOfColumns != other.NumberOfColumns || this.NumberOfRows != other.NumberOfRows)
                throw new ArgumentException();

            for(int i = 0;i<this.NumberOfRows;i++)
            {
                for(int j = 0;j<this.NumberOfColumns;j++)
                {
                    if (this[i, j] == 1 && other[i, j] == 1)
                    
                        this[i, j] = 1;
                    
                    else
                    
                        this[i, j] = 0;
                    
                }
            }
            return this;
        }
        
        public BitMatrix Or(BitMatrix other)
        {
            if (other == null || this == null)
                throw new ArgumentNullException();

            if (this.NumberOfColumns != other.NumberOfColumns || this.NumberOfRows != other.NumberOfRows)
                throw new ArgumentException();

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    if (this[i, j] == 1 || other[i, j] == 1)

                        this[i, j] = 1;
                }
            }
            return this;
        }
        
        public BitMatrix Xor(BitMatrix other)
        {
            
            //int[] array = new int[this.data.Length];

            //BitMatrix x = new BitMatrix(this.NumberOfRows, this.NumberOfColumns, array);
            if (other == null || this == null)
                throw new ArgumentNullException();

            if (this.NumberOfColumns != other.NumberOfColumns || this.NumberOfRows != other.NumberOfRows)
                throw new ArgumentException();

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    if (this[i, j] == 0 && other[i, j] == 0)
                        this[i, j] = 0;
                    else if (this[i, j] == 1 && other[i, j] == 1)
                        this[i, j] = 0;
                    else if (this[i, j] == 1 || other[i, j] == 1)
                        this[i, j] = 1;
                    else
                        this[i, j] = 0;
                }
            }
            return this;
        }
        
        public BitMatrix Not()
        {
            if (this == null)
                throw new ArgumentNullException();

            for(int i = 0; i<this.NumberOfRows;i++)
            {
                for(int j = 0;j< this.NumberOfColumns;j++)
                {
                    if(this[i, j] == 0) this[i, j] = 1;
                    else this[i, j] = 0;
                }
            }
            return this;
        }

        public static BitMatrix operator &(BitMatrix matrix1, BitMatrix matrix2)
        {
            if (matrix2 == null || matrix1 == null)
                throw new ArgumentNullException();

            if (matrix1.NumberOfColumns != matrix2.NumberOfColumns || matrix1.NumberOfRows != matrix2.NumberOfRows)
                throw new ArgumentException();

            var copy = matrix1.And(matrix2);
            return (BitMatrix)copy.Clone();
        }
        
        public static BitMatrix operator |(BitMatrix matrix1, BitMatrix matrix2)
        {
            if (matrix2 == null || matrix1 == null)
                throw new ArgumentNullException();

            if (matrix1.NumberOfColumns != matrix2.NumberOfColumns || matrix1.NumberOfRows != matrix2.NumberOfRows)
                throw new ArgumentException();

            var copy = matrix1.Or(matrix2);
            return (BitMatrix)copy.Clone();
        }

        public static BitMatrix operator ^(BitMatrix matrix1, BitMatrix matrix2)
        {
            if (matrix2 == null || matrix1 == null)
                throw new ArgumentNullException();

            if (matrix1.NumberOfColumns != matrix2.NumberOfColumns || matrix1.NumberOfRows != matrix2.NumberOfRows)
                throw new ArgumentException();

            int[] array = new int[matrix1.data.Length];

            BitMatrix x = new BitMatrix(matrix1.NumberOfRows, matrix1.NumberOfColumns, array);

            for (int i = 0; i < matrix1.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix1.NumberOfColumns; j++)
                {
                    if (matrix1[i, j] == 0 && matrix2[i, j] == 0)
                        x[i, j] = 0;
                    else if (matrix1[i, j] == 1 && matrix2[i, j] == 1)
                        x[i, j] = 0;
                    else if (matrix1[i, j] == 1 || matrix2[i, j] == 1)
                        x[i, j] = 1;
                    else
                        x[i, j] = 0;
                }
            }
            return x;
        }

        public static BitMatrix operator !(BitMatrix matrix1)
        {
            if (matrix1 == null)
                throw new ArgumentNullException();

            var copy = matrix1.Not();
            return (BitMatrix)copy.Clone();
        }
        
    }
}
