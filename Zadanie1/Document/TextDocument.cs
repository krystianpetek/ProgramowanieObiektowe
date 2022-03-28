using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1.Document
{
    public class TextDocument : AbstractDocument
    {
        public TextDocument(string fileName) : base(fileName) { }

        public override IDocument.FormatType GetFormatType() => IDocument.FormatType.TXT;
    }
}
