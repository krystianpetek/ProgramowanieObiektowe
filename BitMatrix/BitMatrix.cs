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
        private BitArray data;
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        public bool IsReadOnly => false;

        // tworzy prostokątną macierz bitową wypełnioną `defaultValue`
        public BitMatrix(int numberOfRows, int numberOfColumns, int defaultValue = 0)
        {
            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException("Incorrect size of matrix");
            data = new BitArray(numberOfRows * numberOfColumns, BitToBool(defaultValue));
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        public static int BoolToBit(bool boolValue) => boolValue ? 1 : 0;
        public static bool BitToBool(int bit) => bit != 0;
    }

    //private BitArray[] data;
    //public int Dimension => data.Length;

    //public BitMatrix(int n)
    //{
    //    data = new BitArray[n];
    //    for(int i = 0; i < Dimension; i++)
    //    {
    //        data[i] = new BitArray(n);
    //    }
    //}

    //public bool this[int i, int j]
    //{
    //    get
    //    {
    //        return data[i][j];
    //    }
    //    set
    //    {
    //        data[i][j] = value;
    //    }
    //}


    //public override string ToString()
    //{
    //    string wynik = "";
    //    for(int i = 0; i < Dimension; i++)
    //    {
    //        for(int j = 0; j < Dimension; j++)
    //        {
    //            wynik += $"{data[i][j]} ";
    //        }
    //        wynik += $"\n";
    //    }
    //    return wynik;
    //}

    //public IEnumerator<bool> GetEnumerator()
    //{
    //    throw new NotImplementedException();
    //}

    //IEnumerator IEnumerable.GetEnumerator()
    //{
    //    throw new NotImplementedException();
    //}
}
