using CoreDL.Entity;
using MISA.VMHUNG.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBL.Interface
{
    public interface IReportSettingBL : IBaseBL<SaveFileParams>
    {
        public Task<bool> FileUpload(SaveFileParams file);
        public Task<bool> saveTemplate(SaveFileParams template);
    }
}
