namespace TestAutomationFramework.Reporting
{
    public class HtmlReport
    {
        private string _reportFilePath;

        public HtmlReport(string reportFilePath)
        {
            _reportFilePath = reportFilePath;
            File.WriteAllText(_reportFilePath, "<html><body><h1>Test Report</h1><table border='1'><tr><th>Test Name</th><th>Status</th><th>Message</th></tr>");
        }

        public void LogTestResult(string testId, string testName, string status, string message)
        {
            var row = $"<tr><td>{testId}</td><td>{testName}</td><td>{status}</td><td>{message}</td></tr>";
            File.AppendAllText(_reportFilePath, row);
        }

        public void CloseReport()
        {
            File.AppendAllText(_reportFilePath, "</table></body></html>");
        }
    }
}
