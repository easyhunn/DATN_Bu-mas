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
    public class AccountDL : BaseDL<User>, IAccountDL
    {
        public User getUserInfo(string email, string password)
        {
            var query = string.Format("Select u.id, u.user_name,  u.password,  u.org_id, u.email," +
                " o.parent_id AS parent_org_id, o.grade as org_grade " +
                " from user u JOIN organization o ON u.org_id = o.id " +
                " where email='{0}' and password='{1}';", email, password);
            var entities = dbConnection.Query<User>(query).FirstOrDefault();
            return entities;
        }

    }
}
