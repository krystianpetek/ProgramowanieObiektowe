using Zadanie5.Document;

namespace Zadanie5.Device
{
    internal interface IFax : IDevice
    {
        public IPrinter printer { get; init; }
        public IScanner scanner { get; init; }
        int ReceiveFaxCounter { get; set; }
        int SendFaxCounter { get; set; }

        /// <summary>
        /// Fax jest wysyłany w momencie, gdy urządzenie jest włączone, w przeciwnym razie nic się nie dzieje
        /// </summary>
        /// <param name="faxNumber">numer faxu na jaki ma być wysłany dokument</param>
        public void SendFax(string faxNumber)
        {
            if (state == State.ON)
            {
                SendFaxCounter++;
                IDocument doc;
                scanner.Scan(out doc);
                DateTime x = DateTime.Now;
                Console.Write($"{x} Send fax: {doc.GetFileName()} to number: {faxNumber }\n");
            }
        }

        /// <summary>
        /// Fax jest odbierany tylko w momencie, gdy urządzenie jest włączone, w przeciwnym razie nic się nie dzieje
        /// </summary>
        /// <param name="document">Dokument odebrany faxem</param>
        public void ReceiveFax(out IDocument document)
        {
            document = new ImageDocument("");
            if (state == State.ON)
            {
                ReceiveFaxCounter++;
                DateTime x = DateTime.Now;
                document = new ImageDocument($"Fax{ReceiveFaxCounter}.{document.GetFormatType().ToString().ToLower()}");
                Console.Write($"{x} Receive fax: {document.GetFileName()}\n");
                printer.Print(document);
            }
        }
    }
}