using Zadanie4.Document;

namespace Zadanie4.Device
{
    public class Copier : IPrinter, IScanner
    {
        
        public int PrintCounter => ((IPrinter)this).Counter;
        public int ScanCounter => ((IScanner)this).Counter;
        public int Counter { get; set; }

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
            this.StandbyOff();
            ((IScanner)this).StandbyOn();
            ((IPrinter)this).StandbyOff();
            if (this.GetState() == IDevice.State.ON &&
                ((IPrinter)this).GetState() == IDevice.State.ON)
            {
                ((IPrinter)this).Counter++;
                DateTime x = DateTime.Now;
                Console.Write($"{x} Print: {document.GetFileName()}\n");
            }
            ((IPrinter)this).StandbyOn();
            this.StandbyOn();
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = new TextDocument("");

            if (GetState() == IDevice.State.ON)
            {
                ((IScanner)this).Counter++;
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

        public void PowerOn()
        {
            ((IPrinter)this).PowerOn();
            ((IScanner)this).PowerOn();
        }

        public void PowerOff()
        {
            ((IPrinter)this).PowerOff();
            ((IScanner)this).PowerOff();
        }

        public void StandbyOff()
        {
            ((IPrinter)this).StandbyOff();
            ((IScanner)this).StandbyOff();
        }

        public void StandbyOn()
        {
            ((IPrinter)this).StandbyOn();
            ((IScanner)this).StandbyOn();
        }

        public IDevice.State GetState()
        {
            return state;
        }

        void IDevice.SetState(IDevice.State state)
        {
            this.state = state;
        }

        public IDevice.State state { get; set; } = IDevice.State.OFF;
    }
}