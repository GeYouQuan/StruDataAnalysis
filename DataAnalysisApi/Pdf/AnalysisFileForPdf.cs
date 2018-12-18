using DataAnalysisApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.Pdf
{
    public class AnalysisFileForPdf : IAnalysisFile
    {
        public EnumDataFileType DataFileType { get => EnumDataFileType.PDF; }
        public string FilePath { get; set; }

        public async Task<bool> Analysis()
        {
            throw new NotImplementedException();
        }
    }
}
