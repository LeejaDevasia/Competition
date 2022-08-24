using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Competition_Mars.Pages;
using Mars_Competition.Pages;
using Mars_Competition.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        ManageListing ManageListingObj;

        public static string excelpath = @"E:\Testing\CompetitionTask\Competition\Mars_Competition\Mars_Competition\input\input.xlsx";
        public static string AutoScriptPath = @"E:\Testing\CompetitionTask\Competition\Mars_Competition\Mars_Competition\FileUploadScriptEdit.exe";
        public static string Excelpath { get => excelpath; set => excelpath = value; }
        public static string ScreenshotPath = @"E:\Testing\CompetitionTask\Competition\Mars_Competition\Mars_Competition\Screenshot\";
        public static string ReportPath = @"E:\Testing\CompetitionTask\Competition\Mars_Competition\Mars_Competition\Reports\";

        #region reports
        public static AventStack.ExtentReports.ExtentReports extent;
        public static AventStack.ExtentReports.ExtentTest test;
        #endregion

        #region setup and tear down
        [OneTimeSetUp]
        protected void ExtentStart()
        {
            //Initialize report

            string reportName = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + @"Reports"
            + Path.DirectorySeparatorChar + "Report_" + DateTime.Now.ToString("_dd-MM-yyyy_HHmm") + Path.DirectorySeparatorChar;
            
            //start reporters
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportName);
            htmlReporter.Config.DocumentTitle = "Automation Report";//Title of the report
            htmlReporter.Config.ReportName = "Functional Report"; //Name of the report.
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);

            //Information need to be display on the report 
            extent.AddSystemInfo("Host Name", "LocalHost");
            extent.AddSystemInfo("Environment", "Test Environment");
            extent.AddSystemInfo("USerName", "Leeja");
            extent.AddSystemInfo("Browser", "Chrome");
           


        }

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


        [TearDown]
        public void TearDown()
        {
            // Screenshot
           String img = GlobalDefinitions.Screenshot.SaveScreenshot(driver,"ScreenShots");
            // log with snapshot
            var exec_status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            string TC_Name = TestContext.CurrentContext.Test.Name;
            string base64 = GlobalDefinitions.Screenshot.GetScreenshot(driver);

            Status logStatus = Status.Pass;
            switch (exec_status)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    test.Log(Status.Fail, exec_status + errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;

                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    test.Log(Status.Skip, errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;

                case TestStatus.Inconclusive:

                    logStatus = Status.Warning;
                    test.Log(Status.Warning, "Test");
                    break;

                case TestStatus.Passed:

                    logStatus = Status.Pass;
                    test.Log(Status.Pass, "Test Passed");
                    break;

                default:
                    break;
            }


            //// Close the driver   
            driver.Close();
            driver.Quit();
        }


        [OneTimeTearDown]
        public void CloseTestRun()
        {
            Thread.Sleep(2000);
            extent.Flush();
            Thread.Sleep(2000);
           
        }
        #endregion


    }

}
