using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMatrixImplementation
{
    public partial class BitMatrix : IEquatable<BitMatrix>
    {
        public override bool Equals(object obj)
        {
            if(obj is BitMatrix)
                return Equals((BitMatrix)obj);
            else
                return base.Equals(obj);
        }

        public bool Equals(BitMatrix other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }

        public static bool operator ==(BitMatrix matrix1, BitMatrix matrix2)
        {
            if ((object)matrix1 == null && (object)matrix2 == null)
                return true;
            if ((object)matrix1 == null || (object)matrix2 == null)
                return false;
            if (matrix1.NumberOfColumns != matrix2.NumberOfColumns)
                return false;
            if (matrix1.NumberOfRows != matrix2.NumberOfRows)
                return false;

            for (int i = 0; i < matrix1.data.Length; i++)
            {
                if (matrix1.data[i] != matrix2.data[i])
                    return false;
            }
            return true;
        }

        public static bool operator !=(BitMatrix matrix1, BitMatrix matrix2)
        {
            return !(matrix1 == matrix2);
        }
    }
}