using Zadanie3.Document;

namespace Zadanie3.Device
{
    public class MultidimensionalDevice : BaseDevice
    {
        private Printer printer;
        private Scanner scanner;
        private Fax fax;

        public int PrintCounter => printer.PrintCounter;
        public int ScanCounter => scanner.ScanCounter;
        public int ReceiveFaxCounter => fax.ReceiveFaxCounter;
        public int SendFaxCounter => fax.SendFaxCounter;

        public MultidimensionalDevice()
        {
            printer = new Printer();
            scanner = new Scanner();
            fax = new Fax();
            fax.printer = this.printer;
            fax.scanner = this.scanner;
        }

        public void Print(in IDocument document)
        {
            printer.Print(document);
        }

        public void ScanAndPrint()
        {
            IDocument document = new ImageDocument("tempFile.jpg");
            scanner.Scan(out document);
            printer.Print(document);
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            scanner.Scan(out document, formatType);
        }

        public void ReceiveFax(out IDocument document)
        {
            fax.ReceiveFax(out document);
        }

        public void SendFax(string faxNumber)
        {
            fax.SendFax("+48338720020");
        }

        public override void PowerOff()
        {
            if (GetState() == IDevice.State.ON)
            {
                state = IDevice.State.OFF;
                printer.state = IDevice.State.OFF;
                scanner.state = IDevice.State.OFF;
                fax.state = IDevice.State.OFF;
                Console.WriteLine("... Device is OFF !");
            }
        }

        public override void PowerOn()
        {
            if (GetState() == IDevice.State.OFF)
            {
                base.Counter++;
                state = IDevice.State.ON;
                printer.state = IDevice.State.ON;
                scanner.state = IDevice.State.ON;
                fax.state = IDevice.State.ON;
                Console.WriteLine("Device is ON ...");
            }
        }
    }
}