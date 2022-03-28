namespace Zadanie2.Device
{
    public abstract class BaseDevice : IDevice
    {
        public int Counter { get; protected set; } = 0;

        protected IDevice.State state { get; set; }

        public IDevice.State GetState() => state;

        public void PowerOff()
        {
            state = IDevice.State.OFF;
            Console.WriteLine("... Device is OFF !");
        }

        public void PowerOn()
        {
            state = IDevice.State.ON;
            Console.WriteLine("Device is ON ...");
        }
    }
}