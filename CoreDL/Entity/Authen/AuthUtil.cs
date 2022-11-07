using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AuthUtil
    {
        //public User user { get; set; }
        public static string userName { get; set; }
        public static Guid? orgId { get; set; }
        /// <summary>
        /// 1 huyện
        /// 2 xã
        /// </summary>
        public static int? orgGrade { get; set; }

        public static Guid? parentOrgId { get; set; }

        public static Guid userId { get; set; }
    }
}
