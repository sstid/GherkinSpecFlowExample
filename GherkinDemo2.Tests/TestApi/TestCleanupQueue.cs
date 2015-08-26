using System;
using System.Collections.Generic;

namespace GherkinDemo2.Tests.TestApi
{
    public class TestCleanupQueue
    {
        readonly Stack<Action> _cleanupQueue = new Stack<Action>();

        public void Add(Action cleanupAction)
        {
            _cleanupQueue.Push(cleanupAction);
        }

        public void Clean()
        {
            while (_cleanupQueue.Count > 0)
            {
                var act = _cleanupQueue.Pop();
                act();
            }
        }
    }
}