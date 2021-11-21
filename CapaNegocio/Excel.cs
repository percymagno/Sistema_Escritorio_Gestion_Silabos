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
            removeEmptyCols();
            removeEmptyRows();
        }
        private void removeEmptyCols()
        {
            int i = 1;
            int n = lastUsedColumn;
            while(i <= lastUsedColumn)
            {
                if (isEmptyCol(i))
                {
                    //Console.WriteLine("Eliminando col: " + (n - lastUsedColumn + i).ToString());
                    ws.Columns[i].Delete();
                    lastUsedColumn--;
                }
                else
                    i++;
            }
        }
        private void removeEmptyRows()
        {
            int i = 1;
            int n = lastUsedRow;
            while (i <= lastUsedRow)
            {
                if (isEmptyRow(i))
                {
                    //Console.WriteLine("Eliminando row: " + (n - lastUsedRow + i).ToString());
                    ws.Rows[i].Delete();
                    lastUsedRow--;
                }
                else
                    i++;
            }
        }
        private bool isEmptyCol(int colIndex)
        {
            for (int i = 1; i <= lastUsedRow; i++)
            {
                if (ws.Cells[i, colIndex].value2 != null && ws.Cells[i, colIndex].value2.ToString() != "")
                    return false;
            }
            return true;
        }
        private bool isEmptyRow(int rowIndex)
        {
            for (int i = 1; i <= lastUsedColumn; i++)
            {
                if (ws.Cells[rowIndex, i].value2 != null && ws.Cells[rowIndex, i].value2.ToString() != "")
                    return false;
            }
            return true;
        }
        public string ReadCell(int i, int j)
        {
            i++; j++;
            if(ws.Cells[i,j] != null)
            {
                return ws.Cells[i,j].Value2;
            }
            else
            {
                return "";
            }
        }
        public int nroRows()
        {
            return lastUsedRow;
        }
        public int nroCols()
        {
            return lastUsedColumn;
        }
    }
}
