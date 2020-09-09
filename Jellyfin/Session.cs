namespace Lunitor.AutomaticShutdown.Jellyfin
{
    public class Session
    {
        public string UserName { get; set; }
        public string Client { get; set; }
        public string DeviceName { get; set; }
        public bool IsActive { get; set; }
        public object NowPlayingItem { get; set; }

        public bool NotIgnoredUser
        {
            get {
                if (UserName == null)
                    return false;

                foreach (var ignoredUserName in Configuration.IgnoredUserNames)
                {
                    if (ignoredUserName.ToUpper() == UserName.ToUpper())
                        return false;
                }

                return true;
            }
        }
    }
}