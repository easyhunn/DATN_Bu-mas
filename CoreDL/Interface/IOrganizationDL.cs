using Entity;
using MISA.VMHUNG.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDL.Interface
{
    public interface IOrganizationDL: IBaseDL<Organization>
    {
        public string getData();
        public List<Organization> getSubOrg(Guid orgId);
        public List<Organization> getSubOrgWithStatus(Guid? orgId);
    }
}
