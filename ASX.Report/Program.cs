using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASX.BusinessLayer;
using ASX.DataAccess;

namespace ASX.Report
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = "CPU";
            var endOfDays = ASXDbContext.GetEndOfDays();
            for (int i = 1998; i <= DateTime.Now.Year; i++)
            {
                var count = endOfDays.Where(d => d.Code == "CPU" && d.Date >= new DateTime(i, 1, 1).Date && d.Date <= new DateTime(i, 12, 31).Date).Count();
                Console.WriteLine($"{code} - {i} - {count}");
            }
            Console.ReadLine();
        }
    }
}
