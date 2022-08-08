using Competition_Mars.Pages;
using Competition_Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using SeleniumExtras.PageObjects;
using System;


namespace Competition_Mars // Note: actual namespace depends on the project name.
{
    [TestFixture]
    public class ShareSkillTest: CommonDriver
    {

        ShareSkill ShareSkillObj;
        
        // Login loginPageObj;
        //Education EducationObj;
        // Education profile = new Education();
        //[SetUp]
        //    public void LoginActions()
        //    {
        //        driver = new ChromeDriver();

        //        //driver.Manage().Window.Maximize();
        //        loginPageObj.LoginSteps(driver);
        //        //profile.welcomeMessage(driver);

        //    }
        [Test]
        public void AddSkillShare()
        {
            Thread.Sleep(2000);
            ShareSkillObj = new ShareSkill(driver);
            //ShareSkillObj.WelcomeMessageCheck();
            //PageFactory.InitElements(driver, ShareSkillObj);
            // shareskillobj.WelcomeMessageCheck();
            ShareSkillObj.NavigateToShareSkill();
            ShareSkillObj.AddSkillShare();

           // EducationObj = new Education(driver);
            //loginPageObj = new Login(driver);
            
            //EducationObj.NavigateEducation();
            //EducationObj.AddEducation();

        }
        //[Test, Order(2)]
        //public void EditEducation()
        //{
        //    //Education EducationObj = new Education();
        //    EducationObj.NavigateEducation(driver);
        //    EducationObj.EditEducation(driver, " ", " ");

        //}
        //[Test, Order(3)]
        //public void DeleteEducation()
        //{
        //    //  Education EducationObj = new Education();
        //    EducationObj.NavigateEducation(driver);
        //    EducationObj.DeleteEducation(driver);

            
        //}
    }
}

