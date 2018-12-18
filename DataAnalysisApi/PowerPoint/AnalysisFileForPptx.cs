using DataAnalysisApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.PowerPoint
{
    public class AnalysisFileForPptx : IAnalysisFile
    {
        public EnumDataFileType DataFileType { get => EnumDataFileType.PPTX; }
        public string FilePath { get; set; }

        public async Task<bool> Analysis()
        {
            throw new NotImplementedException();
        }
    }
}
