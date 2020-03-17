using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AlexaDeleteAllMyUtterances
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver;

            ChromeOptions options = new ChromeOptions();
            Console.WriteLine("Insert your windows folders username:");
            string username = Console.ReadLine();
            options.AddArguments("user-data-dir=C:\\Users\\" + username + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default");
            driver = new ChromeDriver(options);
            driver.Url = "https://www.amazon.it/?ref_=nav_signin&";

            Console.WriteLine("Login in the amazon page of browser! (Needed only the first time you run it.) Then press enter.");
            Console.ReadLine();
            while (true)
            {
                try
                {

                    OpenAmazonAlexaWebPage(driver);
                    Thread.Sleep(4000);
                    OpenPopupClick(driver);
                    Thread.Sleep(3000);
                    ClickYes(driver);
                    Thread.Sleep(6000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reached this exception: " + e.ToString());
                }
            }
        }

        private static void OpenAmazonAlexaWebPage(IWebDriver driver)
        {
            driver.Url = "https://www.amazon.it/hz/mycd/myx#/home/alexaPrivacy/activityHistory&custom&1584399600000&1584437565624";
            driver.Navigate().Refresh();
        }

        private static void OpenPopupClick(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("deleteAllRecordingsString"));
            element.Click();
        }

        private static void ClickYes(IWebDriver driver)
        {
            IWebElement element = driver.FindElements(By.XPath("//Input[@class='a-button-input']"))[1];
            element.Click();
            element.Click();
        }
    }
}
