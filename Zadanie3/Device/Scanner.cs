using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie3.Document;

namespace Zadanie3.Device
{
    public class Scanner : IScanner
    {
        public int Counter { get; set; } = 0;

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

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = new TextDocument("");
            if (GetState() == IDevice.State.ON)
            {
                Counter++;
                switch (formatType)
                {
                    case IDocument.FormatType.TXT:
                        document = new TextDocument($"TextScan{Counter}.txt");
                        break;

                    case IDocument.FormatType.PDF:
                        document = new PDFDocument($"PDFScan{Counter}.pdf");
                        break;

                    case IDocument.FormatType.JPG:
                    default:
                        document = new ImageDocument($"ImageScan{Counter}.jpg");
                        break;
                }
                DateTime x = DateTime.Now;
                Console.Write($"{x} Scan: {document.GetFileName()}\n");
            }
        }
    }
}
