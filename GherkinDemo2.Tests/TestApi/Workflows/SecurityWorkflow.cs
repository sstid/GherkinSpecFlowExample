namespace GherkinDemo2.Tests.TestApi.Workflows
{
    public class SecurityWorkflow
    {
        private Context _context;

        public SecurityWorkflow(Context _context)
        {
            this._context = _context;
        }

        public bool IsLoggedIn()
        {
            throw new System.NotImplementedException("Implement method that indicates if a user is logged in.");
        }

        public void Login()
        {
            throw new System.NotImplementedException("Implement method that logs a user into the application under test.");
        }
    }
}