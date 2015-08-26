using System;
using GherkinDemo2.Tests.TestApi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GherkinDemo2.Tests
{

    public abstract class SeleniumBaseTest
    {

        //protected SeleniumHelpers.WebDriverType DriverType = SeleniumHelpers.WebDriverType.SeleniumGrid;
        protected SeleniumHelpers.WebDriverType DriverType = SeleniumHelpers.WebDriverType.Firefox;
        

        public Context Context
        {
            get { return (Context)ScenarioContext.Current["Context"]; }
            set { ScenarioContext.Current["Context"] = value; }
        }

        

        [BeforeScenario]
        public void SpecFlowInitialize()
        {
            
            Startup();
        }
        

        private void Startup()
        {
            BeforeTestInitialize();
            TestInitializationAndCleanup.Initialize();
            Context = new Context(DriverType);
            AfterTestInitialize();
        }
        

        /// <summary>
        /// Add additional which happens before initialization in inheriting classes.
        /// </summary>
        protected virtual void BeforeTestInitialize()
        {
        }

        /// <summary>
        /// Add additional which happens after initialization in inheriting classes.
        /// </summary>
        protected virtual void AfterTestInitialize()
        {
        }

        

        [AfterScenario]
        public void SpecFlowCleanup()
        {
            Context["HasError"] = (ScenarioContext.Current.TestError != null);
            Cleanup();
        }

        private void Cleanup()
        {
            BeforeTestCleanup();
            if (!Context.ContainsKey("HasCleanupRun"))
            {
                Context["HasCleanupRun"] = true;
                // Don't clean up your test data because there
                // was an error and you'll want it for 
                // debugging the error.
                if (!(bool)Context["HasError"])
                {
                    Context.TestCleanupQueue.Clean();
                }

                Context.Cleanup();
                TestInitializationAndCleanup.Cleanup();
            }
            AfterTestCleanup();
        }

        protected virtual void AfterTestCleanup()
        {

        }

        protected virtual void BeforeTestCleanup()
        {

        }
    }


#pragma warning disable

}