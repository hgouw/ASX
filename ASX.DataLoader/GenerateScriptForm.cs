using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASX.BusinessLayer;
using ASX.DataAccess;
using NLog;

namespace ASX.DataLoader
{
    public partial class GenerateScriptForm : Form
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private const string _sql = "INSERT INTO [dbo].[EndOfDays] ([Code], [Date], [Open], [High], [Low], [Close], [Volume]) VALUES (N'{0}', CAST(N'{1}' AS DateTime), CAST({2} AS Decimal(6, 3)), CAST({3} AS Decimal(6, 3)), CAST({4} AS Decimal(6, 3)), CAST({5} AS Decimal(6, 3)), {6})";
        private const string _filename = "AzureSQL_EndOfDays.sql";

        IList<EndOfDay> _endOfDays = null;
        IList<WatchList> _watchLists = null;

        public GenerateScriptForm()
        {
            InitializeComponent();
            LoadDates();
        }

        private void LoadDates()
        {
            try
            {
                _endOfDays = ASXDbContext.GetEndOfDays();
                _watchLists = ASXDbContext.GetWatchLists();
                var lastDate = _endOfDays.OrderByDescending(e => e.Date).First().Date;
                var startDate = lastDate.AddDays(-1);
                dtpStart.Value = startDate;
                dtpEnd.Value = lastDate;
                dtpEnd.Enabled = Convert.ToBoolean(ConfigurationManager.AppSettings["EndDateEnabled"]);
            }
            catch (Exception ex)
            {
                DisplayOutput(OutputType.Error, $"Failed to load the dates - {ex.Message}");
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            bool ok = false;
            try
            {
                var sb = new StringBuilder();
                sb.Append("USE [ASX]");
                sb.Append(Environment.NewLine);
                sb.Append("GO");
                sb.Append(Environment.NewLine);
                foreach (var watchList in _watchLists)
                {
                    var endOfDays = _endOfDays.Where(x => x.Code == watchList.Code && x.Date >= dtpStart.Value && x.Date <= dtpEnd.Value).ToList();
                    if (endOfDays.Count > 0)
                    {
                        foreach (var endOfDay in endOfDays)
                        {
                            // Code:   {0} - ACX
                            // Date:   {1} - 2015-12-31 00:00:00.000
                            // Open:   {2} - 1.910
                            // High:   {3} - 1.910
                            // Low:    {4} - 1.800
                            // Close:  {5} - 1.800
                            // Volume: {6} - 191455
                            sb.Append(String.Format(_sql, endOfDay.Code, endOfDay.Date.ToString("yyyy-MM-dd HH:mm:ss.fff"), endOfDay.Open, endOfDay.High, endOfDay.Low, endOfDay.Close, endOfDay.Volume));
                            sb.Append(Environment.NewLine);
                        }
                        sb.Append("GO");
                        sb.Append(Environment.NewLine);
                    }
                }
                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var filePath = Path.Combine(desktopPath, _filename);
                File.WriteAllText(filePath, sb.ToString());
                ok = true;
                DisplayOutput(OutputType.Info, String.Format("Successfully generated the script file from {0} to {1}", dtpStart.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.ToString("yyyy-MM-dd")), true);
            }
            catch (Exception ex)
            {
                DisplayOutput(OutputType.Error, $"Failed to generate the script - {ex.Message}");
                ok = false;
            }
            finally
            {
                Close();
                DialogResult = ok ? DialogResult.OK : DialogResult.Abort;
            }
        }

        private void DisplayOutput(OutputType type, string text, bool popup = false)
        {
            switch (type)
            {
                case OutputType.Error:
                    _logger.Error($"{text}");
                    break;

                case OutputType.Info:
                    _logger.Info($"{text}");
                    break;
            }

            if (popup) MessageBox.Show(text);
        }
    }
}