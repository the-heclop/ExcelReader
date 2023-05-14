using System.Data;



Console.WriteLine("Enter Excel path");
string filePath = Console.ReadLine();
DataTable dt =  ExcelClassLibrary.GetExcelDataTable(filePath);
foreach (DataRow dataRow in dt.Rows)
{
    foreach (var item in dataRow.ItemArray)
    {
        Console.WriteLine(item);
    }
}
Console.ReadLine();