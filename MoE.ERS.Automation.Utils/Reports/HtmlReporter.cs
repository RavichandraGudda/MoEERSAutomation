using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace MoE.ERS.Automation.Utils.Reports
{
    public sealed class HtmlReporter
    {
        private static HtmlReporter instance = null;
        private static List<TestResult> testResultList;        
        private int stepNumber = 0;      

        private HtmlReporter()
        {
            testResultList = new List<TestResult>();
        }
        public static HtmlReporter GetInstance()
        {
            if (instance == null)
                instance = new HtmlReporter();
            return instance;
        }
        public void AddResultToReport(params string[] testResultColumns)
        {
            testResultList.Add(new TestResult()
            {
                TestMethodName = testResultColumns[0],
                Actual = testResultColumns[1],
                Expected = testResultColumns[2],
                TestStatus = testResultColumns[3].ToUpper().Equals("PASS") ? TestStatus.Pass : TestStatus.Fail,
                ScreenShotName = testResultColumns[4],
                StartTime = testResultColumns[5],
                EndTime = testResultColumns[6]
            });          
            stepNumber++;
        } 
        public void BuildReport()
        {
            HtmlHelper.BuildTable(testResultList);
        }
    }
}
