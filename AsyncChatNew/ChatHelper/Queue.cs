using System;
using System.Collections.Generic;

namespace AsyncChatNew.ChatHelper
{
    public class Queue
    {
        public List<string> FreeOperatorsList { get; set; }
        public List<string> WaitingUsersList { get; set; }

        public event EventHandler<string> OperatorFree;

        protected virtual void OnOperatorFree(string e)
        {
            OperatorFree?.Invoke(this, e);
        }
    }
}