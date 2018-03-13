using System;
using System.Linq;
using ASX.DataAccess;

namespace ASX.Report
{
    class Program
    {
        static void Main(string[] args)
        {
            var year = 1997;
            var label = "Code";
            while (year <= DateTime.Today.Year)
            {
                label += "," + year;
                year++;
            }
            Console.WriteLine(label);

            var endOfDays = ASXDbContext.GetEndOfDays();
            var watchLists = ASXDbContext.GetWatchLists();
            foreach (var watchList in watchLists)
            {
                year = 1997;
                var line = $"{watchList.Code}";
                while (year <= DateTime.Today.Year)
                {
                    line += "," + endOfDays.Where(d => d.Code == watchList.Code && d.Date >= new DateTime(year, 1, 1) && d.Date <= new DateTime(year, 12, 31)).Count();
                    year++;
                }
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}