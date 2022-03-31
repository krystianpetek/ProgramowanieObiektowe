using static Zadanie5.Device.IDevice;

namespace Zadanie5.Device
{
    public class Printer : IPrinter
    {
        public int Counter { get; set; } = 0;
        public State state { get; set; } = State.OFF;

        public State GetState() => state;

        void IDevice.SetState(State state) => (this.state) = state;
    }
}