using Entity;
using MISA.VMHUNG.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDL.Interface
{
    public interface IAccountDL : IBaseDL<User>
    {
        public User getUserInfo(string userName, string password);
    }
}
