using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAnalysisApi.Common;
using Microsoft.AspNetCore.Cors;

namespace DataAnalysisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromFile]UserFile file)
        {
            /*
             ------WebKitFormBoundaryO9RDf5D3InulEfkO
Content-Disposition: form-data; name="chunkNumber"

155
------WebKitFormBoundaryO9RDf5D3InulEfkO
Content-Disposition: form-data; name="chunkSize"

1048576
------WebKitFormBoundaryO9RDf5D3InulEfkO
Content-Disposition: form-data; name="currentChunkSize"

1048576
------WebKitFormBoundaryO9RDf5D3InulEfkO
Content-Disposition: form-data; name="totalSize"

356755976
------WebKitFormBoundaryO9RDf5D3InulEfkO
Content-Disposition: form-data; name="identifier"

356755976-windows-x64_FineBI4_1-CNexe
------WebKitFormBoundaryO9RDf5D3InulEfkO
Content-Disposition: form-data; name="filename"

windows-x64_FineBI4_1-CN.exe
------WebKitFormBoundaryO9RDf5D3InulEfkO
Content-Disposition: form-data; name="relativePath"

windows-x64_FineBI4_1-CN.exe
------WebKitFormBoundaryO9RDf5D3InulEfkO
Content-Disposition: form-data; name="totalChunks"

340
------WebKitFormBoundaryO9RDf5D3InulEfkO
Content-Disposition: form-data; name="file"; filename="windows-x64_FineBI4_1-CN.exe"
Content-Type: application/x-msdownload


------WebKitFormBoundaryO9RDf5D3InulEfkO--
             */
            if (file == null || !file.IsValid)
                return new JsonResult(new { code = 500, message = "不允许上传的文件类型" });

            string newFile = string.Empty;
            if (file != null)
                newFile = await file.SaveAs("images");

            return new JsonResult(new {
                code = 0,
                message = "成功",
                url = newFile });
        }

     
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            return new JsonResult(new{Value="Ping"});

        }

    }
}
