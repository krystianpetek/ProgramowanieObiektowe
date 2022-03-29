using Zadanie3.Document;

namespace Zadanie3.Device
{
    public class Copier : BaseDevice
    {
        Printer printer;
        Scanner scanner;

        public int PrintCounter => printer.Counter;
        public int ScanCounter => scanner.Counter;

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

        public override void PowerOff()
        {
            if (GetState() == IDevice.State.ON)
            {
                state = IDevice.State.OFF;
                printer.state = IDevice.State.OFF;
                scanner.state = IDevice.State.OFF;
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
                Console.WriteLine("Device is ON ...");
            }
        }
    }
}