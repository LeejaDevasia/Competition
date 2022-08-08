using Competition_Mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
//using OpenQA.Selenium.Support.PageObjects;
//using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;



namespace Competition_Mars.Pages
{
    public class ShareSkill : CommonDriver
    {
        private IWebDriver _driver;
        ShareSkill ShareSkillObj;
        public ShareSkill(IWebDriver driver)
        {
            _driver = driver;
            // ShareSkillObj = PageFactory.InitElements<ShareSkill>(driver);
            PageFactory.InitElements(driver, this);


        }


        //welcome message

        private IWebElement MessageHI => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));

        //ShareSkill Button to add skill sharing details
        private IWebElement shareskillButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a"));


        // Title case
        private IWebElement Titlecase => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]"));
        //getting Title 
        private IWebElement Title => driver.FindElement(By.XPath("//div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));

        //getting description

        private IWebElement Description => driver.FindElement(By.Name("description"));

        //Category dropdown
        private IWebElement Category => driver.FindElement(By.Name("categoryId"));

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]")]
        private IWebElement CategorySelect { get; set; }
        //subcategory dropdown
        // [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategory => driver.FindElement(By.Name("subcategoryId"));
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[5]")]
        private IWebElement SubCategorySelect { get; set; }
        //Tag
        private IWebElement Tags => driver.FindElement(By.XPath("//div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));


        //service Type radiobutton

        private IWebElement ServiceType => driver.FindElement(By.Name("serviceType"));

        private IWebElement ServiceTypeSelect => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
        //Location Type radiobutton
        // [FindsBy(How = How.Name, Using = "locationType")]
        private IWebElement LocationType => driver.FindElement(By.Name("locationType"));
        private IWebElement LocationTypeSelect => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));

        //start date calender
        private IWebElement StartDate => driver.FindElement(By.Name("startDate"));
        private IWebElement StartDateCalender => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));
        //*[@id="service-listing-section"]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input
        //EndDate Calender

        private IWebElement EndDate => driver.FindElement(By.Name("endDate"));

        //Checkbox for days index of sunday- 0, monday- 1 so on

        private IWebElement AvailableCheckbox1 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input"));



        //Start Time selector index changing

        private IWebElement StartTime1 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));

        // StartTime
        //Finish Time selector index

        private IWebElement FinishTime1 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[3]/input"));

        //Checkbox for days
        private IWebElement AvailableCheckbox2 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[7]/div[1]/div/input"));

        //Start Time selector index changing

        private IWebElement StartTime2 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[7]/div[2]/input"));

        //Finish Time selector index

        private IWebElement FinishTime2 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[7]/div[3]/input"));



        //Skill Trade selector index change skill exchange -0 and credit-1

        private IWebElement SkillTrade => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));



        private IWebElement skillExchange => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));


        //if skill trade is credit or index is 1 then amount for credit
        private IWebElement CreditCharge => driver.FindElement(By.Name("charge"));

        //work sample file upload
        //[FindsBy(How = How.XPath, Using = "//div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement WorkSample => driver.FindElement(By.XPath("//div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
        
        // Runtime.getRuntime.exec("E:\Testing\CompetitionTask\Mars_Competition\Mars_Competition\image\girl.jfif");



        //Active Status

        private IWebElement ActiveStatus => driver.FindElement(By.Name("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));



        //Save

        private IWebElement SaveButton => driver.FindElement(By.XPath("//div[2]/div/form/div[11]/div/input[1]"));

        // getting the welcome message text
        public string WelcomeMessageCheck()
        {
            Thread.Sleep(3000);
            //  string welcomeText = "//div/div[1]/div[2]/div/span";
            //WaitHelpers.WaitToBeVisible(driver, "XPath", welcomeText, 5);
            return MessageHI.Text;

        }

        public void NavigateToShareSkill()
        {
            // Thread.Sleep(1000);
            string shareskillbutton = "//div/section[1]/div/div[2]/a";
            WaitHelpers.WaitToBeVisible(driver, "XPath", shareskillbutton, 2);
            shareskillButton.Click();
            Thread.Sleep(2000);
        }







        public void AddSkillShare()
        {
            //ExcelLib.
            //Titlecase.Click();
            Title.Click();
            Title.Clear();
            Title.SendKeys("HAi");
            Description.Click();
            Description.SendKeys("xyz");
            Category.Click();
            CategorySelect.Click();
            SubCategory.Click();
            SubCategorySelect.Click();
            Tags.Click();
            Tags.SendKeys("Dev");
            // Tags.Submit();
            Tags.SendKeys(Keys.Return);
            ServiceTypeSelect.Click();
            LocationTypeSelect.Click();
            StartDateCalender.Click();
            StartDateCalender.SendKeys("22/08/2022");
            EndDate.Click();
            EndDate.SendKeys("30/08/2022");
            //WaitHelpers.WaitToBeVisible(driver, "XPath", AvailableCheckbox1, 2);
            Thread.Sleep(500);
            AvailableCheckbox1.Click();



            StartTime1.SendKeys(Keys.ArrowDown);
            StartTime1.Click();
            Thread.Sleep(500);
            StartTime1.SendKeys("02:30pm");
            FinishTime1.Click();
            FinishTime1.SendKeys("03:30pm");
            AvailableCheckbox2.Click();
            StartTime2.Click();
            StartTime2.SendKeys("02:30pm");
            FinishTime2.Click();
            FinishTime2.SendKeys("03:30pm");


            SkillTrade.Click();
            skillExchange.Click();
            skillExchange.SendKeys("Music");
            skillExchange.SendKeys(Keys.Return);
            WorkSample.Click();
            AutoItX3 autoit = new AutoItX3();
            autoit.WinActivate("Open");
            Thread.Sleep(2000);
            autoit.Send(@"E:\Testing\CompetitionTask\Mars_Competition\Mars_Competition\image\girl.jfif");
            Thread.Sleep(1000);
            autoit.Send("{ENTER}");
            SaveButton.Click();

        }








    }

}
