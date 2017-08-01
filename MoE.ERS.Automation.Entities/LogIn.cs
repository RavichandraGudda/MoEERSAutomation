using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoE.ERS.Automation.Entities
{
    public class LogIn :EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public int LoginID { get; set; }
    }
}
