using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1.Document
{
    public class ImageDocument : AbstractDocument
    {
        public override IDocument.FormatType GetFormatType() => IDocument.FormatType.JPG;
        public ImageDocument(string fileName) : base(fileName) { }
    }
}
