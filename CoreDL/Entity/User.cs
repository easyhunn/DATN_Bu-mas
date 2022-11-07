using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("user")]
    public class User
    {
        public Guid id { get; set; }
        public Guid? org_id { get; set; }
        public Guid? parent_org_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public int org_grade { get; set; }

    }
}
