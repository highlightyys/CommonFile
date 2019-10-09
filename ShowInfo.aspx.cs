using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.XSSF.UserModel;
using System.IO;

namespace WebApplication3
{
    public partial class ShowInfo : System.Web.UI.Page
    {
        public static List<User> users { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (users == null)
            {
                 users = ReadExcel();
            }
        }

        public List<User> ReadExcel()
        {
            List<User> list = new List<User>();
            //读取文件
            using (FileStream stream = new FileStream(Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString()) + "/UserInfo.xlsx", FileMode.Open))
            {
                //创建workbook
                //HSSFWorkbook workbook = new HSSFWorkbook(stream);
                XSSFWorkbook workbook = new XSSFWorkbook(stream);
                //读取sheet
                NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);
                //读取数据
                int rowIndex = 1;
                NPOI.SS.UserModel.IRow row = sheet.GetRow(rowIndex++);

                while (row != null)
                {
                    //读取一行中的对象
                    User u = new User();

                    if (row.GetCell(0) != null)
                    {
                        u.id = (int)row.GetCell(0).NumericCellValue;
                    }
                    if (row.GetCell(1) != null)
                    {
                        row.GetCell(1).SetCellType(NPOI.SS.UserModel.CellType.String);
                        u.name = row.GetCell(1).StringCellValue;
                    }

                    if (row.GetCell(2) != null)
                    {
                        u.age = (int)row.GetCell(2).NumericCellValue;
                    }
                    if (row.GetCell(3) != null)
                    {
                        row.GetCell(3).SetCellType(NPOI.SS.UserModel.CellType.String);
                        u.gender = row.GetCell(3).StringCellValue;
                    }

                    if (row.GetCell(4) != null)
                    {
                        row.GetCell(4).SetCellType(NPOI.SS.UserModel.CellType.String);
                        u.nationality = row.GetCell(4).StringCellValue;
                    }

                    if (row.GetCell(5) != null)
                    {
                        row.GetCell(5).SetCellType(NPOI.SS.UserModel.CellType.String);
                        u.phone = row.GetCell(5).StringCellValue;
                    }

                    if (row.GetCell(6) != null)
                    {
                        row.GetCell(6).SetCellType(NPOI.SS.UserModel.CellType.String);
                        u.address = row.GetCell(6).StringCellValue;
                    }
                    list.Add(u);
                    row = sheet.GetRow(rowIndex++);
                }

                return list;
            }

        }
    }
}