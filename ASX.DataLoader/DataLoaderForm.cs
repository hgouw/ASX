using System;
using System.Windows.Forms;
using ASX.BusinessLayer;

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

        private void Exit_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Application.Exit();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void DisplayWatchList()
        {
            var watchLists = ASX.DataAccess.DataAccess.GetWatchLists();
            this.checkedListBox.Items.Clear();
            foreach (var watchList in watchLists)           
            {
                this.checkedListBox.Items.Add(((WatchList)watchList).Code);
                this.checkedListBox.SetItemChecked(this.checkedListBox.Items.Count - 1, true);
                this.checkedListBox.Enabled = false;
            }
        }
        private void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}