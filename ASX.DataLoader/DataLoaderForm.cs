using System;
using static System.Configuration.ConfigurationManager;
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
            if (FileHandler.Process(e.FullPath))
            {
                _log.Append(e.FullPath);
                _log.Append(" processed on ");
                _log.Append(DateTime.Now.ToString());
                _log.Append(Environment.NewLine);
            }
        }

        private void tmrLog_Tick(object sender, System.EventArgs e)
        {
            rtbLog.Text += _log.ToString();
            _log.Remove(0, _log.Length);
        }
    }
}