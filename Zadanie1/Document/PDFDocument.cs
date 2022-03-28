using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1.Document
{
    public class PDFDocument : AbstractDocument
    {
        public PDFDocument(string fileName) : base(fileName) { }
        public override IDocument.FormatType GetFormatType() => IDocument.FormatType.PDF;
    }
}
