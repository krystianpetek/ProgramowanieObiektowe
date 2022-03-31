using Zadanie5.Document;
using static Zadanie5.Device.IDevice;

namespace Zadanie5.Device
{
    public class MultidimensionalDevice : IDevice
    {
        private IPrinter printer;
        private IScanner scanner;
        private IFax fax;

        public int PrintCounter => printer.Counter;
        public int ScanCounter => scanner.Counter;
        public int ReceiveFaxCounter => fax.ReceiveFaxCounter;
        public int SendFaxCounter => fax.SendFaxCounter;

        public int Counter { get; set; } = 0;
        public State state { get; set; } = State.OFF;

        public MultidimensionalDevice()
        {
            printer = new Printer();
            scanner = new Scanner();
            fax = new Fax(printer, scanner);
        }

        public void ScanAndPrint()
        {
            IDocument document = new ImageDocument("tempFile.jpg");
            scanner.Scan(out document);
            printer.Print(document);
        }

        public void Print(in IDocument document)
        {
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

        void IDevice.SetState(State state) => (this.state) = state;

        public State GetState() => state;

        public void PowerOn()
        {
            if (GetState() == State.OFF)
            {
                Counter++;
                state = State.ON;
                printer.state = State.ON;
                scanner.state = State.ON;
                fax.state = State.ON;
                Console.WriteLine("Device is ON ...");
            }
        }

        public void PowerOff()
        {
            if (GetState() == State.ON)
            {
                state = State.OFF;
                printer.state = State.OFF;
                scanner.state = State.OFF;
                fax.state = State.OFF;
                Console.WriteLine("... Device is OFF !");
            }
        }
    }
}