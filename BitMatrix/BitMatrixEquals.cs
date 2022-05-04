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
            if ((object)other == null || (object)this == null) return false;
            if (this.NumberOfColumns != other.NumberOfColumns)
                return false;
            if (this.NumberOfRows != other.NumberOfRows)
                return false;

            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i] != other.data[i])
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }

        public static bool operator ==(BitMatrix matrix1, BitMatrix matrix2)
        {
            if (matrix1 is null && matrix2 is null) return true;
            if ((object)matrix1 == null || (object)matrix2 == null) return false;

            return matrix1.Equals(matrix2);
        }

        public static bool operator !=(BitMatrix matrix1, BitMatrix matrix2)
        {
            if (matrix1 is null || matrix2 is null) return true;
            if ((object)matrix1 == null || (object)matrix2 == null) return false;
         
            return !(matrix1.Equals(matrix2));
        }
    }
}
