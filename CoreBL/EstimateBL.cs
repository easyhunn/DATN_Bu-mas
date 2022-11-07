using CoreBL.Interface;
using CoreDL.Interface;
using Entity;
using MISA.VMHUNG.Core.Entity;
using MISA.VMHUNG.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBL.Base
{
    public class EstimateBL : BaseBL<Estimate>, IEstimateBL
    {
        private IEstimateDL _EstimateDL;
          public EstimateBL (IEstimateDL EstimateDL): base(EstimateDL)
        {
            this._EstimateDL = EstimateDL;
        }
        public string getData()
        {
            return _EstimateDL.getData();
        }
        public async Task<bool> insert(List<Estimate> data)
        {
            return await _EstimateDL.Inserts<Estimate>(data);
        }
        public async Task<bool> AddSubmitEstimate(SubmitEstimateStatus data)
        {
            var listSubmit = new List<SubmitEstimateStatus>();
            var submitEstimateListId = Guid.NewGuid();
            data.submit_estimate_list_id = submitEstimateListId;
            listSubmit.Add(data);
            // clone data to estime
            // get estimate data
            var orgSentId = new Guid("3c897cb4-5742-11ed-9ca4-516713278a42");
            var orgReceiveId = new Guid("4a0d0162-5743-11ed-9ca4-516713278a42");
            var estimateData = _EstimateDL.GetAll<Estimate>();
            //estimateData = estimateData.Where(x => x.org_id == orgSentId).ToList();
            var submitEstimateData = estimateData.Select(x => {
                SubmitEstimate estData = new SubmitEstimate();
                 estData.id = Guid.NewGuid();
                 estData.amount = x.amount;
                estData.dictrict_amount = x.dictrict_amount;
                estData.ward_amount = x.ward_amount;
                estData.code = x.code;
                estData.org_sent_id = orgSentId;
                estData.org_receive_id = orgReceiveId;
                estData.name = x.name;
                estData.submit_estimate_list_id = submitEstimateListId;
                return estData; 
            }).ToList() as List<SubmitEstimate>;
            return await _EstimateDL.Inserts<SubmitEstimateStatus>(listSubmit)
                && await _EstimateDL.Inserts<SubmitEstimate>(submitEstimateData);
        }
        public bool deletes(List<Estimate> data)
        {
            return _EstimateDL.Deletes<Estimate>(data);
        }
        public async Task<bool> updates(List<Estimate> data)
        {
            return await _EstimateDL.Updates<Estimate>(data);
        }
        public async Task<bool> saveData(EstimateParam data)
        {
            var lstUpdate = data.lstUpdate;
            var lstInsert = data.lstInsert;
            return await _EstimateDL.Inserts<Estimate>(lstInsert) && await _EstimateDL.Updates<Estimate>(lstUpdate);
        }

        /// <summary>
        /// Lấy thông tin lần nộp
        /// </summary>
        /// <returns></returns>
        public ServiceResult GetSubmitEstimateStatus()
        {
            // Lấy tất cả bản ghi
            serviceResult.isSuccess = true;
            var datas = _EstimateDL.GetSubmitList<SubmitEstimateStatus>("submit_estimate_status");
            datas = datas.OrderByDescending(x => x.sortOrder);
            // Kiểm tra số lượng bản ghi trả về
            if (datas.Count() == 0)
            {
                serviceResult.isSuccess = false;
                serviceResult.devMsg = "Không có nội dung";
                serviceResult.userMsg = "Thất bại";
                serviceResult.errorCode = MISAError.noContent;
            }
            else
            {
                serviceResult.data = datas;
                serviceResult.devMsg = "Thành công";
            }

            return serviceResult;
        }
        public ServiceResult GetSubmitEstimateById(Guid id)
        {
            serviceResult.isSuccess = true;
            //Lấy dữ dữ liệu

            var entity = _EstimateDL.GetSubmitEstimateById(id);
            //Kiểm trả bản ghi có tồn tại không
            if (entity == null)
            {
                //Nếu không có bản ghi trả về
                serviceResult.isSuccess = false;
                serviceResult.devMsg = "Không có nội dung";
                serviceResult.userMsg = "Error";
                serviceResult.errorCode = MISAError.noContent;
            }
            else
            {
                serviceResult.data = entity;
                serviceResult.devMsg = "Success";
            }
            return serviceResult;
        }
        public ServiceResult getSummaryData()
        {
            serviceResult.isSuccess = true;
            //Lấy dữ dữ liệu

            var entity = _EstimateDL.GetSummaryData();
            //Kiểm trả bản ghi có tồn tại không
            if (entity == null)
            {
                //Nếu không có bản ghi trả về
                serviceResult.isSuccess = false;
                serviceResult.devMsg = "Không có nội dung";
                serviceResult.userMsg = "Error";
                serviceResult.errorCode = MISAError.noContent;
            }
            else
            {
                serviceResult.data = entity;
                serviceResult.devMsg = "Success";
            }
            return serviceResult;
        }
        /// <summary>
        /// Lấy thông tin lần nộp
        /// </summary>
        /// <returns></returns>
        public ServiceResult GetAuditEstimateStatus()
        {
            // Lấy tất cả bản ghi
            serviceResult.isSuccess = true;
            var datas = _EstimateDL.GetsubmitEstimate("audit_estimate_status");
            // Kiểm tra số lượng bản ghi trả về
            if (datas.Count() == 0)
            {
                serviceResult.isSuccess = false;
                serviceResult.devMsg = "Không có nội dung";
                serviceResult.userMsg = "Thất bại";
                serviceResult.errorCode = MISAError.noContent;
            }
            else
            {
                serviceResult.data = datas;
                serviceResult.devMsg = "Thành công";
            }

            return serviceResult;
        }
        public async Task<bool> SubmitAuditEstimate(AuditEstimateStatus data)
        {
            var listSubmit = new List<AuditEstimateStatus>();
            data.status = 2;
            listSubmit.Add(data);
            // clone data to estime
            // get estimate data
            return await _EstimateDL.Inserts<AuditEstimateStatus>(listSubmit);
        }
        public async Task<bool> UpdateAuditEstimate(AuditEstimateStatus data)
        {
            var listSubmit = new List<AuditEstimateStatus>();
            var submitEstimateListId = Guid.NewGuid();
            data.submit_estimate_list_id = submitEstimateListId;
            data.status = 2;
            listSubmit.Add(data);
            // clone data to estime
            // get estimate data
            

            return await _EstimateDL.Updates<AuditEstimateStatus>(listSubmit);
        }
    }
}
