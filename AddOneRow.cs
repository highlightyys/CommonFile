using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication3;

namespace WebApplication3
{
    public class AddOneRow
    {
        public static void AddRow(User user,string path)
        {
            XSSFWorkbook workbook;
            //读取文件
            
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                //创建workbook
                workbook = new XSSFWorkbook(stream);
                //读取sheet
                NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);

                //获取新行索引
                int index = sheet.LastRowNum + 1; ;
                //添加新行
                NPOI.SS.UserModel.IRow row = sheet.CreateRow(index);
                row.CreateCell(0).SetCellValue(user.id);
                row.CreateCell(1).SetCellValue(user.name);
                row.CreateCell(2).SetCellValue(user.age);
                row.CreateCell(3).SetCellValue(user.gender);
                row.CreateCell(4).SetCellValue(user.nationality);
                row.CreateCell(5).SetCellValue(user.phone);
                row.CreateCell(6).SetCellValue(user.address);

            }
            
               
            if(File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                workbook.Write(fs);
                fs.Close();
                fs.Dispose();
            }
        }
    }
}