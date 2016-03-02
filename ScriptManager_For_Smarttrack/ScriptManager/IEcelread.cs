using ReadDataFromExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptManager
{
    interface IEcelread
    {
        List<ExcelPoco> GetDataFromExcel(String path);
    }
}
