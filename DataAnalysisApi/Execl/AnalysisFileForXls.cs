using DataAnalysisApi.Common;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.Execl
{
    /// <summary>
    /// 解析Execl(2003)
    /// </summary>
    public class AnalysisFileForXls : IAnalysisFile
    {
        public EnumDataFileType DataFileType { get => EnumDataFileType.XLS; }
        public string FilePath { get; set; }

        /// <summary>
        /// 解析Execl文件
        /// </summary>
        /// <returns></returns>
        public Task<bool> Analysis()
        {
            bool result = false;
            
            //根据指定路径读取文件
            FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            //根据文件流创建excel数据结构
            IWorkbook workbook = WorkbookFactory.Create(fs);
            //excel工作表

            if (workbook != null) {


                for (int sheetNum = 0; sheetNum < workbook.NumberOfSheets; sheetNum++) {

                    ISheet sheet = workbook.GetSheetAt(sheetNum);

                   //提取所有文本/图片

                }
                 
            }

            return Task.FromResult(result);
        }
    }
}
