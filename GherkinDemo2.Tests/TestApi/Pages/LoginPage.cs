using System;

namespace GherkinDemo2.Tests.TestApi.Pages
{
    public class LoginPage : BaseWebTestPage
    {
        
        public LoginPage(Context context)
        {
            Context = context;
            throw new NotImplementedException("Implement a login test page");
        }

        public override string Url
        {
            get { return BaseUrl + "Login.html"; }
        }
    }
}