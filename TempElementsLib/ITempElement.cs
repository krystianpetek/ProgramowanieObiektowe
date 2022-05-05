using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempElementsLib
{
    public interface ITempElement : IDisposable
    {
        public bool IsDestroyed { get; }
    }
}
