using GherkinDemo2.Tests.TestApi.Pages;

namespace GherkinDemo2.Tests.TestApi
{
    public class PageCommands
    {
        private readonly Context _context;

        private LoginPage _loginPage;
        private SomeTestPage _someTestPage;

        public PageCommands(Context context)
        {
            _context = context;
        }

        public LoginPage LoginPage
        {
            get { return _loginPage ?? (_loginPage = new LoginPage(_context)); }
        }

        public SomeTestPage SomeTestPage
        {
            get { return _someTestPage ?? (_someTestPage = new SomeTestPage(_context)); }
        }
    }
}