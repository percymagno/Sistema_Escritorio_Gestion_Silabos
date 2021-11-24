using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace CapaNegocio
{
    public class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        int lastUsedRow = 0;
        int lastUsedColumn = 0;

        public Excel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = excel.Worksheets[sheet];
            lastUsedRow = ws.Cells.Find("*", System.Reflection.Missing.Value,
                                System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                _Excel.XlSearchOrder.xlByRows, _Excel.XlSearchDirection.xlPrevious,
                                false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;
            lastUsedColumn = ws.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               _Excel.XlSearchOrder.xlByColumns, _Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;
        }
        public string ReadCell(int i, int j)
        {
            i++; j++;
            if(ws.Cells[i,j] != null)
                return ws.Cells[i, j].Text.ToString().Trim();
            else
                return "";
        }
        public int nroRows()
        {
            return lastUsedRow;
        }
        public int nroCols()
        {
            return lastUsedColumn;
        }
        public void closeExcel()
        {
            wb.Close(0);
            excel.Quit();
        }
    }
}
