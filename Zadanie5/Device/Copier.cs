using Zadanie5.Document;

namespace Zadanie5.Device
{
    public class Copier : IDevice
    {
        private IPrinter printer;
        private IScanner scanner;

        public int PrintCounter => printer.Counter;
        public int ScanCounter => scanner.Counter;

        public int Counter { get; set; } = 0;
        public IDevice.State state { get; set; } = IDevice.State.OFF;

        public Copier()
        {
            printer = new Printer();
            scanner = new Scanner();
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

        public void Scan(out IDocument document)
        {
            scanner.Scan(out document);
        }

        public void PowerOff()
        {
            if (GetState() == IDevice.State.ON)
            {
                state = IDevice.State.OFF;
                printer.state = IDevice.State.OFF;
                scanner.state = IDevice.State.OFF;
                Console.WriteLine("... Device is OFF !");
            }
        }

        public void PowerOn()
        {
            if (GetState() == IDevice.State.OFF)
            {
                Counter++;
                state = IDevice.State.ON;
                printer.state = IDevice.State.ON;
                scanner.state = IDevice.State.ON;
                Console.WriteLine("Device is ON ...");
            }
        }

        private IDevice.State GetState()
        {
            return state;
        }

        void IDevice.SetState(IDevice.State state)
        {
            this.state = state;
        }
    }
}