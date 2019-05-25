using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Utils
{
  public class LoginPage
    {
        public static void LoginStep()
        {
            Driver.NavigateUrl();
            Thread.Sleep(1000);

            Driver.driver.Navigate().Refresh();

            //Enter Url
            Driver.driver.FindElement(By.XPath("//*[@class='item']")).Click();

            //Enter Username
            Driver.driver.FindElement(By.XPath("//*[@name='email']")).SendKeys("divya.pentareddy@gmail.com");

            //Enter password
            Driver.driver.FindElement(By.XPath("//*[@name='password']")).SendKeys("Divyareddy0106");
            Thread.Sleep(1000);
            //Click on Login Button
            Driver.driver.FindElement(By.XPath("//div[@class='field']/button")).Click();

            //string msg = "Add New Job";
            //string Actualmsg = Driver.driver.FindElement(By.XPath("//*[@id='addnewjob']")).Text;

            //if (msg == Actualmsg)
            //{
                //Console.WriteLine("Test Passed");
                //CommonMethods.ExtentReports();
                //Thread.Sleep(500);
                //test = CommonMethods.extent.StartTest("Login with valid data");
                //Thread.Sleep(1000);
                //CommonMethods.test.Log(LogStatus.Pass, "Test Passed");
                //SaveScreenShotClass.SaveScreenshot(Driver.driver, "HomePage");
            //}
            //else
            //{
                //Console.WriteLine("Test Failed");
                //CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            //}
        }

    }
}
