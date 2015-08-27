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

        /// <summary>
        /// Demonstrate thread safe creation/use of test objects
        /// and also automating cleanup in a safe way.
        /// </summary>
        protected ISomeTypeThatNeedsCleanup TypeThatNeedsCleanup
        {
            get
            {
                if (!Context.ContainsKey("TypeThatNeedsCleanup"))
                {
                    var instance = new SomeTypeThatNeedsCleanup();
                    // Storing your instance in the context ensures that
                    // this instance is used by the scenario that created it.
                    Context["TypeThatNeedsCleanup"] = instance;
                    // Adding the instance to the test cleanup queue ensures it
                    // is cleaned up in a thread safe way 
                    // when the this scenario is finished
                    Context.TestCleanupQueue.Add(()=>instance.CleanMeUp());
                }
                return (ISomeTypeThatNeedsCleanup) Context["TypeThatNeedsCleanup"];
            }
        }

        protected override void AfterTestInitialize()
        {
            Context.Pages.SomeTestPage.GoTo();
        }

        [Given(@"I have entered the text ""(.*)""")]
        public void GivenIHaveEnteredTheText(string p0)
        {
            // Access this object in a thread safe way.
            TypeThatNeedsCleanup.UseThisTypeInSomeFashion();
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

    public interface ISomeTypeThatNeedsCleanup
    {
        void UseThisTypeInSomeFashion();
        void CleanMeUp();

    }

    public class SomeTypeThatNeedsCleanup: ISomeTypeThatNeedsCleanup
    {
        public void UseThisTypeInSomeFashion()
        {
            
        }

        public void CleanMeUp()
        {
            
        }
    }
}
