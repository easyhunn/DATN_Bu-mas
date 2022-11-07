
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("audit_estimate_status")]
    public class AuditEstimateStatus
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid id { get; set; }
        public Guid? org_sent_id { get; set; }
        public Guid? org_receive_id { get; set; }
        /// <summary>
        /// Trạng thái: 1 chưa nộp 2 chờ duyệt 3 hoàn thành 4 gửi trả 
        /// </summary>
        public int status { get; set; } 
        public Guid? submit_estimate_list_id { get; set; }
        public string date { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public int? sortOrder { get; set; }
    }
}
