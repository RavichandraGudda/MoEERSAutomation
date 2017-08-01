using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoE.ERS.Automation.Utils.Reports
{
    public static class HtmlHelper
    {
        private static StreamWriter testReport;
        private static string rootDirectory = string.Empty;
        private static string reportDirectory = string.Empty;
        private static string reportFileName = string.Empty;    
        private const string REPORT_NAME = "Sample Report";

        static HtmlHelper()
        {
            testReport = new System.IO.StreamWriter(reportDirectory + reportFileName + ".html", false);
            rootDirectory = Directory.GetCurrentDirectory()
                            .Substring(0, Directory.GetCurrentDirectory().LastIndexOf("MoE.ERS.Automation", StringComparison.Ordinal));
            reportDirectory = string.Format("{0}{1}", rootDirectory, "MoE.ERS.Automation.Utils\\TestReports\\");
            string fileName = DateTime.Now.ToString();
            reportFileName = fileName.Replace("/", "_").Replace(":", "_").Replace(" ", "_");
        }        
        public static void BuildTable(List<TestResult> testResultList)
        {
            using (testReport = new System.IO.StreamWriter(reportDirectory + reportFileName + ".html", true))
            {
                //Adding report name and table headers for the TestResult.
                testReport.WriteLine("<h4>" + REPORT_NAME + "</h4>");
                testReport.WriteLine("<table  cellspacing= \"0\" cellpadding=\"4\" border=\"1\" bordercolor=\"#224466\" width=\"100%\">");
                testReport.WriteLine("<tr bgcolor = \"C0C0C0\">");
                testReport.WriteLine("<th>TestMethodName</th>");
                testReport.WriteLine("<th>Actual</th>");
                testReport.WriteLine("<th>Expected</th>");
                testReport.WriteLine("<th>TestStatus</th>");
                testReport.WriteLine("<th>StartTime</th>");
                testReport.WriteLine("<th>EndTime</th>");
                testReport.WriteLine("</tr>");               

                //Adding test result 
                foreach (TestResult testResult in testResultList)
                {
                    testReport.WriteLine("<tr>");
                    testReport.WriteLine("<td>" + testResult.TestMethodName + "</td>");
                    testReport.WriteLine("<td>" + testResult.Actual + "</td>");
                    testReport.WriteLine("<td>" + testResult.Expected + "</td>");
                    if (testResult.TestStatus.ToString() == TestStatus.Pass.ToString())
                        testReport.WriteLine("<td bgcolor=\"#00FF00\">" + testResult.TestStatus.ToString() + "</td>");
                    else
                        testReport.WriteLine("<td bgcolor=\"#FF0000\"><a href=\"../ErrorScreenshots/" + testResult.ScreenShotName + "\" target=\"_blank\">" + testResult.TestStatus.ToString() + "</a></td>");
                    testReport.WriteLine("<td>" + testResult.StartTime + "</td>");
                    testReport.WriteLine("<td>" + testResult.EndTime + "</td>");
                    testReport.WriteLine("</tr>");
                }
                testReport.WriteLine("</table>");
                testReport.Close();
            }
        }


    }
}
