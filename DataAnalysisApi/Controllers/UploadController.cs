using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAnalysisApi.Common;

namespace DataAnalysisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromFile]UserFile file)
        {
            if (file == null || !file.IsValid)
                return new JsonResult(new { code = 500, message = "不允许上传的文件类型" });

            string newFile = string.Empty;
            if (file != null)
                newFile = await file.SaveAs("/data/files/images");

            return new JsonResult(new { code = 0, message = "成功", url = newFile });
        }

     
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            return new JsonResult(new{Value="Ping"});

        }

    }
}
