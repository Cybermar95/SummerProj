using System;
using System.Threading;

namespace Mediator
{
    class STaskHandler
    {
        static public void ServerHandlerMethod()
        {
            while (true)
            {
                while (!MediatorMain.PackedSTask.IsEmpty)
                {
                    PackedETask RawTask;
                    MediatorMain.PackedSTask.TryDequeue(out RawTask);
                    RawTask.Unpack().execute();
                }
                Thread.Sleep(1);
            }
        }
    }
}
