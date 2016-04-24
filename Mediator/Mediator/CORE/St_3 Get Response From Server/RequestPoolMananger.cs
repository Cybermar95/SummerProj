using System;
using System.Threading;

namespace Mediator
{
    static class RequestPoolMananger
    {
        static public void HandlerMethod()
        {
            while (true)
            {
                while (!MediatorMain.ServerRequestList.IsEmpty)
                {
                    ServerRequestObj request;
                    MediatorMain.ServerRequestList.TryDequeue(out request);
                    try
                    {
                        ThreadPool.QueueUserWorkItem(request.GetResponse);
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
