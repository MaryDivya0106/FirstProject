using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecflowTests
{
    [Binding]
    public class AddCertification
    {
        [Given(@"I click on the Certification tab under Profile page\.")]
        public void GivenIClickOnTheCertificationTabUnderProfilePage_()
        {
            //Clicking on certificate Tab
            Driver.driver.FindElement(By.LinkText("Certifications")).Click();
        }

        [When(@"I enter all the fields and click on Add button\.")]
        public void WhenIEnterAllTheFieldsAndClickOnAddButton_()
        {
            //Click on Addnew
            Driver.driver.FindElement(By.XPath("//thead/tr/th[contains(text(),'Certificate')]/following-sibling::th/div[contains(text(),'Add New')]")).Click();
            //sending certiname
            Driver.driver.FindElement(By.Name("certificationName")).SendKeys("TestEngineer");
            //sendingcertified from
            Driver.driver.FindElement(By.Name("certificationFrom")).SendKeys("MVP Studios");
            //sending year
            Driver.driver.FindElement(By.Name("certificationYear")).SendKeys("2019");
            //clickAdd
            Driver.driver.FindElement(By.XPath("//div[@class='five wide field']/input[@value='Add']")).Click();
        }

        [Then(@"that Certificate list should Add into my Certification listing\.")]
        public void ThenThatCertificateListShouldAddIntoMyCertificationListing_()
        {
            try
          {
            //reports
            CommonMethods.ExtentReports();
            CommonMethods.test = CommonMethods.extent.StartTest("Add Certi ");
            String ExpectedValue = "TestEngineer has been added to your certification";
            String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
            Assert.AreEqual(ExpectedValue, ActualValue);
            Assert.IsTrue(ActualValue.Contains("TestEngineer has been added to your certification"));
            CommonMethods.test.Log(LogStatus.Pass, "test Passed" + ExpectedValue);
            CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certi added to list/");


            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }
        }
    }
}//Add Certification
namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddCerificateWithNullValues
    {
        [Given(@"I click on the Certification tab under Profile page and clicked on add New Button\.")]
        public void GivenIClickOnTheCertificationTabUnderProfilePageAndClickedOnAddNewButton_()
        { //Clicking on certification Tab
            Driver.driver.FindElement(By.LinkText("Certifications")).Click();
            //Click on Addnew
            Driver.driver.FindElement(By.XPath("//thead/tr/th[contains(text(),'Certificate')]/following-sibling::th/div[contains(text(),'Add New')]")).Click();
        }

        [When(@"I enter all the fields except certificate from and click on Add button\.")]
        public void WhenIEnterAllTheFieldsExceptCertificateFromAndClickOnAddButton_()
        {
            //sending certiname
            Driver.driver.FindElement(By.Name("certificationName")).SendKeys("TestEngineer");
            //sendingcertified from
            Driver.driver.FindElement(By.Name("certificationFrom")).SendKeys("");
            //sending year
            Driver.driver.FindElement(By.Name("certificationYear")).SendKeys("2019");
            //clickAdd
            Driver.driver.FindElement(By.XPath("//div[@class='five wide field']/input[@value='Add']")).Click();
        }

        [Then(@"I should able to see  Tool Tip as enter all Certificate name,from,year \.")]
        public void ThenIShouldAbleToSeeToolTipAsEnterAllCertificateNameFromYear_()
        {
            try
            {
                //reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Add Certi ");
                String ExpectedValue = "Please enter Certification Name, Certification From and Certification Year";
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")).Text;
                Assert.AreEqual(ExpectedValue, ActualValue);
                Assert.IsTrue(ActualValue.Contains("Please enter Certification Name, Certification From and Certification Year"));
                CommonMethods.test.Log(LogStatus.Pass, "test Passed" + ExpectedValue);
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certi not added to list");


            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }

        }
    }
}//Add certificate with null values
namespace SpecflowTests
{
    [Binding]
    public class Updatecertificate
    {
        [Given(@"I click on the certification tab under Profile page and clicked on Update icon\.")]
        public void GivenIClickOnTheCertificationTabUnderProfilePageAndClickedOnUpdateIcon_()
        {
            //Clicking on certification Tab
            Driver.driver.FindElement(By.LinkText("Certifications")).Click();
            IList<IWebElement> CertiList = Driver.driver.FindElements(By.XPath("//thead/tr/th[contains(text(),'Certificate')]//..//..//following-sibling::tbody/tr/td[1]"));
            String BeforeXpath2 = "//tbody/tr/td[contains(text(),'";
            String AfterXpath2 = "')]//..//td[@class='right aligned']/span[1]/i";

            for (int List = 0; List < CertiList.Count; List++)
            {
                if (CertiList[List].Text == "TestEngineer")
                {
                    String CertiText = CertiList[List].Text;
                    Console.WriteLine(CertiText);
                    IJavaScriptExecutor ex = (IJavaScriptExecutor)Driver.driver;
                    ex.ExecuteScript("arguments[0].click();", Driver.driver.FindElement(By.XPath(BeforeXpath2 + CertiText + AfterXpath2)));
                    IWebElement CertiYearDropDown = Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']"));
                    SelectElement CertiUpdateYear = new SelectElement(CertiYearDropDown);
                    CertiUpdateYear.SelectByIndex(3);

                    break;
                }
            }
        }

        [When(@"I updated the current certificate name to  in certification Tab and i clicked on Add button\.")]
        public void WhenIUpdatedTheCurrentCertificateNameToInCertificationTabAndIClickedOnAddButton_()
        {
            //clickupdate
            Driver.driver.FindElement(By.XPath("//span[@class='buttons-wrapper']/input[@value='Update']")).Click();

        }

        [Then(@"That current certificate should be displayed in the box \.")]
        public void ThenThatCurrentCertificateShouldBeDisplayedInTheBox_()
        {
            try
            {
                //reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("update Certi ");
                String ExpectedValue = "TestEngineer has been updated to your certification";
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
                Assert.AreEqual(ExpectedValue, ActualValue);
                Assert.IsTrue(ActualValue.Contains("TestEngineer has been updated to your certification"));
                CommonMethods.test.Log(LogStatus.Pass, "test Passed" + ExpectedValue);
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certi updated to list/");


            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }
        }
    }
}//Update certificate
namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class ExistingCertificateData
    {
        [Given(@"I click on the certification tab under Profile page and clicked on Add New button\.")]
        public void GivenIClickOnTheCertificationTabUnderProfilePageAndClickedOnAddNewButton_()
        {
            //Clicking on certificate Tab
            Driver.driver.FindElement(By.LinkText("Certifications")).Click();
            //Click on Addnew
            Driver.driver.FindElement(By.XPath("//thead/tr/th[contains(text(),'Certificate')]/following-sibling::th/div[contains(text(),'Add New')]")).Click();
        }

        [When(@"I gave same inputs which exists and clicked on Add button\.")]
        public void WhenIGaveSameInputsWhichExistsAndClickedOnAddButton_()
        {
            //sending certiname
            Driver.driver.FindElement(By.Name("certificationName")).SendKeys("TestEngineer");
            //sendingcertified from
            Driver.driver.FindElement(By.Name("certificationFrom")).SendKeys("MVP Studios");
            //sending year
            Driver.driver.FindElement(By.Name("certificationYear")).SendKeys("2019");
            //clickAdd
            Driver.driver.FindElement(By.XPath("//div[@class='five wide field']/input[@value='Add']")).Click();
        }

        [Then(@"I shoul able to see Tool Tip as Information already exist \.")]
        public void ThenIShoulAbleToSeeToolTipAsInformationAlreadyExist_()
        {
            try
            {
                //reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Add existing Certi ");
                String ExpectedValue = "This information is already exist.";
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")).Text;
                Assert.AreEqual(ExpectedValue, ActualValue);
                Assert.IsTrue(ActualValue.Contains("This information is already exist."));
                CommonMethods.test.Log(LogStatus.Pass, "test Passed" + ExpectedValue);
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certi not added to list/");


            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }



        }
    }
}//Add Existing xertificate
namespace SpecflowTests
{
    [Binding]
    public class DeleteCerificate
    {
        [Given(@"I click on the certification tab under Profile page\.")]
        public void GivenIClickOnTheCertificationTabUnderProfilePage_()
        {
            //Clicking on certificate Tab
            Driver.driver.FindElement(By.LinkText("Certifications")).Click();
        }

        [When(@"I clicked on particular certificate delete icon\.")]
        public void WhenIClickedOnParticularCertificateDeleteIcon_()
        {
            IList<IWebElement> CertisList = Driver.driver.FindElements(By.XPath("//thead/tr/th[contains(text(),'Certificate')]//..//..//following-sibling::tbody/tr/td[1]"));
            String BeforeXpath3 = "//thead/tr/th[contains(text(),'Certificate')]//..//..//following-sibling::tbody/tr/td[contains(text(),'";
            String AfterXpath3 = "')]//..//td[4]/span[2]/i";

            for (int List = 0; List < CertisList.Count; List++)
            {
                if (CertisList[List].Text == "TestEngineer")
                {
                    String CertiNameText = CertisList[List].Text;
                    Driver.driver.FindElement(By.XPath(BeforeXpath3 + CertiNameText + AfterXpath3)).Click();
                    break;
                }
            }
        }

        [Then(@"that certificate  details should delete from the list\.")]
        public void ThenThatCertificateDetailsShouldDeleteFromTheList_()
        {
            try
            {
                //reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Delete Certi ");
                String ExpectedValue = "TestEngineer has been deleted from your certification";
                String ActualValue = Driver.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
                Assert.AreEqual(ExpectedValue, ActualValue);
                Assert.IsTrue(ActualValue.Contains("TestEngineer has been deleted from your certification"));
                CommonMethods.test.Log(LogStatus.Pass, "test Passed" + ExpectedValue);
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certi added to list/");


            }
            catch (Exception)
            {

                CommonMethods.test.Log(LogStatus.Fail, "testfailed, e.message");
            }





        }
    }
}//Deleting certificate





