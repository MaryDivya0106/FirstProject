using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class AddSkill
    {
        [Scope(Tag = "tag2")]
        [Given(@"I clicked on the skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Skills")).Click();
        }
        
        [When(@"When I add a new ""(.*)""")]
        public void WhenWhenIAddANew(string p0)
        {
            Thread.Sleep(5000);
            // Click on Add New button
            Driver.driver.FindElement(By.XPath("//tr/th[1][contains(text(),'Skill')]/following-sibling::th[2]/div")).Click();

            //Add Skill
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys(p0);

            //Click on Skill Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")).Click();

            //Choose the language level


            IWebElement SkillStatus = Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']/option[2]"));
            // SelectElement sc=new 

            SkillStatus.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"that ""(.*)"" should be displayed on my listings")]
        public void ThenThatShouldBeDisplayedOnMyListings(string p0)
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                String ActualCondition = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
                String ExpectedCondition = p0 + " has been added to your skills";
                Console.WriteLine(p0);
                //Assert.AreEqual(ExpectedCondition, ActualCondition);
                if (ExpectedCondition == ActualCondition)
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Skill added in to list");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
                }



            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}//Adding Multiple skills with same code
namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class UpdateSkill
    {
        [Given(@"I clicked on the skills tab under Profile page\.")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage_()
        {
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Skills")).Click();
        }

        [Given(@"I clicked on the Skill Edit Symbol\.")]
        public void GivenIClickedOnTheSkillEditSymbol_()
        {


            IList<IWebElement> Table1 = Driver.driver.FindElements(By.XPath("//thead/tr/th[contains(text(),'Skill')]//../parent::thead/following-sibling::tbody/tr/td[1]"));
            String BeforeXath = "//tbody/tr/td[1][contains(text(),'";
            String AfterXpath = "')]//..//td[3]/span[1]/i[@class='outline write icon']";
            for (int Skill = 0; Skill < Table1.Count; Skill++)
            {
                String Skills = Table1[Skill].Text;
                if (Table1[Skill].Text == ("Coding"))
                {
                    Driver.driver.FindElement(By.XPath(BeforeXath + Skills + AfterXpath)).Click();
                    break;
                }
            }
        }

        [When(@"i changed the Skill in Skill tab and selected level from dropdown list\.")]
        public void WhenIChangedTheSkillInSkillTabAndSelectedLevelFromDropdownList_()
        {
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).Clear();
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Testing");
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")).Click();
            IWebElement SkillStatus1 = Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
            SelectElement sc = new SelectElement(SkillStatus1);
            sc.SelectByText("Intermediate");
        }

        [When(@"i clicked on the Skill Update Button\.")]
        public void WhenIClickedOnTheSkillUpdateButton_()
        {
            Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }

        [Then(@"that updated Skill should be displayed in my Skill tab with new Skill\.")]
        public void ThenThatUpdatedSkillShouldBeDisplayedInMySkillTabWithNewSkill_()
        {
            //Validating ToopTip After Updating the value
            //IWebElement Success=;
            // Console.WriteLine(Success);
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Update Skill Test");
                String ActualCondition2 = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
                Console.WriteLine(ActualCondition2);
                String ExpectedCondition2 = "Testing has been updated to your skills";
                if (ActualCondition2 == ExpectedCondition2)
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Skill updated in to list");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skillupdated");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " skill not Updated");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}//UpdatingSkill
namespace SpecflowTests
{
    [Binding]
    public class UpdateSkillWithEmptyInputs
    {
        [Given(@"I clicked on Skill tab under Profile page\.")]
        public void GivenIClickedOnSkillTabUnderProfilePage_()
        {
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Skills")).Click();
        }

        [When(@"I leave skill tab and level empty and clicked on Update Button\.")]
        public void WhenILeaveSkillTabAndLevelEmptyAndClickedOnUpdateButton_()
        {
            IList<IWebElement> Table1 = Driver.driver.FindElements(By.XPath("//thead/tr/th[contains(text(),'Skill')]//../parent::thead/following-sibling::tbody/tr/td[1]"));
            String BeforeXath = "//tbody/tr/td[1][contains(text(),'";
            String AfterXpath = "')]//..//td[3]/span[1]/i[@class='outline write icon']";
            for (int Skill = 0; Skill < Table1.Count; Skill++)
            {
                String Skills = Table1[Skill].Text;
                if (Table1[Skill].Text == ("Reading"))
                {
                    Driver.driver.FindElement(By.XPath(BeforeXath + Skills + AfterXpath)).Click();
                    Driver.driver.FindElement(By.XPath("//input[@name='name']")).Clear();
                    IWebElement SkillStatus1 = Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
                    SelectElement sc = new SelectElement(SkillStatus1);
                    sc.SelectByIndex(0);
                    Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();

                    break;
                }
            }

        }

        [Then(@"I should able to see popup to enter Skill and level\.")]
        public void ThenIShouldAbleToSeePopupToEnterSkillAndLevel_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("update a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Please enter skill and experience level";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, ExpectedValue);
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill not updated with empty fields");
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
}//updateSkillWithEmptyInputs
namespace SpecflowTests
{
    [Binding]
    public class DeleteSkill
    {
        [Given(@"I click on the Skill tab under Profile page\.")]
        public void GivenIClickOnTheSkillTabUnderProfilePage_()
        {
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Skills")).Click();
        }

        [When(@"I click on the delete symbol\.")]
        public void WhenIClickOnTheDeleteSymbol_()
        {
            IList<IWebElement> Table1 = Driver.driver.FindElements(By.XPath("//thead/tr/th[contains(text(),'Skill')]//../parent::thead/following-sibling::tbody/tr/td[1]"));
            for (int Skill = 0; Skill < Table1.Count; Skill++)
            {
                String Skills = Table1[Skill].Text;
                if (Table1[Skill].Text == ("Reading")) 
                {
                    String BeforeXpath1 = "//tbody/tr/td[1][contains(text(),'";
                    String AfterXpath1 = "')]//..//td[3]/span[2]/i[@class='remove icon']";
                    Driver.driver.FindElement(By.XPath(BeforeXpath1 + Skills + AfterXpath1)).Click();
                    break;
                }
            }
        }


        [Then(@"that skill should Delete from my skills listing\.")]
        public void ThenThatSkillShouldDeleteFromMySkillsListing_()
        {
            //Validating Automation esting exsists after deleting
            CommonMethods.ExtentReports();
            CommonMethods.test = CommonMethods.extent.StartTest("DeleteSkill");
            String ActualResult3 = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text; ;
            Console.WriteLine(ActualResult3);
            String ExpectedResult3 = "Reading has been deleted";
            if (ExpectedResult3 == ActualResult3)
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, ExpectedResult3);
            }
            else
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Skill has not deleted");
            }

        }
    }
}//DeleteSkill
namespace SpecflowTests
{
    [Binding]
    public class CancelOperation
    {
        [Given(@"when i clicked on the Skills tab under Profile page\.")]
        public void GivenWhenIClickedOnTheSkillsTabUnderProfilePage_()
        {
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Skills")).Click();
        }

        [Given(@"i updated skill tab by selecting edit symbol\.")]
        public void GivenIUpdatedSkillTabBySelectingEditSymbol_()
        {
            IList<IWebElement> Table1 = Driver.driver.FindElements(By.XPath("//thead/tr/th[contains(text(),'Skill')]//../parent::thead/following-sibling::tbody/tr/td[1]"));
            String BeforeXath = "//tbody/tr/td[1][contains(text(),'";
            String AfterXpath = "')]//..//td[3]/span[1]/i[@class='outline write icon']";
            for (int Skill = 0; Skill < Table1.Count; Skill++)
            {
                String Skills = Table1[Skill].Text;
                if (Table1[Skill].Text == ("Reading"))
                {
                    Driver.driver.FindElement(By.XPath(BeforeXath + Skills + AfterXpath)).Click();
                    Driver.driver.FindElement(By.XPath("//input[@name='name']")).Clear();
                    Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Software");
                    IWebElement SkillStatus1 = Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
                    SelectElement sc = new SelectElement(SkillStatus1);
                    sc.SelectByIndex(3);


                    break;
                }
            }
        }

        [When(@"i clicked on the Cancel Button\.")]
        public void WhenIClickedOnTheCancelButton_()
        {
            Driver.driver.FindElement(By.XPath("//span/input[@value='Cancel']")).Click();
        }

        [Then(@"that skill should not updated with new skill\.")]
        public void ThenThatSkillShouldNotUpdatedWithNewSkill_()
        {
            //tbody/tr/td[1][contains(text(),'Reading')]
            String ActualResult1 = Driver.driver.FindElement(By.XPath("//tbody/tr/td[1][contains(text(),'Reading')]")).Text;
            Console.WriteLine(ActualResult1);
            String ExpectedResult1 = "Reading";
            if (ExpectedResult1 == ActualResult1)
            {
                Thread.Sleep(5000);
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Clicked on cancelbutton");
            }
            else
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " Not clicked on CancelButton");
            }
        }
    }
}//Click on Cancel Btton
namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class DuplicatedSkill
    {
        [Given(@"I click on skills tab under Profile page\.")]
        public void GivenIClickOnSkillsTabUnderProfilePage_()
        {
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Skills")).Click();

        }

        [When(@"I click on Add New button \.")]
        public void WhenIClickOnAddNewButton_()
        {
            // Click on Add New button
            Driver.driver.FindElement(By.XPath("//tr/th[1][contains(text(),'Skill')]/following-sibling::th[2]/div")).Click();
        }

        [When(@"I entered existing skill and changed level and clicked on Add button\.")]
        public void WhenIEnteredExistingSkillAndChangedLevelAndClickedOnAddButton_()
        {

            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Testing");
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")).Click();
            IWebElement SkillStatus1 = Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
            SelectElement sc = new SelectElement(SkillStatus1);
            sc.SelectByText("Expert");
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"I should able to see tool tip intimating Duplicated data\.")]
        public void ThenIShouldAbleToSeeToolTipIntimatingDuplicatedData_()
        {
            try
            {
                //reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Duplicate Level In Skill");
                String ExpectedValue = "Duplicated data";
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
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
}//Duplicated Skill
namespace SpecflowTests
{
    [Binding]
    public class SkillExist
    {
        [Given(@"I click on skill tab below Profile page\.")]
        public void GivenIClickOnSkillTabBelowProfilePage_()
        {
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            Driver.driver.FindElement(By.LinkText("Skills")).Click();
        }

        [When(@"I clicked on the Add New button \.")]
        public void WhenIClickedOnTheAddNewButton_()
        {
            Thread.Sleep(5000);
            // Click on Add New button
            Driver.driver.FindElement(By.XPath("//tr/th[1][contains(text(),'Skill')]/following-sibling::th[2]/div")).Click();


        }

        [When(@"I entered existing skill and level and clicked on Add button\.")]
        public void WhenIEnteredExistingSkillAndLevelAndClickedOnAddButton_()
        {
            //Add Skill
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("writing");

            //Click on Skill Level
            Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")).Click();

            //Choose the language level


            IWebElement SkillStatus = Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']/option[4]"));
            // SelectElement sc=new 

            SkillStatus.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"I should able to see tooltip intimating as Skill Exists\.")]
        public void ThenIShouldAbleToSeeTooltipIntimatingAsSkillExists_()
        {
            try
            {
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Adding Existing Skill");
                String ExpectedCondition = "This skill is already exist in your skill list.";
                String ActualCondition = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;

                Assert.AreEqual(ExpectedCondition, ActualCondition);
                Assert.IsTrue(ActualCondition.Contains("This skill is already exist in your skill list."));
                CommonMethods.test.Log(LogStatus.Pass, ExpectedCondition);
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "testfailed", e);
            }
        }
    }
}//Adding Existing Skill


