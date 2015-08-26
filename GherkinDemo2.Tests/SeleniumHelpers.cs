using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace GherkinDemo2.Tests
{
    public static class SeleniumHelpers
    {
        private static readonly object PadLock = new object();

        public enum WebDriverType
        {
            Phantom,
            Firefox,
            Chrome,
            SeleniumGrid,
            InternetExplorer
        }

        [DebuggerHidden]
        public static IWebDriver GetDriver(WebDriverType driverType, string locale, bool enableWindowsEvents)
        {
            lock (PadLock)
            {
                IWebDriver driver;
                switch (driverType)
                {
                    case WebDriverType.Firefox:
                        var profile = new FirefoxProfile { EnableNativeEvents = enableWindowsEvents };
                        if (locale != string.Empty)
                        {
                            profile.SetPreference("intl.accept_languages", locale); //TODO: Implement locales here
                        }
                        driver = new FirefoxDriver(profile);
                        break;
                    case WebDriverType.Phantom:
                        driver = new PhantomJSDriver();
                        break;
                    case WebDriverType.InternetExplorer:
                        driver = new InternetExplorerDriver("C:\\BuildUtilities"); // Path on build server
                        break;
                    case WebDriverType.SeleniumGrid:
                        Uri commandExecutorUri1 = new Uri("http://ssttfsserver:4444/wd/hub"); // start a new remote web driver session on sauce labs
                        DesiredCapabilities desiredCapabilites1 = DesiredCapabilities.Firefox();
                        desiredCapabilites1.SetCapability("screen-resolution", "1920x1200");


                        driver = new RemoteWebDriver(commandExecutorUri1, desiredCapabilites1);
                        driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                        break;
                    default:
                        throw new ApplicationException("Not a supported driver");
                }
                return driver;
            }
        }

        public static IWebDriver GetDriver(WebDriverType driverType, string locale)
        {
            return GetDriver(driverType, locale, false);
        }
        public static IWebDriver GetDriver(WebDriverType driverType)
        {
            return GetDriver(driverType, string.Empty, false);
        }

    }
}