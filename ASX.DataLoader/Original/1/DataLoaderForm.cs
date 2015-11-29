using System;
using System.Collections.Generic;
using static System.Configuration.ConfigurationManager;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ASX.BusinessLayer;

namespace ASX.DataLoader
{
    public partial class DataLoaderForm : Form
    {
        private StringBuilder _log = new StringBuilder();
        private FileSystemWatcher _watcher = new FileSystemWatcher();

        public DataLoaderForm()
        {
            InitializeComponent();
            ApplySettings();
        }

        private void ApplySettings()
        {
            _watcher.Path = AppSettings["FilePath"];
            _watcher.NotifyFilter = NotifyFilters.DirectoryName |
                                    NotifyFilters.FileName |
                                    NotifyFilters.LastAccess |
                                    NotifyFilters.LastWrite;
            _watcher.Filter = AppSettings["FileExt"];
            _watcher.Created += new FileSystemEventHandler(OnCreated);
            _watcher.EnableRaisingEvents = true;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            var records = new List<EndOfDay>(FileHandler.ReadCsv(e.FullPath));
            if (records != null)
            {
                _log.Append($"{e.FullPath} processed on {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")} ({records.Count}){Environment.NewLine}");
            }
            File.Delete(e.FullPath);
        }

        private void tmrLog_Tick(object sender, System.EventArgs e)
        {
            rtbLog.Text += _log.ToString();
            _log.Remove(0, _log.Length);
        }
    }
}