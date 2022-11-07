using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("organization")]
    public class Organization
    {
        
        public Guid id { get; set; }
        public Guid? parent_id { get; set; }

        public string name { get; set; }
        /// <summary>
        /// 1 Huyện
        /// 2 Xã
        /// </summary>
        public string grade { get; set; }
        public string code { get; set; }

        #region custom
        /// <summary>
        /// status nộp dự toán 
        /// 1 || 4 || null: chưa nộp
        /// 2: chưa kiểm tra
        /// 3: đã hoàn thành
        /// </summary>
        public int? status { get; set; }
        public Guid? submit_estimate_id { get; set; }
        public string categoryType { get; set; }
        #endregion

    }
}
