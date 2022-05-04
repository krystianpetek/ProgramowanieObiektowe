using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMatrixImplementation
{
    public partial class BitMatrix : ICloneable
    {
        public object Clone()
        {
            var array = new int[data.Length];            
            data.CopyTo(array, 0);
            BitMatrix matrixCopy = new BitMatrix(NumberOfRows, NumberOfColumns, array);
            return matrixCopy;
        }
    }
}
