using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication3;

namespace WebApplication3
{
    public class UpdateOneRow
    {
        public static void UpdateRow(User user,string path)
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
                    if (ids == user.id)
                    {
                        sheet.GetRow(i).GetCell(1).SetCellValue(user.name);
                        sheet.GetRow(i).GetCell(2).SetCellValue(user.age);
                        sheet.GetRow(i).GetCell(3).SetCellValue(user.gender);
                        if (sheet.GetRow(i).GetCell(4) != null)
                        {
                            sheet.GetRow(i).GetCell(4).SetCellValue(user.nationality);
                        }
                        else
                        {
                            sheet.GetRow(i).CreateCell(4).SetCellValue(user.nationality);
                        }

                        if (sheet.GetRow(i).GetCell(5) != null)
                        {
                            sheet.GetRow(i).GetCell(5).SetCellValue(user.phone);
                        }
                        else
                        {
                            sheet.GetRow(i).CreateCell(5).SetCellValue(user.phone);
                        }

                        if (sheet.GetRow(i).GetCell(6) != null)
                        {
                            sheet.GetRow(i).GetCell(6).SetCellValue(user.address);
                        }
                        else
                        {
                            sheet.GetRow(i).CreateCell(6).SetCellValue(user.address);
                        }
                        break;
                    }
                }
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