using CoreBL.Interface;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.VMHUNG.Core.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bumas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        private IEstimateBL _EstimateBL;
        public EstimateController(IEstimateBL EstimateBL)
        {
            this._EstimateBL = EstimateBL;
        }
        [HttpGet]
        public string Get()
        {
            return _EstimateBL.getData();
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var res = _EstimateBL.GetAll();
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
        public bool Insert([FromBody] EstimateParam data)
        {
            var lstUpadate = data.lstUpdate;
            var lstInsert = data.lstInsert;
            //return _EstimateBL.insert(data);
            return true;
        }
        [HttpPost("saveData")]
        public Task<bool> saveData([FromBody] EstimateParam data)
        {
            return _EstimateBL.saveData(data);
        }
        [HttpDelete("{id}")]
        public bool Deletes(string id)
        {
            var data = new Estimate();
            data.id = new Guid(id);
            var lstDelete = new List<Estimate>();
            lstDelete.Add(data);
            return _EstimateBL.deletes(lstDelete);
        }
        [HttpPut]
        public bool Updates()
        {
            return true;
            //return _EstimateBL.updates();
        }


        // trạng thái lần nộp
        /// <summary>
        /// Thông tin đăng nhập
        /// </summary>
        /// <returns></returns>
        [HttpGet("getSubmitEstimateStatus")]
        public IActionResult GetSubmitEstimateStatus()
        {

            var res = _EstimateBL.GetSubmitEstimateStatus();
            if (!res.isSuccess)
            {
                return StatusCode(204, res);
            }
            else
            {
                return Ok(res.data);
            }

        }

        [HttpPost("AddSubmitEstimate")]
        public Task<bool> AddSubmitEstimate([FromBody] SubmitEstimateStatus data)
        {
            return _EstimateBL.AddSubmitEstimate(data);
        }

        [HttpGet("getEstimateById")]
        public IActionResult getEstimateById(Guid submitSummaryListId)
        {

            var res = _EstimateBL.GetSubmitEstimateById(submitSummaryListId);
            if (!res.isSuccess)
            {
                return StatusCode(204, res);
            }
            else
            {
                return Ok(res.data);
            }

        }

        [HttpGet("getSummaryData")]
        public IActionResult getSummaryData()
        {

            var res = _EstimateBL.getSummaryData();
            if (!res.isSuccess)
            {
                return StatusCode(204, res);
            }
            else
            {
                return Ok(res.data);
            }

        }
        /// <summary>
        /// Nộp dự toán
        /// </summary>
        /// <returns></returns>
        [HttpPost("submitEstimate")]
        public Task<bool> SubmitEstimate(SubmitEstimateParam param)
        {
            if (param.Mode == 1)
            {
                return _EstimateBL.SubmitAuditEstimate(param.auditEstimateStatus);
            } else
            {
                return _EstimateBL.UpdateAuditEstimate(param.auditEstimateStatus);
            }

        }
        /// <summary>
        /// Lấy Trạng thái nộp
        /// </summary>
        /// <returns></returns>
        [HttpGet("submitEstimate")]
        public IActionResult GetSubmitEstimate()
        {
            var res = new ServiceResult();
            res = _EstimateBL.GetAuditEstimateStatus();
            if (!res.isSuccess)
            {
                return StatusCode(204, res);
            }
            else
            {
                return Ok(res.data);
            }

        }
    }   
}
