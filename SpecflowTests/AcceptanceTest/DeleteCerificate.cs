using System;
using TechTalk.SpecFlow;

namespace SpecflowTests
{
    [Binding]
    public class DeleteCerificate
    {
        [Given(@"I click on the certification tab under Profile page\.")]
        public void GivenIClickOnTheCertificationTabUnderProfilePage_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I clicked on particular certificate delete icon\.")]
        public void WhenIClickedOnParticularCertificateDeleteIcon_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"that certificate  details should delete from the list\.")]
        public void ThenThatCertificateDetailsShouldDeleteFromTheList_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
