using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.Images
{
    public class AnalysisFileForJpeg : AnalysisFileForImage
    {
        /// <summary>
        /// 
        /// </summary>
        public new EnumDataFileType DataFileType => EnumDataFileType.JPEG;
    } 
}
