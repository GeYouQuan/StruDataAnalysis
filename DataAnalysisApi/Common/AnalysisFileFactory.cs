using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.Common
{
    /// <summary>
    /// 文件解析工厂
    /// </summary>
    public static class AnalysisFileFactory
    {

        /// <summary>
        /// 获取解析
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static async Task<bool> GetAnalysisFile(string FilePath) {
            IAnalysisFile analysisFile = null;
            string Extension = "";
            if (System.IO.File.Exists(FilePath))
            {
                string FileName = System.IO.Path.GetFileName(FilePath);
                Extension = System.IO.Path.GetExtension(FileName);

            }
            else {
                throw new Exception($"文件：{FilePath}不存在。");
            }

            //
            EnumDataFileType dataFileType = GetDataFileType(Extension);
            //
            switch (dataFileType) {

                #region Office 
                case EnumDataFileType.XLS:
                    {
                        analysisFile = new Execl.AnalysisFileForXls()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                case EnumDataFileType.XLSX:
                    {
                        analysisFile = new Execl.AnalysisFileForXlsx()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                case EnumDataFileType.DOC:
                    {
                        analysisFile = new Word.AnalysisFileForDoc()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                case EnumDataFileType.DOCX:
                    {
                        analysisFile = new Word.AnalysisFileForDoc()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                case EnumDataFileType.PPT:
                    {
                        analysisFile = new PowerPoint.AnalysisFileForPpt()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                case EnumDataFileType.PPTX:
                    {
                        analysisFile = new PowerPoint.AnalysisFileForPptx()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                #endregion

                #region Pdf
                case EnumDataFileType.PDF:
                    {
                        analysisFile = new Pdf.AnalysisFileForPdf()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                #endregion

                #region Txt
                case EnumDataFileType.TXT:
                    {
                        analysisFile = new Txt.AnalysisFileForTxt()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                #endregion

                #region Image

                case EnumDataFileType.PNG:
                    {
                        analysisFile = new Images.AnalysisFileForPng()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                case EnumDataFileType.JPG:
                    {
                        analysisFile = new Images.AnalysisFileForJpg()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                case EnumDataFileType.JPEG:
                    {
                        analysisFile = new Images.AnalysisFileForJpeg()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                case EnumDataFileType.GIF:
                    {
                        analysisFile = new Images.AnalysisFileForGif()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                case EnumDataFileType.BMP:
                    {
                        analysisFile = new Images.AnalysisFileForBmp()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                case EnumDataFileType.TIFF:
                    {
                        analysisFile = new Images.AnalysisFileForTiff()
                        {
                            FilePath = FilePath
                        };
                        break;
                    }
                #endregion

                default:
                    {
                        throw new Exception($"不支持{Extension}文件格式。");
                    }
            }

            return await analysisFile.Analysis();
        }

        /// <summary>
        ///获取文件类型
        /// </summary>
        /// <param name="Extension"></param>
        /// <returns></returns>
        public static EnumDataFileType GetDataFileType(string Extension) {
             
            EnumDataFileType dataFileType = EnumDataFileType.none;

            Enum.TryParse<EnumDataFileType>(Extension, out dataFileType);
             
            return dataFileType;
        }


    }
}
