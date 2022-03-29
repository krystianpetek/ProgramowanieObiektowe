using Zadanie3.Document;

namespace Zadanie3.Device
{
    public class Fax : IFax
    {
        internal Printer printer;
        internal Scanner scanner;

        public Fax()
        {
            printer = new Printer();
            scanner = new Scanner();
        }

        public int Counter { get; set; } = 0;
        public int SendFaxCounter { get; set; } = 0;
        public int ReceiveFaxCounter { get; set; } = 0;

        public IDevice.State state { get; set; } = IDevice.State.OFF;

        public IDevice.State GetState() => this.state;

        public void PowerOff()
        {
            if (GetState() == IDevice.State.ON)
            {
                state = IDevice.State.OFF;
                Console.WriteLine("... Device is OFF !");
            }
        }

        public void PowerOn()
        {
            if (GetState() == IDevice.State.OFF)
            {
                state = IDevice.State.ON;
                Counter++;
                Console.WriteLine("Device is ON ...");
            }
        }

        public void ReceiveFax(out IDocument document)
        {
            document = new ImageDocument("");
            if (state == IDevice.State.ON)
            {
                ReceiveFaxCounter++;
                DateTime x = DateTime.Now;
                document = new ImageDocument($"Fax{ReceiveFaxCounter}.{document.GetFormatType().ToString().ToLower()}");
                Console.Write($"{x} Receive fax: {document.GetFileName()}\n");
                printer.Print(document);
            }
        }

        public void SendFax(string faxNumber)
        {
            if (state == IDevice.State.ON)
            {
                SendFaxCounter++;
                IDocument doc;
                scanner.Scan(out doc);
                DateTime x = DateTime.Now;
                Console.Write($"{x} Send fax: {doc.GetFileName()} to number: {faxNumber }\n");
            }
        }
    }
}