using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("City")]
    public class City
    {
        public City(string name="", string province="", Guid? id = null)
        {
            if (id != null)
            {
                Id = id.Value;
            } else
            {
                Id = Guid.NewGuid();
            }
            Name = name;
            Province = province;
        }
        public City()
        {

        }
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
    }
}
