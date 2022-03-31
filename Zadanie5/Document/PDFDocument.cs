namespace Zadanie5.Document
{
    public class PDFDocument : AbstractDocument
    {
        public PDFDocument(string fileName) : base(fileName)
        {
        }

        public override IDocument.FormatType GetFormatType() => IDocument.FormatType.PDF;
    }
}