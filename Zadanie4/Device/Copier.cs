using Zadanie4.Document;

namespace Zadanie4.Device
{
    public class Copier : IPrinter, IScanner
    {
        IPrinter printer = new Copier();
        IScanner scanner = new Copier();

        public int ScanCounter => scanner.Counter;
        public int PrintCounter => printer.Counter;
        public int Counter { get; set; } = 0;

        public IDevice.State state { get; set; }
        public IDevice.State GetState()
        {
            return state;
        }
        void IDevice.SetState(IDevice.State state)
        {
            this.state = state;
        }

        public void ScanAndPrint()
        {
            this.StandbyOff();
            printer.StandbyOff();
            scanner.StandbyOff();

            if (GetState() == IDevice.State.ON )
            {
                IDocument dokument;
                
                Scan(out dokument);
                Print(dokument);
            }
            scanner.StandbyOn();
            printer.StandbyOn();
            this.StandbyOn();
        }

        public void Print(in IDocument document)
        {
            this.StandbyOff();
            scanner.StandbyOn();
            printer.StandbyOff();
            if (this.GetState() == IDevice.State.ON && 
                printer.GetState() == IDevice.State.ON)
            {
                printer.Counter++;
                DateTime x = DateTime.Now;
                Console.Write($"{x} Print: {document.GetFileName()}\n");
            }
            printer.StandbyOn();
            this.StandbyOn();
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = new TextDocument("");

            this.StandbyOff();
            scanner.StandbyOff();
            printer.StandbyOn();
            if (this.GetState() == IDevice.State.ON &&
                scanner.GetState() == IDevice.State.ON)
            {
                scanner.Counter++;
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
            scanner.StandbyOn();
            this.StandbyOn();
        }

        public void StandbyOn()
        {
            printer.StandbyOn();
            scanner.StandbyOn();
        }
        public void StandbyOff()
        {
            printer.StandbyOff();
            scanner.StandbyOff();
        }
        public void PowerOn()
        {
            printer.PowerOn();
            scanner.PowerOn();
        }
        public void PowerOff()
        {
            printer.PowerOff();
            scanner.PowerOff();
        }
    }
}