using GherkinDemo2.Tests.TestApi.Workflows;

namespace GherkinDemo2.Tests.TestApi
{
    public class WorkflowsCommands
    {
        private Context _context;

        public WorkflowsCommands(Context context)
        {
            _context = context;
        }


        private SecurityWorkflow _security;
        public SecurityWorkflow Security
        {
            get { return _security ?? (_security = new SecurityWorkflow(_context)); }
        }
    }
}