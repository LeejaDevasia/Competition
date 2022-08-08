using Competition_Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition_Mars.Pages
{
    internal class Login : CommonDriver
    {
        public Login(IWebDriver _driver)
        {
            _driver = driver;
        
        }
        public void LoginSteps()
        {

            //maximise the browser window
            driver.Manage().Window.Maximize();
            //navigate to the portal 
            driver.Navigate().GoToUrl("http://localhost:5000/");
            try
            {
                //find and click on  sign in button
                driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();
                //enter valid email ID for the email address
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input")).SendKeys("amal@gmail.com");
                //enter valid Password for the email address
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input")).SendKeys("amal@here");
                //click on Login button
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();
                Thread.Sleep(2000);


            }

            catch (Exception ex)
            {
                Assert.Fail("TurnUp portal page did not launch.", ex.Message);
                //Console.WriteLine("TurnUp portal page did not launch.", ex.Message);
            }

        }
    }
}
