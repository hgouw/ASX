using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

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
            _watcher.Path = "c:\\test\\";
            _watcher.NotifyFilter = NotifyFilters.DirectoryName |
                                    NotifyFilters.FileName |
                                    NotifyFilters.LastAccess |
                                    NotifyFilters.LastWrite;
            _watcher.Filter = "*.csv";
            _watcher.Created += new FileSystemEventHandler(OnCreated);
            _watcher.EnableRaisingEvents = true;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            _log.Append(e.FullPath);
            _log.Append(" processed on ");
            _log.Append(DateTime.Now.ToString());
            _log.Append(Environment.NewLine);
        }

        private void tmrLog_Tick(object sender, System.EventArgs e)
        {
            rtbLog.Text += _log.ToString();
            _log.Remove(0, _log.Length);
        }
    }
}