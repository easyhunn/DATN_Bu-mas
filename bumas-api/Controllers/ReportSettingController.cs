using CoreBL.Interface;
using CoreDL.Entity;
using Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace bumas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 
        
        
        ReportSettingController : ControllerBase
    {
        private IReportSettingBL _reportSettingBL;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ReportSettingController(IReportSettingBL _reportSettingBL, IWebHostEnvironment hostingEnvironment)
        {
            this._reportSettingBL = _reportSettingBL;
            this._hostingEnvironment = hostingEnvironment;
        }
        [HttpPost("FileUpload")]
        public async Task<IActionResult> FileUpload(SaveFileParams file)
        {
            string webRootPath = _hostingEnvironment.WebRootPath; // for deploy
            string contentRootPath = _hostingEnvironment.ContentRootPath; //
            file.FilePath = Path.Combine(contentRootPath, "Storage", file.template_name);
            var result = _reportSettingBL.FileUpload(file);
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok(new { result });
        }
        [HttpGet("getStorageFile")]
        public string getStorageFile(string fileName)
        {
            var rootPath = _hostingEnvironment.ContentRootPath; //get the root path

            var fullPath = Path.Combine(rootPath, "Storage", fileName); //combine the root path with that of our json file inside mydata directory

            var jsonData = System.IO.File.ReadAllText(fullPath); //read all the content inside the file

            if (string.IsNullOrWhiteSpace(jsonData)) return null; //if no data is present then return null or error if you wish

            //var result = JsonConvert.DeserializeObject<object>(jsonData); //deserialize object as a list of users in accordance with your json file
            return jsonData;

        }

        [HttpPost("saveTemplate")]
        public async Task<IActionResult> saveTemplate(SaveFileParams template)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath; //
            template.FilePath = Path.Combine(contentRootPath, "Storage", template.template_code);
            var result = _reportSettingBL.saveTemplate(template);
            return Ok(new { result });
        }

    }
}
