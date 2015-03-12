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
        private bool _dirty = false;

        public DataLoaderForm()
        {
            InitializeComponent();
            ApplySettings();
        }

        private void ApplySettings()
        {
            _watcher.Path = "c:\\test\\";
            _watcher.NotifyFilter = NotifyFilters.LastAccess |
                                    NotifyFilters.LastWrite |
                                    NotifyFilters.FileName |
                                    NotifyFilters.DirectoryName;
            _watcher.Filter = "*.csv";
            _watcher.Created += new FileSystemEventHandler(OnCreated);
            _watcher.EnableRaisingEvents = true;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            var str = e.FullPath;
            if (!_dirty)
            {
                _log.Remove(0, _log.Length);
                _log.Append(e.FullPath);
                _log.Append(" processed on ");
                _log.Append(DateTime.Now.ToString());
                _dirty = true;
            }
        }

        private void tmrLog_Tick(object sender, System.EventArgs e)
        {
            if (_dirty)
            {
                lbLog.BeginUpdate();
                lbLog.Items.Add(_log.ToString());
                lbLog.EndUpdate();
                _dirty = false;
            }
        }
    }
}
