using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using WebDriverManager.DriverConfigs.Impl;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace TestProject1.Utilities
{
    public class Base
    {
        public IWebDriver driver;
        [SetUp]
            public void StartBrowser()
            {
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Manage().Window.Maximize();
            driver.Url = "http://automationpractice.com";
            }

            public IWebDriver getDriver()
            {
                return driver;  
            }

            public void InitBrowser(string browserName)
            {
                switch (browserName)
                {
                    case "Chrome":
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;

                    case "Firefox":
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;

                    case "Edge":
                        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;
                }
            }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

    }
}
