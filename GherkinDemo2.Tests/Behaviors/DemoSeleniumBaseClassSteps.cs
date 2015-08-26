using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GherkinDemo2.Tests.Behaviors
{
    [Binding, Scope(Feature = "Demo Selenium Base Class")]
    public class DemoSeleniumBaseClassSteps : SeleniumBaseTest
    {
        protected override void BeforeTestInitialize()
        {
            WebServer.StartIis();
        }

        protected override void AfterTestCleanup()
        {
            WebServer.StopIis();
        }

        protected override void AfterTestInitialize()
        {
            Context.Pages.SomeTestPage.GoTo();
        }

        [Given(@"I have entered the text ""(.*)""")]
        public void GivenIHaveEnteredTheText(string p0)
        {
            Context.Pages.SomeTestPage.EnterText(p0);
        }
        
        [When(@"I submit the text")]
        public void WhenISubmitTheText()
        {
            Context.Pages.SomeTestPage.SubmitText();
        }
        
        [Then(@"a success result should show")]
        public void ThenASuccessResultShouldShow()
        {
            Assert.IsTrue(Context.Pages.SomeTestPage.HasSuccessResult);
        }
    }
}
