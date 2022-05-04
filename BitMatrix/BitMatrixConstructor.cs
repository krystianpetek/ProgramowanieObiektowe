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
        public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits) : this(numberOfRows, numberOfColumns, 0)
        {
            if (bits == null)
                return;

            int iterator = 0;
            if (data.Length >= bits.Length)
                iterator = bits.Length;
            else
                iterator = data.Length;

            for (int i = 0; i < iterator; i++)
            {
                data[i] = BitToBool(bits[i]);
            }
        }

        public BitMatrix(int[,] bits) : this(bits.GetLength(0), bits.GetLength(1), 0)
        {
            if (bits == null)
                throw new NullReferenceException();
            if(bits.Length == 0)
                throw new ArgumentOutOfRangeException();

            int iterator = 0;
            if (data.Length >= bits.Length)
                iterator = bits.Length;
            else
                iterator = data.Length;

            int row = 0;
            int col = 0;
            for (int i = 0; i < iterator; i++)
            {
                row %= bits.GetLength(1);
                if (i != 0 && row == 0)
                {
                    col++;
                }
                data[i] = BitToBool(bits[col, row]);
                row++;
            }
        }
        
        public BitMatrix(bool[,] bits) : this(bits.GetLength(0), bits.GetLength(1), 0)
        {
            if (bits == null)
                throw new NullReferenceException();
            if(bits.Length == 0)
                throw new ArgumentOutOfRangeException();

            int iterator = 0;
            if (data.Length >= bits.Length)
                iterator = bits.Length;
            else
                iterator = data.Length;

            int row = 0;
            int col = 0;
            for (int i = 0; i < iterator; i++)
            {
                row %= bits.GetLength(1);
                if (i != 0 && row == 0)
                {
                    col++;
                }
                data[i] = bits[col, row];
                row++;
            }
        }

    }
}
