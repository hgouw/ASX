﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASX.BusinessLayer;
using ASX.DataAccess;
using NLog;

namespace ASX.DataLoader
{

    public partial class DataLoaderForm : Form
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        IList<EndOfDay> _endOfDays = null;
        IList<WatchList> _watchLists = null;

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

        private async void Load_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "TXT files (*.csv, *.txt)|*.csv;*.txt";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.menuLoad.Enabled = false;
                var filenames = this.openFileDialog.FileNames.OrderBy(f => f);
                using (var db = new ASXDbContext())
                {
                    foreach (var filename in filenames)
                    {
                        // The input data is in .txt file so cannot use CsvHelper
                        var lines = File.ReadAllText(filename).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        var csv = lines.Select(l => l.Split(',')).ToArray();
                        var endOfDays = csv.Select(x => new EndOfDay()
                        {
                            Code = x[0],
                            Date = DateTime.ParseExact(x[1], "yyyyMMdd", CultureInfo.InvariantCulture),
                            Open = Decimal.Parse(x[2]),
                            High = Decimal.Parse(x[3]),
                            Low = Decimal.Parse(x[4]),
                            Close = Decimal.Parse(x[5]),
                            Volume = Int32.Parse(x[6])
                        });
                        _endOfDays = endOfDays.Where(a => _watchLists.Any(w => w.Code == a.Code)).OrderBy(w => w.Date).ToList(); // Select the EndOfDays in WatchLists only
                        db.EndOfDays.AddRange(_endOfDays);
                        var msg = await SaveDatabase(db);
                        if (String.IsNullOrEmpty(msg))
                        {
                            DisplayOutput(OutputType.Info, $"Successfully saved the data from the file {filename}");
                        }
                        else
                        {
                            DisplayOutput(OutputType.Error, $"Failed to convert the data in - {filename} {msg}");
                            db.EndOfDays.RemoveRange(_endOfDays);
                        }
                    }
                }
                this.menuLoad.Enabled = true;
            }
        }

        private void Script_Click(object sender, EventArgs e)
        {
            var script = new GenerateScriptForm();
            script.ShowDialog();
        }

        private Task<string> SaveDatabase(ASXDbContext db)
        {
            return Task.Run(() =>
            {
                try
                {
                    db.SaveChanges();
                    return null;
                }
                catch (Exception ex)
                {
                    return ex.InnerException.InnerException.Message;
                }
            });
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

        private void Verify_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verifying ...");
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