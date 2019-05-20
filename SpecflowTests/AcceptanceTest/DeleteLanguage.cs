using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests //Deleting language
{
    [Binding]
    public class DeleteLanguage
    {
        [Given(@"I click on the Language tab under Profile page\.")]
        public void GivenIClickOnTheLanguageTabUnderProfilePage_()
        {
            Thread.Sleep(1500);
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Languages")).Click();
        }

        [When(@"I click on delete symbol\.")]
        public void WhenIClickOnDeleteSymbol_()
        {
            Driver.driver.FindElement(By.XPath("//td[@class='right aligned']/span[2]/i")).Click();
        }

        [Then(@"that language should Delete from my Language listing\.")]
        public void ThenThatLanguageShouldDeleteFromMyLanguageListing_()
        {

            //Reports
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("DeleteLanguage");

                //compare
                string ExpectedResult = "English has been deleted from your Language";
                string ActualResult = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                if (ExpectedResult == ActualResult)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "test Passed, Deleted Language Successfully");
                    CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "deleted pic");

                }
                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "testfailed,language not deleted");


                }
            }
            catch(Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }

        }
    }  
        
    
 }   

