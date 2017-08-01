using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoE.ERS.Automation.TestSuites;
using System.Configuration;
using System.Reflection;
using System.Collections.Specialized;
using System.IO;
using MoE.ERS.Automation.Utils.Reports;

namespace MoE.ERS.Automation.TestSuites
{
    public class TestSuitesExecutor
    {
        static void Main(string[] args)
        {
            try
            {
                Assembly testAssembly = Assembly
                                             .LoadFrom(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                                             + "\\" + "MoE.ERS.Automation.dll");
                HtmlReporter htmlReporter = HtmlReporter.GetInstance();
                foreach (string key in ConfigurationManager.AppSettings)
                {                                 
                    string[] configValue = ConfigurationManager.AppSettings[key].ToString().Split(':');
                    Type testMethodType = testAssembly.GetTypes()
                                    .Single(type => type.Name== configValue[0]);
                    //Incase of Static class.
                    if (testMethodType.IsAbstract)
                    {
                        if (ConfigurationManager.AppSettings[key].ToString().Split(':')[1].ToUpper().Equals("ALL"))
                        {
                            foreach (MethodInfo methodInfo in testMethodType.GetMethods())
                                methodInfo.Invoke(null, null);
                        }                          
                        else
                          testMethodType.GetMethod(ConfigurationManager.AppSettings[key].ToString().Split(':')[1])
                                                    .Invoke(null, null);                        
                    }
                    else
                    {
                        object testMethodInstance = Activator.CreateInstance(testMethodType);
                        if (ConfigurationManager.AppSettings[key].ToString().Split(':')[1].ToUpper().Equals("ALL"))
                        {
                            foreach (MethodInfo methodInfo in testMethodType.GetMethods())
                                methodInfo.Invoke(testMethodInstance, null);
                        }
                        else
                            testMethodType.GetMethod(ConfigurationManager.AppSettings[key].ToString().Split(':')[1])
                                                    .Invoke(testMethodInstance, null);                                                
                    }                  
                }
                htmlReporter.BuildReport();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message + ex.InnerException.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
