using OpenQA.Selenium;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{

    [Binding]
    
    public class ShareSkillPage
    {
        [Given(@"I have navigated to profilepage")]
        public void GivenIHaveNavigatedToProfilepage()
        {
            String profile = Driver.driver.Title;
            Console.WriteLine(profile);
        }

        [When(@"I clicked on ShareSkill Button")]
        public void WhenIclickedOnShareSkillButton()
        {
            Driver.driver.FindElement(By.LinkText("Share Skill")).Click();
        }
        
        [Then(@"I should navigate to ServiceListing page")]
        public void ThenIShouldNavigateToManageListingPage()
        {
            try
            { CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("ShareSkills");
                 String ServiceListing = Driver.driver.Title;
                Console.WriteLine(ServiceListing);
                if(ServiceListing== "ServiceListing")
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "ServiceListing");
                }
            }
            catch(Exception e)
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "TestFailed", e.Message);
            }
           
        }
    }
}//Validating ShareSkill Button 
namespace SpecflowTests
{
    [Binding]
    public class ShareSkillSpchlChrsError
    {    [Scope(Tag= "@mytag2")]
        [Given(@"I clicked on Shareskill button and navigated to servicelisting page")]
        public void GivenIClickedOnShareskillButtonAndNavigatedToServicelistingPage()
        {
            Driver.driver.FindElement(By.LinkText("Share Skill")).Click();
        }

        [When(@"I enterd text starting with special charcters in Title field")]
        public void WhenIEnterdTextStartingWithSpecialCharctersInTitleField()
        {
            Driver.driver.FindElement(By.CssSelector("input[name='title']")).SendKeys("@Divya");
        }
        [Scope(Tag = "@mytag2")]
        [Then(@"I should able to see error message")]
        public void ThenIShouldAbleToSeeErrorMessage()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("SplChrError");
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ui basic red prompt label transition visible']")).Text;
                String ExpectedValue = "First character must be an alphabet character or a number.";
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "SplChrError");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "TestFailed", e.Message);
            }
        }
    }
}//Validating SpechlChar Error message
namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class ShareSkillNullError
    {
        [Scope(Tag = "@mytag3")]
        [Given(@"I clicked on Shareskill button and navigated to servicelisting page")]
        public void GivenIClickedOnShareskillButtonAndNavigatedToServicelistingPage()
        {
            Driver.driver.FindElement(By.LinkText("Share Skill")).Click();
        }

        [When(@"I click on description field and leave the description field as empty")]
        public void WhenIClickOnDescriptionFieldAndLeaveTheDescriptionFieldAsEmpty()
        {
            Driver.driver.FindElement(By.CssSelector("textarea[name = 'description']")).SendKeys("D");
            Driver.driver.FindElement(By.CssSelector("textarea[name = 'description']")).SendKeys(Keys.Backspace);

        }
        [Scope(Tag = "@mytag3")]
        [Then(@"I should able to see error message")]
        public void ThenIShouldAbleToSeeErrorMessage()
        {

            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("NullError");
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ui basic red prompt label transition visible'][contains(text(),'Please type a description.')]")).Text;
                String ExpectedValue = "Please type a description.";
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "NullError");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "TestFailed", e.Message);
            }
        }
    }
}//validating Null error message 
namespace SpecflowTests
{
    [Binding]
    public class ShareSkill
    {
        [Scope(Tag = "@mytag4")]
        [Given(@"I clicked on Shareskill button and navigated to servicelisting page")]
        public void GivenIClickedOnShareskillButtonAndNavigatedToServicelistingPage()
        {
            Driver.driver.FindElement(By.LinkText("Share Skill")).Click();
        }

        [When(@"I Entered some text in description field")]
        public void WhenIEnteredSomeTextInDescriptionField()
        {
            Driver.driver.FindElement(By.CssSelector("textarea[name = 'description']")).SendKeys("Diva");
        }
        [Scope(Tag = "@mytag4")]
        [Then(@"I should able to see entered message")]
        public void ThenIShouldAbleToSeeEnteredMessage()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("entered value");
                String ActualValue = Driver.driver.FindElement(By.XPath("//textarea[@name='description']")).Text;
                String ExpectedValue = "Diva";
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "testpassed");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "TestFailed", e.Message);
            }

        }
    }
}//Validating text in field



