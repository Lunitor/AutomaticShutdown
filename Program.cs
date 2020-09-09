using Lunitor.AutomaticShutdown.Jellyfin;
using System;
using System.Threading.Tasks;

namespace Lunitor.AutomaticShutdown
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Configuration.Load();

            var sessionChecker = new JellyfinSessionChecker();
            await sessionChecker.ReCheckTillNoActiveSessionsAsync();

            Console.WriteLine($"Shutting down in {Configuration.ShutdownDelayInMin} min");
            var handler = new CommandHandler();
            handler.SendShutdownCommand();
        }
    }
}
