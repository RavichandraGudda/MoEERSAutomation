using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoE.ERS.Automation.Utils.Reports
{
    public class TestResult
    {
        public string TestMethodName { get; set; }
        public string Actual { get; set; }
        public string Expected { get; set; }
        public TestStatus TestStatus { get; set; }
        public string ScreenShotName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
