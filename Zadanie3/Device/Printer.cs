using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie3.Document;

namespace Zadanie3.Device
{
    public class Printer : IPrinter
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

        public void Print(in IDocument document)
        {
            if (GetState() == IDevice.State.ON)
            {
                Counter++;
                DateTime x = DateTime.Now;
                Console.Write($"{x} Print: {document.GetFileName()}\n");
            }
        }
    }
}
