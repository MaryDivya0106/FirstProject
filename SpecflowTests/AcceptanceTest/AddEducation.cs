using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddEducation
    {
        [Given(@"I clicked on the education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            //Clicking on Education Tab
            Driver.driver.FindElement(By.LinkText("Education")).Click();
        }

        [When(@"When I add all required details '(.*)', '(.*)', '(.*)', '(.*)','(.*)'")]
        public void WhenWhenIAddAllRequiredDetails(string p0, string p1, string p2, string p3, string p4)
        {
            //Click on Addnew
            Driver.driver.FindElement(By.XPath("//thead/tr/th[contains(text(),'Graduation Year')]/following-sibling::th/div")).Click();
            //sending istitutename
            Driver.driver.FindElement(By.Name("instituteName")).SendKeys(p0);
            //sending Country
            Driver.driver.FindElement(By.Name("country")).SendKeys(p1);
            //send Title
            Driver.driver.FindElement(By.Name("title")).SendKeys(p2);
            //send Degree
            Driver.driver.FindElement(By.Name("degree")).SendKeys(p3);
            //choose year
            Driver.driver.FindElement(By.Name("yearOfGraduation")).SendKeys(p4);
            //Click on Add
            Driver.driver.FindElement(By.XPath(" //div[@class='sixteen wide field']/input[@value='Add']")).Click();
  }


        [Then(@"that should be displayed on my education  listings")]
        public void ThenThatShouldBeDisplayedOnMyEducationListings()
        {
            try
            {
                //reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Add Education");
                String ExpectedValue = "Education has been added";
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
                Assert.AreEqual(ExpectedValue, ActualValue);
                Assert.IsTrue(ActualValue.Contains("Education has been added"));
                CommonMethods.test.Log(LogStatus.Pass, "test Passed"+ExpectedValue);
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Added education pic");


            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }

        }


        
    }
    }//Adding Education
namespace SpecflowTests
{
    [Binding]
    public class EducationNullvalues
    {
        [Given(@"I click on the Education tab under Profile page and clicked on add New Button\.")]
        public void GivenIClickOnTheEducationTabUnderProfilePageAndClickedOnAddNewButton_()
        {
            //Clicking on Education Tab
            Driver.driver.FindElement(By.LinkText("Education")).Click();
        }

        [When(@"I enter all the fields except University and click on Add button\.")]
        public void WhenIEnterAllTheFieldsExceptUniversityAndClickOnAddButton_()
        {
            //Click on Addnew
            Driver.driver.FindElement(By.XPath("//thead/tr/th[contains(text(),'Graduation Year')]/following-sibling::th/div")).Click();
            //sending istitutename
            Driver.driver.FindElement(By.Name("instituteName")).SendKeys("");
            //sending Country
            Driver.driver.FindElement(By.Name("country")).SendKeys("Australia");
            //send Title
            Driver.driver.FindElement(By.Name("title")).SendKeys("M.com");
            //send Degree
            Driver.driver.FindElement(By.Name("degree")).SendKeys("Graduation");
            //choose year
            Driver.driver.FindElement(By.Name("yearOfGraduation")).SendKeys("2019");
            //Click on Add
            Driver.driver.FindElement(By.XPath(" //div[@class='sixteen wide field']/input[@value='Add']")).Click();
        }

        [Then(@"I should able to see  Tool Tip as Please enter all the fields\.")]
        public void ThenIShouldAbleToSeeToolTipAsPleaseEnterAllTheFields_()
        {
            try
            {
                //reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Add Education with null values ");
                String ExpectedValue = "Please enter all the fields";
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")).Text;
                Assert.AreEqual(ExpectedValue, ActualValue);
                Assert.IsTrue(ActualValue.Contains("Please enter all the fields"));
                CommonMethods.test.Log(LogStatus.Pass, "test Passed" + ExpectedValue);
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "notAdded education pic");


            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }



        }
    }
}//Education with Null values
namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class UpdateEducation
    {


        [Given(@"I click on the Education tab under Profile page and clicked on Update icon")]
        public void GivenIClickOnTheEducationTabUnderProfilePageAndClickedOnUpdateIcon()
        {
            //Clicking on Education Tab
            Driver.driver.FindElement(By.LinkText("Education")).Click();
        }

        [When(@"I updated the current Tiitle name to new Title and i clicked on Update button\.")]
        public void WhenIUpdatedTheCurrentTiitleNameToNewTitleAndIClickedOnUpdateButton_()
        {
            //Updating the existing Education......................................................

            IList<IWebElement> EducationList = Driver.driver.FindElements(By.XPath("//thead/tr/th[contains(text(),'Title')]//..//..//following-sibling::tbody/tr/td[3]"));
            String BeforeXpath2 = "//thead/tr/th[contains(text(),'Title')]//..//..//following-sibling::tbody/tr/td[contains(text(),'";
            String AfterXpath2 = "')]//../td[6]/span[1]/i";
            for (int List = 0; List < EducationList.Count; List++)
            {
                if (EducationList[List].Text == "PHD")
                {
                    String TitleText = EducationList[List].Text;
                    Console.WriteLine(TitleText);
                    Driver.driver.FindElement(By.XPath(BeforeXpath2 + TitleText + AfterXpath2)).Click();
                    IWebElement TitleDropDown = Driver.driver.FindElement(By.XPath("//select[@name='title']"));
                    SelectElement TitleName = new SelectElement(TitleDropDown);
                    TitleName.SelectByText("B.A");
                    Driver.driver.FindElement(By.XPath("//div[@class='sixteen wide field']/input[@value='Update']")).Click();
                    break;
                }
            }
        }

        [Then(@"I should able to see the tooltip as Education Updated\.")]
        public void ThenIShouldAbleToSeeTheTooltipAsEducationUpdated_()
        {
            try
            {
                //reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Update Education ");
                String ExpectedValue = "Education as been updated";
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
                Assert.AreEqual(ExpectedValue, ActualValue);
                Assert.IsTrue(ActualValue.Contains("Education as been updated"));
                CommonMethods.test.Log(LogStatus.Pass, "test Passed" + ExpectedValue);
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Updated education pic");


            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }
        }



    }
}//UpdateEducation
namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class ExistingEducation
    {
        [Given(@"I click on the Education tab under Profile page and clicked on Add New button\.")]
        public void GivenIClickOnTheEducationTabUnderProfilePageAndClickedOnAddNewButton_()
        {
            //Clicking on Education Tab
            Driver.driver.FindElement(By.LinkText("Education")).Click();
            //Click on Addnew
            Driver.driver.FindElement(By.XPath("//thead/tr/th[contains(text(),'Graduation Year')]/following-sibling::th/div")).Click();
        }
        [Scope(Feature ="Education")]
        [When(@"I gave same inputs which exists and clicked on Add button\.")]
        public void WhenIGaveSameInputsWhichExistsAndClickedOnAddButton_()
        {
            //Click on Addnew
            Driver.driver.FindElement(By.XPath("//thead/tr/th[contains(text(),'Graduation Year')]/following-sibling::th/div")).Click();
            //sending istitutename
            Driver.driver.FindElement(By.Name("instituteName")).SendKeys("CJITS");
            //sending Country
            Driver.driver.FindElement(By.Name("country")).SendKeys("India");
            //send Title
            Driver.driver.FindElement(By.Name("title")).SendKeys("B.Tech");
            //send Degree
            Driver.driver.FindElement(By.Name("degree")).SendKeys("Bachelors");
            //choose year
            Driver.driver.FindElement(By.Name("yearOfGraduation")).SendKeys("2016");
            //Click on Add
            Driver.driver.FindElement(By.XPath(" //div[@class='sixteen wide field']/input[@value='Add']")).Click();

        }
        [Scope(Feature = "Education")]
        [Then(@"I shoul able to see Tool Tip as Information already exist \.")]
        public void ThenIShoulAbleToSeeToolTipAsInformationAlreadyExist_()
        {
            try
            {
                //reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Add existing  Education");
                String ExpectedValue = "This information is already exist.";
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")).Text;
                Assert.AreEqual(ExpectedValue, ActualValue);
                Assert.IsTrue(ActualValue.Contains("This information is already exist."));
                CommonMethods.test.Log(LogStatus.Pass, "test Passed" + ExpectedValue);
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "This information is already exist.");


            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }
        }
    }
}//trying to add Existing education
namespace SpecflowTests
{
    [Binding]
    public class DeleteEducation
    {
        [Given(@"I click on the Education tab under Profile page\.")]
        public void GivenIClickOnTheEducationTabUnderProfilePage_()
        {
            //Clicking on Education Tab
            Driver.driver.FindElement(By.LinkText("Education")).Click();
        }

        [When(@"I clicked on particulat education delete icon\.")]
        public void WhenIClickedOnParticulatEducationDeleteIcon_()
        {
            IList<IWebElement> UpdatedList = Driver.driver.FindElements(By.XPath("//thead/tr/th[contains(text(),'Title')]//..//..//following-sibling::tbody/tr/td[3]"));
            String BeforeXpath3 = "//thead/tr/th[contains(text(),'Title')]//..//..//following-sibling::tbody/tr/td[contains(text(),'";
            String AfterXpath3 = "')]//../td[6]/span[2]/i";

            for (int List = 0; List < UpdatedList.Count; List++)
            {
                if (UpdatedList[List].Text == "B.TEch")
                {
                    String TitleText = UpdatedList[List].Text;
                    Driver.driver.FindElement(By.XPath(BeforeXpath3 + TitleText + AfterXpath3)).Click();
                    break;
                }
            }
        }

        [Then(@"that education details should delete from the list\.")]
        public void ThenThatEducationDetailsShouldDeleteFromTheList_()
        {
            try
            {
                //reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Add existing  Education");
                String ExpectedValue = "Education entry successfully removed";
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
                Assert.AreEqual(ExpectedValue, ActualValue);
                Assert.IsTrue(ActualValue.Contains("Education entry successfully removed"));
                CommonMethods.test.Log(LogStatus.Pass, "test Passed" + ExpectedValue);
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Education entry successfully removed");


            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }
        }
    }
}//DeleteEducation


