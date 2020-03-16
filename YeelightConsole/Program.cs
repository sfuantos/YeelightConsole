using Mono.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (_args.Contains(args[0]))
            {
                await pAsync();
            }
        }

        static async Task pAsync()
        {
            List<Device> devices = await DeviceLocator.Discover();
            await devices[0].Connect();
            await devices[0].Toggle();
        }
        
    }
}
