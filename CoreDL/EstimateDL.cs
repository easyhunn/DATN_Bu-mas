using CoreDL.Interface;
using Dapper;
using Entity;
using MISA.VMHUNG.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDL
{
    public class EstimateDL: BaseDL<Estimate>, IEstimateDL
    {
        public string getData()
        {
            var entity = dbConnection.Query<object>("Select * from city");
            return "from DL";
        }
        public IEnumerable<SubmitEstimate> GetSubmitEstimateById(Guid id)
        {
            var query = string.Format("Select * from {0} where submit_estimate_list_id='{1}'", "submit_estimate", id);
            var entities = dbConnection.Query<SubmitEstimate>(query);
            return entities;
        }
        public IEnumerable<SubmitEstimate> GetSubmitData()
        {
            //var query = string.Format("Select * from {0} where submit_estimate_list_id='{1}'", "submit_estimate", id);
            var entities = dbConnection.Query<SubmitEstimate>("");
            return entities;
        }
        /// <summary>
        /// lấy tất cả khách hàng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// Created By: VM Hùng (12/04/2021)
        public IEnumerable<Estimate> GetSummaryData()
        {
            var parameters = new DynamicParameters();
            var orgReceiveId = AuthUtil.orgId;
            parameters.Add($"@$orgReceiveId", orgReceiveId, DbType.String);
            var storeName = $"Proc_GetSummaryData";
            var entity = dbConnection.Query<Estimate>(storeName, parameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        public IEnumerable<entity> GetSubmitList<entity>(string table = "")
        {
            if (string.IsNullOrWhiteSpace(table))
            {
                table = typeof(entity).Name;
            }
            var orgId = AuthUtil.orgId;
            var query = string.Format("Select * from {0} where org_sent_id='{1}'", table, orgId);
            var entities = dbConnection.Query<entity>(query);
            return entities;
        }
        public IEnumerable<AuditEstimateStatus> GetsubmitEstimate(string table = "")
        {
            if (string.IsNullOrWhiteSpace(table))
            {
                table = typeof(AuditEstimateStatus).Name;
            }
            var orgId = AuthUtil.orgId;
            var query = string.Format("Select * from {0} where org_sent_id='{1}'", table, orgId);
            var entities = dbConnection.Query<AuditEstimateStatus>(query);
            return entities;
        }
    }
}
