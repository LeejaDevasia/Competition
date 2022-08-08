using Competition_Mars.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Competition.Pages
{
    public class ManageListing : CommonDriver
    {
        private IWebDriver _driver;
        ManageListing ManageListingObj;
        public ManageListing(IWebDriver driver)
        {
            _driver = driver;
            // ShareSkillObj = PageFactory.InitElements<ShareSkill>(driver);
            PageFactory.InitElements(driver, this);
        }
        private IWebElement ManageListingTab => driver.FindElement(By.XPath("//*[@id='service-listing-section']/section[1]/div/a[3]"));

        string ManageListingTabWait = "//*[@id='service-listing-section']/section[1]/div/a[3]";
      //  WaitHelpers.WaitToBeVisible(driver, "XPath", ManageListingTabWait, 2);
        private IWebElement Active => driver.FindElement(By.XPath(" //*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input"));

      //view details of listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]/i")]

        private IWebElement viewButton { get; set; }

        //Edit Details
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]")]

        private IWebElement EditButton { get; set; }

        //Add another tag with edit
        [FindsBy(How = How.XPath, Using = " //*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        private IWebElement TagsEdit { get; set; }

        //Credit choose
        [FindsBy(How = How.XPath, Using = " //*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement credit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input")]
        private IWebElement pricePerHour { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
        private IWebElement EditSaveButton { get; set; }



        public void NavigateManageListing()
        {
            ManageListingTab.Click();
            Thread.Sleep(2000);
        }
        public void ViewManageListings()
        {
            viewButton.Click();


        }
        // public void EditManageListing()
        // {

        // }
        // public void DeleteManageListing()
        // {

        // }
    }
}
    

