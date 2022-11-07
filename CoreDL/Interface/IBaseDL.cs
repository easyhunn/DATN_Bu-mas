using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.VMHUNG.Infrastructure.DataAccess
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// lấy tất cả bản ghi
        /// </summary>
        /// <returns>
        /// Danh sách thông tin tất cả bảng ghi
        /// </returns>
        /// Created By: VM Hùng (12/04/2021)
        public IEnumerable<entity> GetAll<entity>(string table = "");
        public IEnumerable<entity> GetById<entity>(Guid id, string table = "");
        /// <summary>
        /// Lấy thông tin bản ghi theo Id
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns>
        /// Bản ghi được lấy về
        /// Null trong trương hợp k tìm thấy bản ghi nào
        /// </returns>
        /// Created By: VM Hùng (12/04/2021)
        //T GetById(Guid id);
        /// <summary>
        /// Thêm nhiều
        /// </summary>
        /// <returns></returns>
        public Task<bool> Inserts<entity>(List<entity> entities);
        /// <summary>
        ///  update multiple
        /// </summary>
        /// <returns></returns>
        public Task<bool> Updates<entity>(List<entity> entities);
        /// <summary>
        /// delete multiple
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool Deletes<entity>(List<entity> entities);

    }
}
