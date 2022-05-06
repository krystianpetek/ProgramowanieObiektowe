using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempElementsLib
{
    public interface ITempElements : IDisposable
    {
        public T AddElement<T>() where T : ITempElement, new();
        public void RemoveDestroyed();
        public bool IsEmpty { get; }
        public IReadOnlyCollection<ITempElement> Elements { get; }
    }
}
