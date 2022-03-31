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
        public void Scan(out IDocument document, FormatType formatType);


        //public new int Counter { get; set; }
        //public new State state { get; set; }

        //public new State GetState()
        //{
        //    return state;
        //}

        //public new void SetState(State state)
        //{
        //    this.state = state;
        //}
        //public new void StandbyOn()
        //{
        //    SetState(State.STANDBY);
        //}
        //public new void StandbyOff()
        //{
        //    SetState(State.ON);
        //}
        //public new void PowerOn()
        //{
        //    SetState(State.ON);
        //}
        //public new void PowerOff()
        //{
        //    SetState(State.ON);
        //}
    }
}