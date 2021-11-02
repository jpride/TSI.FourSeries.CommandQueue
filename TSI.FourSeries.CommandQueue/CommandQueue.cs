using System;
using System.Collections.Generic;



namespace TSI.FourSeries.CommandQueue
{
    public class CommandQueue
    {
        public Queue<string> CommandQueueObj = new Queue<string>();
        

        public CommandQueue()
        { 
            //empty instatiator        
        }


        public void AddCommand(string cmd)
        {
            CommandQueueObj.Enqueue(cmd);
        }

        public void ProcessQueue()
        {
            if (CommandQueueObj.Count > 0)
            {
                ProcessQueueEventArgs args = new ProcessQueueEventArgs
                {
                    cmd = CommandQueueObj.Dequeue()
                };

                if (!ProcessQueueEventCall.Equals(null))
                {
                    ProcessQueueEventCall(this, args);
                }
            }
        }

        public event EventHandler<ProcessQueueEventArgs> ProcessQueueEventCall;
    }
}
