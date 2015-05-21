using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace GherkinDemo2.Tests
{	  
	[Binding]
	public class GherkinAndSpecFlowDemonstrationSteps
	{	   
		[BeforeTestRun]
		public static void PreSetup()
		{
			WebServer.StartIis();
		}

		[AfterTestRun]
		public static void PostClose()
		{
			WebServer.StopIis();
		}	  
		private static IWebDriver _driver;
		[BeforeScenario]
		public static void Setup()
		{
			_driver = new FirefoxDriver();
			_driver.Navigate().GoToUrl("http://localhost:1316/");
		}

		[AfterScenario()]
		public static void Teardown()
		{
			_driver.Quit();
		}

		[Given(@"I have entered the text ""(.*)""")]
		public void GivenIHaveEnteredTheText(string p0)
		{
			_driver.FindElement(By.TagName("input")).SendKeys(p0);
		}

		[When(@"I submit the text")]
		public void WhenISubmitTheText()
		{
			_driver.FindElement(By.Id("goButton")).Click();
		}

		[Then(@"a success result should show")]
		public void ThenASuccessResultShouldShow()
		{
			Assert.IsTrue(_driver.FindElement(By.Id("successLabel")).Displayed);
		}

		[Then(@"a failure result should show")]
		public void ThenAFailureResultShouldShow()
		{
			Assert.IsTrue(_driver.FindElement(By.Id("failureLabel")).Displayed);
		}
	}
}
