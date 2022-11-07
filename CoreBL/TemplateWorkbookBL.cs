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
    public class TemplateWorkbookBL : BaseBL<TemplateWorkbook>, ITemplateWorkbookBL
    {
        private ITemplateWorkbookDL _TemplateWorkbookDL;
          public TemplateWorkbookBL(ITemplateWorkbookDL TemplateWorkbookDL) : base(TemplateWorkbookDL)
        {
            this._TemplateWorkbookDL = TemplateWorkbookDL;
        }
        public async Task<bool> saveData(TemplateWorkbook data)
        {
            var listTemplate = new List<TemplateWorkbook>();
            return await _TemplateWorkbookDL.Inserts<TemplateWorkbook>(listTemplate);
        }
        public ServiceResult GetSubmitTemplateById(Guid templateId)
        {
            serviceResult.isSuccess = true;
            //Lấy dữ dữ liệu

            var entity = _TemplateWorkbookDL.GetSubmitTemplateById(templateId);
            //Kiểm trả bản ghi có tồn tại không
            if (entity == null)
            {
                //Nếu không có bản ghi trả về
                serviceResult.isSuccess = false;
                serviceResult.devMsg = "Không có nội dung";
                serviceResult.userMsg = "Error";
                serviceResult.errorCode = MISAError.noContent;
            }
            else
            {
                serviceResult.data = entity;
                serviceResult.devMsg = "Success";
            }
            return serviceResult;
        }
    }
}
