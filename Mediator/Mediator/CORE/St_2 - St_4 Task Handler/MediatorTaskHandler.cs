using System.Threading;
using System;

namespace Mediator
{
    static class MediatorTaskHandler
    {
        static public void TasksHandlerMethod()
        {
            while (true)
            {
                while (!MediatorMain.MediatorTaskList.IsEmpty)
                {
                    MediatorTask RawTask;
                    MediatorMain.MediatorTaskList.TryDequeue(out RawTask);
                    try
                    {
                        RawTask.Execute();
                    }
                    catch (Exception E)
                    {
                        Log.Error(E.Message, E.ToString());
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}
