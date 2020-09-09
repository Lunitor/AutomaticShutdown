using System.Diagnostics;

namespace Lunitor.AutomaticShutdown
{
    class CommandHandler
    {
        public void SendShutdownCommand()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/C shutdown -s -t {Configuration.ShutdownDelayInMin * 60}"
            };
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
