using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace Selenuim_Web_Drive_Task.Test
{
    public class SauceDemoTest
    {
        public IWebDriver Driver { get; set; }

        public TestContext TestContext { get; set; }

        [SetUp]
        public void Setup()
        {
            var browserOptions = new ChromeOptions();
            browserOptions.PlatformName = "Windows 10";
            browserOptions.BrowserVersion = "latest";

            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("name", TestContext.CurrentContext.Test.Name);
            sauceOptions.Add("username", Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
            sauceOptions.Add("accessKey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));

            browserOptions.AddAdditionalOption("sauce:options", sauceOptions);
            var sauceUrl = new Uri("https://ondemand.us-west-1.saucelabs.com/wd/hub");

            Driver = new RemoteWebDriver(sauceUrl, browserOptions);
        }

        [Test]
        public void LoginTest()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com");

            var usernameLocator = By.CssSelector("#user-name");
            var passwordLocator = By.CssSelector("#password");
            var submitLocator = By.CssSelector(".btn_action");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(drv => drv.FindElement(usernameLocator));

            var usernameElement = Driver.FindElement(usernameLocator);
            var passwordElement = Driver.FindElement(passwordLocator);
            var submitElement = Driver.FindElement(submitLocator);

            usernameElement.SendKeys("standard_user");
            passwordElement.SendKeys("secret_sauce");
            submitElement.Click();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", Driver.Url);
        }

        [TearDown]
        public void Teardown()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            Driver.Quit();
        }
    }
}
