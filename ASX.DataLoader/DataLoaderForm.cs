using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASX.DataLoader
{
    public partial class DataLoaderForm : Form
    {
        FileSystemWatcher _watcher;

        public DataLoaderForm()
        {
            InitializeComponent();
            ApplySettings();
        }

        private void ApplySettings()
        {
        }
    }
}
