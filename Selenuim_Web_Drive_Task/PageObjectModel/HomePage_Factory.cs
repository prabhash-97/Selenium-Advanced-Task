using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

using OpenQA.Selenium.Interactions;

namespace Selenuim_Web_Drive_Task.PageObjects 
{
    public class HomePage_Factory 
    {
        string testUrl = "http://demo.guru99.com/test/guru99home/";

        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage_Factory(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            PageFactory.InitElements(driver, this);
        }

        private IWebElement emailTextBox => driver.FindElement(By.XPath("//*[@id=\"philadelphia-field-email\"]"));
        //*[@id="philadelphia-field-email"]
        private IWebElement signUpButton => driver.FindElement(By.XPath(".//*[@id='philadelphia-field-submit']"));
        private IWebElement sapTitle => driver.FindElement(By.XPath("//*[@id=\"site-name\"]/a"));
        private IWebElement course => driver.FindElement(By.XPath(".//*[@id='awf_field-91977689']"));
        private IWebElement From => driver.FindElement(By.XPath("//*[@id=\"credit2\"]/a"));
        private IWebElement To => driver.FindElement(By.XPath("//*[@id=\"bank\"]/li"));
        private IWebElement link_Home => driver.FindElement(By.LinkText("Home"));
        private IWebElement button => driver.FindElement(By.Name("btnLogin"));
        private IWebElement td_Home => driver.FindElement(By
                .XPath("//html/body/div"
                + "/table/tbody/tr/td"
                + "/table/tbody/tr/td"
                + "/table/tbody/tr/td"
                + "/table/tbody/tr"));
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(testUrl);
            driver.Manage().Window.Maximize();
        }

        public void Signup()
        {
            emailTextBox.Clear();
            emailTextBox.SendKeys("test123@gmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            signUpButton.Click();
        }

        public void IsSignupSuccessful()
        {
            var expectedAlertText = "Form Submitted Successfully...";
            var alert_win = driver.SwitchTo().Alert();

            Assert.AreEqual(expectedAlertText, alert_win.Text);
            alert_win.Accept();
        }

        public void IsTitleExists()
        {
            Assert.AreEqual(sapTitle.Enabled, true);
        }

        public void Title()
        {
            Assert.AreEqual("Demo Site", sapTitle.Text);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        public void Select()
        {
            var selectTest = new SelectElement(course);
            selectTest.SelectByValue("sap-abap");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public void DragAndDrop()
        {
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/drag_drop.html");
           		
            Actions act = new Actions(driver);
            act.DragAndDrop(From, To).Build().Perform();
           
        }
   
        public void CheckBGcolor()
        {

            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/");

            Actions builder = new Actions(driver);
            builder.MoveToElement(link_Home).Build();

            string bgColor = td_Home.GetCssValue("background-color");
            Console.WriteLine("Before hover: " + bgColor);
            builder.Perform();
            bgColor = td_Home.GetCssValue("background-color");
            Console.WriteLine("After hover: " + bgColor);
           
        }


        public void JavaScriptExcutorLogin()
        {	
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
	
            driver.Navigate().GoToUrl("http://demo.guru99.com/V4/");
           
 		
            driver.FindElement(By.Name("uid")).SendKeys("mngr34926");
            driver.FindElement(By.Name("password")).SendKeys("amUpenu");
		
            js.ExecuteScript("arguments[0].click();", button);

        }

        public void JavaScriptExcutorCaptureScrapeData()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl("http://demo.guru99.com/V4/");
	
            string DomainName = js.ExecuteScript("return document.domain;").ToString();
            Console.WriteLine("Domain name of the site = " + DomainName);
            
            string url = js.ExecuteScript("return document.URL;").ToString();
            Console.WriteLine("URL of the site = " + url);
            
            string TitleName = js.ExecuteScript("return document.title;").ToString();
            Console.WriteLine("Title of the page = " + TitleName);
	
            js.ExecuteScript("window.location = 'http://demo.guru99.com/'");

        }


    }
}
