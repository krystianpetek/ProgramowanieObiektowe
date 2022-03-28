using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1.Document;

namespace Zadanie1.Device
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        private int PrintCounter;
        private int ScanCounter;

        //public void ScanAndPrint()
        //{
        //    Scan();
        //    Print();
        //}

        public void Print(in IDocument document)
        {
            if(GetState() == IDevice.State.ON)
            {
                DateTime x = DateTime.Now;
                Console.Write(x.ToLongDateString() + " ");
                Console.Write("Print: ");
                Console.Write(document.GetFileName());
                Console.WriteLine();
                PrintCounter++;

            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            if (GetState() == IDevice.State.ON)
            {
                DateTime x = DateTime.Now;
                Console.Write(x.ToLongDateString() + " ");
                Console.Write("Print: ");
                Console.WriteLine();
                ScanCounter++;
            }
        }
        
    }
}
