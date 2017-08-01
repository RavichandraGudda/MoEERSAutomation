using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.IO;
using System.Reflection;

namespace MoE.ERS.Automation.BaseLibrary
{
    public class DriverFactory
    {
        public static IWebDriver Create(string browserType)
        {
            switch (browserType)
            {
                case "chrome":
                           return  new ChromeDriver(@".\");
                case "FireFox":
                           return  new FirefoxDriver();
                case "IE":                                               
                    return new InternetExplorerDriver(@".\",(InternetExplorerOptions)GetDriverOptions());
                default:
                    return new InternetExplorerDriver();
            }

        }

        public static DriverOptions GetDriverOptions()
        {
            var options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.IgnoreZoomLevel = true;
            return options;
        }
    }
}
