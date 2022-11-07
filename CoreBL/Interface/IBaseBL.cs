using MISA.VMHUNG.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.VMHUNG.Core.Interface
{
    public interface IBaseBL <T>
    {
        /// <summary>
        /// lấy tất cả bản ghi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// Created By: VM Hùng (12/04/2021)
        ServiceResult GetAll();
        /// <summary>
        /// lấy danh sách đơn vị trực thuộc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// Created By: VM Hùng (12/04/2021)
        //ServiceResult GetSubOrg();
        /// <summary>
        /// lấy khách hàng theo ID
        /// </summary>
        /// <typeparam name="ServiceResult"></typeparam>
        /// <returns></returns>
        /// Created By: VM Hùng (12/04/2021)
        ServiceResult GetById(Guid entityId);
    }
}
