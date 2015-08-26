using System;
using GherkinDemo2.Tests.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GherkinDemo2.Tests.TestApi.Pages
{
    public abstract class BaseWebTestPage
    {
        
            protected Context Context;

            protected virtual IWebDriver Driver
            {
                get { return Context.Driver; }
            }

            public abstract string Url { get; }

            public string BaseUrl
            {
                get { return Settings.Default.SiteRoot; }
            }

            public virtual void GoTo()
            {
                //TODO: Implement login if necessary
                //if (!Context.Workflows.Security.IsLoggedIn())
                //{
                //    Context.Workflows.Security.Login();
                //}

                InnerGoTo();
            }

            protected void InnerGoTo()
            {
                if (IsAt) return;

                Driver.Navigate().GoToUrl(Url);
                int navTimeout = Settings.Default.SeleniumNavigationTimeout;
                var wait = new WebDriverWait(Context.Driver, TimeSpan.FromSeconds(navTimeout));
                if (!Driver.Url.Contains(Url))
                {
                    try
                    {
                        wait.Until(drv =>
                        {
                            drv.Navigate().GoToUrl(Url);
                            return Driver.Url.ToLower().Contains(Url.ToLower());
                        });
                        // Wait for page to load up before doing anything else.
                        Context.Tools.WaitForClockingToStop(TimeSpan.FromSeconds(navTimeout));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Unable to get to URL {0} within the timeout of {1} seconds", Url, navTimeout), ex);
                    }
                }
            }

            public virtual bool IsAt
            {
                get { return Driver.Url.ToLower().Contains(Url.ToLower()); }
            }

        }
    
}
