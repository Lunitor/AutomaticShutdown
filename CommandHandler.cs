using System;
using System.Diagnostics;

namespace Lunitor.AutomaticShutdown
{
    class CommandHandler
    {
        public void HandleCommand(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.Shutdown: SendShutdownCommand(); break;
                case CommandType.Sleep: SendSleepCommand(); break;
            }
        }

        private void SendShutdownCommand()
        {
            Console.WriteLine($"Shutting down in {Configuration.ShutdownDelayInMin} min");
            RunCmdCommand($"/C shutdown -s -t {Configuration.ShutdownDelayInMin * 60}");
        }

        private void SendSleepCommand()
        {
            RunCmdCommand($"rundll32.exe powrprof.dll,SetSuspendState 0,1,0");
        }

        private static void RunCmdCommand(string argument)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = argument
            };
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
