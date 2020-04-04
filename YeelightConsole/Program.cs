using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YeelightAPI;

namespace YeelightConsole
{
    class Program
    {
        static List<string> _args = new List<string>() { "power" };

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            Device device = await Connect();

            if (device != null)
            {
                if (_args.Contains(args[0]))
                {
                    await TurnOn(device);
                }
            }
            else
            {
                Console.Out.WriteLine("Could not connect. Is light turned off?");
                Console.ReadKey();
            }
        }

        static async Task<Device> Connect()
        {
            List<Device> devices = await DeviceLocator.Discover();

            if (devices.Count > 0)
            {
                await devices[0].Connect();

                return devices[0];
            }

            return null;
        }

        static async Task TurnOn(Device device)
        {
            await device.Toggle();
        }
    }
}
