using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoE.ERS.Automation.TestScripts.Yahoo;

namespace MoE.ERS.Automation.TestSuites.Yahoo
{
    public static class YahooAccountCreateSuite
    {
        private static YahooTestOperations yahooTestOperations;

        static YahooAccountCreateSuite()
        {
            yahooTestOperations = new YahooTestOperations();
        }
       
        public static void ExecuteAccountCreationSuite()
        {
            try
            {
                yahooTestOperations.InputControls();
            }
            catch(Exception)
            { throw; }
        }

        public static void ExecuteTestSuite()
        {
            try
            {
                yahooTestOperations.ValidateResults();
            }
            catch (Exception)
            { throw; }
        }
    }
}
