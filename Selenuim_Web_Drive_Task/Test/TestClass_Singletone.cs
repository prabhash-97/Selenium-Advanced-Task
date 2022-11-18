using NUnit.Framework;
using OpenQA.Selenium;
using Selenuim_Web_Drive_Task.PageObjectModel;
using Selenuim_Web_Drive_Task.PageObjects;
using Selenuim_Web_Drive_Task.Singletone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenuim_Web_Drive_Task.Test
{
    public class TestClass_Singletone
    {
        //IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            HomePage_Singleton home_page = new HomePage_Singleton();
            home_page.GoToPage();
        }

        [Test]
        public void Test_Singleton()
        {
            HomePage_Singleton home_page = new HomePage_Singleton();
            //act
            home_page.Title();
            //assert
            home_page.IsTitleExists();
        }

        [TearDown]
        public void closeBrowser()
        {
            Browser.GetInstance().driver.Quit();
        }
    }
}
