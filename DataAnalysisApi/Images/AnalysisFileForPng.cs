using DataAnalysisApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.Images
{
    /// <summary>
    /// 图片
    /// </summary>
    public class AnalysisFileForPng : AnalysisFileForImage
    {
        public   new EnumDataFileType DataFileType { get => EnumDataFileType.PNG; }
   
    }
}
