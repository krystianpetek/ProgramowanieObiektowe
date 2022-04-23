using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMatrixImplementation
{
    internal class BitMatrix : IEnumerable<bool>
    {
        private BitArray[] data;
        public int Dimension => data.Length;

        public BitMatrix(int n)
        {
            data = new BitArray[n];
            for(int i = 0; i < Dimension; i++)
            {
                data[i] = new BitArray(n);
            }
        }

        public bool this[int i, int j]
        {
            get
            {
                return data[i][j];
            }
            set
            {
                data[i][j] = value;
            }
        }

        
        public override string ToString()
        {
            string wynik = "";
            for(int i = 0; i < Dimension; i++)
            {
                for(int j = 0; j < Dimension; j++)
                {
                    wynik += $"{data[i][j]} ";
                }
                wynik += $"\n";
            }
            return wynik;
        }

        public IEnumerator<bool> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
