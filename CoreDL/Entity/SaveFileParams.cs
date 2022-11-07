using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDL.Entity
{
    public class SaveFileParams: template_setting
    {
        public string FilePath { get; set; }
        public string JsonData { get; set; }
        /// <summary>
        /// 1 insert
        /// 2: update
        /// </summary>
        public int mode { get; set; }

    }
}
