namespace Zadanie1.Device
{
    public abstract class BaseDevice : IDevice
    {
        public int Counter { get; private set; } = 0;

        protected IDevice.State state = IDevice.State.OFF;

        public IDevice.State GetState() => state;

        public void PowerOff()
        {
            if (GetState() == IDevice.State.ON)
            {
                state = IDevice.State.OFF;
                Console.WriteLine("... Device is OFF !");
            }
        }

        public void PowerOn()
        {
            if (GetState() == IDevice.State.OFF)
            {
                state = IDevice.State.ON;
                Counter++;
                Console.WriteLine("Device is ON ...");
            }
        }
    }
}