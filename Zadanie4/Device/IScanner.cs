using Zadanie4.Document;
using static Zadanie4.Document.IDocument;

namespace Zadanie4.Device
{
    public interface IScanner : IDevice
    {
        /// <summary>
        /// Dokument jest skanowany jeśli urządzenie jest włączone, w przeciwnym razie nic się nie dzieje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od null</param>
        /// <param name="formatType">obiekt typu enum IDocument.FormatType, zawiera format pliku</param>
        public void Scan(out IDocument document, FormatType formatType = FormatType.TXT)
        {
            document = new TextDocument("");

            if (GetState() == State.ON)
            {
                Counter++;
                switch (formatType)
                {
                    case FormatType.TXT:
                        document = new TextDocument($"TextScan{Counter}.txt");
                        break;

                    case FormatType.PDF:
                        document = new PDFDocument($"PDFScan{Counter}.pdf");
                        break;

                    case FormatType.JPG:
                    default:
                        document = new ImageDocument($"ImageScan{Counter}.jpg");
                        break;
                }
                DateTime x = DateTime.Now;
                Console.Write($"{x} Scan: {document.GetFileName()}\n");
            }
        }

        public new State GetState()
        {
            return state;
        }

        public new void PowerOn()
        {
            SetState(State.ON);
        }

        public new void PowerOff()
        {
            SetState(State.OFF);
        }

        public new void StandbyOn()
        {
            SetState(State.STANDBY);
        }

        public new void StandbyOff()
        {
            SetState(State.ON);
        }

        public new int Counter { get; set; }
        public new State state { get; set; }

        new void SetState(State state)
        {
            this.state = state;
        }
    }
}