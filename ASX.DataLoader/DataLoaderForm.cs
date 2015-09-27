using System;
using System.Linq;
using System.Windows.Forms;
using ASX.BusinessLayer;
using ASX.DataAccess;

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
                var filenames = this.openFileDialog.FileNames.OrderBy(f => f);
                foreach (var filename in filenames)
                {
                    LoadDataFile(filename);
                }
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
            try
            {
                var watchLists = ASXDbContext.GetWatchLists();
                this.checkedListBox.Items.Clear();
                foreach (var watchList in watchLists)
                {
                    this.checkedListBox.Items.Add(((WatchList)watchList).Code);
                    this.checkedListBox.SetItemChecked(this.checkedListBox.Items.Count - 1, true);
                    this.checkedListBox.Enabled = false;
                }
                DisplayOutput("Successfully loaded WatchLists");
            }
            catch
            {
            }
        }

        private void LoadDataFile(string filename)
        {
            try
            {
                DisplayOutput("Successfully loaded data from " + filename);
            }
            catch
            {
            }
        }

        private void DisplayOutput(string text)
        {
            this.richTextBox.Text += text + Environment.NewLine;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}