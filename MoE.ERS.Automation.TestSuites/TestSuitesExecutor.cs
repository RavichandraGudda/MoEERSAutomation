using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoE.ERS.Automation.TestSuites.YahooSuites;
using System.Configuration;
using System.Reflection;
using System.Collections.Specialized;

namespace MoE.ERS.Automation.TestSuites
{
    public class TestSuitesExecutor
    {
        static void Main(string[] args)
        {
            try
            {
                NameValueCollection testSuiteCollection =
                     (NameValueCollection)ConfigurationManager.GetSection("appSettings");

                foreach (string key in testSuiteCollection)
                {
                    Assembly.GetExecutingAssembly().GetTypes()
                         .Single(type => type.IsClass && type.Name == key)
                         .GetMethod(ConfigurationManager.AppSettings[key].ToString()).Invoke(null, null);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message + ex.InnerException.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
