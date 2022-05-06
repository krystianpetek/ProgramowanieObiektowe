using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempElementsLib
{
    public interface ITempDir : ITempElement
    {
        public string DirPath { get; }
        public bool IsEmpty { get; }
        public void Empty();
    }
}
