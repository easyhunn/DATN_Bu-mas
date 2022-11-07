using Entity;
using MISA.VMHUNG.Core.Entity;
using MISA.VMHUNG.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBL.Interface
{
    public interface IEstimateBL: IBaseBL<Estimate>
    {
        public string getData();
        public Task<bool> insert(List<Estimate> data);
        public bool deletes(List<Estimate> data);
        public Task<bool> updates(List<Estimate> data);
        public Task<bool> saveData(EstimateParam data);
        public Task<bool> AddSubmitEstimate(SubmitEstimateStatus data);
        public Task<bool> SubmitAuditEstimate(AuditEstimateStatus data);
        public Task<bool> UpdateAuditEstimate(AuditEstimateStatus data);
        public ServiceResult GetSubmitEstimateStatus();
        public ServiceResult GetSubmitEstimateById(Guid id);
        public ServiceResult getSummaryData();
        public ServiceResult GetAuditEstimateStatus();
    }
}
