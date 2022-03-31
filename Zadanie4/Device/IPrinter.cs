using Zadanie4.Document;

namespace Zadanie4.Device
{
    public interface IPrinter : IDevice
    {
        /// <summary>
        /// Dokument jest drukowany, jeśli urządzenie włączone. W przeciwnym przypadku nic się nie wykonuje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od null</param>
        public void Print(in IDocument document)
        {
            if (GetState() == State.ON)
            {
                Counter++;
                DateTime x = DateTime.Now;
                Console.Write($"{x} Print: {document.GetFileName()}\n");
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