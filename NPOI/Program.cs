using System;
using System.IO;
using System.Linq;
using NPOI.DataAccess;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace NPOI
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the number of records:");
            int size;
            int.TryParse(Console.ReadLine(), out size);

            IWorkbook wb = new XSSFWorkbook();

            var sheet = wb.CreateSheet("Sheet One");

            var families = Repository.Get(size).ToList();

            var header = sheet.CreateRow(0);
            header.CreateCell(0).SetCellValue("Mom");
            header.CreateCell(1).SetCellValue("Dad");
            header.CreateCell(2).SetCellValue("No. of Kids");

            for (int i = 1; i <= families.Count(); i++)
            {
                var row = sheet.CreateRow(i);
                var fam = families[i - 1];

                row.CreateCell(0).SetCellValue(fam.Mom.FullName);
                row.CreateCell(1).SetCellValue(fam.Dad.FullName);
                row.CreateCell(2).SetCellValue(fam.Kids.Count());
            }

            var stream = File.Create(@"C:\Output.xlsx");
            wb.Write(stream);

            stream.Close();
            
        }
    }
}
