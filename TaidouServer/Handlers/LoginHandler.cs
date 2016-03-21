using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;
using NHibernate.SqlCommand;
using Photon.SocketServer;
using TaidouCommon;
using TaidouCommon.Model;
using TaidouServer.DataBase.Manager;

namespace TaidouServer.Handlers
{
    public class LoginHandler:HandlerBase
    {
        private UserInfoManager manager;

        public LoginHandler() 
        {
            manager = new UserInfoManager();
        }
        public override OperationResponse OnHandlerMessage(OperationRequest request)
        {
            UserInfo userinfo = manager.GetUserInfoByName((string)request.Parameters[0]);
            string json = JsonMapper.ToJson(userinfo);
            Dictionary<byte,object> parameters = new Dictionary<byte, object>();
            parameters.Add((byte)ParameterCode.UserInfo,json);
            OperationResponse response = new OperationResponse();
            response.ReturnCode = (short) ReturnCode.Success;
            response.Parameters = parameters;
            response.OperationCode = request.OperationCode;
            return response;
        }
    }
}
