using Entity;
using MISA.VMHUNG.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDL.Interface
{
    public interface IEstimateDL: IBaseDL<Estimate>
    {
        public string getData();
        public IEnumerable<SubmitEstimate> GetSubmitData();
        public IEnumerable<SubmitEstimate> GetSubmitEstimateById(Guid id);
        public IEnumerable<Estimate> GetSummaryData();
        public IEnumerable<entity> GetSubmitList<entity>(string table = "");
        public IEnumerable<AuditEstimateStatus> GetsubmitEstimate(string table = "");

    }
}
