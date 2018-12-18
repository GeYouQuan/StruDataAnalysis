using DataAnalysisApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.Txt
{
    public class AnalysisFileForTxt : IAnalysisFile
    {
        public EnumDataFileType DataFileType { get => EnumDataFileType.TXT; }
        public string FilePath { get; set; }

        public async Task<bool> Analysis()
        {
            throw new NotImplementedException();
        }
    }
}
