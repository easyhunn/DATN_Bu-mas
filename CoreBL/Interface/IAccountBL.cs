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
    public interface IAccountBL : IBaseBL<User>
    {
        public User getUserInfo(string email, string password);
    }
}
