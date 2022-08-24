using Competition_Mars.Utilities;
using Mars_Competition.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mars_Competition.Utilities.GlobalDefinitions;

namespace Competition_Mars.Pages
{
    internal class Login : CommonDriver
    {
        public Login(IWebDriver _driver)
        {
            _driver = driver;
        
        }
        private IWebElement SigninTab => driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
        private IWebElement userName => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        private IWebElement Password => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        private IWebElement SigninButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
        public void LoginSteps()
        {

            //maximise the browser window
            driver.Manage().Window.Maximize();
            GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.Excelpath, "SignIn");

            //navigate to the portal 
            driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
          
            try
            {
                //find and click on  sign in button
                SigninTab.Click();
                //enter valid email ID for the email address
                userName.SendKeys(ExcelLib.ReadData(2, "UserName"));
                //enter valid Password for the email address
                Password.SendKeys(ExcelLib.ReadData(2, "Password"));
                //click on Login button
                SigninButton.Click();
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
