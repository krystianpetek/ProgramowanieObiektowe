using static Zadanie5.Device.IDevice;

namespace Zadanie5.Device
{
    public class Fax : IFax
    {
        public IPrinter printer { get; init; }
        public IScanner scanner { get; init; }
        public int Counter { get; set; } = 0;
        public int SendFaxCounter { get; set; } = 0;
        public int ReceiveFaxCounter { get; set; } = 0;
        public State state { get; set; } = State.OFF;

        public Fax(IPrinter x, IScanner y)
        {
            printer = x;
            scanner = y;
        }

        public State GetState() => state;

        void IDevice.SetState(State state) => (this.state) = state;
    }
}