using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Threading;
using System.Drawing;
using Selenuim_Web_Drive_Task.PageObjects;

namespace Selenuim_Web_Drive_Task.Test
{
    public class GridTest1
    {
        IWebDriver driver;
        string hubUrl;

        [SetUp]
        public void StartBrowser()
        {
            hubUrl = "http://192.168.1.103:4444/wd/hub";
            TimeSpan timeSpan = new TimeSpan(0, 33, 0);
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new RemoteWebDriver(
                            new Uri(hubUrl),
                            chromeOptions.ToCapabilities(),
                            timeSpan
                            );
        }

        [Test]
        public void OpenDemoSite()
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
