using Zadanie4.Document;

namespace Zadanie4.Device
{
    public class Copier : IPrinter, IScanner
    {
        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
        public int Counter { get; set; }
        public IDevice.State state { get; set; } = IDevice.State.OFF;

        public IDevice.State GetState()
        {
            return state;
        }

        public void ScanAndPrint()
        {
            if (GetState() == IDevice.State.ON)
            {
                IDocument dokument;
                Scan(out dokument, IDocument.FormatType.JPG);
                Print(dokument);
            }
        }

        public void Print(in IDocument document)
        {
            if (GetState() == IDevice.State.ON)
            {
                PrintCounter++;
                DateTime x = DateTime.Now;
                Console.Write($"{x} Print: {document.GetFileName()}\n");
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = new TextDocument("");

            if (GetState() == IDevice.State.ON)
            {
                ScanCounter++;
                switch (formatType)
                {
                    case IDocument.FormatType.TXT:
                        document = new TextDocument($"TextScan{ScanCounter}.txt");
                        break;

                    case IDocument.FormatType.PDF:
                        document = new PDFDocument($"PDFScan{ScanCounter}.pdf");
                        break;

                    case IDocument.FormatType.JPG:
                    default:
                        document = new ImageDocument($"ImageScan{ScanCounter}.jpg");
                        break;
                }
                DateTime x = DateTime.Now;
                Console.Write($"{x} Scan: {document.GetFileName()}\n");
            }
        }

        void IDevice.SetState(IDevice.State state)
        {
            
        }
        public void PowerOn()
        {
            
        }
        public void PowerOff()
        {

        }
    }
}