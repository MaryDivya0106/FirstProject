using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;
using static SpecflowPages.Driver;
using OpenQA.Selenium.Support.UI;
using NUnit.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddingLanguages
        
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            Driver.driver.FindElement(By.LinkText("Languages")).Click();

        }
       
        [When(@"When I add a new ""(.*)""")]
        [Scope(Feature = "LanguageFeature")]
        public void WhenWhenIAddANew(string p0)
        {
            Thread.Sleep(5000);
            // Click on Add New button
            Driver.driver.FindElement(By.XPath("//th[@class='right aligned']/div")).Click();
            
            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@name='name']")).SendKeys(p0);

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@name='level']")).Click();

            //Choose the language level


            IWebElement LangStatus = driver.FindElement(By.XPath("//select[@class='ui dropdown']/option[2]"));
           // SelectElement sc=new 

            LangStatus.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@value='Add']")).Click();
        }

        [Then(@"Add New Tab should disappear under language tab")]
        public void ThenAddNewTabShouldDisappearUnderLanguageTab()
        {
            try
            {
                Driver.driver.FindElement(By.XPath("//th[@class='right aligned']/div")).Click();

                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = Driver.driver.FindElement(By.XPath("//th[@class='right aligned']/div")).Text;
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ui teal button ']")).Text;
                Thread.Sleep(500);
                Assert.AreNotEqual(ExpectedValue, ActualValue);
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Button disappeared");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
    //}
/*}*///Parameterization using scenario outline"

//namespace SpecflowTests
//{
//    [Binding]
//    public class singlelanguage
//    {
        [Given(@"I clicked on Language tab under the Profile page")]
        public void GivenIClickedOnLanguageTabUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(1500);
            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Languages")).Click();

        }

        [When(@"When I add new language")]
        public void WhenWhenIAddNewLanguage()
        {
            Thread.Sleep(5000);
            // Click on Add New button
            Driver.driver.FindElement(By.XPath("//th[@class='right aligned']/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@name='name']")).SendKeys("Urdu");

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@name='level']")).Click();

            //Choose the language leve
            IWebElement LangStatus = driver.FindElement(By.XPath("//select[@class='ui dropdown']/option[2]"));
            // SelectElement sc=new 

            LangStatus.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@value='Add']")).Click();
        }

        [Then(@"that language should displayed on my listings")]
        public void ThenThatLanguageShouldDisplayedOnMyListings()
        {
            try
            {

                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Urdu";
                string ActualValue = Driver.driver.FindElement(By.XPath("//table/tbody/tr/td[contains(text(),'Urdu')]")).Text;
                Thread.Sleep(500);
                Assert.AreEqual(ExpectedValue, ActualValue);
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Language added");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
}//Adding Single Language
}
}

namespace SpecflowTests //Updating Language
{
    [Binding]
    public class UpdatingLanguage : Utils.Start
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

            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'English')]//..//following-sibling::td[1]/span[1]/i")).Click();

        }
        [When(@"i changed the language in language tab and selected level from dropdown list\.")]
        public void WhenIChangedTheLanguageInLanguageTabAndSelectedLevelFromDropdownList_()
        {
            Thread.Sleep(3000);


            //language remain same and updating value to fluent instead of basic
            
            IWebElement dropdown = Driver.driver.FindElement(By.XPath("//select[@name='level']"));
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
                string ExpectedValue = "English has been updated to your languages";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
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
    public class UpdateWithEmptyInputs
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
            SelectElement lang = new SelectElement(Driver.driver.FindElement(By.XPath("//*[@name='level']")));
            lang.SelectByIndex(0);

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
}//working on cancel after clicking on edit button.
namespace SpecflowTests //Deleting existing  language
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

            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'Tamil')]//..//following-sibling::td[1]/span[2]/i")).Click();
         
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
                string ExpectedResult = "English has been deleted from your languages";
                string ActualResult = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;

                Assert.AreEqual(ExpectedResult, ActualResult);
                Assert.IsTrue(ActualResult.Contains("English has been deleted from your languages"));
                CommonMethods.test.Log(LogStatus.Pass, "test Passed, Deleted Language Successfully");
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "deleted pic");

            }
            catch (Exception )
            {
                CommonMethods.test.Log(LogStatus.Fail, "testfailed");
            }

        }
    }


}
namespace SpecflowTests //DuplicatedValues
{
    [Binding]
    public class DuplicatedLanguage
    {
        

        [When(@"I click on Add New button\.")]
        public void WhenIClickOnAddNewButton_()
        {
            Thread.Sleep(1500);
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Languages")).Click();
        }

        [When(@"I entered existing language and changed level and clicked on Add button")]
        public void WhenIEnteredExistingLanguageAndChangedLevelAndClickedOnAddButton()
        {
            Thread.Sleep(5000);

            //checking what languages are present to validate the duplicate value popupmessage
            System.Collections.Generic.IReadOnlyCollection<IWebElement> list = Driver.driver.FindElements(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]"));
            //number of languages present in Table
            Console.WriteLine(list.Count);
            //writes what languages are present in the list
            foreach (var item in list)
            {
                Console.WriteLine(item.Text);
                //if language is present then trying to send english with different value which actually gives duplicate value message.
                if (item.Text.Contains("English"))

                {
                    // Click on Add New button
                    Driver.driver.FindElement(By.XPath("//th[@class='right aligned']/div")).Click();
                    //trying to Add Language which is present already
                    Driver.driver.FindElement(By.XPath("//*[@name='name']")).SendKeys("English");
                    //Click on Language Level
                    SelectElement lang = new SelectElement(Driver.driver.FindElement(By.XPath("//*[@name='level']")));
                    lang.SelectByIndex(2);
                    //Click on Add button
                    Driver.driver.FindElement(By.XPath("//*[@value='Add']")).Click();


                }

            }
        }

        [Then(@"I should able to see tooltip intimating Duplicated data\.")]
        public void ThenIShouldAbleToSeeTooltipIntimatingDuplicatedData_()
        {
            try
            {
                //reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Duplicate Level In Language");
                String ExpectedValue = "Duplicated data";
                String ActualValue= Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                Assert.AreEqual(ExpectedValue, ActualValue);
                Assert.IsTrue(ActualValue.Contains("Duplicated data"));
                CommonMethods.test.Log(LogStatus.Pass, "test Passed, Duplicate value message displayed Successfully");
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "duplicate pic");


            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }

        }
    }
}
namespace SpecflowTests //AddingExistingLanguage
{
    [Binding]
    public class AddingExistinglanguage
    {
        [Given(@"I clicked on Add New button\.")]
        public void GivenIClickedOnAddNewButton_()
        {
            //clicking on profileTab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            //clicking on Language Tab
            Driver.driver.FindElement(By.LinkText("Languages")).Click();
            //clicking on AddNew button
            Driver.driver.FindElement(By.XPath("//th[@class='right aligned']/div")).Click();
        }

        [When(@"I entered existing language and level and clicked on the Add button\.")]
        public void WhenIEnteredExistingLanguageAndLevelAndClickedOnTheAddButton_()
        {

            //gets list of languages
            IReadOnlyCollection<IWebElement> ListOfLang = Driver.driver.FindElements(By.XPath("//table[@class='ui fixed table']/tbody"));
            //writes count of lanuage on console
            Console.WriteLine(ListOfLang.Count);
            //writes all items in language table
            foreach (var item in ListOfLang)
            {
                Console.WriteLine(item.Text);
                //checks ehether language is present
                if (item.Text.Contains("Greek"))
                {
                    //sends same language which is present in table
                    Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Greek");
                    //selects same level
                    SelectElement value = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='level']")));
                    value.SelectByText("Conversational");
                    //clicks on Add button
                    Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

                }
            }
        }


        [Then(@"I should able to see tooltip intimating as language Exists\.")]
        public void ThenIShouldAbleToSeeTooltipIntimatingAsLanguageExists_()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Adding Existing language");
                String ExpectedCondition = "This language is already exist in your language list";
                String ActualCondition = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner]")).Text;

                Assert.AreEqual(ExpectedCondition, ActualCondition);
                Assert.IsTrue(ActualCondition.Contains("This language is already exist in your language list"));
                CommonMethods.test.Log(LogStatus.Pass, "Test is Passed", "AddingExistinglanguage");
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "testfailed", e);
            }
        }
    }
}
namespace SpecflowTests //checking AvailabityStatus
{
    [Binding]
    public class AvailabilityStatus
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






