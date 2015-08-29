using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using ASX.BusinessLayer;

namespace ASX.DataLoader
{
    public sealed class EndOfDayMap : CsvClassMap<EndOfDay>
    {
        public EndOfDayMap()
        {
            Map(m => m.Code).Name("Code");
            Map(m => m.Date).Name("Date").TypeConverterOption("yyyyMMdd");
            Map(m => m.Open).Name("Open");
            Map(m => m.High).Name("High");
            Map(m => m.Low).Name("Low");
            Map(m => m.Last).Name("Last");
            Map(m => m.Volume).Name("Volume");
        }
    }

    public static class FileHandler
    {
        public static IEnumerable<EndOfDay> ReadCsv(string fullPath)
        {
            using (var textReader = File.OpenText(fullPath))
            {
                using (var csvReader = new CsvReader(textReader))
                {
                    csvReader.Configuration.RegisterClassMap<EndOfDayMap>();
                    while (csvReader.Read())
                    {
                        var record = csvReader.GetRecord<EndOfDay>();
                        yield return record;
                    }
                    //var records = csv.GetRecords<EndOfDay>().ToList();
                }
            }
        }
    }
}