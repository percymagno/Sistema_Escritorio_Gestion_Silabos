using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace CapaNegocio
{
    public class Excel
    {
        ExcelPackage package;
        ExcelWorksheet ws;
        int lastUsedRow = 0;
        int lastUsedColumn = 0;

        public Excel(string path, int sheet)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            package = new ExcelPackage(new FileInfo(path));
            ws = package.Workbook.Worksheets[0];
            lastUsedRow = ws.Dimension.End.Row;
            lastUsedColumn = ws.Dimension.End.Column;
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
            package.Dispose();
            Console.WriteLine("Works???");
        }
    }
}
