using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDL.Entity
{
    [Table("template_setting")]
    public class template_setting
    {
       
        public template_setting()
        {
            Id = Guid.NewGuid();
        }
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid Id { get; set; }
        public string template_code { get; set; }
        public string template_name { get; set; }


        public string organization_code { get; set; }
        public string template_data { get; set; }

        

    }
}
