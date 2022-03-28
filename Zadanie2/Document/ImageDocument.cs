namespace Zadanie2.Document
{
    public class ImageDocument : AbstractDocument
    {
        public override IDocument.FormatType GetFormatType() => IDocument.FormatType.JPG;

        public ImageDocument(string fileName) : base(fileName)
        {
        }
    }
}