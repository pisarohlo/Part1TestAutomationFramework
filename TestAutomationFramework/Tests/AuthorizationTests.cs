using NUnit.Framework;
using NUnit.Framework.Legacy;
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
                var testUser = Users.Find(x => x.Username == "practice");
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
                var testUserInvalidCreds = Users.Find(x => x.Username == "practice1");
                _loginPage.LoginToTheApplication(testUserInvalidCreds.Username, testUserInvalidCreds.Password);
                _loginPage.VerifyPageNotification("Your username is invalid!");
                _report.LogTestResult(GetTestCaseId(), nameof(TestLoginWithInvalidUsername), "Passed", "Valid login succeeded.");
            }
            catch (Exception ex)
            {
                _report.LogTestResult(GetTestCaseId(), nameof(TestLoginWithInvalidUsername), "Failed", ex.Message);
                throw; // Rethrow the exception to ensure the test fails
            }

        }

        [Test]
        [Property("TestId", "003")]
        public void TestLoginWithInvalidPassword()
        {
            try
            {
                var testUserInvalidCreds = Users.Find(x => x.Password == "InvalidPass");
                _loginPage.LoginToTheApplication(testUserInvalidCreds.Username, testUserInvalidCreds.Password);
                ClassicAssert.AreEqual("Your password is invalid!", _loginPage.GetPageNotification());
                _report.LogTestResult(GetTestCaseId(), nameof(TestLoginWithInvalidPassword), "Passed", "Valid login succeeded.");
            }
            catch (Exception ex)
            {
                _report.LogTestResult(GetTestCaseId(), nameof(TestLoginWithInvalidPassword), "Failed", ex.Message);
                throw; // Rethrow the exception to ensure the test fails
            }
        }
    }
}
