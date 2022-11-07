using Entity;
using MISA.VMHUNG.Core.Entity;
using MISA.VMHUNG.Core.Interface;
using MISA.VMHUNG.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.VMHUNG.Core.Service
{
    public class BaseBL<T> : IBaseBL<T>
    {
        IBaseDL<T> _baseRepository;
        protected ServiceResult serviceResult;
        public BaseBL(IBaseDL<T> baseRepository)
        {
            this._baseRepository = baseRepository;
            serviceResult = new ServiceResult();
        }
        /// <summary>
        /// Lấy thông tin tất cả khách hàng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// Created by: VM Hùng (02/04/2021)
        public ServiceResult GetAll()
        {
            // Lấy tất cả bản ghi
            serviceResult.isSuccess = true;
            var datas = _baseRepository.GetAll<T>();

            // Kiểm tra số lượng bản ghi trả về
            if (datas.Count() == 0)
            {
                serviceResult.isSuccess = false;
                serviceResult.devMsg = "Không có nội dung";
                serviceResult.userMsg = "Thất bại";
                serviceResult.errorCode = MISAError.noContent;
            }
            else
            {
                serviceResult.data = datas;
                serviceResult.devMsg = "Thành công";
            }

            return serviceResult;
        }
   
        
        public ServiceResult GetById(Guid id)
        {
            serviceResult.isSuccess = true;
            //Lấy dữ dữ liệu

            var entity = _baseRepository.GetById<T>(id);
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
