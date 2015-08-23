using System;
using System.Collections.Generic;

namespace ExcelDAO
{
    public class ExcelFile : IDisposable
    {
        private readonly Microsoft.Office.Interop.Excel.Application _application;
        private readonly Microsoft.Office.Interop.Excel.Workbook _workbook;
        private Microsoft.Office.Interop.Excel.Worksheet _worksheet;
        private readonly string _filename;
        private int _currentSheetNumber;

        public bool Visible
        {
            get { return _application.Visible; }
            set { _application.Visible = value; }
        }

        public int UsedRows
        {
            get { return _worksheet.UsedRange.Rows.Count; }
        }

        public int UsedCols
        {
            get { return _worksheet.UsedRange.Columns.Count; }
        }

        public void NextSheet()
        {
            _currentSheetNumber++;
            _worksheet = _workbook.Worksheets[_currentSheetNumber];
        }

        public ExcelFile(string filePath)
        {
            _application = new Microsoft.Office.Interop.Excel.Application();
            _workbook = _application.Workbooks.Open(filePath);
            _worksheet = (Microsoft.Office.Interop.Excel.Worksheet)_workbook.Worksheets.Item[1];
            _filename = filePath;
            _currentSheetNumber = 1;
        }

        public void SetValue(string value, int i, int j)
        {
            _worksheet.Cells[i, j] = value;
        }

        public string GetValue(int i, int j)
        {
            var range = (Microsoft.Office.Interop.Excel.Range)_worksheet.Cells[i, j];
            return range.Value2 != null ? range.Value2.ToString() : string.Empty;
        }

        public void Dispose()
        {
            try
            {
                _workbook.Close(true, _filename, System.Reflection.Missing.Value);
                _application.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_application);
            }
            catch (Exception)
            {
                
            }
        }
        List<string[]> logs = new List<string[]>(); 
        public void AddLogs(List<string[]> ar)
        {
            int count = 1;
            ar.ForEach(x =>
            {
                for (int i = 0; i < x.Length; i++)
                {
                    this.SetValue(x[i], count, i+1);
                }
                count++;
            });
        }
    }
}
