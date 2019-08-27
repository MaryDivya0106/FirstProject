using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.Utils
{
    public class Start : Driver
    {
        [BeforeScenario]
        public void SetUp()
        {
            //Launch the browser
            Initialize();
            Thread.Sleep(500);

            //Call the Login Class            
            SpecflowPages.Utils.LoginPage.LoginStep();         
                      
        }

        [AfterScenario]
        public void TearDown()
        {
            Thread.Sleep(5000);
            // Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "report");
            test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));

            // end test. (Reports)
            CommonMethods.extent.EndTest(CommonMethods.test);

            // calling Flush writes everything to the log file (Reports)
            CommonMethods.extent.Flush();

            //Close the browser
           // Driver.driver.Close();
        }

    }
}
