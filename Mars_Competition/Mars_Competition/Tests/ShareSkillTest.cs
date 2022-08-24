using AventStack.ExtentReports.Reporter;
using Competition_Mars.Pages;
using Competition_Mars.Utilities;
using Mars_Competition.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using SeleniumExtras.PageObjects;
using System;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(2)]
namespace Competition_Mars // Note: actual namespace depends on the project name.
{
    [TestFixture]
    [Parallelizable]
    public class ShareSkillTest : CommonDriver
    {

        ShareSkill ShareSkillObj;
        ManageListing ManageListingObj;
        
        [Test, Order(1)]
        public void AddSkillShare()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Thread.Sleep(2000);
            ShareSkillObj = new ShareSkill(driver);
            ShareSkillObj.NavigateToShareSkill();
            ShareSkillObj.AddSkillShare();

            //Assertion objects
            string ExcelAddTitle = ShareSkillObj.TitleAddedExcel().ToString();
            string ExecelAddDescription = ShareSkillObj.DescriptionAddedExcel().ToString();
            string AddTitle = ShareSkillObj.TitleAdded().ToString();
            string AddDescription = ShareSkillObj.DescriptionAdded().ToString();
            Assert.That(ExcelAddTitle == AddTitle, "Title Addded Does not match with the existing");
            Assert.That(ExecelAddDescription == AddDescription, "Description Addded Does not match with the existing");

        }
        [Test, Order(2)]
        public void ViewSkill()
        {

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Thread.Sleep(2000);
            ManageListingObj = new ManageListing(driver);
            ManageListingObj.NavigateManageListing();

            string EditedTitle = ManageListingObj.TitleEdited().ToString();
            string EditedDescription = ManageListingObj.DescriptionEdited().ToString();

            ManageListingObj.ViewManageListings();
            //Assertion Objects
            
            string ViewTitle = ManageListingObj.TitleViewD().ToString();
            string ViewDescription = ManageListingObj.DescriptionViewD().ToString();
           

            Assert.That( EditedTitle== ViewTitle, "Title Details Does not match with the selected");
            Assert.That(EditedDescription== ViewDescription, "Description details Does not match with the selected");

        }
        [Test, Order(3)]
        public void EditSkill()
        {


            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Thread.Sleep(2000);
            ManageListingObj = new ManageListing(driver);
            ManageListingObj.NavigateManageListing();
            ManageListingObj.EditManageListing();
            //Assertion Objects


            string EditedTitle = ManageListingObj.TitleEdited().ToString();
            string EditedDescription = ManageListingObj.DescriptionEdited().ToString();
            string EditExcelTitle = ManageListingObj.TitleEditedExcel().ToString();
            string EditExcelDescription = ManageListingObj.DescriptionEditedExcel().ToString();

            Assert.That(EditExcelTitle == EditedTitle, "Title Edited Does not match with the existing");
            Assert.That(EditExcelDescription == EditedDescription, "Description Edited Does not match with the existing");
        }
        [Test, Order(4)]
        public void DeleteEducation()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Thread.Sleep(2000);
            ManageListingObj = new ManageListing(driver);
            ManageListingObj.NavigateManageListing();
            ManageListingObj.DeleteManageListing();

            string EditedTitle = ManageListingObj.TitleEdited();
            string EditedDescription = ManageListingObj.DescriptionEdited();
            string EditExcelTitle = ManageListingObj.TitleEditedExcel();
            string EditExcelDescription = ManageListingObj.DescriptionEditedExcel();

            Assert.That(EditExcelTitle != EditedTitle, "Title deleted Does not match with the selected");
            Assert.That(EditExcelDescription != EditedDescription, "Description deleted Does not match with the selected");


        }
    }
}

