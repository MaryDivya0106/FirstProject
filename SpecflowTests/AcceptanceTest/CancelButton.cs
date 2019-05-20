using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class CancelButton
    {
        [Given(@"when i clicked on the Language tab under Profile page\.")]
        public void GivenWhenIClickedOnTheLanguageTabUnderProfilePage_()
        {
            Thread.Sleep(500);
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Languages")).Click();
        }
        
        [Given(@"i updated language tab by selecting edit symbol\.")]
        public void GivenIUpdatedLanguageTabBySelectingEditSymbol_()
        {
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//td[@class='right aligned']/span[1]/i")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//div[@class='five wide field']")).Click();
            Driver.driver.FindElement(By.XPath("//*[@name='name']")).Clear();

            IWebElement name = Driver.driver.FindElement(By.XPath("//*[@name='name']"));
            name.SendKeys("Tamil");
        }
        
        [When(@"i clicked on Cancel Button\.")]
        public void WhenIClickedOnCancelButton_()
        {
            Driver.driver.FindElement(By.XPath("//input[@value='Cancel']")).Click();
        }
        
        [Then(@"that language should not updated with new language\.")]
        public void ThenThatLanguageShouldNotUpdatedWithNewLanguage_()
        {
            // ScenarioContext.Current.Pending();
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

