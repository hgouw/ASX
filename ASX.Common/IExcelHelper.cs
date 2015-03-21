using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace Clarius.ManualTimesheet.Interface
{
    public interface IExcelHelper : IDisposable
    {
        Application Application { get; }
        Workbook Workbook { get; }
        Worksheet ActiveSheet { get; }
        Range WorksheetRange { get; }

        void OpenFile(string fullPath);

        Range FindWithinRange(Range rangeToFind, string searchLable);
        Range FindWithinRange(Range rangeToFind, List<string> searchLables);
        object GetCellValue(string cellName);
        object GetCellValue(int row, int column);
        object FindNextCellByValue(string searchLable);
        object FindNextCellByValues(List<string> searchLables);
    }
}