using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace Elite_GPS
{
    class LogMonitor : IDisposable
    {
        FileInfo CurrentFile;
        FileSystemWatcher logWatcher;
        bool ResetMonitor;
        Thread MonitorThread;

        Regex PlayerRegex;

        public LogMonitor()
        {
            PlayerRegex = new Regex(@"FindBestIsland:(.*):(.*):(.*):(.*)");

            DirectoryInfo dir = new DirectoryInfo("D:\\Program Files (x86)\\Steam\\SteamApps\\common\\Elite Dangerous\\Products\\FORC-FDEV-D-1010\\Logs");

            CurrentFile = (from f in dir.GetFiles("netLog.*")
                           orderby f.LastWriteTime descending
                           select f).First();

            logWatcher = new FileSystemWatcher(dir.FullName);
            logWatcher.Filter = "netLog.*";
            logWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;
            logWatcher.Created += new FileSystemEventHandler(OnNewLogFileCreate);
            logWatcher.EnableRaisingEvents = true;
        }

        public void Dispose()
        {
            logWatcher.Dispose();
            MonitorThread.Abort();
        }

        public void Start()
        {
            Console.WriteLine(String.Format("Now monitoring log file '{0}'", CurrentFile.Name));
            ResetMonitor = false;
            MonitorThread = new Thread(MontiorLog);
            MonitorThread.Start();
        }

        private void OnNewLogFileCreate(object source, FileSystemEventArgs e)
        {
            CurrentFile = new FileInfo(e.FullPath);

            // Reset the monitoring thread
            ResetMonitor = true;
            MonitorThread.Join();

            this.Start();
        }

        private void MontiorLog()
        {
            using (FileStream fs = new FileStream(CurrentFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!ResetMonitor)
                    {
                        while (!sr.EndOfStream && !ResetMonitor)
                            ProcessLine(sr.ReadLine());
                        while (sr.EndOfStream && !ResetMonitor)
                            Thread.Sleep(100);
                        if (!ResetMonitor) ProcessLine(sr.ReadLine());
                    }
                }
            }
        }

        private void ProcessLine(String line)
        {
            Match match = PlayerRegex.Match(line);
            if (match.Success)
            {
                LogMonitorEventArgs args = new LogMonitorEventArgs();
                args.Commander = match.Groups[1].Value;
                args.PlayMode = match.Groups[2].Value;
                args.System = match.Groups[4].Value;
                args.Target = match.Groups[3].Value;
                if (!args.Target.Contains(args.System) || (args.Target.Length - args.System.Length) > 2)
                    args.Target = "Supercruise";
                OnDataUpdated(args);
            }
        }

        protected virtual void OnDataUpdated(LogMonitorEventArgs e)
        {
            EventHandler<LogMonitorEventArgs> handler = DataUpdated;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<LogMonitorEventArgs> DataUpdated;
    }

    public class LogMonitorEventArgs : EventArgs
    {
        public String System;
        public String Commander;
        public String PlayMode;
        public String Target;
    }
}
