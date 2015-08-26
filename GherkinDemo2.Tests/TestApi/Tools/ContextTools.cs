using System;

namespace GherkinDemo2.Tests.TestApi.Tools
{
    public class ContextTools
    {
        private Context _context;

        public ContextTools(Context context)
        {
            _context = context;
        }

        public void WaitForClockingToStop(TimeSpan fromSeconds)
        {
            throw new NotImplementedException("Implement a method that will indicate that all activity (including async calls) has completed.");
        }
    }
}