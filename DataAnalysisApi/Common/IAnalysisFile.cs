using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.Common
{
    /// <summary>
    /// 解析文件
    /// </summary>
   public interface IAnalysisFile
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        EnumDataFileType DataFileType {   get; }

        /// <summary>
        /// 解析文件路径
        /// </summary>
        string FilePath { set; get; }

        /// <summary>
        /// 解析
        /// </summary>
        /// <returns></returns>
        async Task<bool> Analysis();

    }
}
