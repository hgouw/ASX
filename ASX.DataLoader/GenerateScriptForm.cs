using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ASX.BusinessLayer;
using ASX.DataAccess;
using NLog;

namespace ASX.DataLoader
{
    public partial class GenerateScriptForm : Form
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        IList<EndOfDay> _endOfDays = null;

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
                var lastDate = _endOfDays.OrderByDescending(e => e.Date).First().Date;
                dtpStart.Value = lastDate.AddDays(1);
                dtpEnd.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to load the dates - {ex.Message}");
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {

        }
    }
}