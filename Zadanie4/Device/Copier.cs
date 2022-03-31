using Zadanie4.Document;

namespace Zadanie4.Device
{
    public class Copier : IPrinter, IScanner
    {
        public IDevice.State state { get; set; } = IDevice.State.OFF;
        IDevice.State IPrinter.state { get; set; } = IDevice.State.OFF;
        IDevice.State IScanner.state { get; set; } = IDevice.State.OFF;

        public int Counter { get; set; } = 0;
        int IScanner.Counter { get; set; } = 0;
        int IPrinter.Counter { get; set; } = 0;

        public void ScanAndPrint()
        {
            if (GetState() == IDevice.State.ON)
            {
                IDocument dokument;
                ((IScanner)this).Scan(out dokument, IDocument.FormatType.JPG);
                ((IPrinter)this).Print(dokument);
            }
        }

        private IDevice.State GetState()
        {
            return state;
        }

        public void PowerOffCopier()
        {
            ((IPrinter)this).PowerOff();
            ((IScanner)this).PowerOff();
            ((IDevice)this).PowerOff();
        }

        public void PowerOnCopier()
        {
            Counter++;
            ((IPrinter)this).PowerOn();
            ((IScanner)this).PowerOn();
            ((IDevice)this).PowerOn();
        }

        public void StandbyOffCopier()
        {
            ((IPrinter)this).StandbyOff();
            ((IScanner)this).StandbyOff();
            ((IDevice)this).StandbyOff();
        }

        public void StandbyOnCopier()
        {
            ((IPrinter)this).StandbyOn();
            ((IScanner)this).StandbyOn();
            ((IDevice)this).StandbyOff();
        }

        void IDevice.SetState(IDevice.State state)
        {
            this.state = state;
        }

        public void Print(in IDocument document)
        {
            ((IScanner)this).StandbyOn(); // podczas drukowania skaner przechodzi w stan STANDBY
            ((IPrinter)this).StandbyOff(); // podczas drukowania drukarka przechodzi w stan ON

            SprawdzStanKserokopiarki();
            if (this.GetState() == IDevice.State.ON &&
                ((IPrinter)this).GetState() == IDevice.State.ON)
            {
                ((IPrinter)this).Counter++;
                DateTime x = DateTime.Now;
                Console.Write($"{x} Print: {document.GetFileName()}\n");
            }

            if (((IPrinter)this).Counter % 3 == 0)
            {
                ((IPrinter)this).StandbyOn(); // po 3 wydrukach drukarka przechodzi w tryb STANDBY a następnie znów na tryb ON
                ((IPrinter)this).StandbyOff();
            }
            SprawdzStanKserokopiarki();
        }

        public void SprawdzStanKserokopiarki()
        {
            IDevice.State printer = ((IPrinter)this).GetState();
            IDevice.State scanner = ((IScanner)this).GetState();

            if (printer == IDevice.State.STANDBY && scanner == IDevice.State.ON || printer == IDevice.State.ON && scanner == IDevice.State.STANDBY)
                StandbyOffCopier();

            if (printer == IDevice.State.STANDBY && scanner == IDevice.State.STANDBY)
                StandbyOnCopier();

            if (printer == IDevice.State.OFF && scanner == IDevice.State.OFF)
                PowerOffCopier();

            if (printer == IDevice.State.ON && scanner == IDevice.State.ON)
                StandbyOffCopier();
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = new TextDocument("");

            ((IPrinter)this).StandbyOn(); // podczas drukowania drukarka przechodzi w stan STANDBY
            ((IScanner)this).StandbyOff(); // podczas drukowania skaner przechodzi w stan ON

            SprawdzStanKserokopiarki();
            if (GetState() == IDevice.State.ON)
            {
                ((IScanner)this).Counter++;
                switch (formatType)
                {
                    case IDocument.FormatType.TXT:
                        document = new TextDocument($"TextScan{((IScanner)this).Counter}.txt");
                        break;

                    case IDocument.FormatType.PDF:
                        document = new PDFDocument($"PDFScan{((IScanner)this).Counter}.pdf");
                        break;

                    case IDocument.FormatType.JPG:
                    default:
                        document = new ImageDocument($"ImageScan{((IScanner)this).Counter}.jpg");
                        break;
                }
                DateTime x = DateTime.Now;
                Console.Write($"{x} Scan: {document.GetFileName()}\n");
            }

            if (((IScanner)this).Counter % 2 == 0)
            {
                ((IScanner)this).StandbyOn(); // po 2 wydrukach skaner przechodzi w tryb STANDBY a następnie znów na tryb ON
                ((IScanner)this).StandbyOff();
            }
            SprawdzStanKserokopiarki();
        }
    }
}