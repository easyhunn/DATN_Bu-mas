using CoreDL.Interface;
using Dapper;
using Entity;
using MISA.VMHUNG.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDL
{
    public class OrganizationDL: BaseDL<Organization>, IOrganizationDL
    {
        public string getData()
        {
            var entity = dbConnection.Query<object>("Select * from city");
            return "from DL";
        }
        public List<Organization> getSubOrg(Guid orgId)
        {
            var query = $"Select * from organization o where o.parent_id ='{orgId}'";
            var entities = dbConnection.Query<Organization>(query) as List<Organization>;
            return entities;
        }
        public List<Organization> getSubOrgWithStatus(Guid? orgId)
        {
            var query = $"SELECT" +
                $"  o.id," +
                $"  o.name," +
                $"  o.grade," +
                $"  o.parent_id," +
                $"  o.code," +
                $"  o.categoryType," +
                $"  aes.status" +
                $" FROM organization o" +
                $"  LEFT JOIN audit_estimate_status aes" +
                $"    ON o.id = aes.org_sent_id" +
                $" WHERE o.parent_id ='{orgId}';";
            //var query = $"Select * from organization o " +
            //    $"LEFT JOIN audit_estimate_status aes " +
            //    $"ON o.id = ses.org_sent_id " +
            //    $"where o.parent_id ='{orgId}'";
            var entities = dbConnection.Query<Organization>(query) as List<Organization>;
            return entities;
        }
    }
}
