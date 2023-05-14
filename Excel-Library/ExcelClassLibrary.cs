using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;


namespace Excel_Library
{
    public class ExcelClassLibrary
    {     


        public static DataTable GetExcelDataTable(string filePath)
        {
            DataTable dt = new DataTable();
            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                IXLWorksheet workSheet = workBook.Worksheet(1);
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                }
            }

            return dt;
        }
    }
}