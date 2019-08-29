using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;


//Profile-> Avilanity, hours,salary
namespace SpecflowTests //checking AvailabityStatus
{
    [Binding]
    public class 
AvailabilityStatus
    {
        [Given(@"I click on edit button of the Availabity in Profile page\.")]
        public void GivenIClickOnEditButtonOfTheAvailabityInProfilePage_()
        {
            Driver.driver.FindElement(By.XPath("//div[@class='item']//div/span[contains(text(),'Part Time')]/i")).Click();
        }

        [When(@"I clicked on the SelectType dropdown and selected status from dropdown\.")]
        public void WhenIClickedOnTheSelectTypeDropdownAndSelectedStatusFromDropdown_()
        {
            SelectElement availability = new SelectElement(Driver.driver.FindElement(By.XPath("//Select[@name='availabiltyType']")));
            availability.SelectByText("Part Time");
        }

        [Then(@"I can see availability selected status and Tooltip\.")]
        public void ThenICanSeeAvailabilitySelectedStatusAndTooltip_()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("check availabity");
                String ExpectedConditions = "Availability updated";
                String ActualCondition = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Assert.AreEqual(ExpectedConditions, ActualCondition);
                CommonMethods.test.Log(LogStatus.Pass, "TestPassed");



            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "Testfailed");
            }
        }
    }
}
namespace SpecflowTests //Checking Hours AvailabilityStatus.
{
    [Binding]
    public class HoursAvailabity
    {
        [Given(@"I click on edit button of hours in Profile page click \.")]
        public void GivenIClickOnEditButtonOfHoursInProfilePageClick_()
        {
            Driver.driver.FindElement(By.XPath("//strong[contains(text(),'Hours')]//..//..//following-sibling::div/span/i")).Click();
        }

        [When(@"I clicked on the SelectType dropdown and selected hours from dropdown\.")]
        public void WhenIClickedOnTheSelectTypeDropdownAndSelectedHoursFromDropdown_()
        {
            SelectElement availability = new SelectElement(Driver.driver.FindElement(By.XPath("//Select[@name='availabiltyHour']")));
            availability.SelectByIndex(2);
        }

        [Then(@"I should able to see the selected hours and popup\.")]
        public void ThenIShouldAbleToSeeTheSelectedHoursAndPopup_()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("check hour availabity");
                String ExpectedConditions = "Availability updated";
                String ActualCondition = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Assert.AreEqual(ExpectedConditions, ActualCondition);
                CommonMethods.test.Log(LogStatus.Pass, "TestPassed");



            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "Testfailed");
            }
        }
    }
}
namespace SpecflowTests
{
    [Binding]
    public class EarnTargetStatus
    {
        [Given(@"I click on edit button of EarnTarget in Profile page \.")]
        public void GivenIClickOnEditButtonOfEarnTargetInProfilePage_()
        {
            Driver.driver.FindElement(By.XPath("//strong[contains(text(),'Earn Target')]//..//..//following-sibling::div/span/i")).Click();
        }

        [When(@"I clicked on the SelectType dropdown and selected amount from dropdown\.")]
        public void WhenIClickedOnTheSelectTypeDropdownAndSelectedAmountFromDropdown_()
        {
            SelectElement availability = new SelectElement(Driver.driver.FindElement(By.XPath("//Select[@name='availabiltyTarget']")));
            availability.SelectByIndex(2);

        }

        [Then(@"I should able to see the selected amount and popup\.")]
        public void ThenIShouldAbleToSeeTheSelectedAmountAndPopup_()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Earn Target");
                String ExpectedConditions = "Availability updated";
                String ActualCondition = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Assert.AreEqual(ExpectedConditions, ActualCondition);
                CommonMethods.test.Log(LogStatus.Pass, "TestPassed");



            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "Testfailed");
            }
        }
    }
} // Checking EarnTargetStatus
//Profile->Description
namespace SpecflowTests
{
    [Binding]
    public class DescriptionSpchChar
    {   [Scope(Tag ="@Desc1")]
        [Given(@"I clicked on Edit button of Description in profile pageing page")]
        public void GivenIClickedOnEditButtonOfDescriptionInProfilePageingPage()
        {
            Driver.driver.FindElement(By.XPath("//h3[contains(text(),'Description')]/span/i")).Click();
        }
        
        [When(@"I enterd text starting with special charcters in Description field")]
        public void WhenIEnterdTextStartingWithSpecialCharctersInDescriptionField()
        {
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).SendKeys("@myTag");
        }
        [Scope(Tag = "@Desc1")]
        [When(@"I clicked on Save button")]
        public void WhenIClickedOnSaveButton()
        {
            Driver.driver.FindElement(By.XPath("//button[@type='button'][contains(text(),'Save')]")).Click();
        }
        [Scope(Tag = "@Desc1")]
        [Then(@"I should able to see error message\.")]
        public void ThenIShouldAbleToSeeErrorMessage_()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("AddDesWithSpchChar");
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")).Text;
                String ExpectedValue = "First character can only be digit or letters";
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
}//valiadting user starts with special char in description
namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class DescriptionSpace
    {
        [Scope(Tag = "@Desc2")]
        [Given(@"I clicked on Edit button of Description in profile pageing page")]
        public void GivenIClickedOnEditButtonOfDescriptionInProfilePageingPage()
        {
            Driver.driver.FindElement(By.XPath("//h3[contains(text(),'Description')]/span/i")).Click();
        }

        [When(@"I enterd text starting with space in Description field")]
        public void WhenIEnterdTextStartingWithSpaceInDescriptionField()
        {
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).SendKeys(" myTag");
        }
        [Scope(Tag = "@Desc2")]
        [When(@"I clicked on Save button")]
        public void WhenIClickedOnSaveButton()
        {
            Driver.driver.FindElement(By.XPath("//button[@type='button'][contains(text(),'Save')]")).Click();
        }
        [Scope(Tag = "@Desc2")]
        [Then(@"I should able to see error message\.")]
        public void ThenIShouldAbleToSeeErrorMessage_()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("AddDesWithSpace");
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")).Text;
                String ExpectedValue = "First character can only be digit or letters";
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
}//Discription starting with space
namespace SpecflowTests
{
    [Binding]
    public class DescriptionNull
    {
        [Scope(Tag = "@Desc3")]
        [Given(@"I clicked on Edit button of Description in profile pageing page")]
        public void GivenIClickedOnEditButtonOfDescriptionInProfilePageingPage()
        {
            Driver.driver.FindElement(By.XPath("//h3[contains(text(),'Description')]/span/i")).Click();
        }

        [When(@"I leave the descrption field as empty")]
        public void WhenILeaveTheDescrptionFieldAsEmpty()
        {
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).SendKeys("");
        }
        [Scope(Tag = "@Desc3")]
        [When(@"I clicked on Save button")]
        public void WhenIClickedOnSaveButton()
        {
            Driver.driver.FindElement(By.XPath("//button[@type='button'][contains(text(),'Save')]")).Click();
        }
        [Scope(Tag = "@Desc3")]
        [Then(@"I should able to see error message\.")]
        public void ThenIShouldAbleToSeeErrorMessage_()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("AddDesWithNull");
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")).Text;
                String ExpectedValue = "Please, a description is required";
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
}//Description with Null Values
namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class DescriptionUpperLowerCase
    {
        [Scope(Tag = "@Desc4")]
        [Given(@"I clicked on Edit button of Description in profile pageing page")]
        public void GivenIClickedOnEditButtonOfDescriptionInProfilePageingPage()
        {
            Driver.driver.FindElement(By.XPath("//h3[contains(text(),'Description')]/span/i")).Click();
        }

        [When(@"I have given text in lower and upper case letters")]
        public void WhenIHaveGivenTextInLowerAndUpperCaseLetters()
        {
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).SendKeys("MaryDivya");
        }
        [Scope(Tag = "@Desc4")]
        [When(@"I clicked on Save button")]
        public void WhenIClickedOnSaveButton()
        {
            Driver.driver.FindElement(By.XPath("//button[@type='button'][contains(text(),'Save')]")).Click();
        }
        [Scope(Tag = "@Desc4")]
        [Then(@"I should able to see message saved\.")]
        public void ThenIShouldAbleToSeeMessageSaved_()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("AddDesWithupperlowe cases");
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
                String ExpectedValue = "Description has been saved successfully";
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
}//Description saved success with upperlower cases
namespace SpecflowTests
{
    [Binding]
    public class DescCharRem
    {
        [Given(@"I clicked on Edit button of Description in profile pageing page")]
        public void GivenIClickedOnEditButtonOfDescriptionInProfilePageingPage()
        {
            Driver.driver.FindElement(By.XPath("//h3[contains(text(),'Description')]/span/i")).Click();
        }

        [When(@"I have given text in Description field")]
        public void WhenIHaveGivenTextInDescriptionField()
        {
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).SendKeys("MaryDivya");
        }



        [Then(@"I should able to see characters remaining to allow\.")]
        public void ThenIShouldAbleToSeeCharactersRemainingToAllow_()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("CharRemainingUnderText");
                String ActualValue = Driver.driver.FindElement(By.XPath("//p")).Text;
                String ExpectedValue = "Characters remaining: ";
                if (ExpectedValue.Contains(ActualValue))
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
}//CharRemaining





