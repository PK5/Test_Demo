using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ScriptManager;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReadDataFromExcel
{
    public class ExcelRead : IEcelread
    {
        public List<ExcelPoco> GetDataFromExcel(String path)
        {
            List<ExcelPoco> lstExceldata = new List<ExcelPoco>();
            if (File.Exists(path))
            {
                XSSFWorkbook xssfwbobj;
                HSSFWorkbook hssfwbobj;
                ISheet excelSheet;
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                var fileExt = Path.GetExtension(path);
                if (fileExt == ".xls")
                {
                    hssfwbobj = new HSSFWorkbook(file);
                    excelSheet = hssfwbobj.GetSheet("Sheet1");
                }
                else
                {
                    xssfwbobj = new XSSFWorkbook(file);
                    excelSheet = xssfwbobj.GetSheet("Sheet1");
                }
                ExcelPoco exlPoco = null;
                for (int row = 1; row <= excelSheet.LastRowNum; row++)
                {
                    if (excelSheet.GetRow(row) != null) //null is when the row only contains empty cells 
                    {
                        exlPoco = new ExcelPoco();
                        bool isNeedToAdd = false;
                        if (excelSheet.GetRow(row).GetCell(0) != null)
                        {
                            exlPoco.Column1 = (excelSheet.GetRow(row).GetCell(0).ToString());
                            isNeedToAdd = true;
                        }

                        if (excelSheet.GetRow(row).GetCell(1) != null)
                        {
                            exlPoco.Column2 = (excelSheet.GetRow(row).GetCell(1).ToString());
                            isNeedToAdd = true;
                        }

                        if (excelSheet.GetRow(row).GetCell(2) != null)
                        {
                            exlPoco.Column3 = (excelSheet.GetRow(row).GetCell(2).ToString());
                            isNeedToAdd = true;
                        }
                        if (excelSheet.GetRow(row).GetCell(3) != null)
                        {
                            exlPoco.Column4 = (excelSheet.GetRow(row).GetCell(3).ToString());
                            isNeedToAdd = true;
                        }

                        // exlPoco.Column2 = (excelSheet.GetRow(row).GetCell(1).ToString());
                        //exlPoco.Column3 = (excelSheet.GetRow(row).GetCell(2).ToString());
                        // exlPoco.Column4 = (excelSheet.GetRow(row).GetCell(3).ToString());
                        if (isNeedToAdd)
                        {
                            lstExceldata.Add(exlPoco);
                        }
                    }

                }
            }
            return lstExceldata;
        }
    }
}
