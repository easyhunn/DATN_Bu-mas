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
    public class TestDL: BaseDL<Test>, ITestDL
    {
        public string getData()
        {
            var entity = dbConnection.Query<object>("Select * from city");
            return "from DL";
        }
    }
}
