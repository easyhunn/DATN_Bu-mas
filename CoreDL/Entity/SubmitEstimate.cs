using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("submit_estimate")]
    public class SubmitEstimate
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid id { get; set; }
        public Guid? org_sent_id { get; set; }
        public Guid? org_receive_id { get; set; }
        public string code { get; set; }

        public string name { get; set; }
        public decimal? amount { get; set; }
        public decimal? dictrict_amount { get; set; }
        public decimal? ward_amount { get; set; }
        public Guid? submit_estimate_list_id { get; set; }

    }
}
