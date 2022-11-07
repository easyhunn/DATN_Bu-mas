using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("summary_template_workbook")]
    public class SummaryTemplateWorkbook
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid id { get; set; }
        public Guid? org_id { get; set; }
        public string template_name { get; set; }
        public string template_json { get; set; }
        public string template_code { get; set; }
        public int header_level { get; set; }
        public int row_count { get; set; }
        /// <summary>
        /// id xác định mẫu nào (cấp dưới cùng mẫu)
        /// </summary>
        public int template_id { get; set; }
    }
}
