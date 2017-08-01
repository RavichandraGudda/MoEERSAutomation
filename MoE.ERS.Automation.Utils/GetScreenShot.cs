using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.IO;

namespace MoE.ERS.Automation.Utils
{
    public class GetScreenShot
    {
        private static string rootDirectory = string.Empty;
        private static string errorScreenshotsDirectory = string.Empty;

        static GetScreenShot()
        {
            rootDirectory = Directory.GetCurrentDirectory()
                            .Substring(0, Directory.GetCurrentDirectory().LastIndexOf("MoE.ERS.Automation", StringComparison.Ordinal));
            errorScreenshotsDirectory = string.Format("{0}{1}", rootDirectory, "MoE.ERS.Automation.Utils\\ErrorScreenshots\\");
            
        }
        public static void Capture(IWebDriver webDriver, string screenShotName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)webDriver;

            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalPath = errorScreenshotsDirectory + screenShotName + ".png";
            string localPath = new Uri(finalPath).LocalPath;

            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);            
        }
    }
}
