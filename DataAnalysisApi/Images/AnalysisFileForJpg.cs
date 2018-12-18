using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.Images
{
    public class AnalysisFileForJpg : AnalysisFileForImage
    {
        /// <summary>
        /// 
        /// </summary>
        public new EnumDataFileType DataFileType => EnumDataFileType.JPG;
    }
}
