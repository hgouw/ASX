using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ASX.BusinessLayer;
using ASX.DataAccess;
using NLog;

namespace ASX.DataLoader
{
    public enum OutputType
    {
        Debug = 0,
        Error = 1,
        Fatal = 2,
        Info = 3,
        Trace = 4,
        Warn = 5
    }

    public partial class DataLoaderForm : Form
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        IList<WatchList> _watchLists = null;
        IList<EndOfDay> _endOfDays = null;

        public DataLoaderForm()
        {
            InitializeComponent();
            LoadWatchList();
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
                DisplayOutput(OutputType.Info, "Successfully loaded the watch list");
            }
            catch (Exception ex)
            {
                DisplayOutput(OutputType.Error, $"Failed to load the watch list - {ex.Message}");
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "TXT files (*.csv, *.txt)|*.csv;*.txt";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filenames = this.openFileDialog.FileNames.OrderBy(f => f);
                using (var db = new ASXDbContext())
                {
                    foreach (var filename in filenames)
                    {
                        try
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
                            _endOfDays = endOfDays.Where(a => _watchLists.Any(w => w.Code == a.Code)).OrderBy(w => w.Date).ToList(); // Select the EndOfDays in WatchLists only
                            db.EndOfDays.AddRange(_endOfDays);
                            //db.SaveChanges();
                            DisplayOutput(OutputType.Info, $"Successfully saved the data from the file {filename}");
                        }
                        catch (Exception ex)
                        {
                            DisplayOutput(OutputType.Error, $"Failed to convert the data in - {filename} {ex.Message} ");
                        }
                    }
                    db.SaveChanges();
                }
            }
        }

        private void DisplayOutput(OutputType type, string text)
        {
            this.richTextBox.Text += text + Environment.NewLine;
            switch (type)
            {
                case OutputType.Error:
                    _logger.Error($"{text}");
                    break;

                case OutputType.Info:
                    _logger.Info($"{text}");
                    break;
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

        private void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}