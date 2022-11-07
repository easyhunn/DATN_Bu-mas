using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SubmitEstimateParam
    {
        public int? Mode { get; set; }
        public AuditEstimateStatus auditEstimateStatus { get; set; }

    }
}
