using Entity;
using MISA.VMHUNG.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBL.Interface
{
    public interface ITestBL: IBaseBL<Test>
    {
        public string getData();
        public Task<bool> insert();
        public bool deletes();
        public Task<bool> updates();

    }
}
