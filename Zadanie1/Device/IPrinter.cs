using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1.Document;

namespace Zadanie1.Device
{
    public interface IPrinter : IDevice
    {
        /// <summary>
        /// Dokument jest drukowany, jeśli urządzenie włączone. W przeciwnym przypadku nic się nie wykonuje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od null</param>
        public void Print(in IDocument document);
    }
}
