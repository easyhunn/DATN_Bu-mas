using CoreBL.Interface;
using CoreDL.Interface;
using Entity;
using MISA.VMHUNG.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBL.Base
{
    public class OrganizationBL : BaseBL<Organization>, IOrganizationBL
    {
        private IOrganizationDL _organizationDL;
          public OrganizationBL(IOrganizationDL organizationDL) : base(organizationDL)
        {
            this._organizationDL = organizationDL;
        }
        public string getData()
        {
            return _organizationDL.getData();
        }
        public async Task<bool> insert()
        {
            var listCity = new List<City>();
            var city1 = new City("Bac Ninh", "Hung Yen");
            var city2 = new City("Nam Dinh", "Hai Hau");
            listCity.Add(city1);
            listCity.Add(city2);

            return await _organizationDL.Inserts<City>(listCity);
        }
        public bool deletes()
        {
            var listCity = new List<City>();
            var city1 = new City("Bac Ninh", "Hung Yen", new Guid("4e965db2-c7e8-4856-9f3d-a3ed902bdeae"));
            var city2 = new City("Nam Dinh", "Hai Hau", new Guid("d34dae12-287b-11ed-a100-223344556677"));
            listCity.Add(city1);
            listCity.Add(city2);

            return _organizationDL.Deletes<City>(listCity);
        }
        public async Task<bool> updates()
        {
            var listCity = new List<City>();
            var city1 = new City("Bac Ninh1", "Hung Yen4", new Guid("212bdefa-f521-467b-8b16-c1eccde67eb5"));
            var city2 = new City("Nam Dinh3", "Hai Hau2", new Guid("694f6613-7668-4f1d-8e72-d6055af51059"));
            listCity.Add(city1);
            listCity.Add(city2);

            return await _organizationDL.Updates<City>(listCity);
        }

        public List<Organization> getSubOrg()
        {
            var orgId = new Guid ("4a0d0162-5743-11ed-9ca4-516713278a42");
            return _organizationDL.getSubOrg(orgId);
        }
        public List<Organization> getSubOrgWithStatus(int? status)
        {
            var orgId = AuthUtil.orgId;
            var subOrg = _organizationDL.getSubOrgWithStatus(orgId);
            List<Organization> res = null;
            if (subOrg != null)
            {  
                if (status == null)
                {
                    res = subOrg;
                } else
                if (status == 0)
                {
                    res = subOrg.Where(x => x.status == null || x.status == 0).ToList();
                }
                else
                {
                    res = subOrg.Where(x => x.status == status).ToList();
                }
            }
            return res;
        }
    }
}
