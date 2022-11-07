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
    public interface ITemplateWorkbookBL : IBaseBL<TemplateWorkbook>
    {
        public Task<bool> saveData(TemplateWorkbook data);
        public ServiceResult GetSubmitTemplateById(Guid templateId);

    }
}
