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
    public class TemplateWorkbookDL: BaseDL<TemplateWorkbook>, ITemplateWorkbookDL
    {
        /// <summary>
        /// lấy tất cả khách hàng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// Created By: VM Hùng (12/04/2021)
        public IEnumerable<TemplateWorkbook> GetSubmitTemplateById(Guid? templateId)
        {
            var parameters = new DynamicParameters();
            var orgReceiveId = AuthUtil.orgId;
            parameters.Add($"@$orgReceiveId", orgReceiveId, DbType.String);
            parameters.Add($"@$templateId", templateId, DbType.String);
            var storeName = $"Proc_GetSubmitTemplateById";
            var entity = dbConnection.Query<TemplateWorkbook>(storeName, parameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

    }
}
