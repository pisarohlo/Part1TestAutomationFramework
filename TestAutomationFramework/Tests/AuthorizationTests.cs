using NUnit.Framework;
using OpenQA.Selenium;
using TestAutomationFramework.Configuration;
using TestAutomationFramework.PageObjects;
using TestAutomationFramework.Reporting;

namespace TestAutomationFramework.Tests
{
    public class AuthorizationTests
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private static string ApplicationUrl = ConfigurationLoader.Settings.ApplicationUrl;
        private static List<UserCredentials> Users = ConfigurationLoader.Settings.Users;
        private readonly HtmlReport _report;
        public string GetTestCaseId() => TestContext.CurrentContext.Test.Properties.Get("TestId") as string;


        public AuthorizationTests()
        {
            _driver = new DriverSetup().Initialize(); // Start the browser
            _driver.Navigate().GoToUrl(ApplicationUrl + "/login"); // Navigate to the application login page
            _loginPage = new LoginPage(_driver); // Initialize the LoginPage object
            _report = new HtmlReport(Environment.CurrentDirectory + "\\TestReport.html"); // Initialize report
        }

        [Test]
        [Property("TestId", "001")]
        public void TestValidLogin()
        {
            try
            {
                var testUser = Users.FirstOrDefault(x => x.Username == "validUser");
                _loginPage.LoginToTheApplication(testUser.Username, testUser.Password);
                _loginPage.VerifyPageNotification("You are successfully logged in!");
                _report.LogTestResult(GetTestCaseId(), nameof(TestValidLogin), "Passed", "Valid login succeeded.");
            }

            catch (Exception ex)
            {
                _report.LogTestResult(GetTestCaseId(), nameof(TestValidLogin), "Failed", ex.Message);
                throw; // Rethrow the exception to ensure the test fails
            }
        }

        [Test]
        [Property("TestId", "002")]
        public void TestLoginWithInvalidUsername()
        {
            try
            {
                var testUserInvalidCreds = Users.FirstOrDefault(x => x.Username == "invalidUser");
                _loginPage.LoginToTheApplication(testUserInvalidCreds.Username, testUserInvalidCreds.Password);
                _loginPage.VerifyPageNotification("Your username or password is invalid!");
                _report.LogTestResult(GetTestCaseId(), nameof(TestLoginWithInvalidUsername), "Passed", "Login with invalid credentials is failed.");
            }
            catch (Exception ex)
            {
                _report.LogTestResult(GetTestCaseId(), nameof(TestLoginWithInvalidUsername), "Failed", ex.Message);
                throw;
            }
        }
    }
}
