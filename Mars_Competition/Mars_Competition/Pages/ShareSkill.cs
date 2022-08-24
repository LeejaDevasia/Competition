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
using static Mars_Competition.Utilities.GlobalDefinitions;
using Mars_Competition.Utilities;
using OpenQA.Selenium.Support.UI;

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


        //select category
        private IWebElement CategorySelect1 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select/option[1]"));
   
        //Category dropdown
        private IWebElement CategorySelect => driver.FindElement(By.Name("categoryId"));

       //subcategory dropdown
        private IWebElement SubCategory => driver.FindElement(By.Name("subcategoryId"));

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[5]")]
        private IWebElement SubCategorySelect { get; set; }
        //Tag
        private IWebElement Tags => driver.FindElement(By.XPath("//div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));


        //service Type radiobutton

        private IWebElement ServiceType => driver.FindElement(By.Name("serviceType"));

        private IWebElement ServiceTypeHourly => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
        private IWebElement ServiceTypeOneOff => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));

        //Location Type radiobutton
        private IWebElement LocationType => driver.FindElement(By.Name("locationType"));
        private IWebElement LocationTypeOn_site => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));
        private IWebElement LocationTypeOnline => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
        //start date calender
        private IWebElement StartDate => driver.FindElement(By.Name("startDate"));
        private IWebElement StartDateCalender => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));
        
        //EndDate Calender
         private IWebElement EndDate => driver.FindElement(By.Name("endDate"));

        //Checkbox for days index of sunday- 0, monday- 1 so on
        private IList <IWebElement> AvailableDays => driver.FindElements(By.XPath("//input[@name='Available']"));

        //Start Time selector index changing
        private IList<IWebElement> StartTime => driver.FindElements(By.Name("StartTime"));

        // StartTime
        //Finish Time selector index

        private IList<IWebElement> FinishTime => driver.FindElements(By.Name("EndTime"));

        //Skill Trade selector index change skill exchange -0 and credit-1

        private IWebElement SkillTrade => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));

        
        private IWebElement skillExchange => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));

        private IWebElement Credit => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));

        //if skill trade is credit or index is 1 then amount for credit
        private IWebElement CreditCharge => driver.FindElement(By.Name("charge"));

        //work sample file upload
         private IWebElement WorkSample => driver.FindElement(By.XPath("//div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));

        //Active Status

        private IWebElement ActiveStatus => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));

        private IWebElement HiddenStatus => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));

        //Save

        private IWebElement SaveButton => driver.FindElement(By.XPath("//div[2]/div/form/div[11]/div/input[1]"));
        private IWebElement ManageListingT => driver.FindElement(By.XPath("//*[@id='service-listing-section']/section[1]/div/a[3]"));


        private string TitleEd = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]";
      
        private string DescriptionEd = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]";


        private string TitleExcel=ExcelLib.ReadData(2, "Title");

        private string DescriptionExcel=ExcelLib.ReadData(2, "Description");
        private IWebElement TitleEdit => driver.FindElement(By.XPath(TitleEd));
        private IWebElement DescriptionEdit => driver.FindElement(By.XPath(DescriptionEd));


        // getting the welcome message text
        public string WelcomeMessageCheck()
        {
            Thread.Sleep(3000);
           
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
            //   GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            ExcelLib.PopulateInCollection(CommonDriver.Excelpath, "SignIn");
            //Titlecase.Click();
            Title.Click();
            Title.Clear();
            
            Title.SendKeys(ExcelLib.ReadData(2, "Title"));
            Description.Click();
            Description.SendKeys(ExcelLib.ReadData(2, "Description"));

            string CategoryXl = (ExcelLib.ReadData(2, "Category"));


            CategorySelect.Click();
            var CategorySel = new SelectElement(CategorySelect);

            for (int i = 0; i < CategoryXl.Count(); i++)
            {

                CategorySel.SelectByText(CategoryXl);

                if (CategoryXl == CategorySelect.ToString())
                {
                    CategorySelect.Click();
                }
            }
            SubCategory.Click();
            var selectSubCategory = new SelectElement(SubCategory);
            selectSubCategory.SelectByText(ExcelLib.ReadData(2, "SubCategory"));
            Tags.Click();
            Tags.SendKeys(ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Return);

            var servicetypeText = ExcelLib.ReadData(2, "ServiceType");
            if (servicetypeText == "Hourly basis service")
            {
                ServiceTypeHourly.Click();
            }
            else
            {
                ServiceTypeOneOff.Click();
            }
            var location = ExcelLib.ReadData(2, "LocationType");

            if (location == "On-site")
            {
                LocationTypeOn_site.Click();
            }
            else
            {
                LocationTypeOnline.Click();
            }

            StartDateCalender.Click();
            StartDateCalender.SendKeys(ExcelLib.ReadData(2, "StartDate"));

            EndDate.Click();
            EndDate.SendKeys(ExcelLib.ReadData(2, "EndDate"));
            Thread.Sleep(500);

            for (int j = 2; j < 9; j++)
            { 
                
                string daysInput = ExcelLib.ReadData(j, "AvailableDays");
                string Days = "";
            switch (daysInput)
            {
                case "Sun":
                    Days = "0";
                    break;
                case "Mon":
                    Days = "1";
                    break;
                case "Tue":
                    Days = "2";
                    break;
                case "Wed":
                    Days = "3";
                    break;
                case "Thu":
                    Days = "4";
                    break;
                case "Fri":
                    Days = "5";
                    break;
                case "Sat":
                    Days = "6";
                    break;

            }

            for (int i = 0; i < AvailableDays.Count; i++)
            {



                    
                    string Available = AvailableDays[i].GetAttribute("index").ToString();


                    if (Days == Available)
                    {
                        AvailableDays[i].Click();

                        StartTime[i].SendKeys(ExcelLib.ReadData(j, "StartTime"));
                        FinishTime[i].SendKeys(ExcelLib.ReadData(j, "FinishTime"));
                    }
                }
            }


            string SkillTradeXl = ExcelLib.ReadData(2, "SkillTrade");
            if (SkillTradeXl == "Skill-exchange")
            {
                SkillTrade.Click();
                skillExchange.Click();
                skillExchange.SendKeys(ExcelLib.ReadData(2, "SkillExchange"));
                skillExchange.SendKeys(Keys.Return);
            }
            else
            {
                Credit.Click();
                CreditCharge.SendKeys(ExcelLib.ReadData(2, "Credit"));
            }
            WorkSample.Click();
            AutoItX3 autoit = new AutoItX3();
            autoit.WinActivate("Open");
            Thread.Sleep(2000);
            autoit.Send(@"E:\Testing\CompetitionTask\Competition\Mars_Competition\Mars_Competition\image\girl.jfif");
            Thread.Sleep(1000);
            autoit.Send("{ENTER}");

            string ActiveStatusXl = ExcelLib.ReadData(2, "Active");

            if(ActiveStatusXl== "Active")
            {
                ActiveStatus.Click();
            }
            else
            {
                HiddenStatus.Click();
            }

            Thread.Sleep(1000);
            SaveButton.Click();
            Thread.Sleep(2000);
            ManageListingT.Click();
            Thread.Sleep(3000);

        }




        public string TitleAdded()
        {

            return TitleEdit.Text;

        }
        public string DescriptionAdded()
        {

            return DescriptionEdit.Text;

        }

        public string TitleAddedExcel()
        {

            return TitleExcel.ToString();

        }
        public string DescriptionAddedExcel()
        {

            return DescriptionExcel.ToString();

        }

    } 
}
