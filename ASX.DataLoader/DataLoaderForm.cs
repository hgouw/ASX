using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ASX.BusinessLayer;
using ASX.DataAccess;

namespace ASX.DataLoader
{
    public partial class DataLoaderForm : Form
    {
        IList<WatchList> _watchLists = null;
        IList<EndOfDay> _endOfDays = null;

        public DataLoaderForm()
        {
            InitializeComponent();
            LoadWatchList();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "TXT files (*.csv, *.txt)|*.csv;*.txt";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filenames = this.openFileDialog.FileNames.OrderBy(f => f);
                foreach (var filename in filenames)
                {
                    LoadData(filename);
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

        private void LoadWatchList()
        {
            try
            {
                _watchLists = ASXDbContext.GetWatchLists();
                this.checkedListBox.Items.Clear();
                foreach (var watchList in _watchLists)
                {
                    this.checkedListBox.Items.Add(((WatchList)watchList).Code);
                    this.checkedListBox.SetItemChecked(this.checkedListBox.Items.Count - 1, true);
                    this.checkedListBox.Enabled = false;
                }
                DisplayOutput("Successfully loaded the watch list");
            }
            catch (Exception ex)
            {
                DisplayOutput($"Failed to load the watch list - {ex.Message}");
            }
        }

        private void LoadData(string filename)
        {
            try
            {
                _endOfDays = ConvertData(filename);
                DisplayOutput($"Successfully loaded the data from the file {filename}");
                SaveData(_endOfDays, filename);
                DisplayOutput($"Successfully saved the data from the file {filename}");
            }
            catch (Exception ex)
            {
                DisplayOutput($"Failed to load or save the data from the file {filename} - {ex.Message}");
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

        private IList<EndOfDay> ConvertData(string filename)
        {
            var lines = File.ReadAllText(filename).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var csv = lines.Select(l => l.Split(',')).ToArray();
            var endOfDays = csv.Select(x => new EndOfDay()
            {
                Code = x[0],
                Date = DateTime.ParseExact(x[1], "yyyyMMdd", CultureInfo.InvariantCulture),
                Open = Decimal.Parse(x[2]),
                High = Decimal.Parse(x[3]),
                Low = Decimal.Parse(x[4]),
                Last = Decimal.Parse(x[5]),
                Volume = Int32.Parse(x[6])
            });
            return endOfDays.Where(l => _watchLists.Any(w => w.Code == l.Code)).OrderBy(w => w.Date).ToList(); // Select the EndOfDays in WatchLists only
        }

        private void SaveData(IList<EndOfDay> endOfDays, string filename)
        {
            try
            {
                using (var db = new ASXDbContext())
                {
                    db.EndOfDays.AddRange(endOfDays);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                DisplayOutput($"Failed to save data from the file {filename} - {ex.Message}");
            }
        }
    }
}