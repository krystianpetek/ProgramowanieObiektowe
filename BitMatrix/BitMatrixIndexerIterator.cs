using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMatrixImplementation
{
    public partial class BitMatrix : IEnumerable<int>
    {
        public int this[int i,int j]
        {
            get
            {
                if(i >= NumberOfRows || i < 0 || j >= NumberOfColumns || j < 0)
                    throw new IndexOutOfRangeException();
                return BoolToBit(data[calculate(i,j,NumberOfColumns)]);
            }
            set
            {
                if (i >= NumberOfRows || i < 0 || j >= NumberOfColumns || j < 0)
                    throw new IndexOutOfRangeException();
                data[calculate(i, j, NumberOfColumns)] = BitToBool(value);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (bool item in data)
                yield return BoolToBit(item);
        }

        private int calculate(int i, int j, int numOfCols)
        {
            return i * numOfCols + j;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in data)
                yield return item;
        }
    }
}
