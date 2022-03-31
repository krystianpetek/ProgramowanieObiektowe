﻿using Zadanie1.Document;

namespace Zadanie1.Device
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public int PrintCounter;
        public int ScanCounter;

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
    }
}