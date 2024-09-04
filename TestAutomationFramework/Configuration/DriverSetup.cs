using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace TestAutomationFramework.Configuration
{
    [Binding]
    public class DriverSetup
    {
        private IWebDriver _driver;
        private static string _browser;

        public static void SetEnvironment()
        {
            var settings = ConfigurationLoader.Settings;
            _browser = settings.Browser;
        }

        public IWebDriver Initialize()
        {
            var webDriverServerPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            switch (_browser)
            {
                case "chrome":
                    _driver = new ChromeDriver(webDriverServerPath);
                    _driver.Manage().Window.Maximize();
                    return _driver;
                case "firefox":
                    _driver = new FirefoxDriver(webDriverServerPath);
                    _driver.Manage().Window.Maximize();
                    return _driver;
                case "edge":
                    _driver = new EdgeDriver(webDriverServerPath);
                    _driver.Manage().Window.Maximize();
                    return _driver;
                default:
                    _driver = new ChromeDriver(webDriverServerPath);
                    _driver.Manage().Window.Maximize();
                    return _driver;
            }
        }

        [AfterScenario]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
