using Competition_Mars.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition_Mars.Utilities
{
    
    public class CommonDriver
    {
        public static IWebDriver driver;
        Login loginPageObj;
        ShareSkill ShareSkillObj;

        [SetUp]
        public void LoginActions()
        {
            driver = new ChromeDriver();
            loginPageObj = new Login(driver);

            ShareSkillObj = new ShareSkill(driver);
            //driver.Manage().Window.Maximize();
            loginPageObj.LoginSteps();
            ShareSkillObj.WelcomeMessageCheck();
           // profile.welcomeMessage();
        }

        public static string excelpath = @"E:\Testing\CompetitionTask\Mars_Competition\Mars_Competition\input\Mars Profile page Test Conditions and Test cases.xlsx";
        //E:\Testing\CompetitionTask\Mars_Competition\Mars_Competition\input\Mars Profile page Test Conditions and Test cases.xlsx

        [OneTimeTearDown]
        public void CloseTestRun()
        {
            Thread.Sleep(2000);
            driver.Close();
        }
    }
}
