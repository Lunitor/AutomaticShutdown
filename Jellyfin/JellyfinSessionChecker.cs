using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lunitor.AutomaticShutdown.Jellyfin
{
    public class JellyfinSessionChecker
    {
        private static JellyfinApi _api;

        public JellyfinSessionChecker()
        {
            _api = new JellyfinApi(new HttpClient());
        }

        public async Task ReCheckTillNoActiveSessionsAsync()
        {
            var reCheck = true;
            while (reCheck)
            {
                var sessionCount = await CountActiveSessionsAsync();

                if (sessionCount == 0)
                {
                    reCheck = false;
                }
                else
                {
                    Console.WriteLine($"Recheck in {Configuration.ReCheckIntervalInMin} minutes");
                    await Task.Delay(Configuration.ReCheckIntervalInMin * 60 * 1000);
                }
            }
        }

        private async Task<int> CountActiveSessionsAsync()
        {
            var sessions = await _api.GetSessionsAsync();

            return sessions.Where(s => s.NotIgnoredUser)
                        .Where(s => s.NowPlayingItem != null)
                        .Count(s => s.IsActive);
        }
    }
}
