using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Selenuim_Web_Drive_Task.Singletone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenuim_Web_Drive_Task.PageObjectModel
{
    public class HomePage_Singleton
    {
        string testUrl = "http://demo.guru99.com/test/guru99home/";

        //private IWebDriver driver;
        //private WebDriverWait wait;
 
        //private IWebElement emailTextBox => Browser.GetInstance().driver.FindElement(By.CssSelector("input[id=philadelphia-field-email]"));
        //private IWebElement signUpButton => Browser.GetInstance().driver.FindElement(By.XPath(".//*[@id='philadelphia-field-submit']"));
        private IWebElement SAPtitle => Browser.GetInstance().driver.FindElement(By.XPath("//*[@id=\"site-name\"]/a"));

        public void GoToPage()
        {
            Browser.GetInstance().driver.Navigate().GoToUrl(testUrl);
            Browser.GetInstance().driver.Manage().Window.Maximize();
        }

        //public void Signup()
        //{
        //    emailTextBox.Clear();
        //    emailTextBox.SendKeys("test123@gmail.com");
        //    signUpButton.Click();
        //}
        //public void IsSignupSuccessful()
        //{
        //    var expectedAlertText = "Form Submitted Successfully...";
        //    var alert_win = Browser.GetInstance().driver.SwitchTo().Alert();

        //    Assert.AreEqual(expectedAlertText, alert_win.Text);
        //    alert_win.Accept();
        //}

        public void IsTitleExists()
        {
            Assert.AreEqual(SAPtitle.Enabled, true);
        }

        public void Title()
        {
            Assert.AreEqual("Demo Site", SAPtitle.Text);
        }
    }
}
