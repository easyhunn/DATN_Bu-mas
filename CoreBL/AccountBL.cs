using CoreBL.Interface;
using CoreDL.Interface;
using Entity;
using MISA.VMHUNG.Core.Entity;
using MISA.VMHUNG.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBL.Base
{
    public class AccountBL : BaseBL<User>, IAccountBL
    {
        private IAccountDL _AccountDL;
          public AccountBL(IAccountDL AccountDL): base(AccountDL)
        {
            this._AccountDL = AccountDL;
        }
        public User getUserInfo(string email, string password)
        {
            serviceResult.isSuccess = true;
            //Lấy dữ dữ liệu

            var entity = _AccountDL.getUserInfo(email, password);
            
            return entity;
        }

    }
}
