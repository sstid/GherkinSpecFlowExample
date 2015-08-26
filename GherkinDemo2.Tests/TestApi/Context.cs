using System;
using System.Drawing;
using GherkinDemo2.Tests.Properties;
using GherkinDemo2.Tests.TestApi.Tools;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GherkinDemo2.Tests.TestApi
{
    public class Context : IShortSyntaxTestContext
    {
        private PageCommands _pageCommands;
        private WorkflowsCommands _workflowCommands;
        private ContextTools _tools;


        public Context(SeleniumHelpers.WebDriverType driverType)
        {
            Driver = SeleniumHelpers.GetDriver(driverType);
            int implicitWait = Settings.Default.SeleniumImplicitWaitSeconds;
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(implicitWait));

            if (driverType == SeleniumHelpers.WebDriverType.Phantom)
            {
                Driver.Manage().Window.Size = new Size(1920, 1080);
            }
            else
            {
                Driver.Manage().Window.Maximize();
            }
        }



        public object this[string key]
        {
            get
            {
                if (ScenarioContext.Current.ContainsKey(key)) return ScenarioContext.Current[key];

                throw new Exception(
                    string.Format(
                        "The request for ScenarioContext element {0} failed because the element does not exist in ScenarioContext.",
                        key));
            }
            set
            {
                if (!ScenarioContext.Current.ContainsKey(key))
                    ScenarioContext.Current.Add(key, value);
                else
                    ScenarioContext.Current[key] = value;
            }
        }

        public bool ContainsKey(string key)
        {
            return ScenarioContext.Current.ContainsKey(key);
        }

        public IWebDriver Driver { get; private set; }

        public PageCommands Pages
        {
            get { return _pageCommands ?? (_pageCommands = new PageCommands(this)); }
        }


        public ContextTools Tools
        {
            get { return _tools ?? (_tools = new ContextTools(this)); }
        }

        public WorkflowsCommands Workflows
        {
            get { return _workflowCommands ?? (_workflowCommands = new WorkflowsCommands(this)); }
        }


        private TestCleanupQueue _testCleanupQueue;

        public TestCleanupQueue TestCleanupQueue
        {
            get { return _testCleanupQueue ?? (_testCleanupQueue = new TestCleanupQueue()); }
        }

        private TimeSpan _findElementTimeout = TimeSpan.MaxValue;
        public TimeSpan FindElementTimeout
        {
            get
            {
                if (_findElementTimeout == TimeSpan.MaxValue)
                {
                    int seconds = Settings.Default.SeleniumFindElementTimeout;
                    _findElementTimeout = TimeSpan.FromSeconds(seconds);
                }
                return _findElementTimeout;
            }
        }


        public void Cleanup()
        {
            Driver.Quit();
        }
    }

    //-----------------------------------------------------------
}