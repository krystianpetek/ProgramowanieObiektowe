namespace Zadanie3.Device
{
    public abstract class BaseDevice : IDevice
    {
        public int Counter { get; set; } = 0;
        public IDevice.State state { get; set; } = IDevice.State.OFF;

        public IDevice.State GetState() => state;

        public virtual void PowerOff()
        {
            if (GetState() == IDevice.State.ON)
            {
                state = IDevice.State.OFF;
                Console.WriteLine("... Device is OFF !");
            }
        }

        public virtual void PowerOn()
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