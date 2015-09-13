using System;
using System.Windows.Forms;

namespace ASX.DataLoader
{
    public partial class DataLoaderForm : Form
    {
        public DataLoaderForm()
        {
            InitializeComponent();
            DisplayWatchList();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "TXT files (*.txt)|*.txt";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //LoadWatchList(this.dlgOpenFile.FileName);
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void DisplayWatchList()
        {
            var watchLists = ASX.DataAccess.DataAccess.GetWatchLists();
        }
    }
}