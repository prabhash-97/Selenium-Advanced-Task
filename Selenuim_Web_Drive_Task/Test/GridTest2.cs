using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace Selenuim_Web_Drive_Task.Test
{
    public class GridTest2
    {
        
        IWebDriver driver;
        string hubUrl;

        [SetUp]
        public void StartBrowser()
        {
            hubUrl = "http://192.168.1.103:4444/wd/hub";
            TimeSpan timeSpan = new TimeSpan(10, 33, 10);
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            driver = new RemoteWebDriver(
                            new Uri(hubUrl),
                            firefoxOptions.ToCapabilities(),
                            timeSpan
                            );
        }

        [Test]
        public void OpenGoogleAndSearch()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Name("user-name")).SendKeys("TestUser");
            driver.FindElement(By.Name("password")).SendKeys("testpassword");
            driver.FindElement(By.Name("login-button")).Click();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }
    }
}
