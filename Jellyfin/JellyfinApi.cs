using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lunitor.AutomaticShutdown.Jellyfin
{
    class JellyfinApi
    {
        private readonly HttpClient _client;

        public JellyfinApi(HttpClient client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Add("X-Emby-Token", Configuration.JellyfinToken);
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            var response = await _client.GetStringAsync(Configuration.JellyfinUrl);

            return JsonSerializer.Deserialize<IEnumerable<Session>>(response);
        }
    }
}
