using CoreBL.Interface;
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
    [ApiController, Authorize]
    public class TestController : ControllerBase
    {
        private ITestBL _testBL;
        public TestController(ITestBL testBL)
        {
            this._testBL = testBL;
        }
        [HttpGet]
        public string Get()
        {
            return _testBL.getData();
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var res = _testBL.GetAll();
            if (!res.isSuccess)
            {
                return StatusCode(204, res);
            }
            else
            {
                return Ok(res.data);
            }

        }
        [HttpPost]
        public bool Insert()
        {
            //return _testBL.insert();
            return true;

        }
        [HttpDelete]
        public bool Deletes()
        {
            return _testBL.deletes();
        }
        [HttpPut]
        public bool Updates()
        {
            return true;
            //return _testBL.updates();
        }
    }   
}
