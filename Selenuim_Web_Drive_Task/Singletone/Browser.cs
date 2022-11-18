using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenuim_Web_Drive_Task.Singletone
{
    public class Browser
    {
        public IWebDriver driver;

        private Browser(IWebDriver driver)
        {
            this.driver = driver;
        }

        private static Browser instance;

        public static Browser GetInstance()
        {
            if(instance == null)
            {
                instance = new Browser(new ChromeDriver("C:\\Users\\UPRABKA\\Documents\\C# traning\\5 - Selenium Web Driver\\chromedriver_win32\\"));
            }
            return instance;
        }
    }
}
