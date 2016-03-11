using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;
using TaidouCommon;
using TaidouServer.Handlers;
using ExitGames.Logging;

namespace TaidouServer
{
    class TaidouClientPeer:ClientPeer
    {
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();
        public TaidouClientPeer(InitRequest initRequest) : base(initRequest)
        {
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            HandlerBase handler;
            TaidouApplication.Instance.handlers.TryGetValue((OperationCode) operationRequest.OperationCode, out handler);
            OperationResponse response;
            if (handler != null)
            {
                response = handler.OnHandlerMessage(operationRequest);
                SendOperationResponse(response, sendParameters);
            }
            else
            {
                log.Debug("Unknown handler operationcode:" + operationRequest.OperationCode);
            }
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            throw new NotImplementedException();
        }
    }
}
