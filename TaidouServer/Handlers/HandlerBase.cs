using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;

namespace TaidouServer.Handlers
{
    public abstract class HandlerBase
    {
        public abstract OperationResponse OnHandlerMessage(OperationRequest request);
    }
}
