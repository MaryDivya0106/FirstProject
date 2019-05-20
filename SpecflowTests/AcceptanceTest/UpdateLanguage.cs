using NUnit.Core;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;
using OpenQA.Selenium.Support.UI;

namespace SpecflowTests //Updating Language
{
    [Binding]
    public class SpecFlowFeature2Steps : Utils.Start
    {

        [Given(@"I clicked on the Language tab under Profile page\.")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage_()
        {
            Thread.Sleep(500);
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Languages")).Click();
        }

        [Given(@"I clicked on Edit Symbol\.")]
        public void GivenIClickedOnEditSymbol_()
        {
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//td[@class='right aligned']/span[1]/i")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//div[@class='five wide field']")).Click();
            Driver.driver.FindElement(By.XPath("//*[@name='name']")).Clear();
        }
        
        [When(@"i changed the language in language tab and selected level from dropdown list\.")]
        public void WhenIChangedTheLanguageInLanguageTabAndSelectedLevelFromDropdownList_()
        {
            Thread.Sleep(3000);

             
            
            IWebElement name=  Driver.driver.FindElement(By.XPath("//*[@name='name']"));
            name.SendKeys("Tamil");
          IWebElement dropdown= Driver.driver.FindElement(By.XPath("//*[@name='level']"));
            //dropdown.Click();
            SelectElement option = new SelectElement(dropdown);
            option.SelectByIndex(3);
            

        }
        
        [When(@"i clicked on Update Button\.")]
        public void WhenIClickedOnUpdateButton_()
        {
            Driver.driver.FindElement(By.XPath("//*[@value='Update']")).Click();
        }

        [Then(@"that updated language should be displayed in my language tab with new language\.")]
        public void ThenThatUpdatedLanguageShouldBeDisplayedInMyLanguageTabWithNewLanguage_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("update a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Tamil";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@name='name']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, updated a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "UpdatedLanguage");
                }

                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }


    }
    
}
namespace SpecflowTests
{
    [Binding]
    public class Update
    {
        [Given(@"I clicked on language tab under Profile page\.")]
        public void GivenIClickedOnLanguageTabUnderProfilePage_()
        {
            Thread.Sleep(1500);
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Languages")).Click();
        }

        [When(@"I leave language tab and level empty and clicked on Update Button\.")]
        public void WhenILeaveLanguageTabAndLevelEmptyAndClickedOnUpdateButton_()
        {
            Driver.driver.FindElement(By.XPath("//td[@class='right aligned']/span[1]/i")).Click();
            Thread.Sleep(1500);
            Driver.driver.FindElement(By.XPath("//div[@class='five wide field']")).Click();
            Driver.driver.FindElement(By.XPath("//*[@name='name']")).Clear();
            //IWebElement name = Driver.driver.FindElement(By.XPath("//*[@name='name']"));
            //name.SendKeys("");
           // Driver.driver.FindElement(By.XPath("//*[@name='level']")).Click();
            Driver.driver.FindElement(By.XPath("//*[@value='Update']")).Click();
        }

        [Then(@"I should able to see popup to enter language and level\.")]
        public void ThenIShouldAbleToSeePopupToEnterLanguageAndLevel_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("update a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Please enter language and level";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ui']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Notupdated Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Not UpdatedLanguage");
                }

                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}//language should not update if language and value is empty;
