using DataAnalysisApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.Execl
{
    /// <summary>
    /// 解析Execl(2007以上)
    /// </summary>
    public class AnalysisFileForXlsx : IAnalysisFile
    {
        public EnumDataFileType DataFileType { get => EnumDataFileType.XLS; }
        public string FilePath { get; set; }

        public async Task<bool> Analysis()
        {
            throw new NotImplementedException();
        }
    }
}
