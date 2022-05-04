using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMatrixImplementation
{
    public partial class BitMatrix
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append(BoolToBit(data[i]));
                    continue;
                }
                if (i % NumberOfColumns == 0)
                    sb.AppendLine();
                sb.Append(BoolToBit(data[i]));
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
