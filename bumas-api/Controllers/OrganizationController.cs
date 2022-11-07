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
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private IOrganizationBL _OrganizationBL;
        public OrganizationController(IOrganizationBL OrganizationBL)
        {
            this._OrganizationBL = OrganizationBL;
        }
        [HttpGet]
        public string Get()
        {
            return _OrganizationBL.getData();
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var res = _OrganizationBL.GetAll();
            if (!res.isSuccess)
            {
                return StatusCode(204, res);
            }
            else
            {
                return Ok(res.data);
            }

        }
        [HttpGet("getSubOrg")]
        public IActionResult GetSubOrg()
        {

            var res = _OrganizationBL.getSubOrg();
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(204, res);
            }

        }

        [HttpGet("getSubOrgByStatus")]
        public IActionResult GetSubOrgByStatus(int? status)
        {

            var res = _OrganizationBL.getSubOrgWithStatus(status);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(204, res);
            }

        }
       
    }   
}
