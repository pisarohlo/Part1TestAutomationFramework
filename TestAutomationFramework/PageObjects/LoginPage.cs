using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace TestAutomationFramework.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        // Constructor to initialize the WebDriver
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Web elements on the login page
        private IWebElement UsernameField => _driver.FindElement(By.Id("username"));
        private IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("submit"));
        private IWebElement PageNotification => _driver.FindElement(By.Id("notification"));

        // Methods to interact with the page

        public void EnterUsername(string username)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public string GetPageNotification()
        {
            return PageNotification.Text;
        }

        public void LoginToTheApplication(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        public void VerifyPageNotification(string notificationText)
        {
            ClassicAssert.AreEqual(notificationText, GetPageNotification());
        }
    }
}
