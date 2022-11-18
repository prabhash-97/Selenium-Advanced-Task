using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenuim_Web_Drive_Task
{
    public class WebDriverFactory
    {
        public IWebDriver CreateInstance(string browser)
        {
            if ("Chrome".ToLower() == browser.ToLower())
            {
                return new ChromeDriver("C:\\Users\\UPRABKA\\Documents\\C# traning\\5 - Selenium Web Driver\\chromedriver_win32\\");
            }
            else if ("InternetExplorer".ToLower() == browser.ToLower())
            {
                return new InternetExplorerDriver();
            }
            else
            {
                return new FirefoxDriver();
            }
        }
    }
}
