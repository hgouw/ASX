using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Clarius.ManualTimesheet.Interface;

namespace Clarius.ManualTimesheet.Helper
{
    public class ExcelHelper : IExcelHelper
    {
        public Application Application { get; private set; }
        public Workbook Workbook { get; private set; }
        public Worksheet ActiveSheet { get; private set; }
        public Range WorksheetRange { get; private set; }

        public virtual void OpenFile(string fullPath)
        {
            ValidateFile(fullPath);

            Application = new Application();
            Workbook = Application.Workbooks.Open(fullPath, Type.Missing, true, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing);

            ActiveSheet = Workbook.ActiveSheet;
            WorksheetRange = ActiveSheet.UsedRange;
        }

        public virtual void ValidateFile(string fullPath)
        {
            if (!File.Exists(fullPath))
                throw new Exception("File does not exist");

            if (Path.GetExtension(fullPath) != ".xls" && Path.GetExtension(fullPath) != ".xlsx")
                throw new Exception("File in wrong format");
        }

        public object GetCellValue(string cellName)
        {
            return ActiveSheet.Range[cellName, Type.Missing].Value[Type.Missing];
        }

        public object GetCellValue(int row, int column)
        {
            return ((Range)ActiveSheet.Cells[row, column]).Value[Type.Missing];
        }

        public object FindNextCellByValue(string searchLable)
        {
            var resultRange = FindWithinRange(WorksheetRange, searchLable);

            if (resultRange != null)
            {
                for (var i = 1; resultRange.Column + i < WorksheetRange.Columns.Count; i++)
                {
                    var value = GetCellValue(resultRange.Row, resultRange.Column + i);
                    if (value != null)
                        return value;
                }
            }
            return null;
        }

        public object FindNextCellByValues(List<string> searchLables)
        {
            foreach (var searchString in searchLables)
            {
                var value = FindNextCellByValue(searchString);
                if (value != null)
                    return value;
            }
            return null;
        }

        public Range FindWithinRange(Range rangeToFind, string searchLable)
        {
            return rangeToFind.Find(searchLable, Type.Missing, XlFindLookIn.xlValues, XlLookAt.xlPart, Type.Missing,
                       XlSearchDirection.xlNext, false, false, Type.Missing);
        }

        public Range FindWithinRange(Range rangeToFind, List<string> searchLables)
        {
            foreach (var searchString in searchLables)
            {
                var range = FindWithinRange(rangeToFind, searchString);
                if (range != null)
                    return range;
            }
            return null;
        }

        public void Dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (WorksheetRange != null)
                Marshal.FinalReleaseComObject(WorksheetRange);

            if (ActiveSheet != null)
                Marshal.FinalReleaseComObject(ActiveSheet);

            if (Workbook != null)
            {
                Workbook.Close(false, Type.Missing, Type.Missing);
                Marshal.FinalReleaseComObject(Workbook);
            }

            if (Application != null)
            {
                Application.Quit();
                Marshal.FinalReleaseComObject(Application);
            }
        }
    }
}