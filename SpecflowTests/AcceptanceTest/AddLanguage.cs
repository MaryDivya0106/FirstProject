using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;
using static SpecflowPages.Driver;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps 
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();
            // Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            Driver.driver.FindElement(By.LinkText("Languages")).Click();

        }
         
        [When(@"When I add a new ""(.*)""")]
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



        //[When(@"I add a new language")]
        //public void WhenIAddANewLanguage()
        //{
        //    //Click on Add New button
        //    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

        //    //Add Language
        //    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");

        //    //Click on Language Level
        //    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();

        //    //Choose the language level
        //    IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
        //    Lang.Click();

        //    //Click on Add button
        //    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        //}

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@name='name']")).Text;
                Thread.Sleep(500);
                if(ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch(Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed",e.Message);
            }

             

        }
    }
}
