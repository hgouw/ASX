using System;
using System.Linq;
using ASX.DataAccess;

namespace ASX.Report
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ASXDbContext())
            {
                var watchLists = db.WatchLists;
                foreach (var watchList in watchLists)
                {
                    var endOfDays = ASXDbContext.GetEndOfDays();
                    for (int i = 1998; i <= DateTime.Now.Year; i++)
                    {
                        var count = endOfDays.Where(d => d.Code == watchList.Code && d.Date >= new DateTime(i, 1, 1).Date && d.Date <= new DateTime(i, 12, 31).Date).Count();
                        Console.WriteLine($"{watchList.Code} - {i} - {count}");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
