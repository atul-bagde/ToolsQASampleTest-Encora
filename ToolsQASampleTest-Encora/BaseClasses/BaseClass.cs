using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using ToolsQASampleTest_Encora.Configurations;
using ToolsQASampleTest_Encora.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using ToolsQASampleTest_Encora.CustomException;

namespace ToolsQASampleTest_Encora.BaseClasses
{
    [Binding]
    public sealed class BaseClass
    {
        private static TestContext _testContext;

        public static TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        #region BrowserProfileAndOptions

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            {
                chromeOptions.AcceptInsecureCertificates = false;
                chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
                chromeOptions.AddArgument("--start-maximized");
                chromeOptions.AddArgument("--ignore-certificate-errors");
                chromeOptions.AddArgument("--disable-popup-blocking");
                chromeOptions.AddArgument("--incognito");
            };

            return chromeOptions;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            {
                firefoxOptions.AcceptInsecureCertificates = false;
                firefoxOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
                firefoxOptions.Profile = default;
            };

            return firefoxOptions;
        }

        private static EdgeOptions GetEdgeOptions()
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            {
                edgeOptions.AcceptInsecureCertificates = false;
                edgeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
            };

            return edgeOptions;
        }

        #endregion

        #region DriverActions

        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxDriver driver = new FirefoxDriver(FolderPaths.GetDriverPath(), GetFirefoxOptions());
            return driver;
        }

        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(FolderPaths.GetDriverPath(), GetChromeOptions());
            return driver;
        }

        private static EdgeDriver GetEdgeDriver()
        {
            EdgeDriver driver = new EdgeDriver(FolderPaths.GetDriverPath(), GetEdgeOptions());
            return driver;
        }

        #endregion

        #region Initilization

        [BeforeTestRun]

        public static void InitWebDriver(TestContext testContext)
        {
            _testContext = testContext;

            ObjectRepository.Config = new AppConfigReader();

            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;

                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;

                case BrowserType.Edge:
                    ObjectRepository.Driver = GetEdgeDriver();
                    break;

                default:
                    throw new NoSutiableDriverFound("Driver not found: " + ObjectRepository.Config.GetBrowser().ToString());
            }

            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeout());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
            ObjectRepository.Driver.Manage().Window.Maximize();
        }

        #endregion

        #region cleanup

        [AfterScenario()]
        public static void TestCleanUp()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
            }
        }

        [AfterTestRun()]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Quit();
            }
        }

        #endregion
    }
}
