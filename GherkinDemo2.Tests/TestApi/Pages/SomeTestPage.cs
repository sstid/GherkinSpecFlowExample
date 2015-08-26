using OpenQA.Selenium;

namespace GherkinDemo2.Tests.TestApi.Pages
{
    public class SomeTestPage : BaseWebTestPage
    {
        
        public SomeTestPage(Context context)
        {
            Context = context;
        }

        public bool HasSuccessResult
        {
            get { return Context.Driver.FindElement(By.Id("successLabel")).Displayed; }
        }

        public void EnterText(string text)
        {
            Context.Driver.FindElement(By.TagName("input")).SendKeys(text);
        }

        public void SubmitText()
        {
            Context.Driver.FindElement(By.Id("goButton")).Click();
        }

        public override string Url
        {
            get { return BaseUrl + "Index.html"; } }
    }
}