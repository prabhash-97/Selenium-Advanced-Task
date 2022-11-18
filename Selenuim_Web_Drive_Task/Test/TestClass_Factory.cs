using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Selenuim_Web_Drive_Task.PageObjects;
using System;
using Selenuim_Web_Drive_Task.PageObjectModel;
using Selenuim_Web_Drive_Task.Factory;

namespace Selenuim_Web_Drive_Task
{
    public class TestClass_Factory
    {
        IWebDriver webDriver;

        [SetUp]
        public void startBrowser()
        {
            WebDriverFactory factory = new WebDriverFactory();
            webDriver = factory.CreateInstance("Chrome");
            HomePage_Factory home_page = new HomePage_Factory(webDriver);
            home_page.GoToPage();
        }

        [Test]
        public void Test_Factory1()
        {
            //Home weebDriver;
            //BrowserProcess factory = new BrowserProcess();
            //weebDriver = factory.Create("UI");
            ////home weeb...
            //weebDriver.Title();
            //weebDriver.IsTitleExists();


            HomePage_Factory home_page = new HomePage_Factory(webDriver);
            //act
            home_page.Signup();
            //assert
            home_page.IsSignupSuccessful();
        }

        [Test]
        public void Test_Factory2()
        {
            HomePage_Factory home_page = new HomePage_Factory(webDriver);
            //act
            home_page.Title();
            //assert
            home_page.IsTitleExists();
        }

        [Test]
        public void Test_Factory3()
        {
            HomePage_Factory home_page = new HomePage_Factory(webDriver);
            home_page.Select();
        }

        [Test]
        public void Test_Factory4()
        {
            HomePage_Factory home_page = new HomePage_Factory(webDriver);
            home_page.DragAndDrop();
        }

        [Test]
        public void Test_Factory5()
        {
            HomePage_Factory home_page = new HomePage_Factory(webDriver);
            home_page.CheckBGcolor();
        }

        [Test]
        public void Test_Factory6()
        {
            HomePage_Factory home_page = new HomePage_Factory(webDriver);
            home_page.JavaScriptExcutorLogin();
        }
        [Test]
        public void Test_Factory7()
        {
            HomePage_Factory home_page = new HomePage_Factory(webDriver);
            home_page.JavaScriptExcutorCaptureScrapeData();
        }

        [TearDown]
        public void closeBrowser()
        {
            webDriver.Quit(); 
        }

    }
}
