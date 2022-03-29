
namespace Zadanie3.Device
{
    public abstract class BaseDevice : IDevice
    {
        public int Counter { get; protected set; } = 0;

        protected IDevice.State state;

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