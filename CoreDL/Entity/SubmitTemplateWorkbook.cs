using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("submit_template_workbook")]
    public class SubmitTemplateWorkbook
    {
        public Guid id { get; set; }
        public Guid org_sent_id { get; set; }
        public Guid? org_receive_id { get; set; }
        public Guid? template_id { get; set; }
        /// <summary>
        /// 1: Đã nộp - chờ duyện
        /// 2: đã hoàn thành
        /// 3: gửi trả
        /// 4: chưa nộp
        /// </summary>
        public int status { get; set; }
    }
}
