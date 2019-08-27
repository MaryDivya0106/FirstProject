using System;
using TechTalk.SpecFlow;

namespace SpecflowTests
{
    [Binding]
    public class AddCertification
    {
        [Given(@"I click on the Certification tab under Profile page\.")]
        public void GivenIClickOnTheCertificationTabUnderProfilePage_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter all the fields and click on Add button\.")]
        public void WhenIEnterAllTheFieldsAndClickOnAddButton_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"that Certificate list should Add into my Certification listing\.")]
        public void ThenThatCertificateListShouldAddIntoMyCertificationListing_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
