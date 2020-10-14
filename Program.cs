using Lunitor.AutomaticShutdown.Jellyfin;
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

            var handler = new CommandHandler();
            handler.HandleCommand(Configuration.CommandType);
        }
    }
}
