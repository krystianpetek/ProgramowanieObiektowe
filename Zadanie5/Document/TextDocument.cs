namespace Zadanie5.Document
{
    public class TextDocument : AbstractDocument
    {
        public TextDocument(string fileName) : base(fileName)
        {
        }

        public override IDocument.FormatType GetFormatType() => IDocument.FormatType.TXT;
    }
}