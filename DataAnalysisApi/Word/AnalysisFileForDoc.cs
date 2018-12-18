﻿using DataAnalysisApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.Word
{
    public class AnalysisFileForDoc : IAnalysisFile
    {
        public EnumDataFileType DataFileType { get => EnumDataFileType.DOC; }
        public string FilePath { get; set; }

        public async Task<bool> Analysis()
        {
            throw new NotImplementedException();
        }
    }
}