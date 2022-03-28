using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1.Document;

namespace Zadanie1.Device
{
    public interface IScanner : IDevice
    {
        /// <summary>
        /// Dokument jest skanowany jeśli urządzenie jest włączone, w przeciwnym razie nic się nie dzieje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od null</param>
        /// <param name="formatType">obiekt typu enum IDocument.FormatType, zawiera format pliku</param>
        public void Scan(out IDocument document, IDocument.FormatType formatType);
    }
}
