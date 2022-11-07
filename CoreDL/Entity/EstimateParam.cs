using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{

    public class EstimateParam
    {
        public List<Estimate> lstUpdate { get; set; }
        public List<Estimate> lstInsert { get; set; }


    }
}
