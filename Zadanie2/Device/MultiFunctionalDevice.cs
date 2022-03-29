using Zadanie2.Document;

namespace Zadanie2.Device
{
    public class MultiFunctionalDevice : BaseDevice, IPrinter, IScanner, IFax
    {
        public MultiFunctionalDevice()
        {
            state = IDevice.State.OFF;
        }

        public int PrintCounter;
        public int ScanCounter;
        public int SendFaxCounter;
        public int ReceiveFaxCounter;

        public void ScanAndPrint()
        {
            if (GetState() == IDevice.State.ON)
            {
                IDocument dokument;
                Scan(out dokument);
                Print(dokument);
            }
        }

        public new void PowerOn()
        {
            if (GetState() == IDevice.State.OFF)
            {
                Counter++;
                state = IDevice.State.ON;
            }
        }

        public new void PowerOff()
        {
            if (GetState() == IDevice.State.ON)
            {
                state = IDevice.State.OFF;
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

        public void SendFax(string faxNumber)
        {
            if(state == IDevice.State.ON)
            {
                SendFaxCounter++;
                IDocument doc;
                Scan(out doc);
                DateTime x = DateTime.Now;
                Console.Write($"{x} Send fax: {doc.GetFileName()} to number: {faxNumber }\n");
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
                Print(document);
            }
        }
    }
}