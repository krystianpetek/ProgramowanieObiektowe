﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie3.Document;

namespace Zadanie3.Device
{
    public class Printer : IPrinter
    {
        public int Counter => throw new NotImplementedException();

        public IDevice.State GetState()
        {
            
            throw new NotImplementedException();
        }

        public void PowerOff()
        {
            throw new NotImplementedException();
        }

        public void PowerOn()
        {
            throw new NotImplementedException();
        }

        public void Print(in IDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
