using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LnP.StepDefinition
{
    [Binding]
    public class SitecoreInvalidLoginSteps
    {
        [Given(@"User is On  CMS Login Page")]
        public void GivenUserIsOnCMSLoginPage()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"User Enters Valid Username and Invalid Password")]
        public void WhenUserEntersValidUsernameAndInvalidPassword()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"Clicks Login  Button")]
        public void WhenClicksLoginButton()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"User Should See Invalid Login Message on Screen")]
        public void ThenUserShouldSeeInvalidLoginMessageOnScreen()
        {
            //ScenarioContext.Current.Pending();
        }


    }
}
