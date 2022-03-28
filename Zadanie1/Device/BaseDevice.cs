using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1.Device
{
    public abstract class BaseDevice : IDevice
    {
        public int Counter { get; private set; }

        public IDevice.State GetState() => state;

        public void PowerOff() => (state) = IDevice.State.OFF;

        public void PowerOn() => (state) = IDevice.State.ON;

        protected IDevice.State state { get; set; }
    }
}
