using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempElementsLib
{
    public interface ITempElements : IDisposable
    {
        public void AddElement<T>(); // ?
        public void RemoveDestroyed();
        public bool IsEmpty { get; set; }
        public int Elements { get; set; }// ?
    }
}
