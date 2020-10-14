using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Lunitor.AutomaticShutdown
{
    static class Configuration
    {
        private static IConfiguration _configuration;

        public static void Load()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static CommandType CommandType => _configuration.GetValue<CommandType>("CommandType");
        public static int ReCheckIntervalInMin => _configuration.GetValue<int>("ReCheckIntervalInMin");
        public static int ShutdownDelayInMin => _configuration.GetValue<int>("ShutdownDelayInMin");
        public static string JellyfinUrl => _configuration.GetValue<string>("Jellyfin:Url");
        public static string JellyfinToken => _configuration.GetValue<string>("Jellyfin:Token");
        public static IEnumerable<string> IgnoredUserNames => _configuration.GetSection("Jellyfin:IgnoredUserNames").Get<IEnumerable<string>>();
    }
}
