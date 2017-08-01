using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoE.ERS.Automation.Entities
{
    public static class TestDataConstants
    {
        //LogIn page constants.
        public const string PASSWORD = "1manual#4%";

        public static string[] USERNAMES
        {
            get { return new string[] { "1auto@3$#", "1frer14@3" }; }
        }
    }
}
