using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysisApi.Common
{
    public class UserFile
    {
        public string FileName { get; set; }
        public long Length { get; set; }
        public string Extension { get; set; }
        public string FileType { get; set; }

        private readonly static string[] Filters = { ".jpg", ".png", ".bmp" };
        public bool IsValid => !string.IsNullOrEmpty(this.Extension) && Filters.Contains(this.Extension);

        /*
            ------WebKitFormBoundaryO9RDf5D3InulEfkO
Content-Disposition: form-data; name="chunkNumber"
155
*/
        public int chunkNumber { set; get; }
        /*
        ------WebKitFormBoundaryO9RDf5D3InulEfkO
        Content-Disposition: form-data; name="chunkSize"

        1048576
*/
        public int chunkSize { set; get; }
        /*
                ------WebKitFormBoundaryO9RDf5D3InulEfkO
                Content-Disposition: form-data; name="currentChunkSize"

                1048576
*/
        public int currentChunkSize { set; get; }
        /*
                ------WebKitFormBoundaryO9RDf5D3InulEfkO
                Content-Disposition: form-data; name="totalSize"

                356755976
*/
        public long totalSize { set; get; }
        /*
                ------WebKitFormBoundaryO9RDf5D3InulEfkO
                Content-Disposition: form-data; name="identifier"

                356755976-windows-x64_FineBI4_1-CNexe
*/
        public string identifier { set; get; }
  
        /*
                ------WebKitFormBoundaryO9RDf5D3InulEfkO
                Content-Disposition: form-data; name="relativePath"

                windows-x64_FineBI4_1-CN.exe
*/
        public string relativePath { set; get; }
        /*
                ------WebKitFormBoundaryO9RDf5D3InulEfkO
                Content-Disposition: form-data; name="totalChunks"

                340
*/
        public int totalChunks { set; get; }
        /*
                ------WebKitFormBoundaryO9RDf5D3InulEfkO
                Content-Disposition: form-data; name="file"; filename="windows-x64_FineBI4_1-CN.exe"
                Content-Type: application/x-msdownload


                ------WebKitFormBoundaryO9RDf5D3InulEfkO--
                            */

        private IFormFile file;
        public IFormFile File
        {
            get { return file; }
            set
            {
                if (value != null)
                {
                    this.file = value;

                    this.FileType = this.file.ContentType;
                    this.Length = this.file.Length;
                    this.Extension =System.IO.Path.GetExtension(  this.file.FileName);
                    //
                    //
                    if (string.IsNullOrEmpty(this.FileName))
                        this.FileName = this.FileName;
                }
            }
        }

        public async Task<string> SaveAs(string destinationDir = null)
        {
            if (this.file == null)
                throw new ArgumentNullException("没有需要保存的文件");

            destinationDir = System.IO.Path.Combine(Directory.GetCurrentDirectory(), destinationDir);

            if (destinationDir != null)
                Directory.CreateDirectory(destinationDir);

            var newName = DateTime.Now.Ticks;
            var newFile = Path.Combine(destinationDir ?? "", $"{newName}{this.Extension}");
            using (FileStream fs = new FileStream(newFile, FileMode.CreateNew))
            {
                await this.file.CopyToAsync(fs);
                fs.Flush();
            }

            return newFile;
        }

        public async Task<string> SaveAsChunks(string destinationDir = null)
        {
            if (this.file == null)
                throw new ArgumentNullException("没有需要保存的文件");

          string  TempDestinationDir = System.IO.Path.Combine(Directory.GetCurrentDirectory(), destinationDir);

            if (TempDestinationDir != null)
                Directory.CreateDirectory(TempDestinationDir);
             
            //
            var newFile = Path.Combine(TempDestinationDir ?? "", $"{this.FileName}");

            if (totalChunks > 1)
            {
                //临时目录
                TempDestinationDir = System.IO.Path.Combine(TempDestinationDir, "Temp");
                if (TempDestinationDir != null)
                    Directory.CreateDirectory(TempDestinationDir);

                newFile = Path.Combine(TempDestinationDir ?? "", $"{this.FileName}.{this.chunkNumber}");

                using (FileStream fs = new FileStream(newFile, FileMode.CreateNew))
                {
                    await this.file.CopyToAsync(fs);
                    fs.Flush();
                }
                //
                //合并 
                // 
                bool succstart = true;
                for (int chunkindex = 1; chunkindex <= this.totalChunks; chunkindex++)
                {
                    newFile = Path.Combine(TempDestinationDir ?? "", $"{this.FileName}.{chunkindex}");
                    if (!System.IO.File.Exists(newFile))
                    {
                        succstart = false;
                        break;
                    }
                }
                if (succstart)
                {
                    //附件目录
                    destinationDir = System.IO.Path.Combine(Directory.GetCurrentDirectory(), destinationDir);
                    //
                    newFile = Path.Combine(destinationDir ?? "", $"{this.FileName}");
                    using (FileStream fs = new FileStream(newFile, FileMode.Create))
                    {
                        //
                        for (int chunkindex = 1; chunkindex <= this.totalChunks; chunkindex++)
                        {
                            newFile = Path.Combine(TempDestinationDir ?? "", $"{this.FileName}.{chunkindex}");
                            var bytes = System.IO.File.ReadAllBytes(newFile);
                            await fs.WriteAsync(bytes, 0, bytes.Length);
                            bytes = null;
                            System.IO.File.Delete(newFile);//删除分块 
                        }
                        fs.Flush();
                    }
                  
                }
            }
            else
            {
                using (FileStream fs = new FileStream(newFile, FileMode.CreateNew))
                {
                    await this.file.CopyToAsync(fs);
                    fs.Flush();
                }
            }



            return newFile;
        }
    }
}
