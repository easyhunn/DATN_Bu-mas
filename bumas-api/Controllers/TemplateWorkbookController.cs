using CoreBL.Interface;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bumas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateWorkbookController : ControllerBase
    {
        private ITemplateWorkbookBL _TemplateBL;
        public TemplateWorkbookController(ITemplateWorkbookBL TemplateBL)
        {
            this._TemplateBL = TemplateBL;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var res = _TemplateBL.GetAll();
            if (!res.isSuccess)
            {
                return StatusCode(204, res);
            }
            else
            {
                return Ok(res.data);
            }
        }
        [HttpGet("GetSubmitTemplateById")]
        public IActionResult GetSubmitTemplateById(Guid templateId)
        {

            var res = _TemplateBL.GetSubmitTemplateById(templateId);
            if (!res.isSuccess)
            {
                return StatusCode(204, res);
            }
            else
            {
                return Ok(res.data);
            }
        }
        [HttpPost("saveData")]
        public Task<bool> saveData([FromBody] TemplateWorkbook data)
        {
            return _TemplateBL.saveData(data);
        }
        
    }   
}
