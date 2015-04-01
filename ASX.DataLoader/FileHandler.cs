using System.Collections.Generic;
using System.IO;
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
            Map(m => m.Date).Name("Date");
            Map(m => m.Open).Name("Open");
            Map(m => m.High).Name("High");
            Map(m => m.Low).Name("Low");
            Map(m => m.Last).Name("Last");
        }
    }

    public class FileHandler
    {
        public static bool Process(string fullPath)
        {
            var csv = new CsvReader(File.OpenText(fullPath));
            var records = csv.GetRecords<EndOfDay>();

            return true;
        }
    }
}

/*
class DataRecord
{
    //Should have properties which correspond to the Column Names in the file
    //i.e. CommonName,FormalName,TelephoneCode,CountryCode
    public String CommonName { get; set; }
    public String FormalName { get; set; }
    public String TelephoneCode { get; set; }
    public String CountryCode { get; set; }
}

var reader = new CsvReader(sr);
IEnumerable<DataRecord> records = reader.GetRecords<DataRecord>();
*/

/*
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CsvHelper;

namespace CSVHelperReadSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var sr = new StreamReader(@"countrylist.csv"))
            {
                var reader = new CsvReader(sr);

                //CSVReader will now read the whole file into an enumerable
                IEnumerable<DataRecord> records = reader.GetRecords<DataRecord>();

                //First 5 records in CSV file will be printed to the Output Window
                foreach (DataRecord record in records.Take(5)) 
                {
                    Debug.Print("{0} {1}, {2}, {3}", record.CommonName, record.CountryCode, record.FormalName,
                        record.TelephoneCode);
                }
            }
        }
    }
}
*/

/*
var csv = new CsvReader( File.OpenText( "file.csv" ) );
var myCustomObjects = csv.GetRecords<MyCustomObject>();
public sealed class MyCustomObjectMap : CsvClassMap<MyCustomObject>
{
    public MyCustomObjectMap()
    {
        Map( m => m.Property1 ).Name( "Column Name" );
        Map( m => m.Property2 ).Index( 4 );
        Map( m => m.Property3 ).Ignore();
        Map( m => m.Property4 ).TypeConverter<MySpecialTypeConverter>();
    }
}
*/

/*
Add a reference to Microsoft.VisualBasic.dll
using Microsoft.VisualBasic.FileIO; 
TextFieldParser parser = new TextFieldParser(@"c:\temp\test.csv");
parser.TextFieldType = FieldType.Delimited;
parser.SetDelimiters(",");
while (!parser.EndOfData) 
{
    //Process row
    string[] fields = parser.ReadFields();
    foreach (string field in fields) 
    {
        //TODO: Process field
    }
}
parser.Close();
*/