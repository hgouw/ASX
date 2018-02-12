﻿using System;
using System.Linq;
using ASX.DataAccess;

namespace ASX.Report
{
    class Program
    {
        static void Main(string[] args)
        {
            var years = new int[] { 1997, 1998, 1999, 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018 };
            var label = "Code";
            foreach (var year in years)
            {
                label += "," + year;
            }
            Console.WriteLine(label);

            var endOfDays = ASXDbContext.GetEndOfDays();
            var watchLists = ASXDbContext.GetWatchLists();
            foreach (var watchList in watchLists)
            {
                var line = $"{watchList.Code}";
                foreach (var year in years)
                {
                    line += "," + endOfDays.Where(d => d.Code == watchList.Code && d.Date >= new DateTime(year, 1, 1) && d.Date <= new DateTime(year, 12, 31)).Count();
                }
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}