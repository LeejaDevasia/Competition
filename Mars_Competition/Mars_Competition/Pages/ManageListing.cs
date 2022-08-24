using Competition_Mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mars_Competition.Utilities.GlobalDefinitions;
using AutoItX3Lib;

namespace Mars_Competition.Pages
{
    public class ManageListing : CommonDriver
    {
        private IWebDriver _driver;
        ManageListing ManageListingObj;
        public ManageListing(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(driver, this);
        }

        private IWebElement ManageListingTab => driver.FindElement(By.XPath("//div/section[1]/div/a[3]"));

        //  string ManageListingTabWait => "//*[@id='service-listing-section']/section[1]/div/a[3]";
        ////  WaitHelpers.WaitToBeVisible(driver, "XPath", ManageListingTabWait, 2);


        //view details of listing
        [FindsBy(How = How.XPath, Using = "//div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]/i")]

        private IWebElement viewButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]")]


        private IWebElement deleteButton { get; set; }



        //delete confirmation 
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]


        private IWebElement deleteButtonconfirmation { get; set; }




        //  //Edit Details
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]")]
        private IWebElement EditButton { get; set; }


        private IList<IWebElement> ServiceTypeRadioButton = driver.FindElements(By.Name("serviceType"));



        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
        private IWebElement EditSaveButton { get; set; }

        private string Titlestr = "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input";
        private string Descriptionstr = "//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea";
        private string CategoryClickstr = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select";
        //  private string categoryId = "categoryId";
        private string SubCategoryClickstr = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select";
        private string Tagsstr = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input";
        private string HourlyBasisServicestr = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input";
        private string OneOffServicestr = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input";
        private string Onsitestr = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input";
        private string Onlinestr = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input";
        private string StartDatestr = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input";
        private string EndDatestr = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input";
        private string AvailableDaysstr = "Available";
        private string StartTimestr = "StartTime";
        private string FinishTimestr = "EndTime";
        private string SkillExchangestr = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input";
        private string SkillExchangeTextstr = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input";
        private string Creditstr = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input";
        private string CreditPricestr = "charge";
        private string WorkSamplestr = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i";
        private string Activestr = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input";
        private string Hiddenstr = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input";
        private string Savestr = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]";
        private string Cancelstr = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[2]";
        private string ManageListingta = "//*[@id='service-listing-section']/section[1]/div/a[3]";
        private string ActualTitleE = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]";
        private string ActualDescriptionE = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]";
        private string TitleEd = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]";
        private string DescriptionEd = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]";



        private IWebElement TitleEdit => driver.FindElement(By.XPath(TitleEd));
        private IWebElement DescriptionEdit => driver.FindElement(By.XPath(DescriptionEd));
        private IWebElement ActualTitle => driver.FindElement(By.XPath("ActualTitleE"));
        private IWebElement ActualDescription=> driver.FindElement(By.XPath("ActualDescriptionE"));
        private IWebElement Title => driver.FindElement(By.XPath(Titlestr));
        private IWebElement Description => driver.FindElement(By.XPath(Descriptionstr));
        private IWebElement CategoryClick => driver.FindElement(By.XPath(CategoryClickstr));

        // private IWebElement CategorySelect = driver.FindElement (By.Name (categoryId));
        private IWebElement SubCategoryClick => driver.FindElement(By.XPath(SubCategoryClickstr));
        private IWebElement Tags => driver.FindElement(By.XPath(Tagsstr));
        private IWebElement HourlyBasisService => driver.FindElement(By.XPath(HourlyBasisServicestr));
        private IWebElement OneOffService => driver.FindElement(By.XPath(OneOffServicestr));
        private IWebElement Onsite => driver.FindElement(By.XPath(Onsitestr));
        private IWebElement Online => driver.FindElement(By.XPath(Onlinestr));
        private IWebElement StartDate => driver.FindElement(By.XPath(StartDatestr));
        private IWebElement EndDate => driver.FindElement(By.XPath(EndDatestr));
        private IList<IWebElement> AvailableDays => driver.FindElements(By.Name(AvailableDaysstr));
        private IList<IWebElement> StartTime => driver.FindElements(By.Name(StartTimestr));
        private IList<IWebElement> FinishTime => driver.FindElements(By.Name(FinishTimestr));
        private IWebElement SkillExchange => driver.FindElement(By.XPath(SkillExchangestr));
        private IWebElement SkillExchangeText => driver.FindElement(By.XPath(SkillExchangeTextstr));
        private IWebElement Credit => driver.FindElement(By.XPath(Creditstr));
        private IWebElement CreditPrice => driver.FindElement(By.Name(CreditPricestr));
        private IWebElement WorkSample => driver.FindElement(By.XPath(WorkSamplestr));
        private IWebElement Active => driver.FindElement(By.XPath(Activestr));
        private IWebElement Hidden => driver.FindElement(By.XPath(Hiddenstr));

        private IWebElement Save => driver.FindElement(By.XPath(Savestr));
        private IWebElement Cancel => driver.FindElement(By.XPath(Cancelstr));
        private IWebElement ManageListingT => driver.FindElement(By.XPath(ManageListingta));





        public void NavigateManageListing()
        {
            ManageListingTab.Click();
            Thread.Sleep(1000);
        }
        public string ActualTitleEdited()
        {
            return ActualTitle.ToString();
        }

        public string ActualDescriptionEdited()
        {
            return ActualDescription.ToString();
        }

        public void ViewManageListings()
        {
            Thread.Sleep(1000);
            viewButton.Click();
            Thread.Sleep(3000);
            //ManageListingT.Click();
         //   Thread.Sleep(3000);

        }
        public void EditManageListing()
        {
            Thread.Sleep(2000);
            ExcelLib.PopulateInCollection(CommonDriver.Excelpath, "Edit");
            EditButton.Click();
            Thread.Sleep(2000);

            string TitleXl = ExcelLib.ReadData(2, "Title");

            if (TitleXl != null || TitleXl != "")
            {
                Title.Clear();
                Title.SendKeys(TitleXl);
            }
            string desc = Description.Text;
            string DescriptionXl = ExcelLib.ReadData(2, "Description");

            if (DescriptionXl != null || DescriptionXl != "" && DescriptionXl != desc)
            {
                Description.Clear();
                Description.SendKeys(DescriptionXl);

            }

            CategoryClick.Click();
            var CategorySel = new SelectElement(CategoryClick);
            string CategoryXl = ExcelLib.ReadData(2, "Category");

            for (int i = 0; i < CategoryXl.Count(); i++)
            {

                CategorySel.SelectByText(CategoryXl);

                if (CategoryXl == CategoryClick.ToString())
                {
                    CategoryClick.Click();
                }
            }

            SubCategoryClick.Click();

            var SubCategorySel = new SelectElement(SubCategoryClick);

            string subCategoryXl = ExcelLib.ReadData(2, "SubCategory");

            for (int i = 0; i < subCategoryXl.Count(); i++)
            {

                SubCategorySel.SelectByText(subCategoryXl);

                if (subCategoryXl == SubCategoryClick.ToString())
                {
                    SubCategoryClick.Click();
                }
            }

            string Tagsxl = ExcelLib.ReadData(2, "Tags");
            string TagsTxt = Tags.Text;
            if (Tagsxl != null || Tagsxl != "" && Tagsxl != TagsTxt)
            {
                Tags.Clear();
                Tags.SendKeys(ExcelLib.ReadData(2, "Tags"));
                Tags.SendKeys(Keys.Return);
            }


            var servicetypeText = ExcelLib.ReadData(2, "ServiceType");
            if (servicetypeText == "Hourly basis service")
            {
                HourlyBasisService.Click();
            }
            else
            {
                OneOffService.Click();
            }
            var location = ExcelLib.ReadData(2, "LocationType");

            if (location == "On-site")
            {
                Onsite.Click();
            }
            else
            {
                Online.Click();
            }

            string StartDateXl = (ExcelLib.ReadData(2, "StartDate")).ToString();
            string StartDatest = StartDate.Text;

            if (StartDateXl != null || StartDateXl != "" && StartDateXl != StartDatest)
            {
                StartDate.Clear();

                StartDate.SendKeys(ExcelLib.ReadData(2, "StartDate"));
                StartDate.SendKeys(Keys.Return);
            }

            string EndDateXl = (ExcelLib.ReadData(2, "EndDate")).ToString();
            string EndDatest = EndDate.Text;
            if (EndDateXl != null || EndDateXl != "" && EndDateXl != EndDatest)
            {
                EndDate.Clear();
                EndDate.SendKeys(ExcelLib.ReadData(2, "EndDate"));
                EndDate.SendKeys(Keys.Return);
            }




            //editing Days, start time and end time

            string daysInput = ExcelLib.ReadData(2, "AvailableDays");
            //If excel have any data to edit then cleqar all the fields
            for (int j = 0; j < AvailableDays.Count; j++)
            {
                if (StartTime[j].Text != null || StartTime[j].Text != "")
                {
                    StartTime[j].SendKeys(Keys.Delete);
                    StartTime[j].SendKeys(Keys.Tab);
                    StartTime[j].SendKeys(Keys.Delete);
                    StartTime[j].SendKeys(Keys.Tab);
                    StartTime[j].SendKeys(Keys.Delete);
                    StartTime[j].SendKeys(Keys.Tab);
                    FinishTime[j].SendKeys(Keys.Delete);
                    FinishTime[j].SendKeys(Keys.Tab);
                    FinishTime[j].SendKeys(Keys.Delete);
                    FinishTime[j].SendKeys(Keys.Tab);
                    FinishTime[j].SendKeys(Keys.Delete);
                    FinishTime[j].SendKeys(Keys.Tab);
                    if (AvailableDays[j].Selected)
                    {
                        AvailableDays[j].Click();

                    }
                }
            }
            //get all data for days in excel sheet for edit
            for (int k = 2; k < 10; k++)
            {
                string daysInputXl = ExcelLib.ReadData(k, "AvailableDays");
                Thread.Sleep(1000);
                if (daysInputXl != null)
                {


                    string Days = "";
                    switch (daysInputXl)
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

                    //edit days, start time and end time from excel

                    for (int i = 0; i < AvailableDays.Count; i++)
                    {

                        string Available = AvailableDays[i].GetAttribute("index").ToString();


                        if (Days == Available)
                        {
                            AvailableDays[i].Click();

                            StartTime[i].SendKeys(ExcelLib.ReadData(k, "StartTime"));
                            FinishTime[i].SendKeys(ExcelLib.ReadData(k, "FinishTime"));
                        }
                    }

                }
            }



            string SkillTradeXl = ExcelLib.ReadData(2, "SkillTrade");
            if (SkillTradeXl == "Skill-exchange")
            {

                SkillExchange.Click();
                SkillExchangeText.SendKeys(ExcelLib.ReadData(2, "SkillExchange"));
                SkillExchangeText.SendKeys(Keys.Return);
            }
            else
            {
                Credit.Click();
                CreditPrice.Clear();
                string CreditPr = ExcelLib.ReadData(2, "Credit").ToString();
                CreditPrice.SendKeys(CreditPr);
                CreditPrice.SendKeys(Keys.Return);
                Thread.Sleep(1000);
            }

            WorkSample.Click();
            //// AutoIT implementation to upload the file
            // using (Process exeProcess = Process.Start(CommonDriver.AutoScriptPath))
            //{
            //    exeProcess.WaitForExit();
            //}
            AutoItX3 autoit = new AutoItX3();
            autoit.WinActivate("Open");
            Thread.Sleep(2000);
            autoit.Send(@"E:\Testing\CompetitionTask\Competition\Mars_Competition\Mars_Competition\image\mountain.jpg");
            Thread.Sleep(1000);

            autoit.Send("{ENTER}");

            string ActiveXl = ExcelLib.ReadData(2, "Active");

            if (ActiveXl == "Active")
            {

                Active.Click();

            }
            else
            {
                Hidden.Click();
                Thread.Sleep(1000);
            }

            // Thread.Sleep(3000);
            EditSaveButton.Click();
            Thread.Sleep(3000);
            ManageListingT.Click();
            Thread.Sleep(3000);
        }


        public string TitleEditedExcel()
        {
            ExcelLib.PopulateInCollection(CommonDriver.Excelpath, "Edit");
            string TitleExcel = (ExcelLib.ReadData(2, "Title")).ToString();
            return TitleExcel;
        }

        public string DescriptionEditedExcel()
        {
            ExcelLib.PopulateInCollection(CommonDriver.Excelpath, "Edit");
            string DescriptionExcel = (ExcelLib.ReadData(2, "Description")).ToString();
            return DescriptionExcel;
        }
       




    public void DeleteManageListing()
        {
            Thread.Sleep(2000);
            deleteButton.Click();
            Thread.Sleep(1000);
            deleteButtonconfirmation.Click();
            Thread.Sleep(3000);

        }

        public string TitleEdited()
        {

            return TitleEdit.Text;

        }
        public string DescriptionEdited()
        {

            return DescriptionEdit.Text;

        }

        private string TitleVi = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span";
        private string DescriptionVi = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]";

        private IWebElement TitleView => driver.FindElement(By.XPath(TitleVi));
        private IWebElement DescriptionView => driver.FindElement(By.XPath(DescriptionVi));
        public string TitleViewD()
        {

            return TitleView.Text;

        }
        public string DescriptionViewD()
        {

            return DescriptionView.Text;

        }

        
        
    }
}


