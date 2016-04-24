using System;
using System.Net;
using Newtonsoft.Json;
using TaskLib;

namespace Mediator
{
    public struct PackedETask
    {
        public PackedETask(IPEndPoint ClientEndPoint, byte MediatorTaskType, string RawJsonData)
        {
            this.ClientEndPoint = ClientEndPoint;
            this.RawJsonData = RawJsonData;
            this.MediatorTaskType = (MediatorSTaskType)MediatorTaskType;
            MediatorMain.PackedSTask.Enqueue(this);
        }

        public IPEndPoint ClientEndPoint;
        string RawJsonData;
        MediatorSTaskType MediatorTaskType;

        public ExecutionTask Unpack()
        {
            switch (MediatorTaskType)
            {
                case MediatorSTaskType.AddClient:
                    return new AddPatientTask(ClientEndPoint, RawJsonData);
                    break;

                default:
                    throw new Exception("Unidentified Task");
            }
        }
    }
}
