using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeelightAPI;

namespace YeelightConsole
{
    class Light
    {
        Device device;
        List<Device> devices;

        public Light()
        {
            //LocateDeviceAsync();
        }

        public async void LocateDeviceAsync()
        {
             devices = await DeviceLocator.Discover();

            if (devices.Count > 0)
            {
                device = devices[0];
                Connect();
            }
        }

        public async void Power()
        {
            if (device != null)
                await device.SetPower();
            
        }

        bool Connect()
        {
            return device.Connect().Result;
        }
    }
}
