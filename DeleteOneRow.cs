using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class DeleteOneRow
    {
        public static void DeleteRow(int id,string path)
        {
            XSSFWorkbook workbook;
            //读取文件
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                //创建workbook
                workbook = new XSSFWorkbook(stream);
                //读取sheet
                NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);
                //获取行索引,并删除
                for (int i = 1; ; i++)
                {
                    int ids = (int)sheet.GetRow(i).GetCell(0).NumericCellValue;
                    if (ids == id)
                    {
                        if (sheet.LastRowNum != i)
                        {
                            sheet.RemoveRow(sheet.GetRow(i));
                            sheet.ShiftRows(i + 1, sheet.LastRowNum, -1);
                        }
                        else
                        {
                            sheet.RemoveRow(sheet.GetRow(i));
                        }
                        break;
                    }
                }
            }
            if (File.Exists(path))
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