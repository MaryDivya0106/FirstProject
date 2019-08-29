using OpenQA.Selenium;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class ManageListingSteps
    {
        [Given(@"I have clicked on MangeListing Tab in ProfilePage")]
        public void GivenIHaveClickedOnMangeListingTabInProfilePage()
        {
            Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(text(),'Manage Listings')]")).Click();
        }
        
        [When(@"i have clicked on delete skill")]
        public void WhenIHaveClickedOnDeleteSkill()
        {
            Driver.driver.FindElement(By.XPath("//tbody[1]/tr[1]/td[2]//..//following-sibling::td[7]/i[3]")).Click();
            Driver.driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']")).Click();
        }
        
        [Then(@"that skill should delete from list\.")]
        public void ThenThatSkillShouldDeleteFromList_()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Delete");
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
                String ExpectedValue = Driver.driver.FindElement(By.XPath("//tbody[1]/tr[1]/td[3]")).Text+" has been delete";
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, ExpectedValue);
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "TestFailed", e.Message);
            }
        }
    }
}
